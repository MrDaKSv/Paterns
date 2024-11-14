public class OldBroadcast
{
    public string Title { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
}

public class Broadcast
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}


public class BroadcastAdapter 
{
    public Broadcast Adapt(OldBroadcast oldBroadcast)
    {
        return new Broadcast
        {
            Name = oldBroadcast.Title,
            StartTime = oldBroadcast.StartTime, 
            EndTime = oldBroadcast.StartTime.AddMinutes(oldBroadcast.Duration),
        };
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Приклад використання
        var oldBroadcast = new OldBroadcast { Title = "Новини", StartTime = new DateTime(2023, 11, 24, 19, 0, 0), Duration = 30 };
        var adapter = new BroadcastAdapter();
        var broadcast = adapter.Adapt(oldBroadcast);

        Console.WriteLine($"Передача: {broadcast.Name}, з {broadcast.StartTime} до {broadcast.EndTime}");

    }
}


