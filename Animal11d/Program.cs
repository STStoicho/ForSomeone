using Animal11d.Controllers;
using Animal11d.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal11d
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 for console, 2 for form");
            int start = int.Parse(Console.ReadLine());
            if (start == 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AnimalShelter());
            }
            else if (start == 1)
            {
                Display d = new Display();
            }
        }
    }
}
