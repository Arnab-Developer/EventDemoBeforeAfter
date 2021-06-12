namespace EventDemo
{
    internal class Student
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (FireStudentAgeChangingEvent(_age, value))
                {
                    return;
                }

                int oldAge = _age;
                _age = value;

                FireStudentAgeChangedEvent(oldAge, _age);
            }
        }

        public Student()
        {
            Name = string.Empty;
        }

        public delegate void StudentAgeChangingDelegate(StudentAgeChangingEventArgs e);
        public delegate void StudentAgeChangedDelegate(StudentAgeChangedEventArgs e);

        public event StudentAgeChangingDelegate? StudentAgeChanging;
        public event StudentAgeChangedDelegate? StudentAgeChanged;

        private bool FireStudentAgeChangingEvent(int oldAge, int newAge)
        {
            if (StudentAgeChanging != null &&
                StudentAgeChanging.GetInvocationList().Length > 0)
            {
                StudentAgeChangingEventArgs e = new()
                {
                    OldAge = oldAge,
                    NewAge = newAge
                };
                StudentAgeChanging(e);
                return e.IsCancel;
            }
            return false;
        }

        private void FireStudentAgeChangedEvent(int oldAge, int newAge)
        {
            if (StudentAgeChanged != null &&
                StudentAgeChanged.GetInvocationList().Length > 0)
            {
                StudentAgeChangedEventArgs e = new()
                {
                    OldAge = oldAge,
                    NewAge = newAge
                };
                StudentAgeChanged(e);
            }
        }
    }
}
