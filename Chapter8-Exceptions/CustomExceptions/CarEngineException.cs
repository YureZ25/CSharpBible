namespace CustomExceptions
{
    internal class CarEngineException : ApplicationException
    {
        public CarEngine CarEngine { get; private set; }

        public CarEngineException(CarEngine carEngine, string message) : base(message)
        {
            CarEngine = carEngine;
        }
    }
}
