namespace CustomDelegates
{
    internal class NameChangedEventArgs : EventArgs
    {
        public enum NameChangingKind { FirstName, LastName }

        public NameChangedEventArgs(string newName, NameChangingKind changingKind)
        {
            ChangingKind = changingKind;
            NewName = newName;
            IsCanceled = false;
        }

        public bool IsCanceled { get; set; }
        public string NewName { get; set; }
        public NameChangingKind ChangingKind { get; set; }
    }
}
