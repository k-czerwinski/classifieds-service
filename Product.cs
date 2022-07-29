using ClassifiedsService;
using System;

namespace ClassifiedsService
{
  abstract class Product
  {
    protected int Price;
    protected string Title;

    protected readonly DateTime DateAdded;
    protected User AddedBy;

    public Categories Category;

    protected Product(int price, string title, User addedBy)
    {
      Price = price;
      Title = title;
      DateAdded = System.DateTime.Now;
      AddedBy = addedBy;

    }
    protected Product(User addedBy)
    {
      Console.WriteLine("Please fill out the form");
      Console.Write("Enter title: ");
      string title = Console.ReadLine();
      int price = Service.GetInt(0, Int32.MaxValue, "Enter price: ", "Price must be positive number. Try again", "Price must be positive integer. Try again");
      Price = price;
      Title = title;
      DateAdded = System.DateTime.Now;
      AddedBy = addedBy;
    }

    public void DisplayProductDetails()
    {
      Console.WriteLine("\"{0}\"", Title);
      Console.WriteLine("Price: " + Price);
      Console.WriteLine("Added: " + DateAdded);
      Console.Write("Added by: ");
      AddedBy.DisplayUser();

    }
    public virtual void DisplayProduct()
    {

    }
    public void AddedMessage()
    {
      Console.WriteLine("Your product was succesfully added to {0} category", Category);
    }

  }

}