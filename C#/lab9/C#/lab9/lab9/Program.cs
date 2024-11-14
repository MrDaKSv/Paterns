public abstract class ProgramComponent
{
    public string Name { get; set; }

    public virtual void Add(ProgramComponent component) { }
    public virtual void Remove(ProgramComponent component) { }
    public virtual bool IsComposite() { return false; }
    public abstract void Display(int depth);
}

public class ProgramLeaf : ProgramComponent
{
    public override void Display(int depth)
    {
        Console.WriteLine($"{new string('-', depth)}{Name}");
    }
}

public class ProgramComposite : ProgramComponent
{
    private List<ProgramComponent> children = new List<ProgramComponent>();

    public override void Add(ProgramComponent component)
    {
        children.Add(component);
    }

    public override void Remove(ProgramComponent component)
    {
        children.Remove(component);
    }

    public override bool IsComposite()
    {
        return true;
    }

    public override void Display(int depth)
    {
        Console.WriteLine($"{new string('-', depth)}{Name}");
        foreach (var child in children)
        {
            child.Display(depth + 2);
        }
    }
}

public class Program
{
    static void Main()
    {
        ProgramComposite program = new ProgramComposite { Name = "Вечірній ефір" };
        ProgramComposite newsBlock = new ProgramComposite { Name = "Новини" };
        ProgramLeaf news1 = new ProgramLeaf { Name = "Новини спорту" };
        ProgramLeaf news2 = new ProgramLeaf { Name = "Новини економіки" };
        ProgramComposite movieBlock = new ProgramComposite { Name = "Блок фільмів" };
        ProgramLeaf movie1 = new ProgramLeaf { Name = "Дедпул" };
        ProgramLeaf movie2 = new ProgramLeaf { Name = "Хата на таракана" };

        newsBlock.Add(news1);
        newsBlock.Add(news2);
        movieBlock.Add(movie1);
        movieBlock.Add(movie2);
        program.Add(newsBlock);
        program.Add(movieBlock);

        program.Display(0);
    }
}


