using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonWithFontIcon
{
    public partial class Form1 : Form
    {
        public static PrivateFontCollection pfc = new PrivateFontCollection();
        public Form1()
        {
            InitializeComponent();
            RegisterIconFonts();

            IconFontButton moveFirstBtn = new IconFontButton() { BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            moveFirstBtn.IconFont = IconFont.FirstPage;
            moveFirstBtn.Bounds = new Rectangle(245, 410, 100, 30);
            moveFirstBtn.FlatAppearance.BorderSize = 0;
            moveFirstBtn.Click += MoveFirstBtn_Click;
            this.Controls.Add(moveFirstBtn);

            IconFontButton movePreviousBtn = new IconFontButton() { BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            movePreviousBtn.IconFont = IconFont.PreviousPage;
            movePreviousBtn.Bounds = new Rectangle(350, 410, 100, 30);
            movePreviousBtn.FlatAppearance.BorderSize = 0;
            movePreviousBtn.Click += MovePreviousBtn_Click;
            this.Controls.Add(movePreviousBtn);

            IconFontButton moveNextBtn = new IconFontButton() { BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            moveNextBtn.IconFont = IconFont.NextPage;
            moveNextBtn.Bounds = new Rectangle(455, 410, 100, 30);
            moveNextBtn.FlatAppearance.BorderSize = 0;
            moveNextBtn.Click += MoveNextBtn_Click;
            this.Controls.Add(moveNextBtn);

            IconFontButton moveLastBtn = new IconFontButton() { BackColor = Color.White, FlatStyle = FlatStyle.Flat };
            moveLastBtn.IconFont = IconFont.LastPage;
            moveLastBtn.Bounds = new Rectangle(560, 410, 100, 30);
            moveLastBtn.FlatAppearance.BorderSize = 0;
            moveLastBtn.Click += MoveLastBtn_Click;
            this.Controls.Add(moveLastBtn);

            RichTextBox rtb = new RichTextBox() {Height = 400, Width = 665, BorderStyle = BorderStyle.None };
            rtb.Name = "rtb";
            rtb.Location = new Point(5, 5);
            rtb.BackColor = Color.White;
            string path = Application.StartupPath.ToString().Replace("\\bin\\Debug", string.Empty) + @"\Installer.rtf";
            if (File.Exists(path))
            {
                rtb.LoadFile(path, RichTextBoxStreamType.RichText);
            }
            rtb.ForeColor = Color.Black;
            this.Controls.Add(rtb);
        }

        private void RegisterIconFonts()
        {
            //Extracting the icon fonts from the WF Fabric.ttf file and inserting into system memory.
            Stream fontAsStream = this.GetType().Assembly.GetManifestResourceStream("WindowsFormsApp1.WF Fabric.ttf");
            byte[] fontAsByte = new byte[fontAsStream.Length];
            fontAsStream.Read(fontAsByte, 0, (int)fontAsStream.Length);
            fontAsStream.Close();
            IntPtr memPointer = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(typeof(byte)) * fontAsByte.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontAsByte, 0, memPointer, fontAsByte.Length);
            pfc.AddMemoryFont(memPointer, fontAsByte.Length);
        }

        public enum IconFont
        {
            //0xe700, 0xe709, 0xe713, 0xe71b - are icon font code from the WF Fabric.ttf file.
            FirstPage = 0xe71b,
            LastPage = 0xe700,
            NextPage = 0xe713,
            PreviousPage = 0xe709
        }

        private void MovePreviousBtn_Click(object sender, EventArgs e)
        {
            //Enter your code here.
        }

        private void MoveNextBtn_Click(object sender, EventArgs e)
        {
            //Enter your code here.
        }

        private void MoveLastBtn_Click(object sender, EventArgs e)
        {
            //Enter your code here.
        }

        private void MoveFirstBtn_Click(object sender, EventArgs e)
        {
            //Enter your code here.
        }
    }

    public class IconFontButton : Button
    {
        public Form1.IconFont IconFont
        {
            get; set;
        }
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
    }
}
