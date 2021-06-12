using System;

namespace EventDemoBeforeAfter
{
    internal class StudentAgeChangedEventArgs : EventArgs
    {
        public int OldAge { get; set; }

        public int NewAge { get; set; }
    }
}
