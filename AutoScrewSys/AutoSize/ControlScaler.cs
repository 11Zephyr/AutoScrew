using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ControlScaler
{
    private Dictionary<Control, ControlRect> _originals = new Dictionary<Control, ControlRect>();
    private Control _root;

    public void Init(Control root)
    {
        _originals.Clear();
        _root = root;
        SaveOriginals(root);
    }

    private void SaveOriginals(Control ctrl)
    {
        _originals[ctrl] = new ControlRect(ctrl);

        foreach (Control child in ctrl.Controls)
        {
            SaveOriginals(child);
        }
    }

    public void Scale(double scaleX, double scaleY)
    {
        foreach (var kv in _originals)
        {
            var ctrl = kv.Key;
            var rect = kv.Value;

            ctrl.Left = (int)(rect.Left * scaleX);
            ctrl.Top = (int)(rect.Top * scaleY);
            ctrl.Width = (int)(rect.Width * scaleX);
            ctrl.Height = (int)(rect.Height * scaleY);

            // 字体缩放
            ctrl.Font = new Font(ctrl.Font.FontFamily, (float)(rect.FontSize * Math.Min(scaleX, scaleY)), ctrl.Font.Style);
        }
    }

    private class ControlRect
    {
        public int Left, Top, Width, Height;
        public float FontSize;

        public ControlRect(Control ctrl)
        {
            Left = ctrl.Left;
            Top = ctrl.Top;
            Width = ctrl.Width;
            Height = ctrl.Height;
            FontSize = ctrl.Font.Size;
        }
    }
}




