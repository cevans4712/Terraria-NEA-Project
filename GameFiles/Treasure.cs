namespace TerrariaNEA
{
    public class Treasure
    {
        public static void generatePots()
        {
            for(int x = 0; x < World.worldWidth; x++)
            {
                for(int y = 0; y < World.worldHeight; y++)
                {
                    if(spaceForPot(x, y))
                    {
                        if(Game.random.NextDouble() < 0.1d)
                        {
                            generatePot(x, y);
                        }
                    }
                }
            }
        }//places pots randomly in the world
        public static void generatePot(int x, int y)
        {
            World.blockMap[x, y] = 35;
            World.spaceMap[x, y] = false;
        }//generates a pot
        public static bool spaceForPot(int x, int y)
        {
            try
            {
                if (World.blockMap[x, y] == 0 && World.cellMap[x, y + 1])
                {
                    if (World.backgroundMap[x, y] == 4 && World.wallMap[x, y] == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch { }
            return false;
        }//checks if a pot can be placed
        public static ushort generateChests(ushort index)
        {
            float chestSpawnChance;
            for (int x = 2; x < World.worldWidth - 2; x++)
            {
                for (int y = 2; y < World.worldHeight - 2; y++)
                {
                    if (y < World.dirtHeight[x])
                    {
                        chestSpawnChance = 0.015f;
                    }
                    else
                    {
                        chestSpawnChance = 0.00025f;
                    }
                    if (spaceForTreasure(x, y))
                    {
                        if (Game.random.NextSingle() < chestSpawnChance)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = -1; j < 1; j++)
                                {
                                    World.chestMap[x + i, y + j] = index;
                                    World.blockMap[x + i, y + j] = 10;
                                    World.spaceMap[x + i, y + j] = false;
                                }
                            }
                            index++;
                        }
                    }
                }
            }
            return index;

        }//places chests randomly in the world
        public static void fillChests(ushort index)
        {
            for (ushort i = 1; i <= index; i++)
            {
                fillChest(i);
            }
        }//fills all the chests in the world upon generation
        public static void fillChest(ushort i)
        {
            Chest chest = new Chest();
            chest.ID = i;
            //adding items to each chest
            for (int j = 0; j < 40; j++)
            {
                chest.StoredItems[j] = Convert.ToByte(Game.random.Next(0, 78));
                chest.StoredItemsQuantity[j] = Game.random.Next(1, Game.items[chest.StoredItems[j]].Stack + 1);
            }
            Game.chests[i] = chest;
        }//fills a chest with items
        public static void chestSpawn()
        {
            ushort index = 1;
            index = generateChests(index);
            fillChests(index);
        }//randomly places chests
        public static void lifeCrystalSpawn()
        {
            float lifeCrystalSpawnChance;
            for (int x = 2; x < World.worldWidth - 2; x++)
            {
                for (int y = 2; y < World.worldHeight - 2; y++)
                {
                    //cant spawn at dirt level
                    if (y < World.dirtHeight[x])
                    {
                        lifeCrystalSpawnChance = 0f;
                    }
                    //sets chance to spawn
                    else
                    {
                        lifeCrystalSpawnChance = 0.0025f;
                    }
                    //if space
                    if (spaceForTreasure(x, y))
                    {
                        //generates life crystal
                        if (Game.random.NextSingle() < lifeCrystalSpawnChance)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = -1; j < 1; j++)
                                {
                                    World.blockMap[x + i, y + j] = 26;
                                    World.spaceMap[x + i, y + j] = false;
                                }
                            }
                        }
                    }
                }
            }
        }//randomly places life crystals
        public static bool spaceForTreasure(int x, int y)
        {
            //check if a 2x2 space is available
            for (int i = 0; i < 2; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (World.blockMap[x + i, y + j] != 0)
                    {
                        return false;
                    }
                }
            }
            //cant spawn next to another treasure
            for (int i = -1; i < 3; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (World.blockMap[x + i, y + j] == 10 || World.blockMap[x + i, y + j] == 26 || World.blockMap[x + i, y + j] == 29)
                    {
                        return false;
                    }
                }
            }
            //check if there is an available floor
            for (int i = 0; i < 2; i++)
            {
                if (!World.cellMap[x + i, y + 1])
                {
                    return false;
                }
            }
            //cant spawn when background is sky with no wall
            if (World.wallMap[x, y] == 0 && World.backgroundMap[x, y] == 4)
            {
                return false;
            }
            return true;
        }//checks whether there is a 2x2 block space for a  2x2 treasure to go
        public static void demonAlterSpawn()
        {
            float demonAlterSpawnChance;
            for (int x = 2; x < World.worldWidth - 2; x++)
            {
                for (int y = 2; y < World.worldHeight - 2; y++)
                {
                    //cant spawn above y = 200
                    if (y < 200)
                    {
                        demonAlterSpawnChance = 0f;
                    }
                    //sets chance to spawn
                    else
                    {
                        //very high spawn chance in corruption
                        if (World.biomeMap[x, y] == 3)
                        {
                            demonAlterSpawnChance = 0.2f;
                        }
                        else
                        {
                            demonAlterSpawnChance = 0.0025f;
                        }
                    }
                    //if space
                    if (spaceForTreasure(x, y))
                    {
                        //generates demon alter
                        if (Game.random.NextSingle() < demonAlterSpawnChance)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = -1; j < 1; j++)
                                {
                                    World.blockMap[x + i, y + j] = 29;
                                    World.spaceMap[x + i, y + j] = false;
                                }
                            }
                        }
                    }
                }
            }
        }//randomly places demon alters
        public static void hellForgeSpawn()
        {
            float hellForgeSpawnChance;
            for (int x = 2; x < World.worldWidth - 2; x++)
            {
                for (int y = 2; y < World.worldHeight - 2; y++)
                {
                    //sets chance to spawn
                    if (World.biomeMap[x, y] == 7)//can only spawn in underworld
                    {
                        hellForgeSpawnChance = 0.005f;
                    }
                    else
                    {
                        hellForgeSpawnChance = 0f;
                    }
                    //if space
                    if (spaceForTreasure(x, y))
                    {
                        //generates hell forge
                        if (Game.random.NextSingle() < hellForgeSpawnChance)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = -1; j < 1; j++)
                                {
                                    World.blockMap[x + i, y + j] = 31;
                                    World.spaceMap[x + i, y + j] = false;
                                }
                            }
                        }
                    }
                }
            }
        }//randomly places hellforges in the underworld
    }
}
