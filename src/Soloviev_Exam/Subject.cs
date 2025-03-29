using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soloviev_Exam
{
    public class Subject
{
    public string Name { get; set; }
    public string Lecturer { get; set; }
    public int Semester { get; set; }

    public Subject(string name, string lecturer, int semester)
    {
        Name = name;
        Lecturer = lecturer;
        Semester = semester;
    }
}

}
