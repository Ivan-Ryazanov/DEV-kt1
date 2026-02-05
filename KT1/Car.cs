namespace KT1
{
    class Driver
    {
        public double AverageSpeed;
        public double Coordinates;
        public double Condition;

        // Расширенные диапазоны городов
        private readonly (double start, double end)[] Cities = new[]
        {
            (1010.0, 1020.0),  // Город A
            (3565.0, 3580.0),  // Город B
            (-2530.0, -2500.0), // Город C
            (5000.0, 5020.0),   // Новый город D
            (-4000.0, -3990.0)  // Новый город E
        };

        public Driver(double averageSpeed, double initialCoordinates)
        {
            AverageSpeed = averageSpeed;
            Coordinates = initialCoordinates;
            Condition = 100;
        }

        public double Drive(double time)
        {
            if (IsBroken())
            {
                Console.WriteLine("Машина сломана! Нужно отремонтировать.");
                return 0;
            }

            double distance = AverageSpeed * time;
            Coordinates += distance;

            UpdateCondition(distance);

            return distance;
        }

        public double DriveBack(double time)
        {
            if (IsBroken())
            {
                Console.WriteLine("Машина сломана! Нужно отремонтировать.");
                return 0;
            }

            double distance = AverageSpeed * time;
            Coordinates -= distance;

            UpdateCondition(distance);

            return distance;
        }

        private void UpdateCondition(double distance)
        {
            double deterioration = Math.Floor(distance / 100);
            Condition -= deterioration * 0.01;
            if (Condition < 0) Condition = 0;
        }

        public void PrintLocation()
        {
            string location = "на трассе";

            foreach (var city in Cities)
            {
                if (Coordinates >= city.start && Coordinates <= city.end)
                {
                    location = $"в городе с координатами от {city.start} до {city.end}";
                    break;
                }
            }

            Console.WriteLine($"Машина {location}");
        }

        public void PrintCarTechnicalState()
        {
            Console.WriteLine($"Техническое состояние машины: {Condition:F2}%");
        }

        public bool IsBroken()
        {
            return Condition <= 0;
        }

        public void Repair()
        {
            Condition = 100;
            Console.WriteLine("Машина отремонтирована до 100%.");
        }
    }
}