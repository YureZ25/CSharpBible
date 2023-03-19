
GetFiles("C:\\Users\\YureZ");

void GetFiles(string path)
{
	Console.WriteLine($"Папки и файлы по пути '{path}':");

	// Берем полные пути ко всем директориям по указанному пути 
	foreach (string dir in Directory.GetDirectories(path))
	{
		// Пропускаем скрытые файлы с помощью побитового И
		if ((File.GetAttributes(dir) & FileAttributes.Hidden) == FileAttributes.Hidden) continue;

		// Берем только название, отбрасывая путь
        string dirName = Path.GetFileName(dir);
		Console.WriteLine(dirName?.ToUpperInvariant());
	}

	// То же самое, только для файлов
	foreach (string file in Directory.GetFiles(path))
	{
        string fileName = Path.GetFileName(file);
		Console.WriteLine(fileName?.ToLowerInvariant());
	}
}
