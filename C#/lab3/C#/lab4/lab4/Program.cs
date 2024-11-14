using System;

//Інтерфейс фабрики
public interface FilmFactory
{
    Film CreateFilm();
    FilmSchedule CreateFilmSchedule();
}

//Фабрика для документальних фільмів
public class DiscoveryFactory : FilmFactory
{
    public Film CreateFilm()
    {
        return new DocumentaryFilm();
    }

    public FilmSchedule CreateFilmSchedule()
    {
        return new DiscoverySchedule();
    }
}

//Фабрика для голівуда
public class HollywoodFactory : FilmFactory
{
    public Film CreateFilm()
    {
        return new BlockbusterFilm();
    }

    public FilmSchedule CreateFilmSchedule()
    {
        return new HollyWoodSchedule();
    }
}

//Інтерфейс для фільма
public interface Film
{
    void ShowInfo();
}

//Клас для документального фільму
public class DocumentaryFilm : Film
{
    public void ShowInfo()
    {
        Console.WriteLine("Документальний фільм: У світі тварин.");
    }
}

//Клас для блокбастера
public class BlockbusterFilm : Film
{
    public void ShowInfo()
    {
        Console.WriteLine("Художній фільм: Дедпул");
    }
}

public interface FilmSchedule
{
    void DisplaySchedule();
}

public class DiscoverySchedule : FilmSchedule
{
    public void DisplaySchedule()
    {
        Console.WriteLine("Розклад передач про тварин: 12:00, 18:00.");
    }
}

public class HollyWoodSchedule : FilmSchedule
{
    public void DisplaySchedule()
    {
        Console.WriteLine("Розклад блокбастерів:14:00, 20:00.");
    }
}

// Клієнтський клас, що використовує фабрики для створення розкладу та шоу
public class FilmApplication
{
    private FilmFactory factory;
    private Film film;
    private FilmSchedule schedule;

    public FilmApplication(FilmFactory factory)
    {
        this.factory = factory;
    }

    public void Create()
    {
        film = factory.CreateFilm();
        schedule = factory.CreateFilmSchedule();
    }

    public void Show()
    {
        film.ShowInfo();
        schedule.DisplaySchedule();
    }
}

// Конфігуратор додатка
public class ApplicationConfigurator
{
    public static void Main(string[] args)
    {
        FilmFactory factory;

        string config = "Discovery"; 

        if (config == "Discovery")
        {
            factory = new DiscoveryFactory();
        }
        else if (config == "Blockbuster")
        {
            factory = new HollywoodFactory();
        }
        else
        {
            throw new Exception("Невідомий фільм");
        }

        FilmApplication app = new FilmApplication(factory);
        app.Create();
        app.Show();
    }
}