using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Dto
{
    public class StudentSignedDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public Guid ClassId { get; set; }

        public string ClassName { get; set; }

    }
}
