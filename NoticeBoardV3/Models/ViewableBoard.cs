using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoticeBoardV3.Models
{
    public class ViewableBoard
    {
        [Key]
        //[ForeignKey("Board")]
        public int Board_ID { get; set; }

        //[ForeignKey("MemeberOfRole")]
        public int PerOrgParent_ID { get; set; }

        //[ForeignKey("MemeberOfRole")]
        public int PerOrgChild_ID { get; set; }

        //[ForeignKey("MemeberOfRole")]
        public int Role_ID { get; set; }

        public virtual Board Board { get; set; }
        public virtual MemberOfRole MemberOfRole { get; set; }
    }
}