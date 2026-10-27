using System.Text;
using Lab7;
Console.OutputEncoding = Encoding.UTF8;
IRepository<Department> repository = new InMemoryRepository<Department>();
repository.Add(new Department { Id = 1, Name = "Розробка", Location = "Рівне" });
repository.Add(new Department { Id = 2, Name = "Тестування", Location = "Київ" });
Console.WriteLine("Після додавання:");
foreach (Department department in repository.GetAll())
    Console.WriteLine($"{department.Id}: {department.Name}, {department.Location}");
repository.Update(new Department { Id = 1, Name = "Розробка", Location = "Львів" });
Console.WriteLine($"Після оновлення Id 1: {repository.GetById(1).Location}");
repository.Delete(2);
Console.WriteLine($"Після видалення Id 2 залишилось: {repository.GetAll().Count()}");
try
{
    repository.GetById(99);
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
