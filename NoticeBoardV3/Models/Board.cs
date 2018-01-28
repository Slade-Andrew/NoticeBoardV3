using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoticeBoardV3.Models
{
    public class Board
    {
        [Key]
        public int Board_ID { get; set; }

        [ForeignKey("BoardType")]
        public int BoardType_ID { get; set; }

        [ForeignKey("PerOrg")]
        public int PerOrg_ID { get; set; }
        public string BoardName { get; set; }
        public string BoardDesc { get; set; }

        public virtual BoardType BoardType { get; set; }
        public virtual PerOrg PerOrg { get; set; }
        public virtual ICollection<NoticeStatus> NoticeStatuses { get; set; }
        public virtual ICollection<ViewableBoard> ViewableBoards { get; set; }
    }
}