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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Font TitleFont = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            Font ContentFont = new Font(FontFamily.GenericSansSerif, 14);

            var popupNotifier = new PopupNotifier();

            popupNotifier.TitleText = "脱ぬぎます [ぬぎます]";
            popupNotifier.ContentText = "Cởi bỏ (quần áo, giày,…)\nVí dụ:部屋に入る前に靴を脱ぬぎなさい。\nTrước khi vào phòng hãy cởi giày.";
            popupNotifier.TitleFont = TitleFont;
            popupNotifier.ContentFont = ContentFont;
            popupNotifier.Popup();
        }
    }
}