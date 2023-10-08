using System.Text.RegularExpressions;

namespace Lab_01;

public class Student
{
    public string LastName { get; }
    public string FirstName { get; }
    private readonly string _cnp; // Cod Numeric Personal
    public string Gender { get; private set; } = null!; // Suppress warning, it is initialized in ProcessCnp()
    public List<Course> Courses { get; set; } = new List<Course>();
    public DateOnly Birthday { get; private set; }

    public Student(string lastName, string firstName, string cnp)
    {
        LastName = lastName;
        FirstName = firstName;
        _cnp = cnp;

        ProcessCnp();
    }

    public override string ToString()
    {
        string studInfo = $"Nume: {LastName} {FirstName}\nMaterii:";
        return Courses.Aggregate(studInfo,
            (current, course) => current + " " + course);
    }

    private void ProcessCnp()
    {
        // Check CNP format
        string pattern = @"^\d{13}$";
        Match m = Regex.Match(_cnp, pattern);
        if (!m.Success)
        {
            throw new InvalidDataException("Invalid CNP");
        }

        // If CNP is valid, extract relevant information from it
        int genderDigit = int.Parse(_cnp.Substring(0, 1));
        Gender = genderDigit % 2 == 0 ? "Female" : "Male";

        int year = int.Parse(_cnp.Substring(1, 2));
        int month = int.Parse(_cnp.Substring(3, 2));
        int day = int.Parse(_cnp.Substring(5, 2));

        if (genderDigit >= 5 && genderDigit <= 6)
        {
            year += 2000;
        }
        else if (genderDigit <= 2 && genderDigit >= 1)
        {
            year += 1900;
        }
        else // Don't handle dead people (3 and 4 means born between 1800 and 1899)
        {
            throw new InvalidDataException("Invalid CNP");
        }

        Birthday = new DateOnly(year, month, day);
    }
}