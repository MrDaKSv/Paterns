public abstract class Broadcast
{
    protected IDevice device;

    protected Broadcast(IDevice device)
    {
        this.device = device;
    }

    public abstract void Play();
}

public class Movie : Broadcast
{
    public Movie(IDevice device) : base(device) { }

    public override void Play()
    {
        device.ShowMovie();
    }
}

public class Series : Broadcast
{
    public Series(IDevice device) : base(device) { }

    public override void Play()
    {
        device.ShowSeries();
    }
}

public interface IDevice
{
    void ShowMovie();
    void ShowSeries();
    void ShowNews();
}

public class TV : IDevice
{
    public void ShowMovie() { Console.WriteLine("Відображаємо фільм на телевізорі"); }
    public void ShowSeries() { Console.WriteLine("Відображаємо серіал на телевізорі"); }
    public void ShowNews() { Console.WriteLine("Відображаємо новини на телевізорі"); }
}

public class MobilePhone : IDevice
{
    public void ShowMovie() { Console.WriteLine("Відображаємо фільм на мобільному телефоні"); }
    public void ShowSeries() { Console.WriteLine("Відображаємо серіал на мобільному телефоні"); }
    public void ShowNews() { Console.WriteLine("Відображаємо новини на мобільному телефоні"); }
}

class Program
{
    static void Main(string[] args)
    {
        IDevice tv = new TV();
        IDevice mobile = new MobilePhone();

        Movie movie = new Movie(tv);
        movie.Play();

        Series series = new Series(mobile);
        series.Play();
    }
}