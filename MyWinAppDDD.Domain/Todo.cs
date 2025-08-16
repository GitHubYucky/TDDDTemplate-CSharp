namespace MyWinAppDDD.Domain;

public sealed class Todo
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public bool IsDone { get; private set; }

    public Todo(Guid id, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        Id = id;
        Title = title.Trim();
        IsDone = false;
    }

    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title is required.", nameof(newTitle));
        Title = newTitle.Trim();
    }

    public void Complete() => IsDone = true;
    public void Reopen() => IsDone = false;
}
