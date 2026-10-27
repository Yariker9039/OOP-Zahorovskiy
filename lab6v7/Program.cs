using System.Text;
using Lab4;
Console.OutputEncoding = Encoding.UTF8;
var person = new Person("Олег", 30);
var student = new Student("Ярослав", 18, "7");
var professor = new Professor("Андрій", 40, "P01", "Програмування");
Person[] people = { person, student, professor };
Console.WriteLine("Виклики Greet через тип Person:");
foreach (Person item in people)
    item.Greet();
student.Study();
professor.Teach();

Person reference = student;
Console.WriteLine("\nОдин об'єкт, два типи посилання:");
student.Greet();
reference.Greet();
Console.WriteLine($"Student.GetRole(): {student.GetRole()}");
Console.WriteLine($"Person.GetRole(): {reference.GetRole()}");
