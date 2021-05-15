﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PricingCalc.Model.Engine.Core;

namespace PricingCalc.Model.Engine.ChangesTracking
{
    [DebuggerDisplay("{_relation}")]
    public class TrackableRelation<TParent, TChild> : IRelation<TParent, TChild>
        where TParent : IEntity
        where TChild : IEntity
    {
        private readonly IRelationCollectionChanges<TParent, TChild> _changes;
        private readonly IRelation<TParent, TChild> _relation;

        public TrackableRelation(IRelationCollectionChanges<TParent, TChild> changesCollection,
            IRelation<TParent, TChild> modelRelation)
        {
            _changes = changesCollection;
            _relation = modelRelation;
        }

        public void Add(TParent parent, TChild child)
        {
            _relation.Add(parent, child);
            _changes.Add(RelationAction.Linked, parent, child);
        }

        public void Remove(TParent parent, TChild child)
        {
            _relation.Remove(parent, child);
            _changes.Add(RelationAction.Unlinked, parent, child);
        }

        public IEnumerable<TChild> Children(TParent parent)
        {
            return _relation.Children(parent);
        }

        public IEnumerable<TParent> Parents(TChild child)
        {
            return _relation.Parents(child);
        }

        public IEnumerator<TParent> GetEnumerator()
        {
            return _relation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IRelation<TParent, TChild> Copy()
        {
            throw new InvalidOperationException("Relation can't be copied because it is attached to changes tracking system");
        }
    }
}
