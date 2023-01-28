using System.ComponentModel;

namespace Destructor
{
    internal class FakeDbConnection : IDisposable
    {
        public string? Name { get; set; }

        private int port = 80;

        private Component managedResource;
        private IntPtr unmanagedResource;

        private bool disposed = false;

        public FakeDbConnection(string name)
        {
            Name = name;

            managedResource = new Component();

            unsafe
            {
                fixed (int* portPtr = &this.port)
                {
                    unmanagedResource = (IntPtr)portPtr;
                }
            }

            Console.WriteLine($"Объект соединения {Name} создан");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    managedResource.Dispose();
                    Console.WriteLine("Диспозим управляемый объект");
                }

                unmanagedResource = IntPtr.Zero;
                Console.WriteLine("Диспозим не управляемый объект");

                disposed = true;
                Console.WriteLine($"DbConnection {Name} удачно задиспозино");
            }

            Console.WriteLine("Попытка освобождения уже освобожденного объекта");
        }
    }
}
