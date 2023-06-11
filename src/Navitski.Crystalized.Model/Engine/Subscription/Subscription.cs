﻿using Navitski.Crystalized.Model.Engine.Exceptions;

namespace Navitski.Crystalized.Model.Engine.Subscription;

internal abstract class Subscription<T> : ISubscription<T>, IObservable<Change<T>>
{
    private readonly HashSet<IObserver<Change<T>>> _handlers;

    public Subscription()
    {
        _handlers = new HashSet<IObserver<Change<T>>>();
    }

    public IDisposable Subscribe(IObserver<Change<T>> onModelChanges)
    {
        if (_handlers.Contains(onModelChanges))
        {
            throw new SubscriptionAlreadyExistsException("Subscription already exists");
        }

        _handlers.Add(onModelChanges);

        return new UnsubscribeOnDispose<Change<T>>(onModelChanges, _handlers);
    }

    public virtual void Publish(Change<T> change)
    {
        foreach (var handler in _handlers.ToArray())
        {
            handler.OnNext(change);
        }
    }
}
