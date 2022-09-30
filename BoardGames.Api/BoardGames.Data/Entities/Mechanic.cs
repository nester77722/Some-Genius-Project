namespace BoardGames.Data.Entities
{
    public class Mechanic : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Game>? Games { get; set; }
        public Image? Image { get; set; }
        public Guid? ImageId { get; set; }
    }
}
