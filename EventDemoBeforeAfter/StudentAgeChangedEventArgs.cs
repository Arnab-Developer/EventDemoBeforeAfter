using System;

namespace EventDemo
{
    internal class StudentAgeChangedEventArgs : EventArgs
    {
        public int OldAge { get; set; }

        public int NewAge { get; set; }
    }
}
