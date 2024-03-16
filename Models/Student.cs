namespace Practice_JSON.Models
{
    public class Student
    {
        public string? Code { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }

        public override string ToString() =>
            $"{LastName} {FirstName} {MiddleName} ({Code})";
    }
}
