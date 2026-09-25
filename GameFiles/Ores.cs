namespace TerrariaNEA
{
    public class Ores
    {
        public static void generateOres()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.cellMap[x, y] == true)
                    {
                        float oreChance = Game.random.NextSingle();
                        if (World.blockMap[x, y] == 1)
                        {
                            if (oreChance < 0.0003)
                            {
                                World.blockMap[x, y] = 5;
                            }
                            else if (oreChance < 0.0007)
                            {
                                World.blockMap[x, y] = 4;
                            }
                            else if(oreChance < 0.0014)
                            {
                                World.blockMap[x, y] = 2;
                            }
                        }
                        else if (World.blockMap[x, y] == 2)
                        {
                            if (oreChance < 0.0002)
                            {
                                World.blockMap[x, y] = 7;
                            }
                            else if (oreChance < 0.0004)
                            {
                                World.blockMap[x, y] = 6;
                            }
                            else if (oreChance < 0.0008)
                            {
                                World.blockMap[x, y] = 5;
                            }
                            else if (oreChance < 0.0016)
                            {
                                World.blockMap[x, y] = 4;
                            }
                            else if(oreChance < 0.0017)
                            {
                                World.blockMap[x, y] = 30;
                            }
                        }
                        else if (World.blockMap[x, y] == 3)
                        {
                            if (oreChance < 0.001)
                            {
                                World.blockMap[x, y] = 8;
                            }
                        }

                    }
                }
            }
        }//randomly places a single ore
        public static int[] countOreNeighbours(int x, int y)
        {
            int stoneCount = 0;
            int copperCount = 0;
            int ironCount = 0;
            int silverCount = 0;
            int goldCount = 0;
            int hellstoneCount = 0;
            int demoniteCount = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = x + i;
                    int neighbourY = y + j;
                    if (i == 0 && j == 0)
                    {
                    }
                    else if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight)
                    {
                    }
                    else
                    {
                        if (World.blockMap[neighbourX, neighbourY] == 2 && neighbourY < World.dirtHeight[neighbourX])
                        {
                            stoneCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 4)
                        {
                            copperCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 5)
                        {
                            ironCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 6)
                        {
                            silverCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 7)
                        {
                            goldCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 8)
                        {
                            hellstoneCount++;
                        }
                        else if (World.blockMap[neighbourX, neighbourY] == 30)
                        {
                            demoniteCount++;
                        }
                    }
                }
            }
            int[] oreCounts = {stoneCount, copperCount, ironCount, silverCount, goldCount, hellstoneCount, demoniteCount };
            return oreCounts;
        }// counts how many of each ore is a neighbour to each cell
        public static void expandOres()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    int[] oreCounts = countOreNeighbours(x, y);
                    int stoneCount = oreCounts[0];
                    int copperCount = oreCounts[1];
                    int ironCount = oreCounts[2];
                    int silverCount = oreCounts[3];
                    int goldCount = oreCounts[4];
                    int hellstoneCount = oreCounts[5];
                    int demoniteCount = oreCounts[6];
                    if(stoneCount != 0)
                    {
                        if (stoneCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 2;
                            }
                        }
                    }
                    if (copperCount != 0)
                    {
                        if (copperCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 4;
                            }
                        }
                    }
                    if (ironCount != 0)
                    {
                        if (ironCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 5;
                            }
                        }
                    }
                    if (silverCount != 0)
                    {
                        if (silverCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 6;
                            }
                        }
                    }
                    if (goldCount != 0)
                    {
                        if (goldCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 7;
                            }
                        }
                    }
                    if (hellstoneCount != 0)
                    {
                        if (hellstoneCount * 12.5 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 8;
                            }
                        }
                    }
                    if (demoniteCount != 0)
                    {
                        if (hellstoneCount * 1.25 / 100 >= Game.random.NextSingle())
                        {
                            if (World.cellMap[x, y] == true)
                            {
                                World.updatedBlockMap[x, y] = 8;
                            }
                        }
                    }
                }
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    World.blockMap[x, y] = World.updatedBlockMap[x, y];
                }
            }
        }//grows the ore veins randomly based on how many neighbours are the same ore
    }
}
