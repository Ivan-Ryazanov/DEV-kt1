namespace KT1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(450, 0);

            Console.WriteLine("=== Начальное состояние ===");
            driver.PrintLocation();
            driver.PrintCarTechnicalState();
            Console.WriteLine();

            Console.WriteLine("=== Поездка вперед (5 часов) ===");
            double distance1 = driver.Drive(5);
            Console.WriteLine($"Пройдено расстояние: {distance1} км");
            driver.PrintLocation();
            driver.PrintCarTechnicalState();
            Console.WriteLine();

            Console.WriteLine("=== Поездка назад (2 часа) ===");
            double distance2 = driver.DriveBack(2);
            Console.WriteLine($"Пройдено расстояние: {distance2} км");
            driver.PrintLocation();
            driver.PrintCarTechnicalState();
            Console.WriteLine();

            Console.WriteLine("=== Длинная поездка (10 часов) ===");
            double distance3 = driver.Drive(10);
            Console.WriteLine($"Пройдено расстояние: {distance3} км");
            driver.PrintLocation();
            driver.PrintCarTechnicalState();
            Console.WriteLine();

            Console.WriteLine("=== Проверка на поломку ===");
            Random rand = new Random();
            if (rand.NextDouble() < 0.3)
            {
                Console.WriteLine("Произошла поломка автомобиля!");
                driver.Condition = 0;
            }
            Console.WriteLine("=== Попытка поехать с неисправной машиной ===");
            driver.Drive(2);

            Console.WriteLine("=== Ремонт машины ===");
            driver.Repair();
            driver.PrintCarTechnicalState();
            Console.WriteLine();

            Console.WriteLine("=== Поездка после ремонта (3 часа) ===");
            double distance4 = driver.Drive(3);
            Console.WriteLine($"Пройдено расстояние: {distance4} км");
            driver.PrintLocation();
            driver.PrintCarTechnicalState();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}