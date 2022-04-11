namespace myArchery.Services.TmpClasses
{
    public  class CreateEventTemplate
    {
        public string? Eventname { get; set; }
        public int Arrowamount { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public short Isprivat { get; set; }
        public string? Password { get; set; }
        public int? ParId { get; set; }
        public List<CreateEventPointsTemplate> Points { get; set; } = new List<CreateEventPointsTemplate>();
    }
}