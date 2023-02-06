# Button with Font Icon in WinForms application
This repository demonstrate about customizing the button. The button can be customized using the paint event.

# C#

    protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            string iconChar = char.ConvertFromUtf32((int)this.IconFont);
            Font iconFont = new Font(Form1.pfc.Families[0], 11.5f, FontStyle.Bold);

            if (this.IconFont.ToString().Contains("First"))
            {
                e.Graphics.DrawString(iconChar, iconFont, new SolidBrush(Color.Black), 20, 9);
                e.Graphics.DrawString(this.IconFont.ToString().Replace("Page", string.Empty), iconFont, new SolidBrush(Color.Black), 40, 6);
            }
            else if(this.IconFont.ToString().Contains("Previous"))
            {
                e.Graphics.DrawString(iconChar, iconFont, new SolidBrush(Color.Black), 3, 8);
                e.Graphics.DrawString(this.IconFont.ToString().Replace("Page", string.Empty), iconFont, new SolidBrush(Color.Black), 20, 6);
            }
            else if (this.IconFont.ToString().Contains("Next") || this.IconFont.ToString().Contains("Last"))
            {
                e.Graphics.DrawString(iconChar, iconFont, new SolidBrush(Color.Black), 60, 9);
                e.Graphics.DrawString(this.IconFont.ToString().Replace("Page", string.Empty), iconFont, new SolidBrush(Color.Black), 24, 6);
            }
        }

![Custom Button](ButtonWithFontIcon/Image/Button%20with%20FontIcon.png)
