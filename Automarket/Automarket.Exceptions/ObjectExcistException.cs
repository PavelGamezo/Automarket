using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Exceptions
{
    public class ObjectExcistException : Exception
    {
        public ObjectExcistException(string objectName) : base($"{objectName} was found!")
        {

        }
    }
}
