from abc import ABC, abstractmethod
from datetime import timedelta

class Broadcast(ABC):
    def __init__(self, name, genre, duration):
        self.name = name
        self.genre = genre
        self.duration = duration

    @abstractmethod
    def clone(self):
        pass

class NewsBroadcast(Broadcast):
    def __init__(self, name, genre, duration, presenter="Невідомий ведучий"):
        super().__init__(name, genre, duration)
        self.presenter = presenter

    def clone(self):
        return NewsBroadcast(self.name, self.genre, self.duration, self.presenter)

class MovieBroadcast(Broadcast):
    def __init__(self, name, genre, duration, year=2000):
        super().__init__(name, genre, duration)
        self.year = year

    def clone(self):
        return MovieBroadcast(self.name, self.genre, self.duration, self.year)

class IBroadcastFactory(ABC):
    @abstractmethod
    def create_broadcast(self, type, name, genre, duration):
        pass

class NewsBroadcastFactory(IBroadcastFactory):
    def create_broadcast(self, type, name, genre, duration):
        if type != "Новини":
            raise ValueError("Неправильний тип передачі")
        return NewsBroadcast(name, genre, duration)

class MovieBroadcastFactory(IBroadcastFactory):
    def create_broadcast(self, type, name, genre, duration):
        if type != "Фільм":
            raise ValueError("Неправильний тип передачі")
        return MovieBroadcast(name, genre, duration, year=2000)

if __name__ == "__main__":
    factory = NewsBroadcastFactory()
    news = factory.create_broadcast("Новини", "Вечірні новини", "Новини", timedelta(minutes=30))
    news.presenter = "Джо Байден"

    factory1 = MovieBroadcastFactory()
    film = factory1.create_broadcast("Фільм", "Месники", "Бойовик", timedelta(minutes=30))

    print(f"Програма: {news.name}, Жанр: {news.genre}, Тривалість: {news.duration} хвилин, Ведучий: {news.presenter}")
    print(f"Програма: {film.name}, Жанр: {film.genre}, Тривалість: {film.duration} хвилин, Рік: {film.year}")
