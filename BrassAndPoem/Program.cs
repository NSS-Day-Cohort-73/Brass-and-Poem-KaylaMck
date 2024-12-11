
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

using System;
using System.Collections.Generic;
using System.Linq;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 299.99m,
        ProductTypeId = 1 
    },
    new Product()
    {
        Name = "Trombone",
        Price = 499.99m,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Flugelhorn",
        Price = 350.00m,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Shakespeare's Sonnets",
        Price = 15.99m,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Emily Dickinson: Selected Poems",
        Price = 12.50m,
        ProductTypeId = 2
    }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass Instrument" 
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poetry Book"
    }
};

//put your greeting here

string greeting = @"Welcome to Brass and Poems!
Your one-stop-shop for all of your
Brass Instrument and Poetry Books.";
Console.WriteLine(greeting);

//implement your loop here

string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        
        case "2":
            DeleteProduct(products, productTypes);
            break;

        case "3":
            AddProduct(products, productTypes);
            break;

        case "4":
            UpdateProduct(products, productTypes);
            break;

        case "5":
            Console.WriteLine("Goodbye");
            break;

        default:
            Console.WriteLine("invalid choice. Please select a valid option.");
            break;
    }
};

void DisplayMenu()
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a product");
    Console.WriteLine("4. Update a product");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    if (products == null || products.Count == 0)
    {
        Console.WriteLine("No products available.");
        return;
    }

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);

        string productTypeTitle = productType != null ? productType.Title : "unknown";

        Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price:F2} ({productTypeTitle})");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    if (products == null || products.Count == 0)
    {
        Console.WriteLine("No products available to delete.");
        return;
    }

    DisplayAllProducts(products, productTypes);

    Console.WriteLine("\nEnter the number of the products you want to delete:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int productNumber) && productNumber >= 1 && productNumber <=products.Count)
    {
        int index = productNumber - 1;
        Product productToDelete = products[index];
        products.RemoveAt(index);
        Console.WriteLine($"Product '{productToDelete.Name}' has been deleted.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nEnter the name of a new product:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the price of the new product (e.g. 12.00, 5.99, 124.50):");
    string priceInput = Console.ReadLine();

    if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
    {
        Console.WriteLine("Invalid price. Product not added");
        return;
    }

    Console.WriteLine("\nProduct Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }

    Console.WriteLine("Enter the number of the product type:");
    string typeInput = Console.ReadLine();

    if (int.TryParse(typeInput, out int typeNumber) && typeNumber >= 1 && typeNumber <= productTypes.Count)
    {
        int productTypeId = typeNumber;

        Product newProduct = new Product
        {
            Name = name,
            Price = price,
            ProductTypeId = productTypeId
        };

        products.Add(newProduct);
        Console.WriteLine($"Produce '{name}' has been added successfully.");
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    if (products == null || products.Count == 0)
    {
        Console.WriteLine("No products available to update.");
        return;
    }

    Console.WriteLine("\nAvailable Products:");
    for (int i = 0; i < products.Count; i++)
    {
        var productType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId)?.Title ?? "Unknown";
        Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C} ({productType})");
    }

    Console.WriteLine("\nEnter the number of the product you want to update:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int productNumber) && productNumber >= 1 && productNumber <= products.Count)
    {
        Product selectedProduct = products[productNumber - 1];

        Console.WriteLine($"Enter the updated name for '{selectedProduct.Name}' (or press Enter to keep it unchanged):");
        string updatedName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(updatedName))
        {
            selectedProduct.Name = updatedName;
        }

        Console.WriteLine($"Enter the updated price for '{selectedProduct.Name}' (or press Enter to keep it unchanged):");
        string updatedPriceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(updatedPriceInput) && decimal.TryParse(updatedPriceInput, out decimal updatedPrice) && updatedPrice >= 0)
        {
            selectedProduct.Price = updatedPrice;
        }

        Console.WriteLine("\nProduct Types:");
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }

        Console.WriteLine($"Enter the number of the updated product type for '{selectedProduct.Name}' (or press Enter to keep it unchanged):");
        string updatedTypeInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(updatedTypeInput) && int.TryParse(updatedTypeInput, out int updatedTypeNumber) && updatedTypeNumber >= 1 && updatedTypeNumber <= productTypes.Count)
        {
            selectedProduct.ProductTypeId = updatedTypeNumber;
        }

        Console.WriteLine($"Product '{selectedProduct.Name}' has been updated successfully.");
    }
}

// don't move or change this!
public partial class Program { }