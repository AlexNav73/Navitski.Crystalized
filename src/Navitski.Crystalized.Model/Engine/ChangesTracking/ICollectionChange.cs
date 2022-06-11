﻿namespace Navitski.Crystalized.Model.Engine.ChangesTracking;

/// <summary>
///     A specific change, recorded when a collection was modified
/// </summary>
/// <typeparam name="TEntity">An entity type</typeparam>
/// <typeparam name="TProperties">A type of a properties</typeparam>
public interface ICollectionChange<TEntity, TProperties>
    where TEntity : Entity
    where TProperties : Properties
{
    /// <summary>
    ///     Action which was performed on the collection
    /// </summary>
    CollectionAction Action { get; }

    /// <summary>
    ///     An entity which was modified
    /// </summary>
    TEntity Entity { get; }

    /// <summary>
    ///     An old properties of an entity
    /// </summary>
    TProperties? OldData { get; }

    /// <summary>
    ///     A new properties of an entity
    /// </summary>
    TProperties? NewData { get; }

    /// <summary>
    ///     Inverts a change
    /// </summary>
    /// <returns>A new change which is opposite to the original one</returns>
    /// <exception cref="NotSupportedException">Throws when an Action has wrong value</exception>
    ICollectionChange<TEntity, TProperties> Invert();
}