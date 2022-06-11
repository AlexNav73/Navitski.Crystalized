﻿namespace Navitski.Crystalized.Model.Engine.Core;

/// <summary>
///     A read-only collection of entity-properties pairs
/// </summary>
/// <typeparam name="TEntity">An entity type</typeparam>
/// <typeparam name="TProperties">A type of a properties</typeparam>
public interface ICollection<TEntity, TProperties> : IEnumerable<TEntity>, ICopy<ICollection<TEntity, TProperties>>
    where TEntity : Entity
    where TProperties : Properties
{
    /// <summary>
    ///     A count of entities
    /// </summary>
    int Count { get; }

    /// <summary>
    ///     Returns properties of a given entity
    /// </summary>
    /// <param name="entity">An entity</param>
    /// <returns>Properties for a given entities</returns>
    /// <exception cref="KeyNotFoundException">Throws when an entity is not present in the collection</exception>
    TProperties Get(TEntity entity);
}