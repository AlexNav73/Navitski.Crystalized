﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PricingCalc.Model.Engine.Core;

namespace PricingCalc.Model.Engine.ChangesTracking
{
    [DebuggerDisplay("{_collection}")]
    public class TrackableCollection<TEntity, TData> : ICollection<TEntity, TData>
        where TEntity : IEntity, ICopy<TEntity>
        where TData : ICopy<TData>, IEquatable<TData>
    {
        private readonly ICollectionChangeSet<TEntity, TData> _changes;
        private readonly ICollection<TEntity, TData> _collection;

        public TrackableCollection(
            ICollectionChangeSet<TEntity, TData> changesCollection,
            ICollection<TEntity, TData> modelCollection)
        {
            _changes = changesCollection;
            _collection = modelCollection;
        }

        public int Count => _collection.Count;

        public EntityBuilder<TEntity, TData> Create()
        {
            return _collection.Create().WithAddHook((e, d) => _changes.Add(CollectionAction.Add, e, default, d));
        }

        public TData Get(TEntity entity)
        {
            return _collection.Get(entity);
        }

        public void Modify(TEntity entity, Action<TData> modifier)
        {
            var oldData = _collection.Get(entity).Copy();
            _collection.Modify(entity, modifier);
            var newData = _collection.Get(entity).Copy();

            if (!oldData.Equals(newData))
            {
                _changes.Add(CollectionAction.Modify, entity, oldData, newData);
            }
        }

        public void Remove(TEntity entity)
        {
            var data = _collection.Get(entity);
            _changes.Add(CollectionAction.Remove, entity, data, default);
            _collection.Remove(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ICollection<TEntity, TData> Copy()
        {
            throw new InvalidOperationException("Collection can't be copied because it is attached to changes tracking system");
        }
    }
}
