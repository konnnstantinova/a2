using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfiniteDropdownMenu
{
    public partial class Form1 : Form
    {
        private int menuLevel = 0;
        private const int MENU_WIDTH = 150;
        private const int MENU_HEIGHT = 25;

        public Form1()
        {
            InitializeComponent();
            CreateInitialMenu();
        }

        private void CreateInitialMenu()
        {
            for (int i = 1; i <= 6; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Size = new Size(MENU_WIDTH, MENU_HEIGHT);
                btn.Location = new Point(10 + (i - 1) * (MENU_WIDTH + 5), 50);
                btn.Tag = i;
                btn.Click += MenuButton_Click;
                this.Controls.Add(btn);
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int level = (int)clickedButton.Tag;
            
            // Удаляем все кнопки следующего уровня
            RemoveButtonsAfterLevel(level);
            
            // Создаем новые кнопки для следующего уровня
            CreateSubMenu(level);
        }

        private void RemoveButtonsAfterLevel(int level)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Button btn && btn.Location.Y > 50 + level * (MENU_HEIGHT + 10))
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }

        private void CreateSubMenu(int parentLevel)
        {
            int yPosition = 50 + parentLevel * (MENU_HEIGHT + 10);
            
            for (int i = 1; i <= 6; i++)
            {
                Button btn = new Button();
                btn.Text = $"{parentLevel}.{i}";
                btn.Size = new Size(MENU_WIDTH, MENU_HEIGHT);
                btn.Location = new Point(10 + (i - 1) * (MENU_WIDTH + 5), yPosition);
                btn.Tag = parentLevel + 1;
                btn.Click += MenuButton_Click;
                this.Controls.Add(btn);
            }
        }
    }
}