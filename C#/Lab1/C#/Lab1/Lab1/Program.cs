using System;
using System.Collections.Generic;

namespace ElectronicSchedule
{
    public class Broadcast
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }

        public Broadcast(string name, string genre, TimeSpan duration)
        {
            Name = name;
            Genre = genre;
            Duration = duration;
        }

        public Broadcast Clone()
        {
            return new Broadcast(this.Name, this.Genre, this.Duration);
        }
    }

    public class Schedule
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

        public List<Broadcast> GetBroadcasts()
        {
            return broadcasts;
        }
    }

    public sealed class ScheduleSingleton
    {
        private static readonly ScheduleSingleton instance = new ScheduleSingleton();
        private ScheduleSingleton() { }
        public static ScheduleSingleton Instance { get { return instance; } }
        public Schedule Schedule { get; private set; } = new Schedule();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var todaySchedule = ScheduleSingleton.Instance;
            var tomorrowSchedule = ScheduleSingleton.Instance;

            todaySchedule.Schedule.AddBroadcast(new Broadcast("News", "News", TimeSpan.FromMinutes(30)));
            todaySchedule.Schedule.AddBroadcast(new Broadcast("Alien", "Movie", TimeSpan.FromMinutes(130)));

            tomorrowSchedule.Schedule.AddBroadcast(new Broadcast("Discovery", "Show", TimeSpan.FromMinutes(30)));
            tomorrowSchedule.Schedule.AddBroadcast(new Broadcast("Terminator", "Movie", TimeSpan.FromMinutes(140)));

            Console.WriteLine("Today's Schedule:");
            foreach (var broadcast in todaySchedule.Schedule.GetBroadcasts())
            {
                Console.WriteLine($"Program: {broadcast.Name}, Genre: {broadcast.Genre}, Duration: {broadcast.Duration}");
            }

            Broadcast avengers = new Broadcast("Avengers", "Movie", TimeSpan.FromMinutes(140));
            Broadcast harryPotter = avengers.Clone();

            Console.WriteLine("\nCloned Program:");
            Console.WriteLine($"Program: {avengers.Name}, Genre: {avengers.Genre}, Duration: {avengers.Duration}");
            Console.WriteLine($"Program: {harryPotter.Name}, Genre: {harryPotter.Genre}, Duration: {harryPotter.Duration}");

            avengers.Name = "Updated Avengers";
            Console.WriteLine("\nAfter Modifying the Original:");
            Console.WriteLine($"Program: {avengers.Name}, Genre: {avengers.Genre}, Duration: {avengers.Duration}");
            Console.WriteLine($"Program: {harryPotter.Name}, Genre: {harryPotter.Genre}, Duration: {harryPotter.Duration}");
        }
    }
}
