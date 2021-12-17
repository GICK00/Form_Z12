using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Form_Z12
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Regular
    {
        private Regex r;
        private string text;

        public string Math()
        {
            bool match = r.IsMatch(text);
            if (match == true)
                return "\r\nТекст содержит шаблон.\r\n";
            else
                return "\r\nТекст не содержит шаблон.\r\n";
        }

        public string MathView()
        {
            string str = "";
            MatchCollection match = r.Matches(text);
            foreach (Match m in match)
                str += m + " ";
            return str + "\r\n";
        }

        public string MatchDelet()
        {
            return r.Replace(text, "") + "\r\n";
        }

        public static string Transform(Regex r)
        {
            return r.ToString();
        }

        public static Regex Transform(string r)
        {
            Regex reg = new Regex(r);
            return reg;
        }

        public static string operator -(Regular regular)
        {
            return regular.r.Replace(regular.text, "");
        }

        public static string operator +(Regular regular, string str)
        {
            return regular.text + " " + str;
        }

        public static bool operator true(Regular regular)
        {
            if (regular.text.Length != 0)
                return true;
            return false;
        }

        public static bool operator false(Regular regular)
        {
            if (regular.text.Length == 0)
                return true;
            return false;
        }

        public Regex R
        {
            get { return r; }
            set { r = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > 1)
                    throw new Exception("Индекс может быть только 0 или 1!");
                if (index == 0)
                    return r;
                else
                    return text;
            }
            set
            {
                if (index < 0 || index > 1)
                    throw new Exception("Индекс может быть только 0 или 1!");
                if (index == 0)
                    r = (Regex)value;
                else
                    text = value.ToString();
            }
        }
    }
}
