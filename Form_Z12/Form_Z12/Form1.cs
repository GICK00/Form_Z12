using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Form_Z12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                Regular reg = new Regular();
                reg.R = new Regex($@"{Convert.ToString(textBoxR.Text)}");
                if (reg.R.ToString().Length <= 0)
                    throw new Exception("Введите строку для поиска!");
                reg.Text = Convert.ToString(textBoxText.Text);
                if (reg.Text.Length <= 0)
                    throw new Exception("Введите текст!");
                

                textBoxText.Text += reg.Math();
                textBoxText.Text += reg.MathView();
                textBoxText.Text += reg.MatchDelet();

                textBoxText.Text += "Значения R - " + reg.R + ", Text - " + reg.Text;

                int index = Convert.ToInt32(textBoxN.Text);
                textBoxText.Text += $"\r\nИндекс #{index} = {reg[index]}";

                string str = Convert.ToString(textBoxStr.Text);
                reg.Text = (reg + str);
                textBoxText.Text += "\r\nПерегруженный + :\r\n" + reg.Text;

                reg.Text = (-reg);
                textBoxText.Text += "\r\nПерегруженный - :\r\n" + reg.Text;

                textBoxText.Text += "\r\nПерегруженный метод преобразования типов данных.\r\n";
                textBoxText.Text += $"{Regular.Transform(reg.R)} = {Regular.Transform(reg.R).GetType()},\r\n{Regular.Transform(reg.R.ToString())} = {Regular.Transform(reg.R.ToString()).GetType()}";

                if (reg)
                    textBoxText.Text += "\r\nСтрока не пустая";
                else
                    textBoxText.Text += "\r\nСтрока пустая";
            }
            catch (FormatException)
            {
                textBoxText.Text = "Поле индекса не может быть пустым!";
            }
            catch (Exception ex)
            {
                textBoxText.Text = ex.Message;
            }
        }
    }
}
