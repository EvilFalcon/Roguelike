namespace Sources.Game.BoundedContexts.Players.Interfaces
{
    public interface IPlayer
    {
        public int Money { get ;}

        public int AttackModifier{ get ;}

        public int ArmorModifier{ get ;}

        public int AttackDelay{ get ;}
        public int HealthModifier{ get ;}
    }
}