using System;

public class Course
{
    public string Title { get; }
    public int LessonCount { get; }

    // 12 ta darsi
    public Course() : this("C# asoslari", 12)
    {
    }

    // nomi bilan 12 ta darsi
    public Course(string title) : this(title, 12)
    {
    }

    public Course(string title, int lessonCount)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Kurs nomini to'liq yozing.", nameof(title));

        if (lessonCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(lessonCount), "Dars soni 0 dan katta bo'lishi kerak.");

        Title = title;
        LessonCount = lessonCount;
    }

    public string GetInfo() => $"{Title} — {LessonCount} ta dars";
}

// Task 4 (Pairwork)
class Program
{
    static void Main()
    {
        Console.WriteLine(new Course().GetInfo()); // 12 ta dars
        Console.WriteLine(new Course("OOP").GetInfo()); // 12 ta dars
        Console.WriteLine(new Course("LINQ", 8).GetInfo()); // 8 ta dars

        // Keraksiz argumentlarni tekshirish
        try
        {
            var c = new Course("  ");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException: {ex.Message}");
        }

        try
        {
            var c = new Course("OOP", 0);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"ArgumentOutOfRangeException: {ex.Message}");
        }
    }
}