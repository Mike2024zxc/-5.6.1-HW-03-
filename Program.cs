using System;


namespace CИтоговый_проект_5._6._1__HW_03_
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = EnterUser();
            ShowAll(item);

            Console.ReadKey();
        }

        static (string Name, string LastName, int Age, string HasPet, string[] Pets, string[] FavColor) EnterUser()
        {
            (string Name, string LastName, int Age, string HasPet, string[] Pets, string[] FavColor) User;

            Console.WriteLine("Введите имя:");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите Фамилию:");
            User.LastName = Console.ReadLine();

            //------------------------------------------------------------------------------------------------------
            string check; //Переменная для проверки значений: возраст, кол-во питомцев, кол-во цветов.
            int intage;   //Переменная после проверки значений возраст, кол-во питомцев, цветов.
                          //------------------------------------------------------------------------------------------------------
            do
            {
                Console.WriteLine("Введите возраст цифрами:");
                check = Console.ReadLine();
            }
            while (CheckNum(check, out intage));

            User.Age = intage;
            //------------------------------------------------------------------------------------------------------
            #region Питомцы
            //------------------------------------------------------------------------------------------------------
            Console.WriteLine("Есть ли питомцы? (ДА/НЕТ)");
            User.HasPet = Console.ReadLine().ToUpper();

            if (User.HasPet == "ДА")
            {
                do
                {
                    Console.WriteLine("Сколько питомцев?:");
                    check = Console.ReadLine();
                }
                while (CheckNum(check, out intage));
            }
            else
            {
                intage = 0;
            }

            if (intage != 0)
            {
                User.Pets = CreateArrayPets(intage);
            }
            else
            {
                User.Pets = null;
            }
            #endregion
            //------------------------------------------------------------------------------------------------------
            #region Цвета
            //------------------------------------------------------------------------------------------------------
            do
            {
                Console.WriteLine("Сколько любимых цветов?");
                check = Console.ReadLine();
            }
            while (CheckNum(check, out intage));

            User.FavColor = CreateArrayFavColor(intage);

            return User;
        }
        #endregion
        //------------------------------------------------------------------------------------------------------
        #region Массив цветов
        //------------------------------------------------------------------------------------------------------
        static string[] CreateArrayFavColor(int num)
        {
            var result = new string[num];

            Console.WriteLine("Введите {0} цвета", num);
            for (int i = 0; i < num; i++)
            {
                result[i] = Console.ReadLine();
            }
            return result;
        }
        #endregion
        //------------------------------------------------------------------------------------------------------
        #region Общий метод проверки значений
        //------------------------------------------------------------------------------------------------------
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                return true;
            }
        }
        #endregion
        //------------------------------------------------------------------------------------------------------
        #region Массив питомцев
        static string[] CreateArrayPets(int num)
        {
            var result = new string[num];

            Console.WriteLine("Введите {0} клички животных", num);
            for (int i = 0; i < num; i++)
            {
                result[i] = Console.ReadLine();
            }
            return result;
        }
        #endregion
        //------------------------------------------------------------------------------------------------------
        #region Вывод значений
        static void ShowAll((string Name, string LastName, int Age, string HasPet, string[] Pets, string[] FavColor) User)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Ваше Имя: {0}", User.Name);
            Console.WriteLine("Ваша Фамилия: {0}", User.LastName);
            Console.WriteLine("Ваш возраст: {0}", User.Age);
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Питомцы: {0}", User.HasPet);
            if (User.HasPet == "ДА")
            {
                for (int i = 0; i < User.Pets.Length; i++)
                {
                    Console.WriteLine("{0}) - {1}", i + 1, User.Pets[i]);
                }
            }
            else
            {
                Console.WriteLine("У Вас нет питомцев");
            }
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Ваши любимые цвета:");
            for (int i = 0; i < User.FavColor.Length; i++)
            {
                Console.WriteLine("{0}) - {1}", i + 1, User.FavColor[i]);
            }
        }
        #endregion

    }


}
