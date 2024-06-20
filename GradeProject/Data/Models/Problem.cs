namespace GradeProject.Data.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string InitialCode { get; set; }
        public Resultse[] Result { get; set; }
    }
}

public class Resultse
{
    public string[] result { get; set; }
}