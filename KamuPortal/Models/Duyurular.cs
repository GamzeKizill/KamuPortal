namespace KamuPortal.Models
{
    public class Duyurular
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public DateTime Tarih { get; set; }
        public string Icerik { get; set; } = string.Empty ;

    }
}
