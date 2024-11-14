from abc import ABC, abstractmethod

class Broadcast(ABC):
    @abstractmethod
    def get_description(self):
        pass

class News(Broadcast):
    def get_description(self):
        return "Новини"

class Decorator(Broadcast):
    def __init__(self, broadcast):
        self.broadcast = broadcast

    def get_description(self):
        return self.broadcast.get_description()

class SubtitleDecorator(Decorator):
    def get_description(self):
        return f"{super().get_description()} з субтитрами"

class MultiLanguageDecorator(Decorator):
    def get_description(self):
        return f"{super().get_description()} з багатомовністю"

if __name__ == "__main__":
    broadcast = News()
    broadcast = SubtitleDecorator(broadcast)
    broadcast = MultiLanguageDecorator(broadcast)

    print(broadcast.get_description())