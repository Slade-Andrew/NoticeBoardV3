using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoardV3.Models
{
    public class Status
    {
        [Key]
        public int Status_ID { get; set; }
        public string StatusName { get; set; }
        public string StatusDesc { get; set; }

        public virtual ICollection<NoticeStatus> NoticeStatuses { get; set; }
    }
}