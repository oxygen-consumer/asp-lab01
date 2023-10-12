namespace Lab_01;

public class Course
{
    public string Name { get; }
    public string Duration { get; }

    public Course(string name, string duration)
    {
        Name = name;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Name} ({Duration})";
    }
}