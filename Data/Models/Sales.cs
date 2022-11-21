namespace CupApplication.Data.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int WorkingTimeId { get; set; }
        public int WorkerId { get; set; }
        public int? BeneficiariID { get; set; }
        public int? Cup1_ID { get; set; }
        public int? Cup1_Amount { get; set; }
        public int? Cup2_ID { get; set; }
        public int? Cup2_Amount { get; set; }
        public int? Cup3_ID { get; set; }
        public int? Cup3_Amount { get; set; }
        public int? Cup4_ID { get; set; }
        public int? Cup4_Amount { get; set; }
        public int? Cup5_ID { get; set; }
        public int? Cup5_Amount { get; set; }
        public int? Product1_ID { get; set; }
        public int? Product1_Amount { get; set; }
        public int? Product2_ID { get; set; }
        public int? Product2_Amount { get; set; }
        public float? Paid { get; set; }
    }
}
