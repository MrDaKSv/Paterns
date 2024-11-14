from abc import ABC, abstractmethod

class Program(ABC):
    def __init__(self, device):
        self.device = device

    @abstractmethod
    def play(self):
        pass

class Movie(Program):
    def play(self):
        self.device.show_movie()

class Series(Program):
    def play(self):
        self.device.show_series()

class IDevice(ABC):
    @abstractmethod
    def show_movie(self):
        pass

    @abstractmethod
    def show_series(self):
        pass

    @abstractmethod
    def show_news(self):
        pass

class TV(IDevice):
    def show_movie(self):
        print("Відображаємо фільм на телевізорі")

    def show_series(self):
        print("Відображаємо серіал на телевізорі")

    def show_news(self):
        print("Відображаємо новини на телевізорі")

class MobilePhone(IDevice):
    def show_movie(self):
        print("Відображаємо фільм на мобільному телефоні")

    def show_series(self):
        print("Відображаємо серіал на мобільному телефоні")

    def show_news(self):
        print("Відображаємо новини на мобільному телефоні")

if __name__ == "__main__":
    tv = TV()
    mobile = MobilePhone()

    movie = Movie(tv)
    movie.play()

    series = Series(mobile)
    series.play()