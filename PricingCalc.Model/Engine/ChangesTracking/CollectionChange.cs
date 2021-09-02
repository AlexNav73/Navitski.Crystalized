﻿using System;
using System.Diagnostics;
using PricingCalc.Model.Engine.Core;

namespace PricingCalc.Model.Engine.ChangesTracking
{
    [DebuggerDisplay("Action = {Action}")]
    internal class CollectionChange<TEntity, TData> : ICollectionChange<TEntity, TData>
        where TEntity : IEntity
        where TData : ICopy<TData>
    {
        public CollectionAction Action { get; }

        public TEntity Entity { get; }

        public TData? OldData { get; }

        public TData? NewData { get; }

        public CollectionChange(CollectionAction action, TEntity entity, TData? oldData, TData? newData)
        {
            Action = action;
            Entity = entity;
            OldData = oldData;
            NewData = newData;
        }

        public ICollectionChange<TEntity, TData> Invert()
        {
            return new CollectionChange<TEntity, TData>(InvertAction(Action), Entity, NewData, OldData);
        }

        private static CollectionAction InvertAction(CollectionAction action)
        {
            return action switch
            {
                CollectionAction.Add => CollectionAction.Remove,
                CollectionAction.Remove => CollectionAction.Add,
                CollectionAction.Modify => CollectionAction.Modify,
                _ => throw new NotSupportedException($"Action type {action} is not supported")
            };
        }
    }
}
