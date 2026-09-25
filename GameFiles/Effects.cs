namespace TerrariaNEA
{
    public class Effects
    {
        public static bool performItemEffects(byte effect)
        {
            bool canBeUsed = true;
            switch (effect)
            {
                case 1: 
                    if(Game.eyeOfCthulhu == null && World.timeOfDay >= 1140 || World.timeOfDay <= 480)
                    {
                        NPCBehavior.spawnNPC(11);
                    }
                    else
                    {
                        canBeUsed = false;
                    }
                    break;
                case 2:
                    if(Player.maxHealth < 400)
                    {
                        Player.maxHealth += 20;
                        Player.health += 20;
                    }
                    else
                    {
                        canBeUsed = false;
                    }
                    break;
            }
            return canBeUsed;
        }//when a consumable item is used activate its effect. returns if the item was able to be used
        public static void performBlockEffects()
        {
            if(Player.playerLocationY < World.worldWidth)
            {
                if (World.blockMap[Player.playerLocationX, Player.playerLocationY] == 8 || World.blockMap[Player.playerLocationX + 1, Player.playerLocationY] == 8)
                {
                    Player.takeDamage(3);
                    Player.immunity = 0;
                }
            }
        }//checks if the player is in contact with a block that causes an effect(e.g. hellstone causes the player to burn)
    }
}
