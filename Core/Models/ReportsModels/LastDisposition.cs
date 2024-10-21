using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models.ReportsModels
{
    [Table("qryLastDisposition",Schema ="dbo")]
    public class LastDisposition
    {
        public int Id { get; set; }
        public int? CustomerID { get; set; }
        public int? MaxOfNoteHistoryID { get; set; }
        public string Disposition { get; set; }
        public DateTime? NoteDateTime { get; set; }
        public int? SortOrder { get; set; }
    }
}
