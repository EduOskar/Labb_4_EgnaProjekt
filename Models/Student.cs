using System;
using System.Collections.Generic;

namespace Labb_4_EgnaProjekt.Models
{
    public partial class Student
    {
        public Student()
        {
            GradingTables = new HashSet<GradingTable>();
            Schools = new HashSet<School>();
        }

        public int StudentId { get; set; }
        public int? FkClassId { get; set; }
        public int? FkPersonIdStudent { get; set; }
        public string Title { get; set; }

        public virtual Class FkClass { get; set; } = null!;
        public virtual PersonalInformation? FkPersonIdStudentNavigation { get; set; }
        public virtual ICollection<GradingTable> GradingTables { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}
