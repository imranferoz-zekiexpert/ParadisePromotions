using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models
{
    public class NotesHistory
    {
        [Key]
        public int NoteHistoryID { get; set; }
        public int? CustomerID { get; set; }
        public int? CustomerIDArchive { get; set; }
        public string EmployeeIDName { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? NoteDateTime { get; set; }
        public string Notes { get; set; }
        public DateTime? CallBackDateTime { get; set; }
        public int? DispositionID { get; set; }
        public DateTime? EndTime { get; set; }
        public byte[] Upsize_Ts { get; set; }
    }

}
