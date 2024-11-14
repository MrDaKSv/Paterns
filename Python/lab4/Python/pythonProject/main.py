from typing import TypeVar
from datetime import datetime, timedelta

T = TypeVar("T")  # Generic type variable

class ObjectPool:
    """
    Implements the Object Pool pattern in Python.

    Attributes:
        _objects (List[T]): List to store objects in the pool.
        _counter (int): Counter to track the number of objects in the pool.
        max_objects (int): Maximum number of objects allowed in the pool.
        T (TypeVar): Generic type variable for the pool objects.
    """

    def __init__(self, object_type: type[T], max_objects: int = 5) -> None:
        """
        Initializes the Object Pool.

        Args:
            object_type (type[T]): The type of object to be pooled.
            max_objects (int, optional): The maximum number of objects allowed in the pool. Defaults to 5.
        """
        self._objects: [T] = []
        self._counter: int = 0
        self.max_objects: int = max_objects
        self.object_type = object_type  # Store object type for creation

    def get_obj(self) -> T:
        """
        Retrieves an object from the pool. If no objects are available,
        creates a new one.

        Returns:
            T: An object of type T from the pool or a newly created one.
        """
        if self._counter > 0:
            obj = self._objects.pop(0)
            self._counter -= 1
            return obj
        else:
            return self.object_type()  # Create a new object of type T

    def release_obj(self, obj: T) -> None:
        """
        Releases an object back to the pool, limiting the pool size
        to `max_objects`.

        Args:
            obj (T): The object to be released back to the pool.
        """
        if self._counter < self.max_objects:
            self._objects.append(obj)
            self._counter += 1

    def get_count(self) -> int:
        """
        Returns the current number of objects in the pool.

        Returns:
            int: The number of objects in the pool.
        """
        return self._counter

# Example usage
class Broadcast:
    def __init__(self, name, duration, start_time):
        self.name = name
        self.duration = duration
        self.start_time = start_time

    def get_name(self):
        return self.name

    def get_duration(self):
        return self.duration

    def get_start_time(self):
        return self.start_time

if __name__ == "__main__":
    from datetime import timedelta, datetime  # Assuming these are imported

    pool = ObjectPool(Broadcast)

    # Get objects from the pool
    obj1 = pool.get_obj()
    obj2 = pool.get_obj()

    # Set some properties
    obj1.name = "News"
    obj1.duration = timedelta(minutes=30)
    obj1.start_time = datetime(2023, 11, 24, 19, 0, 0)

    obj2.name = "Series"
    obj2.duration = timedelta(minutes=60)
    obj2.start_time = datetime(2023, 11, 24, 20, 0, 0)

    # Print information
    print(f"Created first broadcast: {obj1.name}, {obj1.duration}, {obj1.start_time}")
    print(f"Created second broadcast: {obj2.name}, {obj2.duration}, {obj2.start_time}")

    # Get object count
    count = pool.get_count()
    print(f"Currently in pool: {count}")

    # Release object back to pool
    pool.release_obj(obj1)
    print("Released first broadcast back to pool")

    # Get object count again
    count = pool.get_count()
    print(f"Currently in pool: {count}")