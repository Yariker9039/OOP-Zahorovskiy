using Lab7;
using Xunit;

namespace Lab7.Tests;

public class RepositoryTests
{
    private static Department CreateDepartment(int id = 1) => new()
    {
        Id = id, Name = "Розробка", Location = "Рівне"
    };

    [Fact]
    public void Add_StoresDepartment()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment());
        Department result = Assert.Single(repository.GetAll());
        Assert.Equal(1, result.Id);
        Assert.Equal("Розробка", result.Name);
        Assert.Equal("Рівне", result.Location);
    }

    [Fact]
    public void Add_DuplicateId_Throws()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment());
        Assert.Throws<ArgumentException>(() => repository.Add(CreateDepartment()));
        Assert.Single(repository.GetAll());
    }

    [Fact]
    public void GetById_ReturnsRequestedDepartment()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment(1));
        repository.Add(new Department { Id = 2, Name = "Тестування", Location = "Київ" });
        Assert.Equal("Тестування", repository.GetById(2).Name);
        Assert.Equal("Київ", repository.GetById(2).Location);
    }

    [Fact]
    public void GetById_MissingId_Throws()
    {
        var repository = new InMemoryRepository<Department>();
        Assert.Throws<KeyNotFoundException>(() => repository.GetById(99));
    }

    [Fact]
    public void GetAll_ReturnsAllDepartments()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment(1));
        repository.Add(CreateDepartment(2));
        Assert.Equal(new[] { 1, 2 }, repository.GetAll().Select(item => item.Id).ToArray());
    }

    [Fact]
    public void GetAll_EmptyRepository_ReturnsEmptyCollection()
    {
        var repository = new InMemoryRepository<Department>();
        Assert.Empty(repository.GetAll());
    }

    [Fact]
    public void Update_ReplacesOnlyRequestedDepartment()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment(1));
        repository.Add(CreateDepartment(2));
        repository.Update(new Department { Id = 1, Name = "Підтримка", Location = "Львів" });
        Assert.Equal("Підтримка", repository.GetById(1).Name);
        Assert.Equal("Львів", repository.GetById(1).Location);
        Assert.Equal("Розробка", repository.GetById(2).Name);
        Assert.Equal(2, repository.GetAll().Count());
    }

    [Fact]
    public void Update_MissingId_ThrowsAndDoesNotAddItem()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment(1));
        Assert.Throws<KeyNotFoundException>(() => repository.Update(CreateDepartment(99)));
        Assert.Single(repository.GetAll());
        Assert.Equal(1, repository.GetAll().Single().Id);
    }

    [Fact]
    public void Delete_RemovesOnlyRequestedDepartment()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment(1));
        repository.Add(CreateDepartment(2));
        repository.Delete(1);
        Assert.Equal(2, Assert.Single(repository.GetAll()).Id);
        Assert.Throws<KeyNotFoundException>(() => repository.GetById(1));
    }

    [Fact]
    public void Delete_MissingId_ThrowsAndKeepsItems()
    {
        var repository = new InMemoryRepository<Department>();
        repository.Add(CreateDepartment());
        Assert.Throws<KeyNotFoundException>(() => repository.Delete(99));
        Assert.Equal(1, Assert.Single(repository.GetAll()).Id);
    }

    [Fact]
    public void Add_Null_Throws()
    {
        var repository = new InMemoryRepository<Department>();
        Assert.Throws<ArgumentNullException>(() => repository.Add(null!));
    }

    [Fact]
    public void Update_Null_Throws()
    {
        var repository = new InMemoryRepository<Department>();
        Assert.Throws<ArgumentNullException>(() => repository.Update(null!));
    }
}
