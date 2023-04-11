using System;
using EFEasyExample.DataModels;
using System.Linq;
namespace EFEasyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context myContext = new Context();
            var myClass = myContext
                .Classes
                .FirstOrDefault(c => c.MaxClassSize > 0);

            myClass.ClassName = "changed Name!";
            
            myContext.SaveChanges();
        }
    }
}