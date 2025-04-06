import tkinter as tk
from tkinter import messagebox


# Базовий клас
class Employee:
    def __init__(self, name="", age=0, salary=0.0):
        self.name = name
        self.age = age
        self.salary = salary

    def show(self):
        return f"Ім'я: {self.name}, Вік: {self.age}, Зарплата: {self.salary} грн"

    def __del__(self):
        print("Лабораторна робота виконана студентом 2 курсу ПІБ студента")


# Похідні класи
class Worker(Employee):
    def __init__(self, name="", age=0, salary=0.0, shift="Денна"):
        super().__init__(name, age, salary)
        self.shift = shift

    def show(self):
        return super().show() + f", Зміна: {self.shift}"


class Engineer(Employee):
    def __init__(self, name="", age=0, salary=0.0, specialty="Механіка"):
        super().__init__(name, age, salary)
        self.specialty = specialty

    def show(self):
        return super().show() + f", Спеціальність: {self.specialty}"


class Administration(Employee):
    def __init__(self, name="", age=0, salary=0.0, position="Менеджер"):
        super().__init__(name, age, salary)
        self.position = position

    def show(self):
        return super().show() + f", Посада: {self.position}"


# GUI додаток
class EmployeeApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Облік працівників")

        tk.Label(root, text="Ім'я:").grid(row=0, column=0)
        tk.Label(root, text="Вік:").grid(row=1, column=0)
        tk.Label(root, text="Зарплата:").grid(row=2, column=0)
        tk.Label(root, text="Тип працівника:").grid(row=3, column=0)

        self.name_entry = tk.Entry(root)
        self.age_entry = tk.Entry(root)
        self.salary_entry = tk.Entry(root)
        self.type_var = tk.StringVar(value="Worker")

        self.name_entry.grid(row=0, column=1)
        self.age_entry.grid(row=1, column=1)
        self.salary_entry.grid(row=2, column=1)

        self.type_menu = tk.OptionMenu(root, self.type_var, "Worker", "Engineer", "Administration")
        self.type_menu.grid(row=3, column=1)

        tk.Button(root, text="Додати працівника", command=self.add_employee).grid(row=4, column=0, columnspan=2)

    def add_employee(self):
        name = self.name_entry.get()
        age = int(self.age_entry.get())
        salary = float(self.salary_entry.get())
        emp_type = self.type_var.get()

        if emp_type == "Worker":
            emp = Worker(name, age, salary)
        elif emp_type == "Engineer":
            emp = Engineer(name, age, salary)
        else:
            emp = Administration(name, age, salary)

        messagebox.showinfo("Працівник", emp.show())


if __name__ == "__main__":
    root = tk.Tk()
    app = EmployeeApp(root)
    root.mainloop()
