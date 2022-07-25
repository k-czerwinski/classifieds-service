using OnlineShop;
using System;

namespace OnlineShop
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

  }

}