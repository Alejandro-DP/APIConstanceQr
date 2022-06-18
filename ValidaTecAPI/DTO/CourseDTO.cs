namespace ValidaTecAPI.DTO
{
    public class CourseDTO
    {
        public string courseNme { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int duration { get; set; }
        public string catedratic { get; set; }
        public string Status { get; set; }
        public string Folio { get; set; }
        public int UserId { get; set; }

        public int CarrerId { get; set; }

    }
}
