using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoticeBoardV3.Models
{
    public class NoticeStatus
    {
        [Key]
        //[ForeignKey("Status")]
        public int Status_ID { get; set; }

        //[ForeignKey("Notice")]
        public int Notice_ID { get; set; }

        //[ForeignKey("Board")]
        public int Board_ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Board Board { get; set; }
        public virtual Notice Notice { get; set; }
        public virtual Status Status { get; set; }
    }
}