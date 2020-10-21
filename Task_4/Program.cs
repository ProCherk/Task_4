using System;
using System.Transactions;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Оберіть варіант вводу: \n1 - з клавіатури\n2 - з файлу\nВвід: ");
            string enter = Console.ReadLine();

            do
            {
                if (enter == "1")
                {
                    //Введення данних вручну
                    Console.WriteLine("Введіть грошову суму:");
                    double a = Convert.ToDouble(Console.ReadLine());

                    Money cash1 = new Money(a);

                    cash1.GetInfo();

                    Console.WriteLine("Введіть суму, для додавання до основної суми" + "\n" + "Сума: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    cash1.SumMoney(a, b);

                    Console.WriteLine("Введіть суму у копійках, для переведення її у гривні" + "\n" + "Сума: ");
                    double c = Convert.ToDouble(Console.ReadLine());

                    cash1.ToCoin(a);
                    cash1.ToPaperMoney(c);

                    //Запис вихідних данних у файл

                    FileStream final = new FileStream("Final MoneyInfo.txt", FileMode.Open, FileAccess.Write);
                    StreamWriter finr = new StreamWriter(final);
                    finr.WriteLine(Convert.ToString(a));
                    final.Close();
                    break;

                }
                else if (enter == "2")
                {
                    //Отримання інформації з файлу
                    FileStream f = new FileStream("MoneyInfo.txt", FileMode.Open, FileAccess.Read);
                    StreamReader fr = new StreamReader(f);
                    string info = fr.ReadLine();
                    double a = Convert.ToDouble(info);
                    fr.Close();

                    Console.WriteLine($"Грошова сума - {a}");

                    Money cash1 = new Money(a);

                    cash1.GetInfo();
                    
                    Console.WriteLine("Введіть суму, для додавання до основної суми" + "\n" + "Сума: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    cash1.SumMoney(a, b);

                    Console.WriteLine("Введіть суму у копійках, для переведення її у гривні" + "\n" + "Сума: ");
                    double c = Convert.ToDouble(Console.ReadLine());

                    cash1.ToCoin(a);
                    cash1.ToPaperMoney(c);

                    break;
                }
                else
                {
                    Console.WriteLine("Оберіть варіант вводу: \n1 - з клавіатури\n2 - з файлу\nВвід: ");
                    enter = Console.ReadLine();
                }
            } while (true);
        }
    }

    class Money
    {
        private double p_money { get; set; } 
        private double coin { get; set; }
        private double summa { get; set; }


        //Введення грошової суми 
        public Money(double a) {
            if (a > 0)
            {   
                p_money = Math.Truncate(a);
                coin = a * 100 - p_money;
            }
            else
            {
                p_money = 0;
                coin = 0;
            }
        }

        //Виведення інформації про грошову суму
        public void GetInfo()
        {
            Console.WriteLine($"Ваш баланс - {p_money} гривень, {coin} копійок");
        }

        //Обчислення суми
        public void SumMoney(double a, double b)
        {
            summa = a + b;
            Console.WriteLine($"Сума: {a} грн. + {b} грн. = {summa} грн.");
        }

        //Переведення у копійки
        public void ToCoin(double a)
        {
            coin = a * 100;
            coin = Math.Truncate(coin) + 1;
            Console.WriteLine($"{a} гривень у копійках = {coin} копійок");
        }

        //Переведення з копійок
        public void ToPaperMoney(double a)
        {
            coin = (a % 100) * 100;
            p_money = ((a - (coin)) / 100) + (coin / 100);
            Console.WriteLine($"{a} копійок у гривнях = {p_money} гривень");
        }
    }
}
