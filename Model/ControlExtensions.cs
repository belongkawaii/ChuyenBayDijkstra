using System;
using System.Reflection;
using System.Windows.Forms;

public static class ControlExtensions
{
    public static void EnableDoubleBuffer(this Control ctrl)
    {
        PropertyInfo prop = typeof(Control).GetProperty(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        prop?.SetValue(ctrl, true, null);
    }
}
