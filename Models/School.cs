using System;
using System.Collections.Generic;

namespace Labb_4_EgnaProjekt.Models
{
    public partial class School
    {
        public int SchoolId { get; set; }
        public int FkClassId { get; set; }
        public int FkStudentId { get; set; }
        public string FkClassName { get; set; } = null!;

        public virtual Class FkClass { get; set; } = null!;
        public virtual Student FkStudent { get; set; } = null!;
    }
}
