﻿using CoreCraft.Storage.Sqlite.Migrations;
using CoreCraft.Storage.Sqlite.Tests.Infrastructure;

namespace CoreCraft.Storage.Sqlite.Tests;

internal class MigrationRunnerTest
{
    [Test]
    public void RunTest()
    {
        using var repository = new SqliteRepository(":memory:");
        var table = $"{FakeModelShardStorage.FirstCollectionInfo.ShardName}.{FakeModelShardStorage.FirstCollectionInfo.Name}";
        var runner = new MigrationRunner(new[] { new DropTableMigration(table) });

        repository.Insert(
            FakeModelShardStorage.FirstCollectionInfo,
            new List<KeyValuePair<FirstEntity, FirstEntityProperties>>()
            {
                new KeyValuePair<FirstEntity, FirstEntityProperties>(new(), new())
            });

        Assert.That(repository.Exists(table), Is.True);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(0));

        runner.Run(repository);

        Assert.That(repository.Exists(table), Is.False);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(1));
    }

    [Test]
    public void RunFailsOnApplyingTransactionTest()
    {
        using var repository = new SqliteRepository(":memory:");
        var runner = new MigrationRunner(new[] { new FailingMigration() });

        Assert.Throws<NotImplementedException>(() => runner.Run(repository));
    }

    [Test]
    public void ExecuteRawSqlTest()
    {
        var table = "Test";
        using var repository = new SqliteRepository(":memory:");
        var sql = $"CREATE TABLE [{table}]([Id] INTEGER);";
        var runner = new MigrationRunner(new[] { new ExecuteRawSqlMigration(sql) });

        Assert.That(repository.Exists(table), Is.False);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(0));

        runner.Run(repository);

        Assert.That(repository.Exists(table), Is.True);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(1));
    }

    private class FailingMigration : Migration
    {
        public FailingMigration()
            : base(1)
        {
        }

        public override void Migrate(IMigrator migrator)
        {
            throw new NotImplementedException();
        }
    }
}