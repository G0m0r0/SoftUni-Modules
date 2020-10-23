namespace BattleCards2.Data
{
    public class UserCard
    {
        public virtual Card Card { get; set; }
        public int CardId { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}
