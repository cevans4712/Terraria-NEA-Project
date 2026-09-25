namespace TerrariaNEA
{
    public class NPC
    {
        //class contains all data about all npcs
        protected int id;
        protected string name;
        protected int totalHealth;
        protected int health;
        protected int sizeX;
        protected int sizeY;
        protected int locationX;
        protected int locationY;
        protected int damage;
        protected int immunity;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int TotalHealth
        {
            get { return totalHealth; }
            set { totalHealth = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int SizeX
        {
            get { return sizeX; }
            set { sizeX = value; }
        }
        public int SizeY
        {
            get { return sizeY; }
            set { sizeY = value; }
        }
        public int LocationX
        {
            get { return locationX; }
            set { locationX = value; }
        }
        public int LocationY
        {
            get { return locationY; }
            set { locationY = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Immunity
        {
            get { return immunity; }
            set { immunity = value; }
        }
        public void DropItems()
        {
            switch (id)
            {
                case 1:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(10, 16), locationX + 41, locationY + 21);
                    break;
                case 2:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(20, 31), locationX + 41, locationY + 21);
                    break;
                case 3:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(50, 61), locationX + 41, locationY + 21);
                    break;
                case 4:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(70, 81), locationX + 41, locationY + 21);
                    break;
                case 5:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(25, 36), locationX + 41, locationY + 21);
                    break;
                case 6:
                    DroppedItemBehaviour.dropItem(21, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(80, 91), locationX + 41, locationY + 21);
                    break;
                case 7:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(85, 116), locationX + 41, locationY + 21);
                    break;
                case 8:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(95, 131), locationX + 41, locationY + 21);
                    break;
                case 9:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(80, 111), locationX + 41, locationY + 21);
                    break;
                case 10:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(170, 201), locationX + 41, locationY + 21);
                    break;
                case 11:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(30000, 50000), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(60, Game.random.Next(120, 220), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(67, Game.random.Next(50, 100), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(59, Game.random.Next(2, 4), locationX + 41, locationY + 21);
                    break;
                case 12:
                    DroppedItemBehaviour.dropItem(17, Game.random.Next(85, 116), locationX + 41, locationY + 21);
                    DroppedItemBehaviour.dropItem(59, 1, locationX + 41, locationY + 21);
                    break;
                case 13:
                    break;
            }
        }//upon npc death drop the items that correspond with what the npc is
    }
}
