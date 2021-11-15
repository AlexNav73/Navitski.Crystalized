﻿using PricingCalc.Model.Engine.ChangesTracking;

namespace PricingCalc.Model.Engine.Persistence;

public abstract class ModelShardStorage<TShard, TFrame> : IModelShardStorage
    where TShard : IModelShard
    where TFrame : class, IChangesFrame
{
    protected ModelShardStorage(TShard shard)
    {
        Shard = shard;
    }

    protected TShard Shard { get; }

    public void Save(string path, IRepository repository, IModelChanges changes)
    {
        if (changes.TryGetFrame<TFrame>(out var frame))
        {
            SaveInternal(path, repository, frame);
        }
    }

    public void Save(string path, IRepository repository)
    {
        SaveInternal(path, repository);
    }

    public void Load(string path, IRepository repository)
    {
        LoadInternal(path, repository);
    }

    protected abstract void SaveInternal(string path, IRepository repository, TFrame changes);

    protected abstract void SaveInternal(string path, IRepository repository);

    protected abstract void LoadInternal(string path, IRepository repository);

    protected void Save<TEntity, TData>(IRepository repository, string name, ICollectionChangeSet<TEntity, TData> changes, Scheme scheme)
        where TEntity : Entity
        where TData : Properties
    {
        if (!changes.HasChanges())
        {
            return;
        }

        var added = new List<KeyValuePair<TEntity, TData>>();
        var modified = new List<KeyValuePair<TEntity, TData>>();
        var removed = new List<TEntity>();

        foreach (var change in changes)
        {
            switch (change.Action)
            {
                case CollectionAction.Add:
                    added.Add(new KeyValuePair<TEntity, TData>(change.Entity, change.NewData!));
                    break;

                case CollectionAction.Modify:
                    modified.Add(new KeyValuePair<TEntity, TData>(change.Entity, change.NewData!));
                    break;

                case CollectionAction.Remove:
                    removed.Add(change.Entity);
                    break;
            }
        }

        if (added.Count > 0)
        {
            repository.Insert(name, added, scheme);
        }
        if (modified.Count > 0)
        {
            repository.Update(name, modified, scheme);
        }
        if (removed.Count > 0)
        {
            repository.Delete(name, removed);
        }
    }

    protected void Save<TEntity, TData>(IRepository repository, string name, ICollection<TEntity, TData> collection, Scheme scheme)
        where TEntity : Entity
        where TData : Properties
    {
        repository.Insert(name, collection.Select(x => new KeyValuePair<TEntity, TData>(x, collection.Get(x))).ToArray(), scheme);
    }

    protected void Save<TParent, TChild>(IRepository repository, string name, IRelationChangeSet<TParent, TChild> changes)
        where TParent : Entity
        where TChild : Entity
    {
        if (!changes.HasChanges())
        {
            return;
        }

        var linked = new List<KeyValuePair<TParent, TChild>>();
        var unlinked = new List<KeyValuePair<TParent, TChild>>();

        foreach (var change in changes)
        {
            switch (change.Action)
            {
                case RelationAction.Linked:
                    linked.Add(new KeyValuePair<TParent, TChild>(change.Parent, change.Child));
                    break;
                case RelationAction.Unlinked:
                    unlinked.Add(new KeyValuePair<TParent, TChild>(change.Parent, change.Child));
                    break;
            }
        }

        if (linked.Count > 0)
        {
            repository.Insert(name, linked);
        }
        if (unlinked.Count > 0)
        {
            repository.Delete(name, unlinked);
        }
    }

    protected void Save<TParent, TChild>(IRepository repository, string name, IRelation<TParent, TChild> relation)
        where TParent : Entity
        where TChild : Entity
    {
        var pairs = relation
            .SelectMany(x => relation.Children(x).Select(y => new KeyValuePair<TParent, TChild>(x, y)));

        repository.Insert(name, pairs.ToArray());
    }

    protected void Load<TEntity, TData>(
        IRepository repository,
        string name,
        ICollection<TEntity, TData> collection,
        Scheme scheme)
        where TEntity : Entity
        where TData : Properties
    {
        repository.Select(name, collection, scheme);
    }

    protected void Load<TParent, TChild>(
        IRepository repository,
        string name,
        IRelation<TParent, TChild> relation,
        IEntityCollection<TParent> parents,
        IEntityCollection<TChild> children)
        where TParent : Entity
        where TChild : Entity
    {
        repository.Select(name, relation, parents, children);
    }
}
