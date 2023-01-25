﻿using Navitski.Crystalized.Model.Engine.ChangesTracking;

namespace Navitski.Crystalized.Model.Engine.Core;

internal sealed class View
{
    private volatile Model _model;

    public View(IEnumerable<IModelShard> shards)
    {
        _model = new Model(shards);
    }

    public IModel UnsafeModel => _model;

    public TrackableSnapshot CreateTrackableSnapshot()
    {
        return new TrackableSnapshot(_model);
    }

    public Snapshot CreateSnapshot()
    {
        return new Snapshot(_model);
    }

    public ModelChangeResult ApplySnapshot(Snapshot snapshot)
    {
        var newModel = snapshot.ToModel();
        var oldModel = Interlocked.Exchange(ref _model, newModel);

        return new ModelChangeResult(oldModel, newModel);
    }
}
