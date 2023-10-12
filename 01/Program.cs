// See https://aka.ms/new-console-template for more information

using Lab_01;

// I'm too lazy to add more of these
Student alice = new Student("Smith", "Alice", "6040404000000");
Console.WriteLine(alice);
Course asp = new Course("Web development using ASP.NET", "2 hours");
alice.Courses = alice.Courses.Append(asp).ToList();
Console.WriteLine(alice);

// TODO: CRUD menu