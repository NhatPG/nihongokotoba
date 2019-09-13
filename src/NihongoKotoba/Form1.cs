using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace NihongoKotoba
{
    public partial class Form1 : Form
    {
        private Font TitleFont = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
        private Font ContentFont = new Font(FontFamily.GenericSansSerif, 14);

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Add(new ToolStripMenuItem("Đã thuộc", null, null, "Fruit"));
        }

        private void ToolStripItem_Click(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var popupNotifier = new PopupNotifier();

            popupNotifier.TitleText = "脱ぎます [ぬぎます] - [Nhóm 1]";
            popupNotifier.ContentText = "Cởi bỏ (quần áo, giày,…)\nVí dụ:部屋に入る前に靴を脱ぬぎなさい。\nTrước khi vào phòng hãy cởi giày.";
            popupNotifier.ShowCloseButton = true;
            popupNotifier.TitlePadding = new Padding(0, 0, 0, 5);
            popupNotifier.TitleFont = TitleFont;
            popupNotifier.ContentFont = ContentFont;
            popupNotifier.Delay = 10000;
            popupNotifier.OptionsMenu = contextMenuStrip1;
            popupNotifier.ShowOptionsButton = true;
            popupNotifier.Popup();
        }
    }
}