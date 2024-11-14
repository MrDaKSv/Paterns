import copy
import queue
from datetime import datetime

class Broadcast:
    def __init__(self, name, start_time, end_time):
        self.name = name
        self.start_time = start_time
        self.end_time = end_time

class BroadcastPool:
    def __init__(self, max_size):
        self.pool = queue.Queue(maxsize=max_size)
        for _ in range(max_size):
            self.pool.put(Broadcast("", 0, 0))

    def get_broadcast(self):
        broadcast = self.pool.get()
        # Створюємо копію об'єкта
        return copy.deepcopy(broadcast)

    def return_broadcast(self, broadcast):
        self.pool.put(broadcast)

pool = BroadcastPool(1)

broadcast = pool.get_broadcast()
broadcast.name = "Новини"
broadcast.start_time = datetime(2023, 11, 24, 19, 0, 0)
broadcast.end_time = datetime(2023, 11, 24, 20, 0, 0)

print(f"{broadcast.name} {broadcast.start_time} {broadcast.end_time}")

pool.return_broadcast(broadcast)

broadcast1 = pool.get_broadcast()
print(f"{broadcast1.name} {broadcast1.start_time} {broadcast1.end_time}")