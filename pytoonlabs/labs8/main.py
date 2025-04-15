import tkinter as tk
from tkinter import messagebox
from collections import namedtuple


Athlete = namedtuple('Athlete', ['surname', 'birth_year', 'score', 'city'])


athletes = [
    Athlete('Іваненко', 2000, 85, 'Київ'),
    Athlete('Петренко', 1998, 92, 'Львів'),
    Athlete('Сидоренко', 2002, 78, 'Одеса'),
    Athlete('Коваленко', 1999, 88, 'Харків'),
    Athlete('Мельник', 2001, 90, 'Дніпро'),
    Athlete('Гончарук', 1997, 70, 'Житомир'),
    Athlete('Ткаченко', 2003, 95, 'Полтава'),
]

def good_athletes(athletes_list):
    avg = sum(a.score for a in athletes_list) / len(athletes_list)
    best = [a.surname for a in athletes_list if a.score > avg]
    if best:
        result = f"Середній бал: {avg:.2f}\nСпортсмени: {', '.join(best)} — найкращі!"
    else:
        result = "Немає спортсменів з вищим за середній бал."
    return result

def show_original():
    result = good_athletes(athletes)
    messagebox.showinfo("Результат", result)

def update_scores():
    try:
        new_scores = [int(entry.get()) for entry in score_entries]
        if len(new_scores) != len(athletes):
            raise ValueError("Недостатньо балів")
        updated = [a._replace(score=new) for a, new in zip(athletes, new_scores)]
        result = good_athletes(updated)
        messagebox.showinfo("Оновлені результати", result)
    except ValueError:
        messagebox.showerror("Помилка", "Будь ласка, введіть коректні цілі числа")

# === Інтерфейс ===
root = tk.Tk()
root.title("Спортивний рейтинг")
root.geometry("450x500")

tk.Label(root, text="Початкові спортсмени:", font=("Arial", 12, "bold")).pack(pady=5)
frame = tk.Frame(root)
frame.pack()

score_entries = []
for a in athletes:
    row = tk.Frame(frame)
    row.pack(fill="x", padx=5, pady=2)
    tk.Label(row, text=f"{a.surname} ({a.city})", width=20, anchor="w").pack(side="left")
    entry = tk.Entry(row)
    entry.insert(0, str(a.score))
    entry.pack(side="left")
    score_entries.append(entry)

tk.Button(root, text="Аналіз початкових результатів", command=show_original, bg="#d9ead3").pack(pady=10)
tk.Button(root, text="Оновити бали та повторити", command=update_scores, bg="#fce5cd").pack(pady=5)

root.mainloop()
