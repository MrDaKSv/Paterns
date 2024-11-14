using System.Xml.Linq;

public class Broadcast
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public class User
{
    public string rules { get; set; }

    public bool canEdit()
    {
        if (rules == "Едітор" || rules == "Адмін")
        {
            return true;
        }
        return false;
    }

    public bool isAdmin()
    {
        if (rules == "Адмін")
        {
            return true;
        }
        return false;
    }
}

public interface IScheduleManager
{
    void AddBroadcast(Broadcast broadcast);
    void RemoveBroadcast(Broadcast broadcast);
    List<Broadcast> GetBroadcast();

}

public class ScheduleManager : IScheduleManager
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

    public void Clear()
    {
        broadcasts.Clear();
    }

}

public class ScheduleManagerProxy : IScheduleManager
{
    private ScheduleManager scheduleManager;
    private User user;

    public ScheduleManagerProxy(ScheduleManager scheduleManager, User user)
    {
        this.scheduleManager = scheduleManager;
        this.user = user;
    }

    public void AddBroadcast(Broadcast broadcast)
    {
        if (user.canEdit())
        {
            scheduleManager.AddBroadcast(broadcast);
        }
        else
        {
            Console.WriteLine("Недостатньо прав");
        }
    }

    public void RemoveBroadcast(Broadcast broadcast)
    {
        if (user.canEdit())
        {
            scheduleManager.RemoveBroadcast(broadcast);
        }
        else
        {
            Console.WriteLine("Недостатньо прав");
        }
    }
    public void Clear()
    {
        if (user.isAdmin())
        {
            scheduleManager.Clear();
            Console.WriteLine("Передачі видалено!");

        }
        else
        {
            Console.WriteLine("Недостатньо прав");
        }
    }
    public List<Broadcast> GetBroadcast()
    {
        if (user.isAdmin())
        {
            return scheduleManager.GetBroadcast();
        }
        else
        {
            Console.WriteLine("Недостатньо прав");
            return new List<Broadcast>();
        }
    }

}


public class Program
{
    static void Main()
    {
        ScheduleManager scheduleManager = new ScheduleManager();
        User editor = new User { rules = "Едітор" };
        User admin = new User { rules = "Адмін" }; 

        ScheduleManagerProxy proxy = new ScheduleManagerProxy(scheduleManager, editor);
        proxy.AddBroadcast(new Broadcast { Name = "Вечірні новини", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1)}); 

        proxy.Clear(); // Едітор не може видалити всі передачі Т_Т

        proxy = new ScheduleManagerProxy(scheduleManager, admin);
        proxy.Clear();

    }
}

