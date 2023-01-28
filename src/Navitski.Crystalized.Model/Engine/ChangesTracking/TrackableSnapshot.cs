﻿namespace Navitski.Crystalized.Model.Engine.ChangesTracking;

internal sealed class TrackableSnapshot : Snapshot
{
    public TrackableSnapshot(Core.Model model)
        : base(model)
    {
        Changes = new ModelChanges();
    }

    public IWritableModelChanges Changes { get; }

    public override T Shard<T>()
    {
        var modelShard = base.Shard<ICanBeMutable<T>>();
        var trackable = modelShard.AsMutable(Features.Track, Changes);

        return trackable;
    }
}
