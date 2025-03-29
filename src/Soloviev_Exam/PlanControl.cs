using Soloviev_Exam;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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

    public void SaveToFile(string filePath)
    {
        string json = JsonSerializer.Serialize(subjects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
