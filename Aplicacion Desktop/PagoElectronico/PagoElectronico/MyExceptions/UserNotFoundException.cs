using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExceptions
{
    class UserNotFoundException : Exception
    {

        public UserNotFoundException(String message) {
            Console.WriteLine("User not Found");
        }
    }
}
