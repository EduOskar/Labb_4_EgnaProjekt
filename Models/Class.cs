using System;
using System.Collections.Generic;

namespace Labb_4_EgnaProjekt.Models
{
    public partial class Class
    {
        public Class()
        {
            GradingTables = new HashSet<GradingTable>();
            Schools = new HashSet<School>();
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public int FkEmployeeId { get; set; }
        public int? FkGradingTable { get; set; }

        public virtual Employee FkEmployee { get; set; } = null!;
        public virtual GradingTable? FkGradingTableNavigation { get; set; }
        public virtual ICollection<GradingTable> GradingTables { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
