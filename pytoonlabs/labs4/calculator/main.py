import tkinter as tk
from tkinter import messagebox
import os

INPUT_FILE = "Input data.txt"
OUTPUT_FILE = "Output data.txt"
LOG_FILE = "Session log.txt"

with open(LOG_FILE, "w") as log:
    log.write("Дія 1: додаток запущено\n")

def log_action(action):
    with open(LOG_FILE, "a") as log:
        log.write(f"Дія {sum(1 for _ in open(LOG_FILE)) + 1}: {action}\n")

def import_data():
    try:
        with open(INPUT_FILE, "r") as file:
            data = file.readline().strip()
            if not data:
                raise ValueError("Файл порожній, введіть дані")
            values = data.split()
            if len(values) != 2 or not all(x.replace('.', '', 1).isdigit() for x in values):
                raise ValueError("Недопустимі значення введених параметрів")
            entry1.delete(0, tk.END)
            entry2.delete(0, tk.END)
            entry1.insert(0, values[0])
            entry2.insert(0, values[1])
            log_action("Обрано «Імпортувати вхідні дані»")
    except ValueError as e:
        messagebox.showerror("Помилка", str(e))
    except Exception as e:
        messagebox.showerror("Помилка", f"Помилка читання файлу: {e}")


# Функція обчислення виразу
def calculate():
    try:
        num1 = float(entry1.get())
        num2 = float(entry2.get())
        operation = operation_var.get()

        if operation == "Ділення" and num2 == 0:
            raise ZeroDivisionError("Ділення на 0 заборонено")

        operations = {
            "Додавання": lambda x, y: x + y,
            "Віднімання": lambda x, y: x - y,
            "Множення": lambda x, y: x * y,
            "Ділення": lambda x, y: x / y,
            "Степінь": lambda x, y: x ** y,
        }

        result = operations[operation](num1, num2)
        result_label.config(text=f"Результат: {result}")
        log_action(f"Обрано арифметичну операцію «{operation}»")
        log_action("Обрано «Обчислити вираз»")

    except ZeroDivisionError as e:
        messagebox.showerror("Помилка", str(e))
    except ValueError:
        messagebox.showerror("Помилка", "Недопустимі значення введених параметрів")
    except Exception as e:
        messagebox.showerror("Помилка", f"Помилка обчислення: {e}")


# Функція експорту результату
def export_result():
    try:
        num1 = entry1.get()
        num2 = entry2.get()
        operation = operation_var.get()
        result_text = result_label.cget("text")

        if not result_text.startswith("Результат:"):
            raise ValueError("Спочатку обчисліть вираз")

        with open(OUTPUT_FILE, "w") as file:
            file.write(f"{num1} {operation} {num2}, {result_text}\n")

        log_action("Обрано «Експортувати результат у файл»")
        messagebox.showinfo("Успіх", "Результат збережено у Output data.txt")

    except ValueError as e:
        messagebox.showerror("Помилка", str(e))
    except Exception as e:
        messagebox.showerror("Помилка", f"Помилка запису у файл: {e}")


# Функція виходу
def on_closing():
    log_action("Додаток закрито")
    root.destroy()


# Створення GUI
root = tk.Tk()
root.title("Арифметичний калькулятор")
root.geometry("350x300")

# Поля вводу
tk.Label(root, text="Перше число:").pack()
entry1 = tk.Entry(root)
entry1.pack()

tk.Label(root, text="Друге число:").pack()
entry2 = tk.Entry(root)
entry2.pack()

# Вибір операції
operation_var = tk.StringVar(value="Додавання")
operations = ["Додавання", "Віднімання", "Множення", "Ділення", "Степінь"]
for op in operations:
    tk.Radiobutton(root, text=op, variable=operation_var, value=op).pack()

# Кнопки
tk.Button(root, text="Імпортувати вхідні дані", command=import_data).pack()
tk.Button(root, text="Обчислити", command=calculate).pack()
tk.Button(root, text="Експортувати результат", command=export_result).pack()

# Відображення результату
result_label = tk.Label(root, text="Результат:")
result_label.pack()

# Закриття програми
root.protocol("WM_DELETE_WINDOW", on_closing)

root.mainloop()