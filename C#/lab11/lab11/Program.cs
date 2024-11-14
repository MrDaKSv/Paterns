public interface Broadcast
{
    string Name { get; }
    DateTime StartTime { get; }
    DateTime EndTime { get; }
}

public class News : Broadcast
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Presenter { get; set; }
}

public class Movie : Broadcast
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Genre { get; set; }
}


public class ScheduleManager
{
    private List<Broadcast> broadcasts = new List<Broadcast>();

    public void AddBroadcast(Broadcast broadcast)
    {
        broadcasts.Add(broadcast);
    }

    public void RemoveBroadcast(Broadcast broadcast)
    {
        broadcasts.Remove(broadcast);
    }
    public List<Broadcast> GetBroadcast()
    {
        return broadcasts;
    }
}

public class ScheduleFacade
{
    private ScheduleManager manager = new ScheduleManager();

    public void CreateNews(string name, DateTime startTime, DateTime endTime, string presenter)
    {
        News news = new News { Name = name, StartTime = startTime, EndTime = endTime, Presenter = presenter };
        manager.AddBroadcast(news);
    }

    public void CreateMovie(string name, DateTime startTime, DateTime endTime, string genre)
    {
        Movie movie = new Movie { Name = name, StartTime = startTime, EndTime = endTime, Genre = genre };
        manager.AddBroadcast(movie);
    }

    public void ShowAll()
    {
        foreach (var broadcast in manager.GetBroadcast())
        {
            if (broadcast is News news)
            {
                Console.WriteLine($"Програма: {news.Name}, Початок: {news.StartTime}, Кінець: {news.EndTime}, Ведучий: {news.Presenter}");
            }
            else if (broadcast is Movie movie)
            {
                Console.WriteLine($"Програма: {movie.Name}, Початок: {movie.StartTime}, Кінець: {movie.EndTime}, Жанр: {movie.Genre}");
            }
        }
    }
}


public class Program
{
    static void Main()
    {
        ScheduleFacade facade = new ScheduleFacade();
        facade.CreateNews("Вечірні новини", DateTime.Now, DateTime.Now.AddHours(1), "Відомий чоловік");
        facade.CreateMovie("Дедпул", DateTime.Now, DateTime.Now.AddHours(1), "Бойовик");
        facade.ShowAll();
    }
}
