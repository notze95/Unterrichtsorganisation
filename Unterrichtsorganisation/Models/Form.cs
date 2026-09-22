namespace Unterrichtsorganisation.Models {
    public class Form {
        public int Id { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string ContentJson { get; set; }
    }
}
