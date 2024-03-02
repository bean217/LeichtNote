using System;

namespace LeichtNote.Utils;

public class LNException : Exception
{
    public LNException() { }
    public LNException(string message) : base(message) { }
    public LNException(string message, Exception inner) : base(message, inner) { }
}

public class NullParentException : LNException
{
    public NullParentException() { }
    public NullParentException(string message) : base(message) { }
    public NullParentException(string message, Exception inner) : base(message, inner) { }
}