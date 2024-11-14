from datetime import datetime, timedelta

class OldBroadcast:
    def __init__(self, title, start_time, duration):
        self.title = title
        self.start_time = start_time
        self.duration = duration

class Broadcast:
    def __init__(self, name, start_time, end_time):
        self.name = name
        self.start_time = start_time
        self.end_time = end_time

class BroadcastAdapter:
    def adapt(self, old_broadcast):
        end_time = old_broadcast.start_time + timedelta(minutes=old_broadcast.duration)
        return Broadcast(old_broadcast.title, old_broadcast.start_time, end_time)

old_broadcast = OldBroadcast("Новини", datetime(2023, 11, 24, 19, 0, 0), 30)
adapter = BroadcastAdapter()
broadcast = adapter.adapt(old_broadcast)

print(f"Передача: {broadcast.name}, з {broadcast.start_time} до {broadcast.end_time}")