
﻿using System;

namespace DO;

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
<<<<<<< HEAD
    public NullItemException(string message) : base($"This  Null Item {message}!") { }
=======
    public NullItemException(string message) : base($"This Null Item {message}!") { }
>>>>>>> d46e9f8b71c4a2a8f0d2c4a4f8c4cea0a668c973
}


