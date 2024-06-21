using GradeProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace GradeProject.Services
{
    public class ProblemService
    {
        private readonly List<Problem> _problems = new List<Problem>
        {
            new Problem 
            {             
                Id = 1,
                Title = "Two Sum",
                Description = "Given an array of integers, return indices of the two numbers such that they add up to a specific target.",
                Difficulty = "Easy",
                InitialCode = "using System;\n\npublic class Program\n{\n    public static void Main()\n    {\n \n    }\n}",
                Result = new Resultse[]
                {
                    new Resultse { result = new string[] { "1", "2" } },
                    new Resultse {result = new string[] {"0", "1"}}
                }
            },
            // Add more problems here...
        };

        public List<Problem> GetProblems() => _problems;

        public Problem GetProblemById(int id) => _problems.FirstOrDefault(p => p.Id == id);
    }
}