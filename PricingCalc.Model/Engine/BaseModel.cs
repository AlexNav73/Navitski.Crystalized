﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PricingCalc.Model.Engine.Commands;
using PricingCalc.Model.Engine.Core;
using PricingCalc.Model.Engine.GenericCommands;
using PricingCalc.Model.Engine.Persistence;

namespace PricingCalc.Model.Engine
{
    internal abstract class BaseModel : IBaseModel
    {
        private readonly IView _view;
        private readonly IStorage _storage;
        private readonly IJobService _jobService;
        private readonly HashSet<Action<ModelChangedEventArgs>> _subscriptions;

        private volatile ModelChangedEventArgs? _currentChanges;

        protected BaseModel(IView view, IStorage storage, IJobService jobService)
        {
            _subscriptions = new HashSet<Action<ModelChangedEventArgs>>();
            _view = view;
            _storage = storage;
            _jobService = jobService;
        }

        public T Shard<T>() where T : IModelShard
        {
            return _view.UnsafeModel.Shard<T>();
        }

        public IDisposable Subscribe(Action<ModelChangedEventArgs> onModelChanges)
        {
            if (!_subscriptions.Contains(onModelChanges))
            {
                _subscriptions.Add(onModelChanges);
            }

            if (_currentChanges != null)
            {
                onModelChanges(_currentChanges);
            }

            return new UnsubscribeOnDispose(onModelChanges, _subscriptions);
        }

        public async Task Run(ModelCommand command)
        {
            var result = await _jobService.StartNew(() => _view.Mutate(snapshot => command.Run(snapshot)));

            if (result.Changes.HasChanges())
            {
                RaiseEvent(result);
            }
        }

        public virtual void RaiseEvent(ModelChangeResult result)
        {
            RaiseModelChangesEvent(result);
        }

        internal async Task Save(string path, IReadOnlyList<IModelChanges> changes)
        {
            await _jobService.StartNew(() => _storage.Save(path, _view.UnsafeModel, changes));
        }

        internal async Task Load(string path)
        {
            var result = await _jobService.StartNew(() => _view.Mutate(snapshot => _storage.Load(path, snapshot)));

            if (result.Changes.HasChanges())
            {
                RaiseModelChangesEvent(result);
            }
        }

        internal async Task Apply(IWritableModelChanges changes)
        {
            if (changes.HasChanges())
            {
                var result = await _jobService.StartNew(() => _view.Apply(changes));

                RaiseModelChangesEvent(result);
            }
        }

        internal async Task Clear()
        {
            var clearCommand = new ClearModelCommand(this);

            var result = await _jobService.StartNew(() => _view.Mutate(model => clearCommand.Run(model)));

            if (result.Changes.HasChanges())
            {
                RaiseEvent(result);
            }
        }

        private void RaiseModelChangesEvent(ModelChangeResult result)
        {
            _currentChanges = new ModelChangedEventArgs(result.OldModel, result.NewModel, result.Changes);

            var observers = _subscriptions.ToArray();
            foreach (var observer in observers)
            {
                observer(_currentChanges);
            }

            _currentChanges = null;
        }
    }
}
