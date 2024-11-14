public abstract class Broadcast
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public TimeSpan Duration { get; set; }

    public abstract Broadcast Clone();
}

public class NewsBroadcast : Broadcast
{
    public string Presenter { get; set; }

    public override Broadcast Clone()
    {
        return (NewsBroadcast)MemberwiseClone();
    }
}

public class MovieBroadcast : Broadcast
{
    public int Year { get; set; }

    public override Broadcast Clone()
    {
        return (MovieBroadcast)MemberwiseClone();
    }
}

public interface IBroadcastFactory
{
    Broadcast CreateBroadcast(string name, string genre, TimeSpan duration);
}

public class NewsBroadcastFactory : IBroadcastFactory
{
    public Broadcast CreateBroadcast(string name, string genre, TimeSpan duration)
    {
        return new NewsBroadcast
        {
            Name = name,
            Genre = genre,
            Duration = duration,
            Presenter = "Unknown Presenter"
        };
    }
}

public class MovieBroadcastFactory : IBroadcastFactory
{
    public Broadcast CreateBroadcast(string name, string genre, TimeSpan duration)
    {
        if (genre != "Movie")
        {
            throw new ArgumentException("Invalid genre for Movie broadcast");
        }

        return new MovieBroadcast
        {
            Name = name,
            Genre = genre,
            Duration = duration,
            Year = 2000
        };
    }
}

public class Program
{
    static void Main(string[] args)
    {
        IBroadcastFactory newsFactory = new NewsBroadcastFactory();
        IBroadcastFactory movieFactory = new MovieBroadcastFactory();

        // Create news broadcast
        Broadcast news = newsFactory.CreateBroadcast("Evening News", "News", TimeSpan.FromMinutes(30));

        // Create movie broadcast
        Broadcast film = movieFactory.CreateBroadcast("Avengers", "Movie", TimeSpan.FromMinutes(120));

        // Print details of created broadcasts
        Console.WriteLine($"Program: {news.Name}, Genre: {news.Genre}, Duration: {news.Duration.Minutes} minutes, Presenter: {((NewsBroadcast)news).Presenter}");
        Console.WriteLine($"Program: {film.Name}, Genre: {film.Genre}, Duration: {film.Duration.Minutes} minutes, Year: {((MovieBroadcast)film).Year}");
    }
}
