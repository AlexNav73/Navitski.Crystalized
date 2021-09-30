﻿using PricingCalc.Model.Engine.Core;

namespace PricingCalc.Model.Engine
{
    public interface IModelShardAccessor
    {
        T Shard<T>() where T : IModelShard;
    }
}