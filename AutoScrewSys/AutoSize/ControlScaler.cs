using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ControlScaler
{
    private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();

    public void Init(Control root)
    {
        originalControlBounds.Clear();
        SaveOriginalBounds(root);
    }

    private void SaveOriginalBounds(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            originalControlBounds[ctrl] = ctrl.Bounds;
            if (ctrl.HasChildren)
                SaveOriginalBounds(ctrl);
        }
    }

    public void Scale(Control root, float scaleX, float scaleY)
    {
        foreach (var kvp in originalControlBounds)
        {
            Control ctrl = kvp.Key;
            Rectangle original = kvp.Value;
            ctrl.Bounds = new Rectangle(
                (int)(original.X * scaleX),
                (int)(original.Y * scaleY),
                (int)(original.Width * scaleX),
                (int)(original.Height * scaleY));
        }
    }
}



