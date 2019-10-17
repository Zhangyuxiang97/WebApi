using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Dto
{
    public class StudentScoreDto
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public Guid ScoreId { get; set; }

        public int Score { get; set; }

        public Guid ExamId { get; set; }

        public DateTime ExamTime { get; set; }

        public Guid SubjectId { get; set; }
        
        public string SubjectName { get; set; }

        public Guid ClassId { get; set; }

        public string ClassName { get; set; }

    }
}
