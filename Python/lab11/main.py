from datetime import datetime, timedelta

class Broadcast:
    def __init__(self, name, start_time, end_time):
        self.name = name
        self.start_time = start_time
        self.end_time = end_time

class News(Broadcast):
    def __init__(self, name, start_time, end_time, presenter):
        super().__init__(name, start_time, end_time)
        self.presenter = presenter

class Movie(Broadcast):
    def __init__(self, name, start_time, end_time, genre):
        super().__init__(name, start_time, end_time)
        self.genre = genre

class ScheduleManager:
    def __init__(self):
        self.broadcasts = []

    def add_broadcast(self, broadcast):
        self.broadcasts.append(broadcast)

    def remove_broadcast(self, broadcast):
        self.broadcasts.remove(broadcast)

    def get_broadcasts(self):
        return self.broadcasts

class ScheduleFacade:
    def __init__(self):
        self.manager = ScheduleManager()

    def create_news(self, name, start_time, end_time, presenter):
        news = News(name, start_time, end_time, presenter)
        self.manager.add_broadcast(news)

    def create_movie(self, name, start_time, end_time, genre):
        movie = Movie(name, start_time, end_time, genre)
        self.manager.add_broadcast(movie)

    def show_all(self):
        for broadcast in self.manager.get_broadcasts():
            if isinstance(broadcast, News):
                print(f"Програма: {broadcast.name}, Початок: {broadcast.start_time}, Кінець: {broadcast.end_time}, Ведучий: {broadcast.presenter}")
            elif isinstance(broadcast, Movie):
                print(f"Програма: {broadcast.name}, Початок: {broadcast.start_time}, Кінець: {broadcast.end_time}, Жанр: {broadcast.genre}")

if __name__ == "__main__":
    facade = ScheduleFacade()
    facade.create_news("Вечірні новини", datetime.now(), datetime(2023, 11, 24, 19, 0, 0),  "Відомий чоловік")
    facade.create_movie("Дедпул", datetime.now(), datetime(2023, 11, 24, 19, 0, 0),  "Бойовик")
    facade.show_all()