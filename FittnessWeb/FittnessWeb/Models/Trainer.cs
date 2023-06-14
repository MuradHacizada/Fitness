namespace FittnessWeb.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
    }
}
