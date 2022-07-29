using ClassifiedsService;

namespace ClassifiedsService
{

  //when you add new category you have to update switch statements inside Service class (in methods: AddProduct, DisplayProductsByCategory) and update enum Categories below:
  //when number of categories will be greater than 9 you have to update 
  public enum Categories
  {
    Bike = 1, Car, Book
  }
  class Bike : Product
  {
    private int _frameSize;
    private int _wheelSize;
    public Bike(User addedBy) : base(addedBy)
    {
      _wheelSize = Service.GetInt(12, 36, "Enter wheel size: ", "Wheel size must be higher or eqal 12 and lower or equal 36. Try again", "Wheel size must be higher or eqal 12 and lower or equal 36. Try again");
      _frameSize = Service.GetInt(13, 25, "Enter frame size: ", "Frame size must be higher or eqal 13 and lower or equal 24. Try again", "Frame size must be higher or eqal 13 and lower or equal 24. Try again");
      Category = Categories.Bike;
      AddedMessage();
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
    public Car(User addedBy) : base(addedBy)
    {
      _productionYear = Service.GetInt(1817, DateTime.Now.Year, "Enter production year: ", "Production year be higher or eqal 1817 and lower or equal " + DateTime.Now.Year + ". Try again", "Production year must be positive integer higher or eqal 1817. Try again");
      Console.Write("Enter color: ");
      _color = Console.ReadLine();
      Category = Categories.Car;
      AddedMessage();
    }
    public override void DisplayProduct()
    {
      DisplayProductDetails();
      Console.WriteLine("Color: " + _color);
      Console.WriteLine("Production year: " + _productionYear);
      Console.WriteLine("-----------------------------");

    }
  }
  class Book : Product
  {
    public enum Genres
    {
      Novel = 1, Poem, Fable
    }
    private Genres _genre;
    private int _numOfPages;
    public Book(User addedBy) : base(addedBy)
    {
      int numOfPages = Service.GetInt(1, Int32.MaxValue, "Enter number of pages: ", "Number of pages must be positive integer. Try again", "Number of pages must be positive integer. Try again");
      Genres genre = ChooseBookGenre();
      _numOfPages = numOfPages;
      _genre = genre;
      Category = Categories.Book;
      AddedMessage();
    }
    public override void DisplayProduct()
    {
      DisplayProductDetails();
      Console.WriteLine("Genre: " + _genre);
      Console.WriteLine("Number of pages: " + _numOfPages);
      Console.WriteLine("-----------------------------");

    }
    private Genres ChooseBookGenre()
    {
      int numOfGenres = Enum.GetNames(typeof(Genres)).Length;
      foreach (var x in Enum.GetValues(typeof(Genres)))
      {
        Console.WriteLine("[{0}] {1}", (int)x, x);
      }
      int choice = 0;
      bool isChoiceCorrect = false;
      while (isChoiceCorrect == false)
      {
        try
        {
          Console.Write("Your choice: ");
          choice = Convert.ToInt32(Console.ReadLine());
          if (choice < 1 || choice > numOfGenres)
          {
            throw new KeyNotFoundException();
          }
          isChoiceCorrect = true;
        }
        catch (Exception)
        {
          Console.WriteLine("Choose number from 1 to {1} according to list above", 1, Enum.GetNames(typeof(Genres)).Length);
          isChoiceCorrect = false;
        }
      }
      return (Genres)choice;
    }

  }
  //SUBCATEGORIES CAR
  /*
  class Ford : Car
  {

    public Ford()
    {

    }
  }
  */
}
