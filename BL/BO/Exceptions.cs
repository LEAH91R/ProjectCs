using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
        [Serializable]
        public class IdAlreadyExistsException : Exception
        {
            public IdAlreadyExistsException(string message) : base($"This Id Already Exists: {message}!") { }
        }

        [Serializable]
        public class IdNotFoundException : Exception
        {
            public IdNotFoundException(string message) : base($"This Id Not Found: {message}!") { }
        }

        [Serializable]
        public class NullItemException : Exception
        {
            public NullItemException(string message) : base($"This Null Item {message}!") { }
        }
 }




