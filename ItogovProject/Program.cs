using System;

namespace ItogovProject
{
    class Program
    {

        //метод на проверку ввода int >0
        static int Proverka()
        {
            int otvet = 0;
            bool flag = true;
            while (flag)
            {
                if (int.TryParse(Console.ReadLine(), out int k))
                {
                    if (k > 0)
                    {
                        otvet = k;
                        flag = false;
                    }
                   else Console.WriteLine("Некорректный ввод число должно быть больше 0, попробуйте еше раз");
                }
                 else
                {
                    Console.WriteLine("Некорректный ввод: вы ввели не число, попробуйте еше раз");
                    k = 0;
                }
            
            
            }


            return otvet;
        }


        //метод на проверку ввода bool
        static bool ProverkaBool()
        {
            bool otvet=true;
            bool flag = true;
            while (flag)
            {
                if (bool.TryParse(Console.ReadLine(), out bool k))
                {
                        otvet = k;
                        flag = false;
                 }
                else
                {
                    Console.WriteLine("Некорректный ввод: необходимо ввести либо true либо false , попробуйте еше раз");
                   // k = 0;
                }


            }


            return otvet;
        }

        //метод возращающий клички питомцев
        static string[] PetKlicki(int petkol)
        {
            string[] rezult = new string[petkol];
            for (int i = 0; i < petkol; i++)
            {
                Console.Write($"Введите имя {i+1} питомца: ");
                rezult[i] = Console.ReadLine();
            }
            return rezult;
        }

        //метод возращающий любимые цвета
        static string[] ShowColor(int kol)
        {
            string[] rezult = new string[kol];
            for (int i = 0; i < kol; i++)
            {
                Console.Write($"Введите любимый {i + 1} цвет ");
                rezult[i] = Console.ReadLine();
            }
            return rezult;
        }
           //вывод на экран
        static void Vivod((string name, string surname, int age, bool nal, int kolpet, string[] klicki, int kolcolor, string[] favcolor) ank)
        {
            Console.WriteLine("Ваше имя: {0}", ank.name);
            Console.WriteLine("Ваша фамилия: {0}", ank.surname);
            Console.WriteLine("Ваш возраст: {0}", ank.age);
            if (ank.nal == true)
            {
                Console.WriteLine($"Питомцы у вас есть, в количестве {ank.kolpet}");
                Console.WriteLine("Клички ваших питомцев:");
                foreach (var item in ank.klicki)
                { Console.WriteLine($"{item} "); }
            }
            else Console.WriteLine("Питомцев у вас нет");

            Console.WriteLine($"Количество любимых цветов {ank.kolcolor}");
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var item in ank.favcolor)
            { Console.WriteLine($"{item} "); }

           

        }


        // формирование кортежа
      static (string name, string surname, int age, bool nal, int kolpet, string[] klichki, int kolcolor, string[] favcolor) Opros()
        {
            var anketa = (name: "", surname: "", age: 0, nal: true, kolpet: 0, klichki: new string[0], kolcolor: 0, favcolor: new string[0]);  //= ("Марина","", 33,true,0,);

            Console.Write("Введите имя: ");
            anketa.name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            anketa.surname = Console.ReadLine();

            Console.Write("Введите возрас  цифрами:");
            anketa.age = Proverka();

            Console.Write("Введите есть ли у вас питомцы (true / false):");
            anketa.nal = ProverkaBool();

            if (anketa.nal == true)
            {
                Console.Write("Введите количество питомцев:");
                anketa.kolpet = Convert.ToInt32(Console.ReadLine());

                anketa.klichki = PetKlicki(anketa.kolpet);

            }

            Console.Write("Введите количество любимых цветов:");
            anketa.kolcolor = Proverka();

            anketa.favcolor = ShowColor(anketa.kolcolor);
            return anketa;
        }

        static void Main(string[] args)
        {

            Vivod( Opros());

          

        }
    }
}
