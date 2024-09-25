namespace ParadisePromotions.Core.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public int? Old_ID { get; set; }
        public string Company_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone1_Ext { get; set; }
        public string Phone2 { get; set; }
        public string Phone2_Ext { get; set; }
        public string Cycle { get; set; }
        public DateTime? Input_Date { get; set; }
        public string Last_Closer { get; set; }
        public DateTime? Last_Sale_Date { get; set; }
        public int? Last_Closer_ID { get; set; }
        public int? Invoice_Count { get; set; }
        public string NextAssignedSalesPersonID { get; set; }
        public string SpecialNotes { get; set; }
        public bool? Assign { get; set; }
        public DateTime? ImportDate { get; set; }
        public string InternalNotes { get; set; }
        public byte[] Upsize_Ts { get; set; }
        public DateTime? NextAssignmentDate { get; set; }
        public string NewLead { get; set; }
        public int? PreviousCloserID { get; set; }
        public int? NextCloserID { get; set; }
        public int? CallListLastCloserID { get; set; }
        public bool? SamplePack { get; set; }
    }

}
