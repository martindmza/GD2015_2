using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExceptions
{
    public class UserRolNotFoundException : Exception
    {
        public String message;

        public UserRolNotFoundException(String message) {
            this.message = message;
            Console.WriteLine(message);
        }

    }
}
