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
        // Лейбл для виведення координат переміщення текстового поля
        private Label coordinatesLabel;

        public Form1()
        {
            InitializeComponent();
            // Додаємо обробник події MouseClick для форми
            this.MouseClick += Form_MouseClick;
            // Ініціалізуємо лейбл
            InitializeCoordinatesLabel();
        }

        // Ініціалізація лейбла
        private void InitializeCoordinatesLabel()
        {
            coordinatesLabel = new Label();// Створюємо новий лейбл
            coordinatesLabel.AutoSize = true;// Автоматично визначаємо розмір лейбла
            coordinatesLabel.Location = new Point(10, 10); // Задаємо початкове розташування лейбла
            this.Controls.Add(coordinatesLabel); // Додаємо лейбл на форму
        }

        private void MoveControlUp(object sender, EventArgs e)
        {
            // Переміщаємо елемент вгору на 10 пікселів
            if (selectedControl != null)
            {
                selectedControl.Top -= 10;
                UpdateCoordinatesLabel(); // Оновлюємо координати у лейблі
            }
        }

        private void MoveControlDown(object sender, EventArgs e)
        {
            // Переміщаємо елемент вниз на 10 пікселів
            if (selectedControl != null)
            {
                selectedControl.Top += 10;
                UpdateCoordinatesLabel(); // Оновлюємо координати у лейблі
            }
        }

        // Оновлення координат у лейблі
        private void UpdateCoordinatesLabel()
        {
            if (selectedControl != null)
            {
                coordinatesLabel.Text = $"Coordinates: X = {selectedControl.Location.X}, Y = {selectedControl.Location.Y}";
            }
        }

        //Повертаємо елемент на початкові координати
        private void ResetControlPosition(object sender, EventArgs e)
        {
            if (selectedControl != null)//Перевіряємо чи вибраний елемент
            {
                // Переміщаємо елемент на початкові координати
                selectedControl.Location = initialLocation;
                UpdateCoordinatesLabel(); // Оновлюємо координати у лейблі
            }
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            // Переміщаємо вибраний елемент на координати кліка
            if (selectedControl != null)
            {
                selectedControl.Left = e.X - selectedControl.Width / 2;
                selectedControl.Top = e.Y - selectedControl.Height / 2;
                UpdateCoordinatesLabel(); // Оновлюємо координати у лейблі
            }
        }
        // Переміщення елемента по кліку
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
                UpdateCoordinatesLabel(); // Оновлюємо координати у лейблі
            }
            else
            {
                button1.Click -= MoveControlUp;
                button2.Click -= MoveControlDown;
                textBox1.Text = "Start";
                selectedControl = null;
                coordinatesLabel.Text = ""; // Очищаємо лейбл при зупинці руху елемента
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Click += MoveControlDown;//Підписуємо кнопку на обробник події
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Click += MoveControlUp;//Підписуємо кнопку на обробник події
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Click += ResetControlPosition;//Підписуємо кнопку на обробник події
        }
    }
}

