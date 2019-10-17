using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class Score:BaseEntity
    {
        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }

        public Exam Exam { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public int ExamScore { get; set; }



    }
}
