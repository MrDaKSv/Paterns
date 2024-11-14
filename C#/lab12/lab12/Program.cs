public class Broadcast
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public BroadcastType Type { get; set; }

}

public class BroadcastType
{
    public string Channel { get; set; }
    public bool HaveAD { get; set; }
}

public class BroadcastFactory
{
    public static BroadcastType CreateBroadcast(string channel, bool haveAD)
    {

        return new BroadcastType
        {
            Channel = channel,
            HaveAD = haveAD,
        };
    }
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

    public void CreateBroadcast(string name, DateTime startTime, DateTime endTime, string presenter)
    {
        BroadcastType type = BroadcastFactory.CreateBroadcast("2+2", true);
        Broadcast broadcast = new Broadcast { Name = name, StartTime = startTime, EndTime = endTime, Type = type };
        manager.AddBroadcast(broadcast);
    }
    public void ShowAll()
    {
        foreach (var broadcast in manager.GetBroadcast())
        {
            Console.WriteLine($"Програма: {broadcast.Name}, Початок: {broadcast.StartTime}, Кінець: {broadcast.EndTime}, Канал: {broadcast.Type.Channel}, Реклама: {broadcast.Type.HaveAD}");
        }
    }
}


public class Program
{
    static void Main()
    {
        ScheduleFacade facade = new ScheduleFacade();
        facade.CreateBroadcast("Вечірні новини", DateTime.Now, DateTime.Now.AddHours(1), "Відомий чоловік");
        facade.ShowAll();    
    }
}
