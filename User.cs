using System;
using ClassifiedsService;
using System.Collections.Generic;

namespace ClassifiedsService
{
  class User
  {
    private static int _ID = 0;
    public readonly int UserID;
    private string _name;
    private string _surname;
    private string _login;
    public string Login
    {
      get { return _login; }
    }
    private string _password;

    private List<Product> _addedByUser = new List<Product>();


    public User(string name, string surname, string login, string password)
    {
      _name = name;
      _surname = surname;
      _login = login;
      _password = password;
      UserID = _ID;
      _ID++;
    }
    public bool PasswordCheck(string password)
    {
      if (_password == password)
        return true;
      else
        return false;
    }
    public void DisplayUser()
    {
      Console.WriteLine(_name + " " + _surname);
    }
    public void AssignToUser(Product product)
    {
      _addedByUser.Add(product);
    }
    public void DisplayUserProducts()
    {
      foreach (var x in _addedByUser)
      {
        Console.WriteLine("Category: " + x.Category);
        x.DisplayProduct();
      }
    }




  }
}