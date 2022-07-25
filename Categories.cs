using System;

namespace OnlineShop
{

  //when you add new category you have to update switch statements inside Service class (in methods: AddProduct, DisplayProductsByCategory) and update enum Categories below:

  public enum Categories
  {
    Bike = 1, Car
  }
  class Bike : Product
  {
    private int _frameSize;
    private int _wheelSize;

    public Bike(int price, string title, User addedBy, int frameSize, int wheelSize) : base(price, title, addedBy)
    {
      _frameSize = frameSize;
      _wheelSize = wheelSize;
      Category = Categories.Bike;
    }


    public override void DisplayProduct()
    {
      DisplayProductDetails();
      Console.WriteLine("Wheel size: " + _wheelSize);
      Console.WriteLine("Frame size: " + _frameSize);
      Console.WriteLine("-----------------------------------");

    }
  }
  class Car : Product
  {
    private int _productionYear;
    private string _color;
    public Car(int price, string title, User addedBy, int productionYear, string color) : base(price, title, addedBy)
    {
      _color = color;
      _productionYear = productionYear;
      Category = Categories.Car;
    }
    public override void DisplayProduct()
    {
      DisplayProductDetails();
      Console.WriteLine("Color: " + _color);
      Console.WriteLine("Production year: " + _productionYear);
      Console.WriteLine("-----------------------------");

    }
  }
}