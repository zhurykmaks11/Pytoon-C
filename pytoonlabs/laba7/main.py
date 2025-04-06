import tkinter as tk
from tkinter import messagebox
from datetime import datetime, timedelta


def calculate():
    try:
        start_time = entry_start.get()
        duration_sec = int(entry_duration.get())

        start_dt = datetime.strptime(start_time, "%H:%M")
        duration_min = duration_sec // 60

        end_dt = start_dt + timedelta(seconds=duration_sec)
        ad_breaks = duration_min // 5

        result = f"Час закінчення: {end_dt.strftime('%H:%M')}\n"
        result += f"Тривалість: {duration_min} хв\n"
        result += f"Кількість рекламних пауз: {ad_breaks}"

        lbl_result.config(text=result)
    except ValueError:
        messagebox.showerror("Помилка", "Введіть коректні дані!")


# Головне вікно
root = tk.Tk()
root.title("Розрахунок телепередачі")

# Введення часу початку
lbl_start = tk.Label(root, text="Час початку (HH:MM):")
lbl_start.pack()
entry_start = tk.Entry(root)
entry_start.pack()

# Введення тривалості
lbl_duration = tk.Label(root, text="Тривалість (секунди):")
lbl_duration.pack()
entry_duration = tk.Entry(root)
entry_duration.pack()

# Кнопка обчислення
btn_calculate = tk.Button(root, text="Розрахувати", command=calculate)
btn_calculate.pack()

# Відображення результату
lbl_result = tk.Label(root, text="")
lbl_result.pack()

# Запуск GUI
root.mainloop()
