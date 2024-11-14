public class objectPool<T> where T : new()
{

    private List<T> objectsList = new List<T>();

    private int counter = 0;
    private int maxObjects = 5;


    public int getCount()
    {
        return counter;
    }

    public T getObj()
    {

        T objectItem;

        if (counter > 0)
        {
            objectItem = objectsList[0];
            objectsList.RemoveAt(0);
            counter--;
            return objectItem;
        }
        else
        {
            T obj = new T();
            return obj;
        }
    }

    public void releaseObj(T item)
    {
        if (counter < maxObjects)
        {
            objectsList.Add(item);
            counter++;
        }
    }

}



class Broadcast
{
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime StartTime { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        objectPool<Broadcast> objPool = new objectPool<Broadcast>();

        Broadcast obj = objPool.getObj();
        Console.WriteLine($"Створив першу передачу  {obj.Name} {obj.Duration} {obj.StartTime}");

        Broadcast obj1 = new Broadcast { Name = "aa", Duration = TimeSpan.FromMinutes(30), StartTime = new DateTime(2023, 11, 24, 19, 00, 00) };
        Console.WriteLine($"Створив другу передачу {obj1.Name} {obj1.Duration} {obj1.StartTime}");

        objPool.releaseObj(obj1);
        Console.WriteLine($"Друга передача в пулі");


        int count = objPool.getCount();
        Console.WriteLine("Зараз в пулі: " + count);
        objPool.releaseObj(obj);
        Console.WriteLine("Додав першу програма в пулі");
        count = objPool.getCount();
        Console.WriteLine("Зараз в пулі: " + count);

        Broadcast obj3 = objPool.getObj();
        Console.WriteLine($"Повернув програму  {obj3.Name} {obj3.Duration} {obj3.StartTime}");
        count = objPool.getCount();
        Console.WriteLine("Зараз в пулі: " + count);

    }
}

