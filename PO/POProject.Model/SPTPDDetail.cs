namespace POProject.Model
{
    public class SPTPDDetail : BaseEntity
    {
        public string ID_SPTPD { get; set; }
        public string Nop { get; set; }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Nominal { get; set; }
    }
}