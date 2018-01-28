using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoticeBoardV3.Models
{
    public class MemberOfRole
    {
        [Key]
        public int PerOrgParent_ID { get; set; }

        //[ForeignKey("MemberOf")]
        public int PerOrgChild_ID { get; set; }

        //[ForeignKey("Role")]
        public int Role_ID { get; set; }

        public virtual MemberOf MemberOf { get; set; }
        public virtual Role Role { get; set; }
    }
}