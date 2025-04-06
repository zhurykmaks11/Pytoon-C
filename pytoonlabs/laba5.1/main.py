import tkinter as tk
from tkinter import messagebox

class Компютер:
    def __init__(self, частота, ядра, память, жорсткий_диск):
        self.частота = частота
        self.ядра = ядра
        self.память = память
        self.жорсткий_диск = жорсткий_диск

    def вартість(self):
        return (self.частота * self.ядра) / 100 + (self.память / 80) + (self.жорсткий_диск / 20)

    def придатність(self):
        return (self.частота >= 2000 and self.ядра >= 2 and self.память >= 2048 and self.жорсткий_диск >= 320)

    def інформація(self):
        return (f"Частота процесора: {self.частота} МГц\n"
                f"Кількість ядер: {self.ядра}\n"
                f"Обсяг пам'яті: {self.память} МБ\n"
                f"Обсяг жорсткого диска: {self.жорсткий_диск} ГБ\n"
                f"Вартість: {self.вартість():.2f} грн\n"
                f"Придатність: {'Так' if self.придатність() else 'Ні'}")

class Ноутбук(Компютер):
    def __init__(self, частота, ядра, память, жорсткий_диск, автономна_робота):
        super().__init__(частота, ядра, память, жорсткий_диск)
        self.автономна_робота = автономна_робота

    def вартість(self):
        return super().вартість() + (self.автономна_робота / 10)

    def придатність(self):
        return super().придатність() and self.автономна_робота >= 60

    def інформація(self):
        return (super().інформація() + 
                f"\nТривалість автономної роботи: {self.автономна_робота} хв")

class Планшет(Компютер):
    def __init__(self, частота, ядра, память, жорсткий_диск, вага):
        super().__init__(частота, ядра, память, жорсткий_диск)
        self.вага = вага

    def вартість(self):
        return super().вартість() / 10

    def інформація(self):
        return (super().інформація() + 
                f"\nВага: {self.вага} кг")

def створити_компютер():
    try:
        частота = float(частота_entry.get())
        ядра = int(ядра_entry.get())
        память = int(память_entry.get())
        жорсткий_диск = int(жорсткий_диск_entry.get())
        компютер = Компютер(частота, ядра, память, жорсткий_диск)
        messagebox.showinfo("Інформація про комп'ютер", компютер.інформація())
    except ValueError:
        messagebox.showerror("Помилка", "Невірний формат даних")

def створити_ноутбук():
    try:
        частота = float(частота_entry.get())
        ядра = int(ядра_entry.get())
        память = int(память_entry.get())
        жорсткий_диск = int(жорсткий_диск_entry.get())
        автономна_робота = int(автономна_робота_entry.get())
        ноутбук = Ноутбук(частота, ядра, память, жорсткий_диск, автономна_робота)
        messagebox.showinfo("Інформація про ноутбук", ноутбук.інформація())
    except ValueError:
        messagebox.showerror("Помилка", "Невірний формат даних")

def створити_планшет():
    try:
        частота = float(частота_entry.get())
        ядра = int(ядра_entry.get())
        память = int(память_entry.get())
        жорсткий_диск = int(жорсткий_диск_entry.get())
        вага = float(вага_entry.get())
        планшет = Планшет(частота, ядра, память, жорсткий_диск, вага)
        messagebox.showinfo("Інформація про планшет", планшет.інформація())
    except ValueError:
        messagebox.showerror("Помилка", "Невірний формат даних")

# Створення GUI
root = tk.Tk()
root.title("Введення даних про комп'ютери")

tk.Label(root, text="Частота процесора (МГц):").grid(row=0, column=0)
частота_entry = tk.Entry(root)
частота_entry.grid(row=0, column=1)

tk.Label(root, text="Кількість ядер:").grid(row=1, column=0)
ядра_entry = tk.Entry(root)
ядра_entry.grid(row=1, column=1)

tk.Label(root, text="Обсяг пам'яті (МБ):").grid(row=2, column=0)
память_entry = tk.Entry(root)
память_entry.grid(row=2, column=1)

tk.Label(root, text="Обсяг жорсткого диска (ГБ):").grid(row=3, column=0)
жорсткий_диск_entry = tk.Entry(root)
жорсткий_диск_entry.grid(row=3, column=1)

tk.Label(root, text="Тривалість автономної роботи (хв):").grid(row=4, column=0)
автономна_робота_entry = tk.Entry(root)
автономна_робота_entry.grid(row=4, column=1)

tk.Label(root, text="Вага (кг):").grid(row=5, column=0)
вага_entry = tk.Entry(root)
вага_entry.grid(row=5, column=1)

tk.Button(root, text="Створити комп'ютер", command=створити_компютер).grid(row=6, column=0)
tk.Button(root, text="Створити ноутбук", command=створити_ноутбук).grid(row=6, column=1)
tk.Button(root, text="Створити планшет", command=створити_планшет).grid(row=6, column=2)

root.mainloop()