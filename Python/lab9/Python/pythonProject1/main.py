from abc import ABC, abstractmethod

class ProgramComponent(ABC):
    def __init__(self, name):
        self.name = name

    @abstractmethod
    def add(self, component):
        pass

    @abstractmethod
    def remove(self, component):
        pass

    @abstractmethod
    def is_composite(self):
        pass

    @abstractmethod
    def display(self, depth):
        pass

class ProgramLeaf(ProgramComponent):
    def __init__(self, name):
        super().__init__(name)

    def add(self, component):
        pass
    def remove(self, component):
        pass

    def is_composite(self):
        return False

    def display(self, depth):
        print(f"{'-' * depth}{self.name}")

class ProgramComposite(ProgramComponent):
    def __init__(self, name):
        super().__init__(name)
        self.children = []

    def add(self, component):
        self.children.append(component)

    def remove(self, component):
        self.children.remove(component)

    def is_composite(self):
        return True

    def display(self, depth):
        print(f"{'-' * depth}{self.name}")
        for child in self.children:
            child.display(depth + 2)

if __name__ == "__main__":
    program = ProgramComposite("Вечірній ефір")
    newsBlock = ProgramComposite("Новини")
    news1 = ProgramLeaf("Новини спорту")
    news2 = ProgramLeaf("Новини економіки")
    movieBlock = ProgramComposite("Блок фільмів")
    movie1 = ProgramLeaf("Дедпул")
    movie2 = ProgramLeaf("Хата на таракана")

    newsBlock.add(news1)
    newsBlock.add(news2)
    movieBlock.add(movie1)
    movieBlock.add(movie2)
    program.add(newsBlock)
    program.add(movieBlock)

    program.display(0)