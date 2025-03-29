using Soloviev_Exam;
using System;
using System.IO;
using System.Text;

class Program
{
    // Метод для ввода целого числа с проверкой на корректность
    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result > 0) 
                return result;
            Console.WriteLine("Ошибка: Введите корректное число больше нуля.");
        }
    }

    // Метод для ввода строки с проверкой, что она не пуста
    static string ReadString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Ошибка: Поле не должно быть пустым.");
        }
    }

    // Основной метод программы
    static void Main()
    {
        string relativeFilePath = @"../../File/subjects.txt";
        string absoluteFilePath = Path.GetFullPath(relativeFilePath);

        string fileDirectory = Path.GetDirectoryName(absoluteFilePath);

        if (!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }

        int size = ReadInt("Введите количество дисциплин: ");
        PlanControl plan = new PlanControl();

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"\nВвод данных для дисциплины {i + 1}:");
            string name = ReadString("Введите название дисциплины: ");
            string lecturer = ReadString("Введите фамилию преподавателя: ");
            int semester = ReadInt("Введите номер семестра: ");

            plan.AddSubject(new Subject(name, lecturer, semester));
        }

        plan.SortSubjects();
        SaveToTxt(plan, absoluteFilePath);

        Console.WriteLine($"Данные успешно сохранены в файл: {absoluteFilePath}");
    }

    // Метод для сохранения списка дисциплин в текстовый файл
    static void SaveToTxt(PlanControl plan, string filePath)
    {
        using (StreamWriter sw = new(filePath, false, Encoding.UTF8))
        {
            foreach (var subject in plan.GetSubjects())
            {
                sw.WriteLine($"Название: {subject.Name}, Преподаватель: {subject.Lecturer}, Семестр: {subject.Semester}");
            }
        }
    }
}
