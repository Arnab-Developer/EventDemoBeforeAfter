using EventDemo;
using System;

Student s1 = new() { Name = "jon", Age = 10 };
Console.WriteLine($"s1: Name {s1.Name} Age {s1.Age}");
s1.StudentAgeChanging += e => Console.WriteLine($"Age changing. Old age: {e.OldAge}, New age: {e.NewAge}");
s1.StudentAgeChanged += e => Console.WriteLine($"Age changed. Old age: {e.OldAge}, New age: {e.NewAge}");
s1.Age++;
Console.WriteLine($"s1: Name {s1.Name} Age {s1.Age}");

Console.WriteLine();

Console.Write("Do you want to cancel(Y/N): ");
char input = Console.ReadKey().KeyChar;
bool isCancel = input == 'Y' || input == 'y';

Console.WriteLine();
Console.WriteLine();

Student s2 = new() { Name = "bob", Age = 20 };
Console.WriteLine($"s2: Name {s2.Name} Age {s2.Age}");
s2.StudentAgeChanging += e =>
{
    Console.WriteLine($"Age changing. Old age: {e.OldAge}, New age: {e.NewAge}");
    e.IsCancel = isCancel;
};
s2.StudentAgeChanged += e => Console.WriteLine($"Age changed. Old age: {e.OldAge}, New age: {e.NewAge}");
s2.Age = 45;
Console.WriteLine($"s2: Name {s2.Name} Age {s2.Age}");

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