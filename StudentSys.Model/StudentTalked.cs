﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class StudentTalked:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }

        public Class Class { get; set; }

        public String Content { get; set; }

        public bool IsDone { get; set; }

        public String Result { get; set; }

    }
}
