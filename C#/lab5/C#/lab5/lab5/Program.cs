public interface IBroadcast
{
    string Name { get; }
    TimeSpan Duration { get; }
    DateTime StartTime { get; }
}

public class BroadcastBuilder
{
    private string name;
    private TimeSpan duration;
    private DateTime startTime;

    public BroadcastBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public BroadcastBuilder SetDuration(TimeSpan duration)
    {
        this.duration = duration;
        return this;
    }

    public BroadcastBuilder SetStartTime(DateTime startTime)
    {
        this.startTime = startTime;
        return this;
    }

    public IBroadcast Build()
    {
        return new Broadcast(name, duration, startTime);
    }
}

public class Broadcast: IBroadcast
{
    public Broadcast(string name, TimeSpan duration, DateTime startTime)
    {
        Name = name;
        Duration = duration;
        StartTime = startTime;
    }

    public string Name { get; }
    public TimeSpan Duration { get; }
    public DateTime StartTime { get; }
}

public class Schedule
{
    private readonly List<IBroadcast> broadcasts = new();

    public void AddBroadcast(IBroadcast broadcast)
    {
        broadcasts.Add(broadcast);
    }

    public void PrintSchedule()
    {
        Console.WriteLine("Розклад передач:");
        foreach (var broadcast in broadcasts)
        {
            Console.WriteLine($"{broadcast.StartTime:HH:mm} - {broadcast.Name} ({broadcast.Duration})");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var schedule = new Schedule();

        // Створення трансляції новин
        var newsBroadcast = new BroadcastBuilder()
            .SetName("Дедпул")
            .SetDuration(TimeSpan.FromMinutes(30))
            .SetStartTime(new DateTime(2023, 11, 24, 19, 00, 00))
            .Build();

        schedule.AddBroadcast(newsBroadcast);

        // Створення трансляції серіалу
        var serialBroadcast = new BroadcastBuilder()
            .SetName("Чоловік-таракан")
            .SetDuration(TimeSpan.FromMinutes(60))
            .SetStartTime(new DateTime(2023, 11, 24, 20, 00, 00))
            .Build();

        schedule.AddBroadcast(serialBroadcast);

        schedule.PrintSchedule();

    }
}
