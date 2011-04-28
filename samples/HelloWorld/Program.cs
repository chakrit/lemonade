
using System;
using System.Collections.Generic;
using Lemonade;

namespace HelloWorld
{
  public class Program
  {
    internal static void Main(string[] args) { new Program().Run(); }


    public void Run()
    {
      var builder = new ContextBuilder();
      using (var ctx = builder.NewContext()) {
        var counter = ctx.GetRoot<IList<string>>();

        while (true) {
          Console.WriteLine("Hit UP to increment, DOWN to decrement.");

          var key = Console.ReadKey().Key;
          int value;

          switch (key) {
          case ConsoleKey.UpArrow: value = counter.Increment(); break;
          case ConsoleKey.DownArrow: value = counter.Decrement(); break;
          default: value = counter.GetValue(); break;
          }

          Console.WriteLine("Counter = {0}", value);
        }
      }
    }
  }
}

