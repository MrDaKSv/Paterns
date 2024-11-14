from datetime import datetime

class BroadcastType:
    def __init__(self, channel, have_ad):
        self.channel = channel
        self.have_ad = have_ad

class Broadcast:
    def __init__(self, name, start_time, end_time, broadcast_type):
        self.name = name
        self.start_time = start_time
        self.end_time = end_time
        self.type = broadcast_type

class BroadcastFactory:
    @staticmethod
    def create_broadcast_type(channel, have_ad):
        return BroadcastType(channel, have_ad)

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

    def create_broadcast(self, name, start_time, end_time, presenter):
        broadcast_type = BroadcastFactory.create_broadcast_type("2+2", True)
        broadcast = Broadcast(name, start_time, end_time, broadcast_type)
        self.manager.add_broadcast(broadcast)

    def show_all(self):
        for broadcast in self.manager.get_broadcasts():
            print(f"Програма: {broadcast.name}, Початок: {broadcast.start_time}, Кінець: {broadcast.end_time}, Канал: {broadcast.type.channel}, Реклама: {broadcast.type.have_ad}")

if __name__ == "__main__":
    facade = ScheduleFacade()
    facade.create_broadcast("Вечірні новини", datetime.now(), datetime(2023, 11, 24, 19, 0, 0), "Відомий чоловік")
    facade.show_all()