using ClassifiedsService;

using System;

namespace ClassifiedsService
{
  class Program
  {
    static int Main(String[] args)
    {
      Service OLX = new Service();
      OLX.MainMenu();
      return 0;
    }

  }


}