using System.Data.Common;

namespace Template9.Common.Extensions.Tests;

public class DeepCloneTests
{
    private static Order GetOrder()
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            OrderDate = DateTime.Now,
            Customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                Age = 89

            },
            Products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Description = Guid.NewGuid().ToString(),
                    PartList = new List<Part>
                    {
                        new Part
                        {
                            Id = Guid.NewGuid(),
                            Description = Guid.NewGuid().ToString(),
                        },
                        new Part
                        {
                            Id = Guid.NewGuid(),
                            Description = Guid.NewGuid().ToString(),
                        },
                        new Part
                        {
                            Id = Guid.NewGuid(),
                            Description = Guid.NewGuid().ToString(),
                        },
                    }
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Description = Guid.NewGuid().ToString(),
                    PartList = new List<Part>
                    {
                        new Part
                        {
                            Id = Guid.NewGuid(),
                            Description = Guid.NewGuid().ToString(),
                        },
                        new Part
                        {
                            Id = Guid.NewGuid(),
                            Description = Guid.NewGuid().ToString(),
                        },
                    }
                },
            }
        };
    }

    [Fact]
    public void DeepCloneTest()
    {
        var order = GetOrder();

        var clone = order.DeepClone();

        clone.ShouldNotBeNull();
        clone.ShouldNotBe(order);
        clone.ShouldBeEquivalentTo(order);

        clone.Products.Count.ShouldNotBe(0);
        clone.Products.Count.ShouldBe(order.Products.Count);
        clone.Products[0].PartList.Count.ShouldNotBe(0);
        clone.Products[0].PartList.Count.ShouldBe(order.Products[0].PartList.Count);

        clone.Id.ShouldBe(order.Id);
        order.Id = Guid.NewGuid();
        clone.Id.ShouldNotBe(order.Id);
    }
}

public class Order
{
    public Guid Id { get; set; }

    public DateTime OrderDate { get; set; }

    public Customer Customer { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}

public class Customer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }
}

public class Product
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public List<Part> PartList { get; set; } = [];
}

public class Part
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;
}
