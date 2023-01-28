const int maxDepth = 10;

int[] array = { 10, 98, 78, 4, 54, 25, 41, 30, 87, 60, 84, 6, 12 };

// Первичный вызов рекурсивной функции сортировки
Sort(0, array.Length - 1);

Console.WriteLine("Отсортированный массив:");
Console.WriteLine(string.Join(", ", array));

// Рекурсивная функция сортировки массива
// Принимает левый индекс массива с которого сортировать, правый индекс массива до которого сортировать и глубину рекурсии
// Ничего не возвращает
void Sort(int left, int right, int depth = 0)
{
    // Проверка на максимальную глубину рекурсии
    if (depth > maxDepth)
    {
        Console.WriteLine("Глубина рекурсии превысила максимальное значение! Прерываем сортировку!");
        return;
    }

    // Помещаем изначальные границы в переменные для последующего доступа к элементам массива по индексам
    int i = left;
    int j = right;
    // Определяем значение по середине массива (т.к. int - дробная часть будет отброшена)
    int middle = array[(left + right) / 2];

    do
    {
        // Идем по элементам массива с лево на право,
        // если элемент меньше middle - пропускаем, т.к. он стоит в правильном месте
        while (array[i] < middle) i++;
        while (array[j] > middle) j--;

        
        if (i <= j)
        {
            int tempL = array[i];
            int tempR = array[j];
            array[i] = tempR;
            array[j] = tempL;

            i++;
            j--;
        }
    }
    while (i < j);

    Console.WriteLine(string.Join(", ", array) + $" (текущая глубина рекурсии: {depth})");

    if (left < j)
        Sort(left, j, ++depth);

    if (left < right)
        Sort(i, right, ++depth);
}