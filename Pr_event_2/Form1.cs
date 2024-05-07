using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr_event_2
{
    public partial class Form1 : Form
    {
        // Змінна для підрахунку кількості елементів на формі
        private static int eCount = 0;
        // Змінна для зберігання вибраного елемента
        private Control selectedControl;
        // Змінна для зберігання початкових координат елемента
        private Point initialLocation; 

        public Form1()
        {
            InitializeComponent();
            // Додаємо обробник події MouseClick для форми
            this.MouseClick += Form_MouseClick;
        }

        private void MoveControlUp(object sender, EventArgs e)
        {
            // Переміщаємо елемент вгору на 10 пікселів
            if (selectedControl != null) selectedControl.Top -= 10;
        }

        private void MoveControlDown(object sender, EventArgs e)
        {
            // Переміщаємо елемент вниз на 10 пікселів
            if (selectedControl != null) selectedControl.Top += 10;
        }

        private void MoveControlLeft(object sender, EventArgs e)
        {
            // Переміщаємо елемент вліво на 10 пікселів
            if (selectedControl != null) selectedControl.Left -= 10; 
        }
        //Повертаємо елемент на початкові координати
        private void ResetControlPosition(object sender, EventArgs e)
        {
            if (selectedControl != null)//Перевіряємо чи вибраний елемент
            {
                // Переміщаємо елемент на початкові координати
                selectedControl.Location = initialLocation;
            }
        }
       
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedControl != null)//Перевіряємо чи вибраний елемент
            {
                selectedControl.Left = e.X - selectedControl.Width / 2;//Переміщаємо елемент по горизонталі
                selectedControl.Top = e.Y - selectedControl.Height / 2;//Переміщаємо елемент по вертикалі
            }
        }
        // Переміщення элемента по кліку
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Start")
            {
                selectedControl = textBox1;
                button1.Click += MoveControlUp;
                button2.Click += MoveControlDown;
                textBox1.Text = "Stop";
                //Зберігаємо початкові координати елемента
                initialLocation = selectedControl.Location;
            }
            else
            {
                button1.Click -= MoveControlUp;
                button2.Click -= MoveControlDown;
                textBox1.Text = "Start";
                selectedControl = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point screenCoords = Control.MousePosition;//Отримуємо координати курсора на екрані
            Point formCoords = this.PointToClient(screenCoords);//Перетворюємо координати курсора на координати форми
            MessageBox.Show($"X = {formCoords.X}, Y = {formCoords.Y}");//Виводимо координати курсора на формі
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Click += MoveControlLeft;//Підписуємо кнопку на обробник події
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Click += ResetControlPosition;//Підписуємо кнопку на обробник події
        }
    }
}

