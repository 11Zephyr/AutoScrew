using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ControlScaler
{
    private Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
    private Size originalContainerSize;

    public void RecordOriginalSizes(Control container)
    {
        originalBounds.Clear();
        originalContainerSize = container.Size;
        SaveBounds(container);
    }

    private void SaveBounds(Control ctrl)
    {
        originalBounds[ctrl] = ctrl.Bounds;
        foreach (Control child in ctrl.Controls)
        {
            SaveBounds(child);
        }
    }

    public void ScaleUserControlToPanel(Control userControl, Size panelSize, Size designSize)
    {
        // 先清空之前的缩放（手动重置大小）
        userControl.Size = designSize;

        // 计算缩放比例（按最小缩放因子，保持等比）
        float scaleX = (float)panelSize.Width / designSize.Width;
        float scaleY = (float)panelSize.Height / designSize.Height;
        float scale = Math.Min(scaleX, scaleY);

        // 执行等比缩放
        userControl.Scale(new SizeF(scale, scale));

        // 可选：居中显示
        int offsetX = (panelSize.Width - userControl.Width) / 2;
        int offsetY = (panelSize.Height - userControl.Height) / 2;
        userControl.Location = new Point(offsetX, offsetY);
    }


}


