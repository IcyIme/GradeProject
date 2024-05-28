using GradeProject.Data.Models;

namespace GradeProject.Services
{
    public class ProblemService
    {
        private readonly List<Problem> _problems = new List<Problem>
        {
            new Problem { Id = 1, Title = "Two Sum", Description = "Given an array of integers...", Difficulty = "Easy" },
            new Problem { Id = 2, Title = "Add Two Numbers", Description = "You are given two non-empty linked lists...", Difficulty = "Medium" },
            // Add more problems here...
        };

        public List<Problem> GetProblems() => _problems;

        public Problem GetProblemById(int id) => _problems.FirstOrDefault(p => p.Id == id);
    }
}
