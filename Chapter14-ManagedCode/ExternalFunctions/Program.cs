using System.Runtime.InteropServices;

// Создаем указатель на объект текстового вывода для передачи его
// в качестве параметра нативной функции (ручное выделение памяти)
var _textWriter = Console.Out;
var _handle = GCHandle.Alloc(_textWriter);
var _handlePtr = GCHandle.ToIntPtr(_handle);

// Создаем делегат для использования в качестве функции обратного вызова
// platform/Invoke не даст его очистить до окончания метода
Callback _callback = CaptureEnumWindowsProc;

WindowNativeMethods.EnumWindows(_callback, _handlePtr); // Вызов нативной функции

_handle.Free(); // Ручная очистка памяти

// Реализация делегата, параметр param передается из нативной функции
bool CaptureEnumWindowsProc(int windowHandle, IntPtr param)
{
    var gcHandle = GCHandle.FromIntPtr(param);

    if (gcHandle.Target is TextWriter textWriter)
    {
        textWriter.WriteLine(windowHandle);
    }

    return true;
}

delegate bool Callback(int windowHandle, IntPtr param);

static class WindowNativeMethods
{
    // Эта нативная функция перечисляет все окна

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern bool EnumWindows(Callback callback, IntPtr param);
}
