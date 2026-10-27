namespace Lab4;

public class Person
{
    private string _name;
    private int _age;
    public string Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public virtual void Greet() => Console.WriteLine($"Я {Name}, мені {Age} років.");
    public string GetRole() => "Людина";
}

public class Student : Person
{
    public string StudentId { get; set; }
    public Student(string name, int age, string studentId) : base(name, age)
    {
        StudentId = studentId;
    }

    public override void Greet() => Console.WriteLine($"Я студент {Name}, номер {StudentId}.");
    public void Study() => Console.WriteLine($"{Name} виконує лабораторну.");
    public new string GetRole() => "Студент";
}

// Ланцюжок наслідування взято з варіанта в методичці.
public class Professor : Student
{
    public string Department { get; set; }
    public Professor(string name, int age, string studentId, string department)
        : base(name, age, studentId)
    {
        Department = department;
    }

    public override void Greet() => Console.WriteLine($"Я викладач {Name}, кафедра: {Department}.");
    public void Teach() => Console.WriteLine($"{Name} пояснює ООП.");
}
