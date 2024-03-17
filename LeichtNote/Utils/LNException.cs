using System;

namespace LeichtNote.Utils;

public class LNException : Exception
{
    public LNException() { }
    public LNException(string message) : base(message) { }
    public LNException(string message, Exception inner) : base(message, inner) { }
}