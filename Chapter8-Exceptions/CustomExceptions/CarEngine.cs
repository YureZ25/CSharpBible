using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    internal class CarEngine
    {
        public bool IsWorking { get; private set; }
        public string Name { get; set; }

        public CarEngine(string name)
        {
            Name = name;
            IsWorking = false;
        }

        public void Start()
        {
            if (IsWorking) throw new CarEngineException(this, "Двигатель уже запущен");
            IsWorking = true;
        }

        public void Stop()
        {
            IsWorking = false;
        }
    }
}
