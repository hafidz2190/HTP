namespace POProject.Model
{
  public class SPTPD : BaseEntity
  {
    public string ID_SPTPD { get; set; }
    public string Username { get; set; }
    public int MasaPajak { get; set; }
    public int Tahun { get; set; }
    public double Pajak { get; set; }
    public double Sanksi { get; set; }
    public double Total { get; set; }
    public string Id_Bayar { get; set; }
    public bool Is_Active { get; set; }
  }
}