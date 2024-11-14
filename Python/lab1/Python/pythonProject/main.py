import copy

class Broadcast:
    def __init__(self, name, genre, duration):
        self.name = name
        self.genre = genre
        self.duration = duration

    def cloneMe(self):
        return copy.deepcopy(self)

class Schedule:
    def __init__(self):
        self.broadcasts = []

    def add_broadcast(self, broadcast):
        self.broadcasts.append(broadcast)

    def remove_broadcast(self, broadcast):
        self.broadcasts.remove(broadcast)

    def get_broadcasts(self):
        return self.broadcasts

class ScheduleSingleton:
    __instance = None

    @staticmethod
    def get_instance():
        if ScheduleSingleton.__instance is None:
            ScheduleSingleton.__instance = ScheduleSingleton()
        return ScheduleSingleton.__instance

    def __init__(self):
        self.schedule = Schedule()

if __name__ == "__main__":
    today_schedule = ScheduleSingleton.get_instance()
    tomorrow_schedule = ScheduleSingleton.get_instance()

    today_schedule.schedule.add_broadcast(Broadcast("News", "News", 30))
    today_schedule.schedule.add_broadcast(Broadcast("Alien", "Movie", 130))

    tomorrow_schedule.schedule.add_broadcast(Broadcast("Discovery", "Show", 30))
    tomorrow_schedule.schedule.add_broadcast(Broadcast("Terminator", "Movie", 140))

    for broadcast in today_schedule.schedule.get_broadcasts():
        print(f"Program: {broadcast.name}, Genre: {broadcast.genre}, Duration: {broadcast.duration} minutes")

    avengers = Broadcast("Avengers", "Movie", 140)
    harry_potter = avengers.cloneMe()

    print(f"\nProgram: {avengers.name}, Genre: {avengers.genre}, Duration: {avengers.duration} minutes")
    print(f"Program: {harry_potter.name}, Genre: {harry_potter.genre}, Duration: {harry_potter.duration} minutes")

    avengers.name = "xgt"
    print(f"Program: {avengers.name}, Genre: {avengers.genre}, Duration: {avengers.duration} minutes")
    print(f"Program: {harry_potter.name}, Genre: {harry_potter.genre}, Duration: {harry_potter.duration} minutes")
