﻿using Navitski.Crystalized.Model.Engine.ChangesTracking;

namespace Navitski.Crystalized.Model.Engine.Subscription;

internal sealed class CollectionSubscriber<TChangesFrame, TEntity, TProperties> :
    Subscriber<ICollectionChangeSet<TEntity, TProperties>>,
    ICollectionSubscriber<TEntity, TProperties>,
    ISubscription<TChangesFrame>
    where TChangesFrame : class, IChangesFrame
    where TEntity : Entity
    where TProperties : Properties
{
    private readonly Func<TChangesFrame, ICollectionChangeSet<TEntity, TProperties>> _accessor;

    public CollectionSubscriber(Func<TChangesFrame, ICollectionChangeSet<TEntity, TProperties>> accessor)
    {
        _accessor = accessor;
    }

    public void Publish(Change<TChangesFrame> change)
    {
        var collectionChangeSet = _accessor(change.Hunk);
        if (collectionChangeSet.HasChanges())
        {
            var msg = new Change<ICollectionChangeSet<TEntity, TProperties>>(
                change.OldModel,
                change.NewModel,
                collectionChangeSet);

            Publish(msg);
        }
    }
}
