import re
import tkinter as tk
from tkinter import messagebox

def check(text):
    pattern = r'\b(0[0-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9])\b'
    matches = re.findall(pattern, text)
    if(matches):
        return True
    else:
        return False



def find_times(text):
    pattern = r'\b(0[0-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9])\b'
    matches = re.findall(pattern, text)
    return [":".join(match) for match in matches]


def replace_time():
    text = text_input.get("1.0", tk.END)
    old_time = old_time_entry.get()
    if(check(old_time)):
        # Перевірка на наявність часу у списку
        times = find_times(text)
        if old_time in times:
            new_time = new_time_entry.get()
            if(check(new_time)):

                updated_text = text.replace(old_time, new_time)
                text_input.delete("1.0", tk.END)
                text_input.insert(tk.END, updated_text)
                messagebox.showinfo("Успіх", f"Час {old_time} замінено на {new_time}")
            else:
                messagebox.showerror("Помилка", f"Час {new_time} не знайден!")

        else:
            messagebox.showerror("Помилка", f"Час {old_time} не знайде!")
    else:
        messagebox.showerror("Помилка", f"Час {old_time} не знайдено!")



# Функція для пошуку часу
def search_time():
    text = text_input.get("1.0", tk.END)
    times = find_times(text)
    result_label.config(text=f"Знайдені часові мітки: {times}")
    count_label.config(text=f"Кількість знайдених: {  len(times)}")


# Налаштування вікна
root = tk.Tk()
root.title("Часовий пошук і заміна")
root.geometry("500x400")

# Ввід тексту
text_input_label = tk.Label(root, text="Введіть текст:")
text_input_label.pack()

text_input = tk.Text(root, height=8, width=50)
text_input.pack()

# Кнопки пошуку і заміни
search_button = tk.Button(root, text="Шукати час", command=search_time)
search_button.pack(pady=5)

# Результати
result_label = tk.Label(root, text="Знайдені часові мітки:")
result_label.pack()

count_label = tk.Label(root, text="Кількість знайдених:")
count_label.pack()

# Заміна часу
old_time_label = tk.Label(root, text="Час для заміни (гг:хх:сс):")
old_time_label.pack()

old_time_entry = tk.Entry(root)
old_time_entry.pack()

new_time_label = tk.Label(root, text="Новий час (гг:хх:сс):")
new_time_label.pack()

new_time_entry = tk.Entry(root)
new_time_entry.pack()

replace_button = tk.Button(root, text="Замінити час", command=replace_time)
replace_button.pack(pady=10)

# Запуск вікна
root.mainloop()
