namespace MyWinAppDDD.Domain;

public interface ITodoRepository
{
    Task<Todo?> GetAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Todo todo, CancellationToken ct = default);
    Task UpdateAsync(Todo todo, CancellationToken ct = default);
    Task<IReadOnlyList<Todo>> ListAsync(CancellationToken ct = default);
}
