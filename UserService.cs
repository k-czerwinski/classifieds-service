using ClassifiedsService;

namespace ClassifiedsService
{
  class Service
  {
    private List<User> _users = new List<User>();
    private List<Product> _products = new List<Product>();

    public void MainMenu()
    {
      char c = '0';
      while (c != '5')
      {
        Console.WriteLine("Please choose from menu: ");
        Console.WriteLine("[1] Add user account");
        Console.WriteLine("[2] Add product");
        Console.WriteLine("[3] Display products filtered by category");
        Console.WriteLine("[4] Display products filtred by user");
        Console.WriteLine("[5] Exit");
        Console.Write("Your choice: ");
        c = Console.ReadKey().KeyChar;
        Console.Clear();
        switch (c)
        {
          case '1':
            AddUser();
            break;
          case '2':
            AddProduct();
            break;
          case '3':
            DisplayProductsByCategory();
            break;
          case '4':
            DispalyProductsAddedByUser();
            break;
          case '5':
            Console.WriteLine("Thank you for using our services");
            break;
          default:
            Console.WriteLine("Please chooce correct oprion");
            break;
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
      }



    }
    private void AddUser()
    {
      string name, surname, login, password;
      Console.Write("Enter your name: ");
      name = Console.ReadLine();
      Console.Write("Enter your surname: ");
      surname = Console.ReadLine();
      Console.Write("Enter your login: ");
      login = Console.ReadLine();
      Console.Write("Enter your password: ");
      password = Console.ReadLine();
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(login))
      {
        Console.WriteLine("Values mustn't be empty. Please try again.");
      }
      else if (FindUser(login) == null)
      {
        _users.Add(new User(name, surname, login, password));
        Console.WriteLine("You singed up succesfully");
      }
      else
      {
        Console.WriteLine("That username is taken. Please try again and enter with diffrent username");
      }
    }
    private User UserLogIn()
    {
      Console.Write("Please enter your login: ");
      string login = Console.ReadLine();
      Console.Write("Please enter your password: ");
      string password = Console.ReadLine();
      User temp = FindUser(login);
      if (temp == null)
      {
        throw new MissingMemberException();
      }
      if (temp.PasswordCheck(password))
      {
        return temp;
      }
      else
      {
        throw new UnauthorizedAccessException();
      }


    }
    private User FindUser(string login)
    {
      return _users.FirstOrDefault(s => s.Login == login);
    }

    private void AddProduct()
    {
      User user;
      try
      {
        user = UserLogIn();
        Console.WriteLine("You logged in succesfully.");
        Console.Clear();
        Console.WriteLine("Avalibe categories: ");
        DisplayCategories();
        Console.Write("Your choice: ");
        try
        {
          int choice = Console.ReadKey().KeyChar - '0';
          if (choice < 1 || choice > NumberOfCategories())
          {
            throw new KeyNotFoundException();
          }
          Console.Clear();

          Categories category = (Categories)choice;
          string namespaceName = typeof(Program).Namespace;
          string className = category.ToString();
          Type type = Type.GetType($"{namespaceName}.{className}");
          Product newProduct = (Product)Activator.CreateInstance(type, user);
          _products.Add(newProduct);
          user.AssignToUser(newProduct);
        }
        catch (KeyNotFoundException)
        {
          Console.WriteLine("\nYou have to choose option from list above. Try again");
        }
        catch (Exception)
        {
          Console.WriteLine("Error while adding new product.");
        }
      }

      catch (MissingMemberException)
      {
        Console.WriteLine("We couldn't find your account");
      }
      catch (UnauthorizedAccessException)
      {
        Console.WriteLine("Please check your password and try again.");
      }


    }
    public static int GetInt(int minValue, int maxValue, string enterIntMessage, string minValueError, string convertionToIntError)
    {
      int num = -1;
      while (num == -1)
      {
        Console.Write(enterIntMessage);
        try
        {
          num = Convert.ToInt32(Console.ReadLine());
          if (num < minValue || num > maxValue)
          {
            Console.WriteLine(minValueError);
            num = -1;
          }
        }
        catch (Exception)
        {
          Console.WriteLine(convertionToIntError);
        }
      }
      return num;
    }
    private void DisplayProductsByCategory()
    {
      Console.WriteLine("Avalibe categories:");
      DisplayCategories();
      Console.Write("Your choice: ");
      try
      {
        int choice = Console.ReadKey().KeyChar - '0';
        if (choice < 1 || choice > NumberOfCategories())
        {
          throw new KeyNotFoundException();
        }
        Console.Clear();
        Categories category = (Categories)choice;
        Console.WriteLine("CATEGORY: " + category.ToString());
        var filtredByCategory = from x in _products
                                where x.Category == category
                                select x;
        foreach (var x in filtredByCategory)
        {
          x.DisplayProduct();
        }

      }
      catch (Exception)
      {
        Console.WriteLine("You have to choose option from list above. Try again");
      }

    }
    private void DisplayCategories()
    {
      var categories = Enum.GetValues(typeof(Categories));
      foreach (var x in categories)
      {
        Console.WriteLine("[" + (int)x + "] " + x);
      }
    }
    private void DispalyProductsAddedByUser()
    {
      Console.Write("To display products added by specified user, please enter his username: ");
      string userName = Console.ReadLine();
      User user = FindUser(userName);
      Console.Clear();
      if (user != null)
      {
        Console.WriteLine("Products added by \"{0}\":", userName);
        Console.WriteLine("-----------------------------------");
        user.DisplayUserProducts();
      }
      else
      {
        Console.WriteLine("We couldn't find: \"{0}\".", userName);
      }
    }
    public int NumberOfCategories()
    {
      return Enum.GetNames(typeof(Categories)).Length;
    }

  }

}