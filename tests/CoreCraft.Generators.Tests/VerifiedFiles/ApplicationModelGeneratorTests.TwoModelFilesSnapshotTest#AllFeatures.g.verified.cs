﻿//HintName: AllFeatures.g.cs

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace compilation.AllFeatures
{
    using CoreCraft;
    using CoreCraft.Core;
    using CoreCraft.Views;
    using CoreCraft.ChangesTracking;
    using CoreCraft.Persistence;
    using CoreCraft.Persistence.History;
    using compilation.AllFeatures.Entities;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public interface IFakeModelShard : IModelShard
    {
        ICollection<FirstEntity, FirstEntityProperties> FirstCollection { get; }
        ICollection<SecondEntity, SecondEntityProperties> SecondCollection { get; }

        IRelation<FirstEntity, SecondEntity> OneToOneRelation { get; }
        IRelation<FirstEntity, SecondEntity> OneToManyRelation { get; }
        IRelation<SecondEntity, FirstEntity> ManyToOneRelation { get; }
        IRelation<FirstEntity, SecondEntity> ManyToManyRelation { get; }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public interface IMutableFakeModelShard : IMutableModelShard
    {
        IMutableCollection<FirstEntity, FirstEntityProperties> FirstCollection { get; }
        IMutableCollection<SecondEntity, SecondEntityProperties> SecondCollection { get; }

        IMutableRelation<FirstEntity, SecondEntity> OneToOneRelation { get; }
        IMutableRelation<FirstEntity, SecondEntity> OneToManyRelation { get; }
        IMutableRelation<SecondEntity, FirstEntity> ManyToOneRelation { get; }
        IMutableRelation<FirstEntity, SecondEntity> ManyToManyRelation { get; }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    internal static class FakeModelShardInfo
    {
        public static readonly CollectionInfo FirstCollectionInfo = new("Fake", "FirstCollection", new PropertyInfo[] { new("NonNullableStringProperty", typeof(string), false), new("NullableStringProperty", typeof(string), true), new("NullableStringWithDefaultValueProperty", typeof(string), true) });
        public static readonly CollectionInfo SecondCollectionInfo = new("Fake", "SecondCollection", new PropertyInfo[] { new("IntProperty", typeof(int), false), new("BoolProperty", typeof(bool), false), new("DoubleProperty", typeof(double), false), new("FloatProperty", typeof(float), false) });

        public static readonly RelationInfo OneToOneRelationInfo = new("Fake", "OneToOneRelation");
        public static readonly RelationInfo OneToManyRelationInfo = new("Fake", "OneToManyRelation");
        public static readonly RelationInfo ManyToOneRelationInfo = new("Fake", "ManyToOneRelation");
        public static readonly RelationInfo ManyToManyRelationInfo = new("Fake", "ManyToManyRelation");
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    internal sealed partial class FakeModelShard : IFakeModelShard
    {
        public FakeModelShard()
        {
            FirstCollection = new Collection<FirstEntity, FirstEntityProperties>(
                FakeModelShardInfo.FirstCollectionInfo,
                static id => new FirstEntity(id),
                static () => new FirstEntityProperties());
            SecondCollection = new Collection<SecondEntity, SecondEntityProperties>(
                FakeModelShardInfo.SecondCollectionInfo,
                static id => new SecondEntity(id),
                static () => new SecondEntityProperties());

            OneToOneRelation = new Relation<FirstEntity, SecondEntity>(
                FakeModelShardInfo.OneToOneRelationInfo,
                new OneToOne<FirstEntity, SecondEntity>(),
                new OneToOne<SecondEntity, FirstEntity>());
            OneToManyRelation = new Relation<FirstEntity, SecondEntity>(
                FakeModelShardInfo.OneToManyRelationInfo,
                new OneToMany<FirstEntity, SecondEntity>(),
                new OneToOne<SecondEntity, FirstEntity>());
            ManyToOneRelation = new Relation<SecondEntity, FirstEntity>(
                FakeModelShardInfo.ManyToOneRelationInfo,
                new OneToMany<SecondEntity, FirstEntity>(),
                new OneToOne<FirstEntity, SecondEntity>());
            ManyToManyRelation = new Relation<FirstEntity, SecondEntity>(
                FakeModelShardInfo.ManyToManyRelationInfo,
                new OneToMany<FirstEntity, SecondEntity>(),
                new OneToMany<SecondEntity, FirstEntity>());
        }

        internal FakeModelShard(IMutableFakeModelShard mutable)
        {
            FirstCollection = ((IMutableState<ICollection<FirstEntity, FirstEntityProperties>>)mutable.FirstCollection).AsReadOnly();
            SecondCollection = ((IMutableState<ICollection<SecondEntity, SecondEntityProperties>>)mutable.SecondCollection).AsReadOnly();

            OneToOneRelation = ((IMutableState<IRelation<FirstEntity, SecondEntity>>)mutable.OneToOneRelation).AsReadOnly();
            OneToManyRelation = ((IMutableState<IRelation<FirstEntity, SecondEntity>>)mutable.OneToManyRelation).AsReadOnly();
            ManyToOneRelation = ((IMutableState<IRelation<SecondEntity, FirstEntity>>)mutable.ManyToOneRelation).AsReadOnly();
            ManyToManyRelation = ((IMutableState<IRelation<FirstEntity, SecondEntity>>)mutable.ManyToManyRelation).AsReadOnly();
        }

        public ICollection<FirstEntity, FirstEntityProperties> FirstCollection { get; init; } = null!;
        public ICollection<SecondEntity, SecondEntityProperties> SecondCollection { get; init; } = null!;

        public IRelation<FirstEntity, SecondEntity> OneToOneRelation { get; init; } = null!;
        public IRelation<FirstEntity, SecondEntity> OneToManyRelation { get; init; } = null!;
        public IRelation<SecondEntity, FirstEntity> ManyToOneRelation { get; init; } = null!;
        public IRelation<FirstEntity, SecondEntity> ManyToManyRelation { get; init; } = null!;

        public void Save(IRepository repository)
        {
            FirstCollection.Save(repository);
            SecondCollection.Save(repository);

            OneToOneRelation.Save(repository);
            OneToManyRelation.Save(repository);
            ManyToOneRelation.Save(repository);
            ManyToManyRelation.Save(repository);
        }
    }

    internal sealed partial class FakeModelShard : IReadOnlyState<IMutableFakeModelShard>
    {
        public IMutableFakeModelShard AsMutable(global::System.Collections.Generic.IEnumerable<IFeature> features)
        {
            var firstCollection = (IMutableCollection<FirstEntity, FirstEntityProperties>)FirstCollection;
            var secondCollection = (IMutableCollection<SecondEntity, SecondEntityProperties>)SecondCollection;

            var oneToOneRelation = (IMutableRelation<FirstEntity, SecondEntity>)OneToOneRelation;
            var oneToManyRelation = (IMutableRelation<FirstEntity, SecondEntity>)OneToManyRelation;
            var manyToOneRelation = (IMutableRelation<SecondEntity, FirstEntity>)ManyToOneRelation;
            var manyToManyRelation = (IMutableRelation<FirstEntity, SecondEntity>)ManyToManyRelation;

            foreach (var feature in features)
            {
                firstCollection = feature.Decorate(this, firstCollection);
                secondCollection = feature.Decorate(this, secondCollection);

                oneToOneRelation = feature.Decorate(this, oneToOneRelation);
                oneToManyRelation = feature.Decorate(this, oneToManyRelation);
                manyToOneRelation = feature.Decorate(this, manyToOneRelation);
                manyToManyRelation = feature.Decorate(this, manyToManyRelation);
            }

            return new MutableFakeModelShard()
            {
                FirstCollection = firstCollection,
                SecondCollection = secondCollection,

                OneToOneRelation = oneToOneRelation,
                OneToManyRelation = oneToManyRelation,
                ManyToOneRelation = manyToOneRelation,
                ManyToManyRelation = manyToManyRelation,
            };
        }
    }

    internal sealed partial class FakeModelShard : IFrameFactory
    {
        public IChangesFrame Create()
        {
            return new FakeChangesFrame();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public interface IFakeChangesFrame : IChangesFrame
    {
        ICollectionChangeSet<FirstEntity, FirstEntityProperties> FirstCollection { get; }
        ICollectionChangeSet<SecondEntity, SecondEntityProperties> SecondCollection { get; }

        IRelationChangeSet<FirstEntity, SecondEntity> OneToOneRelation { get; }
        IRelationChangeSet<FirstEntity, SecondEntity> OneToManyRelation { get; }
        IRelationChangeSet<SecondEntity, FirstEntity> ManyToOneRelation { get; }
        IRelationChangeSet<FirstEntity, SecondEntity> ManyToManyRelation { get; }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    internal sealed class FakeChangesFrame : IFakeChangesFrame, IChangesFrameEx
    {
        public FakeChangesFrame()
        {
            FirstCollection = new CollectionChangeSet<FirstEntity, FirstEntityProperties>(FakeModelShardInfo.FirstCollectionInfo);
            SecondCollection = new CollectionChangeSet<SecondEntity, SecondEntityProperties>(FakeModelShardInfo.SecondCollectionInfo);

            OneToOneRelation = new RelationChangeSet<FirstEntity, SecondEntity>(FakeModelShardInfo.OneToOneRelationInfo);
            OneToManyRelation = new RelationChangeSet<FirstEntity, SecondEntity>(FakeModelShardInfo.OneToManyRelationInfo);
            ManyToOneRelation = new RelationChangeSet<SecondEntity, FirstEntity>(FakeModelShardInfo.ManyToOneRelationInfo);
            ManyToManyRelation = new RelationChangeSet<FirstEntity, SecondEntity>(FakeModelShardInfo.ManyToManyRelationInfo);
        }

        public ICollectionChangeSet<FirstEntity, FirstEntityProperties> FirstCollection { get; private set; }
        public ICollectionChangeSet<SecondEntity, SecondEntityProperties> SecondCollection { get; private set; }

        public IRelationChangeSet<FirstEntity, SecondEntity> OneToOneRelation { get; private set; }
        public IRelationChangeSet<FirstEntity, SecondEntity> OneToManyRelation { get; private set; }
        public IRelationChangeSet<SecondEntity, FirstEntity> ManyToOneRelation { get; private set; }
        public IRelationChangeSet<FirstEntity, SecondEntity> ManyToManyRelation { get; private set; }

        public ICollectionChangeSet<TEntity, TProperty>? Get<TEntity, TProperty>(ICollection<TEntity, TProperty> collection)
            where TEntity : Entity
            where TProperty : Properties
        {
            if (FirstCollection.Info == collection.Info) return FirstCollection as ICollectionChangeSet<TEntity, TProperty>;
            if (SecondCollection.Info == collection.Info) return SecondCollection as ICollectionChangeSet<TEntity, TProperty>;

            throw new System.InvalidOperationException("Unable to find collection's changes set");
        }

        public IRelationChangeSet<TParent, TChild>? Get<TParent, TChild>(IRelation<TParent, TChild> relation)
            where TParent : Entity
            where TChild : Entity
        {
            if (OneToOneRelation.Info == relation.Info) return OneToOneRelation as IRelationChangeSet<TParent, TChild>;
            if (OneToManyRelation.Info == relation.Info) return OneToManyRelation as IRelationChangeSet<TParent, TChild>;
            if (ManyToOneRelation.Info == relation.Info) return ManyToOneRelation as IRelationChangeSet<TParent, TChild>;
            if (ManyToManyRelation.Info == relation.Info) return ManyToManyRelation as IRelationChangeSet<TParent, TChild>;

            throw new System.InvalidOperationException($"Unable to find relation's change set");
        }

        public IChangesFrame Invert()
        {
            return new FakeChangesFrame()
            {
                FirstCollection = FirstCollection.Invert(),
                SecondCollection = SecondCollection.Invert(),

                OneToOneRelation = OneToOneRelation.Invert(),
                OneToManyRelation = OneToManyRelation.Invert(),
                ManyToOneRelation = ManyToOneRelation.Invert(),
                ManyToManyRelation = ManyToManyRelation.Invert(),
            };
        }

        public void Apply(IModel model)
        {
            var modelShard = model.Shard<IMutableFakeModelShard>();

            OneToOneRelation.Apply(modelShard.OneToOneRelation);
            OneToManyRelation.Apply(modelShard.OneToManyRelation);
            ManyToOneRelation.Apply(modelShard.ManyToOneRelation);
            ManyToManyRelation.Apply(modelShard.ManyToManyRelation);
            FirstCollection.Apply(modelShard.FirstCollection);
            SecondCollection.Apply(modelShard.SecondCollection);
        }

        public bool HasChanges()
        {
            return FirstCollection.HasChanges() || SecondCollection.HasChanges() || OneToOneRelation.HasChanges() || OneToManyRelation.HasChanges() || ManyToOneRelation.HasChanges() || ManyToManyRelation.HasChanges();
        }

        public IChangesFrame Merge(IChangesFrame frame)
        {
            var typedFrame = (FakeChangesFrame)frame;

            return new FakeChangesFrame()
            {
                FirstCollection = FirstCollection.Merge(typedFrame.FirstCollection),
                SecondCollection = SecondCollection.Merge(typedFrame.SecondCollection),

                OneToOneRelation = OneToOneRelation.Merge(typedFrame.OneToOneRelation),
                OneToManyRelation = OneToManyRelation.Merge(typedFrame.OneToManyRelation),
                ManyToOneRelation = ManyToOneRelation.Merge(typedFrame.ManyToOneRelation),
                ManyToManyRelation = ManyToManyRelation.Merge(typedFrame.ManyToManyRelation),
            };
        }

        public void Do<T>(T operation)
            where T : IChangesFrameOperation
        {
            operation.OnCollection(FirstCollection);
            operation.OnCollection(SecondCollection);

            operation.OnRelation(OneToOneRelation);
            operation.OnRelation(OneToManyRelation);
            operation.OnRelation(ManyToOneRelation);
            operation.OnRelation(ManyToManyRelation);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    internal sealed class MutableFakeModelShard : IMutableFakeModelShard, IMutableState<IFakeModelShard>
    {
        public bool ManualLoadRequired => false;

        public IMutableCollection<FirstEntity, FirstEntityProperties> FirstCollection { get; init; } = null!;
        public IMutableCollection<SecondEntity, SecondEntityProperties> SecondCollection { get; init; } = null!;

        public IMutableRelation<FirstEntity, SecondEntity> OneToOneRelation { get; init; } = null!;
        public IMutableRelation<FirstEntity, SecondEntity> OneToManyRelation { get; init; } = null!;
        public IMutableRelation<SecondEntity, FirstEntity> ManyToOneRelation { get; init; } = null!;
        public IMutableRelation<FirstEntity, SecondEntity> ManyToManyRelation { get; init; } = null!;

        public IFakeModelShard AsReadOnly()
        {
            return new FakeModelShard(this);
        }

        public void Load(IRepository repository, bool force = false)
        {
            FirstCollection.Load(repository);
            SecondCollection.Load(repository);

            OneToOneRelation.Load(repository, FirstCollection, SecondCollection);
            OneToManyRelation.Load(repository, FirstCollection, SecondCollection);
            ManyToOneRelation.Load(repository, SecondCollection, FirstCollection);
            ManyToManyRelation.Load(repository, FirstCollection, SecondCollection);
        }

        public void Save(IRepository repository)
        {
            FirstCollection.Save(repository);
            SecondCollection.Save(repository);

            OneToOneRelation.Save(repository);
            OneToManyRelation.Save(repository);
            ManyToOneRelation.Save(repository);
            ManyToManyRelation.Save(repository);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    internal sealed partial class FakeModelShardView : global::System.IDisposable
    {
        private bool _disposed = false;

        public FakeModelShardView(IDomainModel model)
        {
            var builder = model.View<IFakeModelShard, IFakeChangesFrame>();

            FirstCollection = builder.Create(static shard => shard.FirstCollection, static frame => frame.FirstCollection);
            SecondCollection = builder.Create(static shard => shard.SecondCollection, static frame => frame.SecondCollection);

            OneToOneRelation = builder.Create(static shard => shard.OneToOneRelation, static frame => frame.OneToOneRelation);
            OneToManyRelation = builder.Create(static shard => shard.OneToManyRelation, static frame => frame.OneToManyRelation);
            ManyToOneRelation = builder.Create(static shard => shard.ManyToOneRelation, static frame => frame.ManyToOneRelation);
            ManyToManyRelation = builder.Create(static shard => shard.ManyToManyRelation, static frame => frame.ManyToManyRelation);
        }

        public ICollectionView<FirstEntity, FirstEntityProperties> FirstCollection { get; private set; }
        public ICollectionView<SecondEntity, SecondEntityProperties> SecondCollection { get; private set; }

        public IRelationView<FirstEntity, SecondEntity> OneToOneRelation { get; private set; }
        public IRelationView<FirstEntity, SecondEntity> OneToManyRelation { get; private set; }
        public IRelationView<SecondEntity, FirstEntity> ManyToOneRelation { get; private set; }
        public IRelationView<FirstEntity, SecondEntity> ManyToManyRelation { get; private set; }

        public void Save(IRepository repository)
        {
            throw new global::System.InvalidOperationException("Cannot save model shard's view. Call Save on the real model shard.");
        }

        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }

        ~FakeModelShardView()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            FirstCollection.Dispose();
            SecondCollection.Dispose();

            OneToOneRelation.Dispose();
            OneToManyRelation.Dispose();
            ManyToOneRelation.Dispose();
            ManyToManyRelation.Dispose();

            _disposed = true;
        }
    }

}

namespace compilation.AllFeatures.Entities
{
    using CoreCraft.Core;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public sealed record FirstEntity(global::System.Guid Id) : Entity(Id)
    {
        internal FirstEntity() : this(global::System.Guid.NewGuid())
        {
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public sealed partial record FirstEntityProperties : Properties
    {
        public FirstEntityProperties()
        {
            NonNullableStringProperty = string.Empty;
        }

        public string NonNullableStringProperty { get; init; }
        public string? NullableStringProperty { get; init; }
        public string? NullableStringWithDefaultValueProperty { get; init; }

#if NET5_0_OR_GREATER
        public override FirstEntityProperties ReadFrom(IPropertiesBag bag)
#else
        public override Properties ReadFrom(IPropertiesBag bag)
#endif
        {
            return new FirstEntityProperties()
            {
                NonNullableStringProperty = bag.Read<string>("NonNullableStringProperty"),
                NullableStringProperty = bag.Read<string>("NullableStringProperty"),
                NullableStringWithDefaultValueProperty = bag.Read<string>("NullableStringWithDefaultValueProperty"),
            };
        }

        public override void WriteTo(IPropertiesBag bag)
        {
            bag.Write("NonNullableStringProperty", NonNullableStringProperty);
            bag.Write("NullableStringProperty", NullableStringProperty);
            bag.Write("NullableStringWithDefaultValueProperty", NullableStringWithDefaultValueProperty);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public sealed record SecondEntity(global::System.Guid Id) : Entity(Id)
    {
        internal SecondEntity() : this(global::System.Guid.NewGuid())
        {
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("C# Source Generator", "1.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public sealed partial record SecondEntityProperties : Properties
    {
        public SecondEntityProperties()
        {
        }

        public int IntProperty { get; init; }
        public bool BoolProperty { get; init; }
        public double DoubleProperty { get; init; }
        public float FloatProperty { get; init; }

#if NET5_0_OR_GREATER
        public override SecondEntityProperties ReadFrom(IPropertiesBag bag)
#else
        public override Properties ReadFrom(IPropertiesBag bag)
#endif
        {
            return new SecondEntityProperties()
            {
                IntProperty = bag.Read<int>("IntProperty"),
                BoolProperty = bag.Read<bool>("BoolProperty"),
                DoubleProperty = bag.Read<double>("DoubleProperty"),
                FloatProperty = bag.Read<float>("FloatProperty"),
            };
        }

        public override void WriteTo(IPropertiesBag bag)
        {
            bag.Write("IntProperty", IntProperty);
            bag.Write("BoolProperty", BoolProperty);
            bag.Write("DoubleProperty", DoubleProperty);
            bag.Write("FloatProperty", FloatProperty);
        }

    }


}

