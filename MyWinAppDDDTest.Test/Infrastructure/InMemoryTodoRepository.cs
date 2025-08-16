using System;
using System.Threading.Tasks;
using MyWinAppDDD.Domain;
using MyWinAppDDD.Infrastructure;
using Xunit;

namespace MyWinAppDDDTest.Test.Infrastructure;

public class InMemoryTodoRepositoryTests
{
    [Fact]
    public async Task 追加して一覧_取得できる()
    {
        ITodoRepository repo = new InMemoryTodoRepository();
        var id = Guid.NewGuid();
        var t = new Todo(id, "牛乳を買う");

        await repo.AddAsync(t);
        var list = await repo.ListAsync();

        Assert.Single(list);
        Assert.Equal(id, list[0].Id);
        Assert.Equal("牛乳を買う", list[0].Title);
        Assert.False(list[0].IsDone);
    }

    [Fact]
    public async Task 完了して更新_状態が保持される()
    {
        ITodoRepository repo = new InMemoryTodoRepository();
        var id = Guid.NewGuid();
        var t = new Todo(id, "水やり");
        await repo.AddAsync(t);

        t.Complete();
        await repo.UpdateAsync(t);

        var again = await repo.GetAsync(id);
        Assert.NotNull(again);
        Assert.True(again!.IsDone);
    }
}
