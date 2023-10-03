using System.Security;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            (string name, string lastName, byte age, string[] namePets, string[] color) = InputConsoleUserData();
            PrintDataUser(name, lastName, age, namePets, color);
            Console.ReadKey();
        }
        private static (string name, string lastName, byte age,string[] namePets, string[] color) InputConsoleUserData()
        {
            bool havePet = false;
            string[] namePets = new string[] {};
            string[] colors = new string[] {};
            Print("Введите ваше имя");
            string name = Console.ReadLine();
            Print("Введите вашу фамилию");
            string lastName = Console.ReadLine();
            byte age = GetData("Введите ваш возраст");
            Print("Если ли у вас питомец");
            if(Console.ReadLine().ToLower() == "да") havePet = true;
            if(havePet)
            {
                namePets = GetArrayData(true);
            }
            colors = GetArrayData(false);
            return (name, lastName, age, namePets, colors);
        }

        private static byte GetData(string message)
        {
            while(true)
            {
                Print(message);
                string temp = Console.ReadLine();
                byte bytetemp;
                if(byte.TryParse(temp, out bytetemp))
                {
                    if (bytetemp > 0)
                    {
                        if (bytetemp < 100)
                        {
                            return bytetemp;
                        }
                    }
                }
                Print("Не корректный ввод");
            }
        }

        private static string[] GetArrayData(bool truePetFalseColor)
        {
            string[] pet = new string[] {"Сколько у вас питомцев?", "Какое имя у вашего питомца",
            "Какие у ваших питомцев имена", "имен питомцев"};
            string[] color = new string[] { "Сколько у вас любимых цветов", "Введите ваш цвет и нажмите Enter", 
                "Вводите любимые цвета через Enter", "еще цветов" };
            string[] tempQuestion = new string[] { };
            if(truePetFalseColor)
            {
                tempQuestion = pet;
            }
            else
            {
                tempQuestion = color;
            }
            string[] dataAray = new string[GetData(tempQuestion[0])];
            if(dataAray.Length == 1)
            {
                Print(tempQuestion[1]);
            }
            else
            {
                Print(tempQuestion[2]);
            }
            for (int i = 0; i < dataAray.Length; i++)
            {
                dataAray[i] = Console.ReadLine();
                Print($"Еще {dataAray.Length - (i + 1)} {tempQuestion[3]}");
            }
            return dataAray;
        }
        private static void PrintDataUser(string name, string lastName, byte age, string[] namePets, string[] color) 
        {
            Print($"\nВаше имя:{name} \nВаша фамилия: {lastName} \nВаш возраст: {age} \nКоличество питомцев {namePets.Length + 1}" +
                $"\n {DataRes(namePets)} \nКоличество цветов: {color.Length} \n{DataRes(color)}");
        }

        private static string DataRes(string[] data)
        {
            string dataStr = "Список";
            for (int i = 0; i < data.Length; i++)
            {
                dataStr = dataStr + "\n" + (i + 1) + ". " + data[i];
            }
            return dataStr;
        }
        private static void Print(string message)=> Console.WriteLine(message);
    }
}