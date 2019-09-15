using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private List<Kotoba> items = new List<Kotoba>();
        private int total = 0;

        public Form1()
        {
            InitializeComponent();
            contextMenuStrip1.Items.Add(new ToolStripMenuItem("Đã thuộc", null, null, "Fruit"));
            timer1.Interval = 300000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            FileInfo existingFile = new FileInfo("Data.xlsx");
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook?.Worksheets[1];
                total = worksheet.Dimension.End.Row;

                for (int row = 1; row <= total; row++)
                {
                    items.Add(new Kotoba() {
                        OriginalKotoba = worksheet.Cells[row, 1]?.Value?.ToString(),
                        Hiragana = worksheet.Cells[row, 2]?.Value?.ToString(),
                        Type = worksheet.Cells[row, 3]?.Value?.ToString(),
                        VietnameseMeaning = worksheet.Cells[row, 4]?.Value?.ToString(),
                        Example = worksheet.Cells[row, 5]?.Value?.ToString(),
                        ExampleMeaning = worksheet.Cells[row, 6]?.Value?.ToString()
                    });;
                }
            }

            ShowPopup();
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void ToolStripItem_Click(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ShowPopup();
        }

        private void ShowPopup()
        {
            var item = items[RandomNumber(0, total-1)];

            if(item != null)
            {
                var popupNotifier = new PopupNotifier();
                popupNotifier.TitleText = $"{item.Hiragana} - {item.OriginalKotoba} - [{item.Type}]";
                popupNotifier.ContentText = $"{item.VietnameseMeaning}\n{item.Example}\n{item.ExampleMeaning}";
                popupNotifier.ShowCloseButton = true;
                popupNotifier.TitlePadding = new Padding(0, 0, 0, 5);
                popupNotifier.Size = new Size() { Height = 120, Width = 500 };
                popupNotifier.Scroll = false;
                popupNotifier.TitleFont = TitleFont;
                popupNotifier.ContentFont = ContentFont;
                popupNotifier.Delay = 20000;
                popupNotifier.OptionsMenu = contextMenuStrip1;
                popupNotifier.ShowOptionsButton = true;
                popupNotifier.Popup();
                items.Remove(item);
            }            
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }

    public class Kotoba
    {
        public string OriginalKotoba = string.Empty;
        public string Hiragana = string.Empty;
        public string Type = string.Empty;
        public string VietnameseMeaning = string.Empty;
        public string Example = string.Empty;
        public string ExampleMeaning = string.Empty;
    }
}