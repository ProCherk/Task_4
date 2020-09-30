using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Money cash1 = new Money(23.7);
            Money cash2 = new Money(40, 5);
            /*
            cash1.GetInfo();
            cash2.GetInfo();

            cash1.SumMoney(23.1, 45.5);
            cash2.SumMoney(20, 90, 31, 45);
            */
            cash1.ToCoin(34.23);
            cash2.ToPaperMoney(23423);
            
            //Console.WriteLine(23.12 % 100 / 100);

        }
    }

    class Money
    {
        private double p_money; 
        private double coin;
        private double summa;
        private int summa_coin;
        private int summa_pm;

        //Введення грошової суми можливе у двох форматах 1 - як дріб, 2 - окремо гривні і копійки
        public Money(double a) {
            if (a > 0)
            {   
                p_money = Math.Truncate(a);
                coin = 100 * (a - p_money);
            }
            else
            {
                p_money = 0;
                coin = 0;
            }
        }

        public Money(int a, int b) {
            if (a > 0 & b >= 0)
            {
                p_money = a;
                coin = b;
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
        //1 варіант, введення 2 дробових значень
        public void SumMoney(double a, double b)
        {
            summa = a + b;
            Console.WriteLine($"Сума: {a} грн. + {b} грн. = {summa} грн.");
        }

        //2 варіант, введення окремо гривень і копійок
        public void SumMoney(int a, int b, int c, int d)
        {
            summa_coin = b + d;
            if (summa_coin > 100)
            {
                summa_coin -= 100;
                summa_pm = 1;
            }

            summa_pm += a + c;
            Console.WriteLine($"Сума: {a} грн. {b} коп. + {c} грн. {d} коп. = {summa_pm} грн. {summa_coin} коп.");
        }
         //Переведення у копійки
        public void ToCoin(double a)
        {
            coin = Math.Truncate(a);
            coin += (a - coin)*100;
            Math.Ceiling(coin);
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
