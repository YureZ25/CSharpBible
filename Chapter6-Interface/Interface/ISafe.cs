namespace Interface
{
    internal interface ISafe : IPurse
    {
        bool IsLocked { get; }

        void Lock();
        void Unlock();
    }
}
