﻿using System;
using System.Windows.Forms;

namespace HelloWorld
{
  public class Program
  {
    [STAThread]
    internal static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      new Program().Run();
    }


    public void Run()
    {
      Application.Run(new MainForm());
    }
  }
}
