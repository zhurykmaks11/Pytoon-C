from abc import ABC, abstractmethod
import tkinter as tk
from tkinter import messagebox

# абстрактний клас
class PrintPublication(ABC):
    def __init__(self, title, publisher, year):
        self.title = title
        self.publisher = publisher
        self.year = year

@abstractmethod
def get_info(self):
    pass

def display(self):
    return f"{self.title} {self.publisher} {self.year}"

class Magazine(PrintPublication):
    def __init__(self, title, publisher, year, issue_number):
        super().__init__(title, publisher, year)
        self.issue_number = issue_number
    def get_info(self):
        return f"Журнал: {self.title}, Видавець: {self.publisher}, Рік: {self.year}, Номер: {self.issue_number}"

class Book(PrintPublication):
    def __init__(self, title, publisher, year, author):
        super().__init__(title, publisher, year)
        self.author = author
    def get_info(self):
        return f"Книга: {self.title}, Видавець: {self.publisher}, Рік: {self.year}"



publications = [
    Magazine("National Geographic", "NatGeo", 2023, 5),
    Book("Python for Beginners", "Tech Books", 2021, "John Doe"),
    Magazine("Science Today", "SciPub", 2022, 12),
    Book("Artificial Intelligence", "AI Press", 2020, "Jane Smith")
]

# Функція для пошуку за видавцем
def search_publication():
    search_term = entry_search.get().strip()
    results = [p.get_info() for p in publications if p.publisher.lower() == search_term.lower()]
    if results:
        messagebox.showinfo("Результати пошуку", "\n".join(results))
    else:
        messagebox.showinfo("Результати пошуку", "Не знайдено жодного видання")

# Функція для виведення всіх видань
def show_all():
    info_text = "\n".join(p.get_info() for p in publications)
    messagebox.showinfo("Список видань", info_text)

# Графічний інтерфейс
root = tk.Tk()
root.title("База друкарських видань")
root.geometry("400x300")

tk.Label(root, text="Пошук за видавцем:").pack(pady=5)
entry_search = tk.Entry(root)
entry_search.pack(pady=5)

tk.Button(root, text="Пошук", command=search_publication).pack(pady=5)
tk.Button(root, text="Показати всі", command=show_all).pack(pady=5)
tk.Button(root, text="Вийти", command=root.quit).pack(pady=10)

root.mainloop()
