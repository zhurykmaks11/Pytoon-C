import random


def is_hit(x, y, R):
    """Перевіряє, чи потрапляє точка (x, y) у заштриховану область."""
    # Умова: мішень - це нижня права чверть кола (x > 0, y < 0) і верхня ліва (x < 0, y > 0)
    return (x > 0 and y < 0 and x ** 2 + y ** 2 <= R ** 2) or (x < 0 and y > 0 and x ** 2 + y ** 2 <= R ** 2)


def generate_shots(num_shots, R):
    """Генерує випадкові координати для пострілів у діапазоні від -R до R."""
    shots = []
    for _ in range(num_shots):
        x = random.uniform(-R, R)  # Випадкове число в межах від -R до R
        y = random.uniform(-R, R)
        shots.append((round(x, 2), round(y, 2)))  # Округлюємо для красивого виводу
    return shots


def print_results(shots, R):
    """Виводить таблицю результатів пострілів."""
    print(f"{'№ пострілу':<10}{'Координати пострілу':<20}{'Результат'}")
    print("-" * 50)

    for i, (x, y) in enumerate(shots, start=1):
        result = "потрапив в мішень" if is_hit(x, y, R) else "мішень не ушкоджена"
        print(f"{i:<10}({x}, {y}){' ' * (17 - len(str((x, y))))}{result}")


def main():
    R = float(input("Введіть радіус мішені: "))  # Користувач задає радіус мішені
    num_shots = 10  # Кількість пострілів
    shots = generate_shots(num_shots, R)  # Генеруємо постріли
    print_results(shots, R)  # Виводимо результати


if __name__ == "__main__":
    main()
