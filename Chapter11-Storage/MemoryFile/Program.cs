using System.Text;

const string example = "Эта строка была помещена и изьята из оперативной памяти";

var strBytes = Encoding.Unicode.GetBytes(example);
var strBytesCount = Encoding.Unicode.GetByteCount(example);

var ms = new MemoryStream(strBytesCount);

ms.Write(strBytes, 0, strBytesCount);

var readBuffer = new byte[strBytesCount];
ms.Seek(0, SeekOrigin.Begin);
ms.Read(readBuffer, 0, strBytesCount);

Console.WriteLine(Encoding.Unicode.GetString(readBuffer));
