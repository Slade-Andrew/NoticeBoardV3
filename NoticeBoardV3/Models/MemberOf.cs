using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoticeBoardV3.Models
{
    public class MemberOf
    {
        [Key]
        public int PerOrgParent_ID { get; set; }

        //[ForeignKey("PerOrgChild")]
        public int PerOrgChild_ID { get; set; }

        public virtual PerOrg PerOrgParent { get; set; }
        public virtual PerOrg PerOrgChild { get; set; }
        public virtual ICollection<MemberOfRole> MemberOfRoles { get; set; }
    }
}