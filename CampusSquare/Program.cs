using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            ICampusSquareClient cam = new CampusSuquareClient("c01144495d", "6qa4Jg%Kq");
            Console.WriteLine(cam.GetGradePage());
            Console.ReadLine();
        }
    }
}
