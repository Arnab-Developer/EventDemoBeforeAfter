using EventDemoBeforeAfter;
using static System.Console;

Student s1 = new() { Name = "jon", Age = 10 };
WriteLine($"s1: Name {s1.Name} Age {s1.Age}");
s1.StudentAgeChanging += e => WriteLine($"Age changing. Old age: {e.OldAge}, New age: {e.NewAge}");
s1.StudentAgeChanged += e => WriteLine($"Age changed. Old age: {e.OldAge}, New age: {e.NewAge}");
s1.Age++;
WriteLine($"s1: Name {s1.Name} Age {s1.Age}");

WriteLine();

Write("Do you want to cancel(Y/N): ");
char input = ReadKey().KeyChar;
bool isCancel = input == 'Y' || input == 'y';

WriteLine();
WriteLine();

Student s2 = new() { Name = "bob", Age = 20 };
WriteLine($"s2: Name {s2.Name} Age {s2.Age}");
s2.StudentAgeChanging += e =>
{
    WriteLine($"Age changing. Old age: {e.OldAge}, New age: {e.NewAge}");
    e.IsCancel = isCancel;
};
s2.StudentAgeChanged += e => WriteLine($"Age changed. Old age: {e.OldAge}, New age: {e.NewAge}");
s2.Age = 45;
WriteLine($"s2: Name {s2.Name} Age {s2.Age}");

/*
Output:

---- If not canceled:

s1: Name jon Age 10
Age changing. Old age: 10, New age: 11
Age changed. Old age: 10, New age: 11
s1: Name jon Age 11

Do you want to cancel(Y/N): n

s2: Name bob Age 20
Age changing. Old age: 20, New age: 45
Age changed. Old age: 20, New age: 45
s2: Name bob Age 45

---- If canceled:

s1: Name jon Age 10
Age changing. Old age: 10, New age: 11
Age changed. Old age: 10, New age: 11
s1: Name jon Age 11

Do you want to cancel(Y/N): y

s2: Name bob Age 20
Age changing. Old age: 20, New age: 45
s2: Name bob Age 20
*/