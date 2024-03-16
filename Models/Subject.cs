namespace Practice_JSON.Models
{
    public class Subject
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public int LectureCount { get; set; }
        public int PracticeCount { get; set; }

        public override string ToString() =>
            $"{Title} ({Code}): {LectureCount} лекций, {PracticeCount} практик";

        public string ToShortString() =>
            $"{Title} ({Code})";
    }
}
