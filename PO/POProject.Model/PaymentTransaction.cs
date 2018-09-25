namespace POProject.Model
{
    public class PaymentTransaction
    {
        public string Username { get; set; }
        public string Nop { get; set; }
        public string MasaPajak { get; set; }
        public string StrMasaPajak { get; set; }
        public string Tahun { get; set; }
        public double Pajak { get; set; }
        public string StrNominal { get; set; }
        public int Is_Generate { get; set; }
    }
}