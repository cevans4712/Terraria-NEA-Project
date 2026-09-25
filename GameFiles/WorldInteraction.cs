namespace TerrariaNEA
{
    public class WorldInteraction
    {
        public static bool checkNotFloating(int x, int y)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = x + i;
                    int neighbourY = y + j;
                    if (i == 0 && j == 0)
                    {
                    }
                    else if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight || Math.Abs(i) + Math.Abs(j) == 2)
                    {
                    }
                    else if (World.cellMap[neighbourX, neighbourY])
                    {
                        return true;
                    }
                }
            }
            return false;
        }//check a block wont be floating when placed
        public static bool checkWallNotFloating(int x, int y)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = x + i;
                    int neighbourY = y + j;
                    if (i == 0 && j == 0)
                    {
                    }
                    else if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight || Math.Abs(i) + Math.Abs(j) == 2)
                    {
                    }
                    else if (World.wallMap[neighbourX, neighbourY] != 0 || World.cellMap[neighbourX, neighbourY])
                    {
                        return true;
                    }
                }
            }
            return false;
        }//check a block wont be floating when placed
        public static bool checkOnWall(int x, int y)
        {
            if (World.wallMap[x, y] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//checks certain blocks are on a wall(eg torches)
        public static void wallDamaged(int x, int y)
        {
            World.wallHealth[x, y] -= Player.currentHammerPower;
            if (World.wallHealth[x, y] <= 0)
            {
                wallDestroyed(x, y);
            }
        }//wall being mined
        public static void wallDestroyed(int x, int y)
        {
            for (int i = 0; i < Game.items.Length; i++)
            {
                if (Game.items[i] != null)
                {
                    if (Game.items[i].BuildableWall == World.wallMap[x, y] && World.wallMap[x, y] != 0)
                    {
                        DroppedItemBehaviour.dropItem(Game.items[i].ID, 1, x + 40, y + 24);
                        break;
                    }
                }
            }
            World.wallMap[x, y] = 0;
        }//wall mined
        public static void blockDamaged(int x, int y)
        {
            if ((World.blockMap[x, y] == 9 && World.blockMap[x, y - 1] == 14) == false)
            {
                if ((World.blockMap[x, y - 1] == 10 && World.blockMap[x, y] != 10) == false)
                {
                    if (World.blockMap[x, y] == 14 || World.blockMap[x, y] == 15)
                    {
                        World.blockHealth[x, y] -= Player.currentAxePower;
                    }
                    else
                    {
                        World.blockHealth[x, y] -= Player.currentPickaxePower;
                    }
                }
            }
            float currentBlockHealth = World.blockHealth[x, y];
            float currentBlockTotalHealth = World.blockTotalHealth[x, y];
            if (currentBlockTotalHealth > 0)
            {
                float damage = currentBlockHealth / currentBlockTotalHealth;
                if (damage < 0.25)
                {
                    World.cracksMap[x, y] = 2;
                }
                else if (damage < 0.5)
                {
                    World.cracksMap[x, y] = 1;
                }
                else if (damage < 0.75)
                {
                    World.cracksMap[x, y] = 0;
                }
            }
            if (currentBlockHealth <= 0)
            {
                blockDestroyed(x, y);
            }
        }//block being mined
        public static void blockDestroyed(int x, int y)
        {
            World.cellMap[x, y] = false;//remove hitbox
            World.spaceMap[x, y] = true;//a block can be placed
            World.cracksMap[x, y] = 3;
            if (World.blockMap[x, y - 1] == 14 || World.blockMap[x, y - 1] == 15)
            {
                while (World.blockMap[x, y - 1] == 14 || World.blockMap[x, y - 1] == 15)
                {
                    if(World.blockMap[x, y - 1] == 14)
                    {
                        blockDestroyed(x, y - 1);
                    }
                    else
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            if (World.blockMap[x + i, y - 1] == 15)
                            {
                                blockDestroyed(x + i, y - 1);
                            }
                        }
                    }
                }
            }
            else if (World.blockMap[x, y] == 10 || World.blockMap[x, y] == 24 || World.blockMap[x, y] == 26 || World.blockMap[x, y] == 31 || World.blockMap[x, y] == 32)
            {
                break2x2(x, y);
            }
            else if(World.blockMap[x, y] == 23 || World.blockMap[x, y] == 25)
            {
                break2x1(x, y);
            }
            else if (World.blockMap[x, y] == 33)
            {
                break1x2(x, y);
            }
            //change blocks into what they will drop(eg grass drops dirt)
            if (World.blockMap[x, y] == 9)
            {
                World.blockMap[x, y] = 1;
            }
            else if (World.blockMap[x, y] == 35)
            {
                byte item = Convert.ToByte(Game.random.Next(0, 78));
                int quantity = Game.random.Next(1, Game.items[item].Stack + 1);
                DroppedItemBehaviour.dropItem(item, quantity, x + 40, y + 24);
            }
            else if (World.blockMap[x, y] == 14)
            {
                World.blockMap[x, y] = 19;
                if(Game.random.NextDouble() < 0.1d)//10% chance to drop an acorn
                {
                    DroppedItemBehaviour.dropItem(33, 1, x + 40, y + 24);
                }
            }
            for (int i = 0; i < Game.items.Length; i++)
            {
                if (Game.items[i] != null)
                {
                    if (Game.items[i].Buildable == World.blockMap[x, y] && World.blockMap[x, y] != 0)
                    {
                        DroppedItemBehaviour.dropItem(Game.items[i].ID, 1, x + 40, y + 24);
                        break;
                    }
                }
            }
            World.blockMap[x, y] = 0;
            BlockHealth.blockHealthUpdater(x, y);
        }//block mined
        public static void blockBuilt(int x, int y)
        {
            if(Game.currentItem != 255)
            {
                if (Game.items[Game.currentItem].Buildable != 0)
                {
                    if(Game.items[Game.currentItem].Buildable != 23 && Game.items[Game.currentItem].Buildable != 24 && Game.items[Game.currentItem].Buildable != 25 && Game.items[Game.currentItem].Buildable != 10 && Game.items[Game.currentItem].Buildable != 31 && Game.items[Game.currentItem].Buildable != 32 && Game.items[Game.currentItem].Buildable != 33)
                    {
                        if (Game.items[Game.currentItem].HasHitbox)
                        {
                            World.cellMap[x, y] = true;
                        }
                        World.blockMap[x, y] = Game.items[Game.currentItem].Buildable;
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (Inventory.inventoryUsage[i, j])
                                {
                                    Inventory.inventoryQuantity[j * 10 + i]--;
                                    if (Inventory.inventoryQuantity[j * 10 + i] == 0)
                                    {
                                        Inventory.inventory[j * 10 + i] = 255;
                                    }
                                }
                            }
                        }
                        World.spaceMap[x, y] = false;
                        BlockHealth.blockHealthUpdater(x, y);
                    }
                    else if(Game.items[Game.currentItem].Buildable == 23 || Game.items[Game.currentItem].Buildable == 25)
                    {
                        build2x1(x, y);
                    }
                    else if (Game.items[Game.currentItem].Buildable == 24 || Game.items[Game.currentItem].Buildable == 10 || Game.items[Game.currentItem].Buildable == 31 || Game.items[Game.currentItem].Buildable == 32)
                    {
                        build2x2(x, y);
                    }
                    else if(Game.items[Game.currentItem].Buildable == 33)
                    {
                        build1x2(x, y);
                    }
                    FriendlyNPCManager.checkHousingAroundPlayer(x, y);
                }

            }
        }//block placed
        public static void wallBuilt(int x, int y)
        {
            if(Game.currentItem != 255)
            {
                if (Game.items[Game.currentItem].BuildableWall != 0)
                {
                    World.wallMap[x, y] = Game.items[Game.currentItem].BuildableWall;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Inventory.inventoryUsage[i, j])
                            {
                                Inventory.inventoryQuantity[j * 10 + i]--;
                                if (Inventory.inventoryQuantity[j * 10 + i] == 0)
                                {
                                    Inventory.inventory[j * 10 + i] = 255;
                                }
                            }
                        }
                    }
                    BlockHealth.wallHealthUpdater(x, y);
                    FriendlyNPCManager.checkHousingAroundPlayer(x, y);
                }

            }
        }//wall placed
        public static void break2x2(int x, int y)
        {
            byte blockToBeBroken = World.blockMap[x, y];
            for (int i = 0; i < Game.items.Length; i++)
            {
                if (Game.items[i] != null)
                {
                    if (Game.items[i].Buildable == World.blockMap[x, y] && World.blockMap[x, y] != 0)
                    {
                        DroppedItemBehaviour.dropItem(Game.items[i].ID, 1, x + 40, y + 24);
                        break;
                    }
                }
            }
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = x + i;
                    int neighbourY = y + j;
                    if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight)
                    {
                    }
                    else if (World.blockMap[neighbourX, neighbourY] == blockToBeBroken)
                    {
                        World.blockMap[neighbourX, neighbourY] = 0;
                        World.spaceMap[neighbourX, neighbourY] = true;
                        BlockHealth.blockHealthUpdater(neighbourX, y);
                    }
                }
            }
        }//when a 2x2 block is broken, it breaks the whole thing
        public static void break2x1(int x, int y)
        {
            for (int i = 0; i < Game.items.Length; i++)
            {
                if (Game.items[i] != null)
                {
                    if (Game.items[i].Buildable == World.blockMap[x, y] && World.blockMap[x, y] != 0)
                    {
                        DroppedItemBehaviour.dropItem(Game.items[i].ID, 1, x + 40, y + 24);
                        break;
                    }
                }
            }
            for (int i = -1; i < 2; i++)
            {
                int neighbourX = x + i;
                if (neighbourX < 0 || neighbourX >= World.worldWidth)
                {
                }
                else if (World.blockMap[neighbourX, y] == 23)
                {
                    World.blockMap[neighbourX, y] = 0;
                    World.spaceMap[neighbourX, y] = true;
                    BlockHealth.blockHealthUpdater(neighbourX, y);
                }
            }
        }//when a 2x1 block is broken, it breaks the whole thing
        public static void break1x2(int x, int y)
        {
            for (int i = 0; i < Game.items.Length; i++)
            {
                if (Game.items[i] != null)
                {
                    if (Game.items[i].Buildable == World.blockMap[x, y] && World.blockMap[x, y] != 0)
                    {
                        DroppedItemBehaviour.dropItem(Game.items[i].ID, 1, x + 40, y + 24);
                        break;
                    }
                }
            }
            for (int i = -1; i < 2; i++)
            {
                int neighbourY = y + i;
                if (neighbourY < 0 || neighbourY >= World.worldHeight)
                {
                }
                else if (World.blockMap[x, neighbourY] == 33)
                {
                    World.blockMap[x, neighbourY] = 0;
                    World.spaceMap[x, neighbourY] = true;
                    BlockHealth.blockHealthUpdater(x, neighbourY);
                }
            }
        }//when a 1x2 block is broken, it breaks the whole thing
        public static void build2x2(int x, int y)
        {
            if (World.cellMap[x, y + 1] && World.cellMap[x + 1, y + 1] && World.spaceMap[x, y] && World.spaceMap[x + 1, y] && World.spaceMap[x, y - 1] && World.spaceMap[x + 1, y - 1])
            {
                if (Game.items[Game.currentItem].HasHitbox)
                {
                    World.cellMap[x, y] = true;
                    World.cellMap[x + 1, y] = true;
                    World.cellMap[x, y - 1] = true;
                    World.cellMap[x + 1, y - 1] = true;
                }
                World.blockMap[x, y] = Game.items[Game.currentItem].Buildable;
                World.blockMap[x + 1, y] = Game.items[Game.currentItem].Buildable;
                World.blockMap[x, y - 1] = Game.items[Game.currentItem].Buildable;
                World.blockMap[x + 1, y - 1] = Game.items[Game.currentItem].Buildable;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Inventory.inventoryUsage[i, j])
                        {
                            Inventory.inventoryQuantity[j * 10 + i]--;
                            if (Inventory.inventoryQuantity[j * 10 + i] == 0)
                            {
                                Inventory.inventory[j * 10 + i] = 255;
                            }
                        }
                    }
                }
                World.spaceMap[x, y] = false;
                World.spaceMap[x + 1, y] = false;
                BlockHealth.blockHealthUpdater(x, y);
                BlockHealth.blockHealthUpdater(x + 1, y);
                World.spaceMap[x, y - 1] = false;
                World.spaceMap[x + 1, y - 1] = false;
                BlockHealth.blockHealthUpdater(x, y - 1);
                BlockHealth.blockHealthUpdater(x + 1, y - 1);
            }
        }//builds a 2x2 block from the bottom left
        public static void build1x2(int x, int y)
        {
            if (World.cellMap[x, y + 1] && World.spaceMap[x, y] && World.spaceMap[x, y - 1])
            {
                if (Game.items[Game.currentItem].HasHitbox)
                {
                    World.cellMap[x, y] = true;
                    World.cellMap[x, y - 1] = true;
                }
                World.blockMap[x, y] = Game.items[Game.currentItem].Buildable;
                World.blockMap[x, y - 1] = Game.items[Game.currentItem].Buildable;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Inventory.inventoryUsage[i, j])
                        {
                            Inventory.inventoryQuantity[j * 10 + i]--;
                            if (Inventory.inventoryQuantity[j * 10 + i] == 0)
                            {
                                Inventory.inventory[j * 10 + i] = 255;
                            }
                        }
                    }
                }
                World.spaceMap[x, y] = false;
                World.spaceMap[x, y - 1] = false;
                BlockHealth.blockHealthUpdater(x, y);
                BlockHealth.blockHealthUpdater(x, y - 1);
            }
        }//builds a 2x2 block from the bottom
        public static void build2x1(int x, int y)
        {
            if (World.cellMap[x, y + 1] && World.cellMap[x + 1, y + 1] && World.spaceMap[x, y] && World.spaceMap[x + 1, y])
            {
                if (Game.items[Game.currentItem].HasHitbox)
                {
                    World.cellMap[x, y] = true;
                    World.cellMap[x + 1, y] = true;
                }
                World.blockMap[x, y] = Game.items[Game.currentItem].Buildable;
                World.blockMap[x + 1, y] = Game.items[Game.currentItem].Buildable;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Inventory.inventoryUsage[i, j])
                        {
                            Inventory.inventoryQuantity[j * 10 + i]--;
                            if (Inventory.inventoryQuantity[j * 10 + i] == 0)
                            {
                                Inventory.inventory[j * 10 + i] = 255;
                            }
                        }
                    }
                }
                World.spaceMap[x, y] = false;
                World.spaceMap[x + 1, y] = false;
                BlockHealth.blockHealthUpdater(x, y);
                BlockHealth.blockHealthUpdater(x + 1, y);
            }
        }//builds a 2x2 block from the left
    }
}
