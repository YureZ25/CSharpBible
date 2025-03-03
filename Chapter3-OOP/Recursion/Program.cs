﻿const int maxDepth = 10;

int callCount = 0;
int callMaxDepth = 0;

int[] array = { 10, 98, 78, 4, 54, 25, 41, 30, 87, 60, 84, 6, 12 };

// Первичный вызов рекурсивной функции сортировки
Sort(0, array.Length - 1);

Console.WriteLine("Отсортированный массив:");
Console.WriteLine(string.Join(", ", array));
Console.WriteLine($"Кол-во рекурсивных вызовов: {callCount}, максимальная глубина рекурсии: {callMaxDepth}");

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

    callCount++;
    callMaxDepth = Math.Max(depth, callMaxDepth);

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
        // Идем по элементам массива с право на лево
        // Если элемент больше middle - пропускаем, останавливаемся на индексе элемента
        // который меньше middle, чтобы переместить его в лево
        while (array[j] > middle) j--;

        // Если левый индекс меньше правого
        if (i <= j)
        {
            // Меняем левый и правый элемент местами
            int tempL = array[i];
            int tempR = array[j];
            array[i] = tempR;
            array[j] = tempL;

            // Сдвигаемся на 1 к середине с каждой стороны
            i++;
            j--;
        }
    }
    while (i < j);
    // Цикл работет пока левый индекс меньше правого

    // Выводим все элементы массива через запятую
    Console.WriteLine(string.Join(", ", array) + $" (текущая глубина рекурсии: {depth})");

    // Если левый индекс меньше индекса который мы сдвигали влево
    // Вызываем этот же метод со левым внутреним промежутком относительно текущего
    if (left < j)
        Sort(left, j, depth + 1);

    // Если правый индекс больше индекса который мы сдвигали вправо
    // Вызываем этот же метод со левым внутреним промежутком относительно текущего
    if (right > i)
        Sort(i, right, depth + 1);
}