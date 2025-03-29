using System.Text.Json;

namespace Soloviev_Exam
{
    public class PlanControl
    {
        private List<Subject> subjects;

        public PlanControl()
        {
            subjects = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            subjects.Add(subject);
        }

        public void SortSubjects()
        {
            subjects = subjects.OrderBy(s => s.Semester).ThenBy(s => s.Name).ToList();
        }

        public List<Subject> GetSubjects()
        {
            return subjects;
        }

        public void SaveToFile(string filePath)
        {
            string json = JsonSerializer.Serialize(subjects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
