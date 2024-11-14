from datetime import datetime

class Broadcast:
    def __init__(self, name, start_time, end_time):
        self.name = name
        self.start_time = start_time
        self.end_time = end_time

class User:
    def __init__(self, rules):
        self.rules = rules

    def can_edit(self):
        return self.rules in ("Editor", "Admin")

    def is_admin(self):
        return self.rules == "Admin"

class IScheduleManager:
    def add_broadcast(self, broadcast):
        pass

    def remove_broadcast(self, broadcast):
        pass

    def get_broadcasts(self):
        pass

    def clear(self):
        pass

class ScheduleManager(IScheduleManager):
    def __init__(self):
        self.broadcasts = []

    def add_broadcast(self, broadcast):
        self.broadcasts.append(broadcast)

    def remove_broadcast(self, broadcast):
        self.broadcasts.remove(broadcast)

    def get_broadcasts(self):
        return self.broadcasts.copy()  # Return a copy to avoid modifying the original list

    def clear(self):
        self.broadcasts.clear()
        print("Передачі видалено!")

class ScheduleManagerProxy(IScheduleManager):
    def __init__(self, schedule_manager, user):
        self.schedule_manager = schedule_manager
        self.user = user

    def add_broadcast(self, broadcast):
        if self.user.can_edit():
            self.schedule_manager.add_broadcast(broadcast)
        else:
            print("Недостатньо прав")

    def remove_broadcast(self, broadcast):
        if self.user.can_edit():
            self.schedule_manager.remove_broadcast(broadcast)
        else:
            print("Недостатньо прав")

    def clear(self):
        if self.user.is_admin():
            self.schedule_manager.clear()
        else:
            print("Недостатньо прав")

    def get_broadcasts(self):
        if self.user.is_admin():
            return self.schedule_manager.get_broadcasts()
        else:
            print("Недостатньо прав")
            return []

if __name__ == "__main__":
    schedule_manager = ScheduleManager()
    editor = User("Editor")
    admin = User("Admin")

    proxy = ScheduleManagerProxy(schedule_manager, editor)
    proxy.add_broadcast(Broadcast("Вечірні новини", datetime.now(), datetime(2024, 11, 24, 20, 0, 0)))

    proxy.clear()

    proxy = ScheduleManagerProxy(schedule_manager, admin)
    proxy.clear()