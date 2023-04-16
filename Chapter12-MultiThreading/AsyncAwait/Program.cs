
var asyncTask = AccessTheWebAsync();

Console.WriteLine($"Состояние задачи: {asyncTask.Status}");

// Простое синхронное ожидание
//Task.Delay(3000).Wait();

Console.WriteLine($"Состояние задачи: {asyncTask.Status}");

string content;

// Сихронное (блокирующее) ожидание
//content = asyncTask.Result;

// Тоже синхронное ожидание
// Разница в том, что при возникновении ошибки в случае Task.Result она будет вложенной (Inner)
// А при использовании данной конструкции мы получим ее на прямую
//content = asyncTask.GetAwaiter().GetResult();

// Способ избежать дэдлоков при синхронном выполнении
// По поведению одинаков с ContinueWith((t) => content = t.Result)
// Не лучший вариант, лучше использовать await
// Подробнее об этом https://habr.com/ru/articles/482354/
// Основное предназначение - не менять контекст (поток) после выхода из async функции
//content = asyncTask.ConfigureAwait(false).GetAwaiter().GetResult();

Console.WriteLine($"Номер потока до await: {Thread.CurrentThread.ManagedThreadId}"); // Допустим 1

// Нормальное использование задачи с await
// При этом захватывается контекст (поток) async функции
// И следующий код выполняется в новом потоке
content = await asyncTask;

// Если await - 7, если ConfigureAwait(false) - 1
Console.WriteLine($"Номер потока после await: {Thread.CurrentThread.ManagedThreadId}");

Console.WriteLine($"Состояние задачи: {asyncTask.Status}");
Console.WriteLine($"Данные с сайта: \n{content}");


// Лучше использовать async Task, а не возвращать Task, т.к. при возниконении ошибки в методе,
// который возвращает Task мы не узнаем о месте её возникновения в call stack (узнаем только место где эта задача awaited),
// а выигрыш в производительности благодаря отсутвию стейт машины минимален
// Видео об этом https://youtu.be/Q2zDatDVnO0
// И еще больше инфы в статье https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md
// Актуально только при асинхронном выолнении
async Task<string> AccessTheWebAsync()
{
    var httpClient = new HttpClient();

    Console.WriteLine($"Номер потока в функции до await: {Thread.CurrentThread.ManagedThreadId}"); // Допустим 1

    var content = await httpClient.GetStringAsync("http://www.flenov.info/robots.txt");

    Console.WriteLine($"Номер потока в функции после await: {Thread.CurrentThread.ManagedThreadId}"); // Добустим 7

    return content;
}
