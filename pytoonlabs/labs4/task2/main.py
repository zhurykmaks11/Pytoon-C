# а) Створення текстового файлу TF_1 із символьних рядків різної довжини
lines = ["Hello", "Python programming", "This is a test", "Short", "Longer line example here", "OK"]
with open("TF_1.txt", "w") as file_1:
    for line in lines:
        file_1.write(line + "\n")

# б) Читання вмісту файлу TF_1 і запис його у файл TF_2 по рядках за умовою
with open("TF_1.txt", "r") as file_1, open("TF_2.txt", "w") as file_2:
    for line in file_1:
        line = line.strip()
        if len(line) < 20:
            line = line + "&" * (20 - len(line))
        elif len(line) > 20:
            line = line[:20]
        file_2.write(line + "\n")

# в) Читання вмісту файлу TF_2 і виведення його вмісту по рядках
with open("TF_2.txt", "r") as file_2:
    for line in file_2:
        print(line.strip())
