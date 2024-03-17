﻿namespace CoreCraft.ChangesTracking;

/// <summary>
///     A mutable counterpart of an <see cref="IModelChanges"/>
/// </summary>
/// <remarks>
///     <see cref="IModelChanges"/> is a read-only part of a model changes which
///     is accessible by the developer to analyze changes. On the other hand,
///     <see cref="IMutableModelChanges"/> is a mutable part of a model changes
///     which can be used to implement history of changes and undo/redo logic.
///     <b><see cref="IMutableModelChanges"/> should not be used when handling event
///     of a model change.</b>
/// </remarks>
public interface IMutableModelChanges : IModelChanges
{
    /// <summary>
    ///     Adds or retrieves an existing changes frame for the specified model shard.
    /// </summary>
    /// <param name="frame">
    ///     The <see cref="IChangesFrame"/> instance representing the changes for a specific model shard.
    ///     If a frame for the same shard already exists, this frame is returned.
    /// </param>
    /// <returns>
    ///     - The provided `frame` if it's a new frame for a shard that wasn't previously tracked.
    ///     - The existing <see cref="IChangesFrame"/> instance associated with the shard if one already exists.
    /// </returns>
    IChangesFrame AddOrGet(IChangesFrame frame);

    /// <summary>
    ///     Applies changes to the given model
    /// </summary>
    /// <param name="model">A target model</param>
    void Apply(IModel model);

    /// <summary>
    ///     Merges two <see cref="IMutableModelChanges"/> into one,
    ///     reducing a number of operations (changes) stored in the <see cref="IMutableModelChanges"/>.
    /// </summary>
    /// <remarks>
    ///     It helps to optimize count of actions needed to be performed to update stored data to the latest version
    /// </remarks>
    /// <param name="changes">Changes, that have happened after the current ones</param>
    /// <returns>Merged changes by combining current changes with the newest</returns>
    IMutableModelChanges Merge(IModelChanges changes);
}
