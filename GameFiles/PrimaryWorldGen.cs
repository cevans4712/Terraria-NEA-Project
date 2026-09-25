namespace TerrariaNEA
{
    public class PrimaryWorldGen
    {
        public static bool[,] initialiseMap(bool[,] map)
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.cellMap[x, y] == false)
                    {
                        World.chanceToStartAlive = 0f;
                    }
                    else if (y < 350)
                    {
                        World.chanceToStartAlive = 0.55f;
                    }
                    else if (y < 900)
                    {
                        World.chanceToStartAlive = 0.5f;
                    }
                    else if (y < 970)
                    {
                        World.chanceToStartAlive = 0.3f;
                    }
                    else
                    {
                        World.chanceToStartAlive = 0.6f;
                    }
                    if (Game.random.NextDouble() < World.chanceToStartAlive)
                    {
                        map[x, y] = true;
                    }
                    else
                    {
                        map[x, y] = false;
                    }
                }
            }
            return map;
        }//randomly generates cells based on their depth
        public static int countAliveNeighbours(bool[,] map, int x, int y)
        {
            int count = 0;
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
                        count++;
                    }
                    else if (map[neighbourX, neighbourY])
                    {
                        count++;
                    }
                }
            }
            return count;
        }// count the amount of alive neighbours
        public static bool[,] doSimulationStep(bool[,] oldMap)
        {
            bool[,] newMap = new bool[World.worldWidth, World.worldHeight];
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    int neighboursCount = countAliveNeighbours(oldMap, x, y);
                    if (oldMap[x, y])
                    {
                        if (neighboursCount < 4)
                        {
                            newMap[x, y] = false;
                        }
                        else
                        {
                            newMap[x, y] = true;
                        }
                    } 
                    else
                    {
                        if (neighboursCount > 4)
                        {
                            newMap[x, y] = true;
                        }
                        else
                        {
                            newMap[x, y] = false;
                        }
                    }
                }
            }
            return newMap;
        }//generate random cave structure
        public static void generateTerrain()
        {
            int[] columnHeight = new int[World.worldWidth];
            for (int i = 0; i < World.worldWidth; i++)
            {
                if (Math.Abs(Player.playerX - i) < 50)
                {
                    columnHeight[i] = 850;
                }
                else
                {
                    columnHeight[i] = Game.random.Next(800, 900);
                }
            }
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < World.worldWidth - 1; j++)
                {
                    columnHeight[j] = Convert.ToInt16((columnHeight[j] + columnHeight[j + 1]) / 2);
                }
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.worldHeight - y - columnHeight[x] <= 0)
                    {
                        World.cellMap[x, y] = true;
                    }
                    else
                    {
                        World.cellMap[x, y] = false;
                    }
                }
            }
        }//adds hills to the map
        public static void generateCaves()
        {
            for (int i = 0; i < World.worldWidth; i++)
            {
                if (Math.Abs(Player.playerX - i) < 75)
                {
                    World.caveChance[i] = 0;
                }
                else
                {
                    World.caveChance[i] = 0.005f;
                }
            }
            for (int i = 0; i < World.worldWidth; i++)
            {
                if (World.caveChance[i] > Game.random.NextSingle())
                {
                    int caveWidth = Game.random.Next(7, 11);
                    float caveChanceRight = Convert.ToSingle(Game.random.Next(0, 2));
                    for (int j = 0; j < World.worldHeight; j++)
                    {
                        for (int k = 0; k < caveWidth; k++)
                        {
                            if (caveChanceRight > Game.random.NextSingle())
                            {
                                i += 5;
                                caveChanceRight -= Game.random.NextSingle();
                            }
                            else
                            {
                                i -= 5;
                                caveChanceRight += Game.random.NextSingle();
                            }
                            if (i + k > World.worldWidth - 25)
                            {
                                caveChanceRight = 0;
                            }
                            else
                            {
                                if (i + k < 25)
                                {
                                    caveChanceRight = 1;
                                }
                                else
                                {
                                    World.cellMap[i + k, j] = false;
                                }
                            }
                        }
                    }
                }
            }
        }//generates random cave systems in the world
    }
}
