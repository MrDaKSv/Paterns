public abstract class Broadcast
{
    public abstract string GetDescription();
}

public class News : Broadcast
{
    public override string GetDescription()
    {
        return "Новини";
    }
}

public abstract class Decorator : Broadcast
{
    protected Broadcast broadcast;

    public Decorator(Broadcast broadcast)
    {
        this.broadcast = broadcast;
    }
}

public class SubtitleDecorator : Decorator
{
    public SubtitleDecorator(Broadcast broadcast) : base(broadcast) { }

    public override string GetDescription()
    {
        return $"{broadcast.GetDescription()} з субтитрами";
    }
}

public class MultiLanguageDecorator : Decorator
{
    public MultiLanguageDecorator(Broadcast broadcast) : base(broadcast) { }

    public override string GetDescription()
    {
        return $"{broadcast.GetDescription()} з багатомовністю";
    }
}

public class Program
{
    static void Main()
    {
        Broadcast broadcast = new News();
        broadcast = new SubtitleDecorator(broadcast);
        broadcast = new MultiLanguageDecorator(broadcast);

        Console.WriteLine(broadcast.GetDescription());
    }
}