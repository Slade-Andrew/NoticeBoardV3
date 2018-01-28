using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoardV3.Models
{
    public class PerOrg
    {
        [Key]
        public int PerOrg_ID { get; set; }
        public string OrganisationName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<PerOrgLocation> PerOrgLocations { get; set; }
        public virtual ICollection<MemberOf> MemberOfParents { get; set; }
        public virtual ICollection<MemberOf> MemberOfChilds { get; set; }
    }
}