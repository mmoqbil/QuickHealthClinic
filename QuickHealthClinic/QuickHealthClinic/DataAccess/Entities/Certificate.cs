namespace QuickLifeCoachingClinic.DataAccess.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public virtual Mentor Mentor { get; set; }
        public string Filename { get; set; } = null!;
    }
}
