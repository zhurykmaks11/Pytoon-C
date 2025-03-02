
def input_array(name):
    n = int(input(f"Введіть елементів масиву {name}: "))
    arr = list(map(int, input(f"Введіть {n} елементів масиву{name}, розділених пробілом: ").split()))
    return arr
def swap_max_element(arr1, arr2  ):
    if not arr1 or not arr2:
        print("Один з масивів порожний Обмін неможливий")
        return arr1, arr2
    max1, index1 = max(arr1), arr1.index(max(arr1))
    max2, index2 = max(arr2), arr2.index(max(arr2))

    arr1[index1], arr2[index2] = arr2[index2], arr1[index1]
    return arr1, arr2
def print_array(name, arr):
    print(f"{name}: {''.join(map(str, arr))}")
if __name__ == '__main__':
    array1 =input_array("A")
    array2 =input_array("B")

    print("\nДо обміну: ")
    print_array("A", array1)
    print_array("B", array2)
    print("\nПісля обміну: ")
    array1, array2 = swap_max_element(array1, array2)
    print_array("A", array1)
    print_array("B", array2)
