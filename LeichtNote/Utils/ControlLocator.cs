using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace LeichtNote.Utils;

public static class ControlLocator
{
    /// <summary>Locates the parent containing control class of a specified type.</summary>
    /// <param name="control"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>object reference to specified control type.</returns>
    /// <exception cref="NullParentWindowException">Thrown if the parent cannot be found.</exception>
    public static T? LocateParentControl<T>(Control control)
    {
        var parent = control.Parent;
        while (parent != null)
        {
            if (parent is T parentControl)
            {
                return parentControl;
            }
            parent = parent.Parent;
        }
        throw new NullParentException();
    }
}