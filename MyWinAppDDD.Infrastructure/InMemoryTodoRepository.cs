using MyWinAppDDD.Domain;

namespace MyWinAppDDD.Infrastructure;

public sealed class InMemoryTodoRepository : ITodoRepository
{
    private readonly Dictionary<Guid, Todo> _store = new();

    public Task<Todo?> GetAsync(Guid id, CancellationToken ct = default)
        => Task.FromResult(_store.TryGetValue(id, out var t) ? t : null);

    public Task AddAsync(Todo todo, CancellationToken ct = default)
    {
        _store.Add(todo.Id, todo);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Todo todo, CancellationToken ct = default)
        => Task.CompletedTask; // 参照型なので何もしなくてOK

    public Task<IReadOnlyList<Todo>> ListAsync(CancellationToken ct = default)
        => Task.FromResult((IReadOnlyList<Todo>)_store.Values.ToList());
}
