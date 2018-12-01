using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var contests = new Dictionary<string, string>();
            var students = new Dictionary<string, Dictionary<string, int>>();
            while (input != "end of contests")
            {
                string[] contestInfo = input.Split(":");

                string contestName = contestInfo[0];
                string contestPassowrd = contestInfo[1];

                contests.Add(contestName, contestPassowrd);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] contestInfo = input.Split("=>");

                string contestName = contestInfo[0];
                string contestPassowrd = contestInfo[1];
                string user = contestInfo[2];
                int points = int.Parse(contestInfo[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == contestPassowrd)
                {
                    if (students.ContainsKey(user) &&  students[user].ContainsKey(contestName) && students[user][contestName] < points)
                    {
                        students[user][contestName] = points;
                    }
                    else if (students.ContainsKey(user) && !students[user].ContainsKey(contestName))
                    {
                        students[user].Add(contestName, points);
                    }
                    else if (!students.ContainsKey(user))
                    {
                        students.Add(user, new Dictionary<string, int>());
                        students[user].Add(contestName, points);
                    }
                }

                input = Console.ReadLine();
            }
            var topStudent = students.OrderByDescending(x => x.Value.Sum(n => n.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(x => x.Value)} points.");

            Console.WriteLine("Ranking:");

            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
