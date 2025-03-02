import random


NUM_WAGONS = 10
SEATS_PER_WAGON = 20

train = [[random.choice([0, 1]) for _ in range(SEATS_PER_WAGON)] for _ in range(NUM_WAGONS)]

print("Схема заповнення вагонів (0 - вільне, 1 - зайняте):")
for i, wagon in enumerate(train, start=1):
    print(f"Вагон {i}: {wagon}")

while True:
    try:
        wagon_number = int(input("\nВведіть номер вагона (1-10): "))
        if 1 <= wagon_number <= NUM_WAGONS:
            break
        else:
            print("Будь ласка, введіть число від 1 до 10.")
    except ValueError:
        print("Будь ласка, введіть коректне число.")

# Перевіряємо наявність вільних місць
selected_wagon = train[wagon_number - 1]
free_seats = selected_wagon.count(0)

# Виводимо результат
if free_seats > 0:
    print(f"У вагоні {wagon_number} є {free_seats} вільних місць.")
else:
    print(f"У вагоні {wagon_number} всі місця зайняті.")
