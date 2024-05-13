using System;
using System.Threading;

class AlarmClock
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в будильник!");

        // Инициализируем переменные для времени будильника
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        // Бесконечный цикл проверки времени
        while (true)
        {
            // Перезапрашиваем время, когда нужно прозвенеть будильнику
            Console.Write("\rВведите время будильника (ЧЧ/ММ/СС): ");
            string inputTime = Console.ReadLine();

            // Пытаемся разобрать введенное время
            string[] timeParts = inputTime.Split('/');
            if (timeParts.Length != 3 || !int.TryParse(timeParts[0], out hours) || !int.TryParse(timeParts[1], out minutes) || !int.TryParse(timeParts[2], out seconds))
            {
                Console.WriteLine("Некорректный формат времени. Пожалуйста, введите время в формате ЧЧ/ММ/СС.");
                continue;
            }

            // Бесконечный цикл проверки времени для будильника
            while (true)
            {
                // Получаем текущее системное время
                DateTimeOffset now = DateTimeOffset.Now;
                int currentHours = now.Hour;
                int currentMinutes = now.Minute;
                int currentSeconds = now.Second;

                // Перезаписываем строку для вывода текущего системного времени в одной строке
                Console.Write($"\rТекущее системное время: {now.ToString("HH:mm:ss")} | Время будильника: {hours:00}:{minutes:00}:{seconds:00}");

                // Проверяем, совпадает ли текущее время с установленным будильником
                if (currentHours == hours && currentMinutes == minutes && currentSeconds == seconds)
                {
                    Console.WriteLine("\nВремя прозвенеть! Ура!");
                    // Звуковой сигнал будильника
                    Console.Beep(1000, 2000); // Частота и длительность звука

                    // После прозвона будильника завершаем цикл проверки времени для будильника
                    break;
                }

                // Ждем 1 секунду перед повторной проверкой
                Thread.Sleep(1000); // 1000 миллисекунд = 1 секунда
            }
        }
    }
}
