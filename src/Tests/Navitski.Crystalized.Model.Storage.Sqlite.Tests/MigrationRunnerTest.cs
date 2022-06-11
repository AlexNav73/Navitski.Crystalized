﻿using Navitski.Crystalized.Model.Storage.Sqlite.Migrations;
using Navitski.Crystalized.Model.Storage.Sqlite.Tests.Infrastructure;

namespace Navitski.Crystalized.Model.Storage.Sqlite.Tests;

internal class MigrationRunnerTest
{
    [Test]
    public void RunTest()
    {
        using var repository = new SqliteRepository(":memory:");
        var table = "test";
        var runner = new MigrationRunner(new[] { new DropTableMigration(table) });

        repository.Insert(
            table,
            new List<KeyValuePair<FirstEntity, FirstEntityProperties>>()
            {
                new KeyValuePair<FirstEntity, FirstEntityProperties>(new(), new())
            },
            FakeModelShardStorage.FirstCollectionScheme);

        Assert.That(repository.Exists(table), Is.True);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(0));

        runner.Run(repository);

        Assert.That(repository.Exists(table), Is.False);
        Assert.That(repository.GetDatabaseVersion(), Is.EqualTo(1));
    }
}