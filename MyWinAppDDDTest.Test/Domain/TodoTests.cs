using System;
using MyWinAppDDD.Domain;
using Xunit;

namespace MyWinAppDDDTest.Test.Domain;

public class TodoTests
{
    [Fact]
    public void 新規作成_タイトル必須()
    {
        Assert.Throws<ArgumentException>(() => new Todo(Guid.NewGuid(), ""));
    }

    [Fact]
    public void 完了_フラグが立つ()
    {
        var t = new Todo(Guid.NewGuid(), "買い物");
        t.Complete();
        Assert.True(t.IsDone);
    }

    [Fact]
    public void タイトル変更_空は不可()
    {
        var t = new Todo(Guid.NewGuid(), "買い物");
        Assert.Throws<ArgumentException>(() => t.Rename("  "));
    }
}
