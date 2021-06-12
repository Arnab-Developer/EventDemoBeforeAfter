using System;

namespace EventDemoBeforeAfter
{
    internal class StudentAgeChangingEventArgs : EventArgs
    {
        public int OldAge { get; set; }

        public int NewAge { get; set; }

        public bool IsCancel { get; set; }
    }
}
