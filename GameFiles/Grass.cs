namespace TerrariaNEA
{
    public class Grass
    {
        public static void generateGrass()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.blockMap[x, y] == 1 || World.blockMap[x, y] == 21)
                    {
                        int neighbours = PrimaryWorldGen.countAliveNeighbours(World.cellMap, x, y);
                        if (neighbours != 8)
                        {
                            World.blockMap[x, y] = 9;
                            assignGrassValue(x, y, findAirNeighbours(x, y));
                        }
                    }
                }
            }
        }//if a dirt block is next to air it becomes grass
        public static bool[] findAirNeighbours(int x, int y)
        {
            byte index = 0;
            bool[] airNeighbours = new bool[8];
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = x + j;
                    int neighbourY = y + i;
                    if (i == 0 && j == 0)
                    {
                    }
                    else if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight)
                    {
                        airNeighbours[index] = false;
                        index++;
                    }
                    else if (World.cellMap[neighbourX, neighbourY] == false)
                    {
                        airNeighbours[index] = true;
                        index++;
                    }
                    else
                    {
                        airNeighbours[index] = false;
                        index++;
                    }
                }
            }
            return airNeighbours;
        }// finds the neighbouring cells of a grass block
        public static void assignGrassValue(int x, int y, bool[] airNeighbours)
        {
            if (airNeighbours[1])
            {
                if (airNeighbours[3])
                {
                    if (airNeighbours[4])
                    {
                        if (airNeighbours[6])
                        {
                            World.grassMap[x, y] = 18;
                        }
                        else
                        {
                            World.grassMap[x, y] = 15;
                        }
                    }
                    else if (airNeighbours[6])
                    {
                        World.grassMap[x, y] = 12;
                    }
                    else if (airNeighbours[7])
                    {
                        World.grassMap[x, y] = 19;
                    }
                    else
                    {
                        World.grassMap[x, y] = 10;
                    }
                }
                else if (airNeighbours[4])
                {
                    if (airNeighbours[6])
                    {
                        World.grassMap[x, y] = 11;
                    }
                    else if (airNeighbours[5])
                    {
                        World.grassMap[x, y] = 20;
                    }
                    else
                    {
                        World.grassMap[x, y] = 8;
                    }
                }
                else if (airNeighbours[6])
                {
                    World.grassMap[x, y] = 9;
                }
                else if (airNeighbours[5])
                {
                    if (airNeighbours[7])
                    {
                        World.grassMap[x, y] = 42;
                    }
                    else
                    {
                        World.grassMap[x, y] = 34;
                    }
                }
                else if (airNeighbours[7])
                {
                    World.grassMap[x, y] = 35;
                }
                else
                {
                    World.grassMap[x, y] = 4;
                }
            }
            else if (airNeighbours[4])
            {
                if (airNeighbours[3])
                {
                    if (airNeighbours[6])
                    {
                        World.grassMap[x, y] = 16;
                    }
                    else
                    {
                        World.grassMap[x, y] = 14;
                    }
                }
                else if (airNeighbours[6])
                {
                    if (airNeighbours[0])
                    {
                        World.grassMap[x, y] = 21;
                    }
                    else
                    {
                        World.grassMap[x, y] = 13;
                    }
                }
                else if (airNeighbours[0])
                {
                    if (airNeighbours[5])
                    {
                        World.grassMap[x, y] = 43;
                    }
                    else
                    {
                        World.grassMap[x, y] = 36;
                    }
                }
                else if (airNeighbours[5])
                {
                    World.grassMap[x, y] = 37;
                }
                else
                {
                    World.grassMap[x, y] = 5;
                }
            }
            else if (airNeighbours[6])
            {
                if (airNeighbours[3])
                {
                    if (airNeighbours[2])
                    {
                        World.grassMap[x, y] = 22;
                    }
                    else
                    {
                        World.grassMap[x, y] = 17;
                    }
                }
                else if (airNeighbours[0])
                {
                    if (airNeighbours[2])
                    {
                        World.grassMap[x, y] = 44;
                    }
                    else
                    {
                        World.grassMap[x, y] = 39;
                    }
                }
                else if (airNeighbours[2])
                {
                    World.grassMap[x, y] = 38;
                }
                else
                {
                    World.grassMap[x, y] = 6;
                }
            }
            else if (airNeighbours[3])
            {
                if (airNeighbours[2])
                {
                    if (airNeighbours[7])
                    {
                        World.grassMap[x, y] = 45;
                    }
                    else
                    {
                        World.grassMap[x, y] = 40;
                    }
                }
                else if (airNeighbours[7])
                {
                    World.grassMap[x, y] = 41;
                }
                else
                {
                    World.grassMap[x, y] = 7;
                }
            }
            else if (airNeighbours[0])
            {
                if (airNeighbours[2])
                {
                    if (airNeighbours[5])
                    {
                        if (airNeighbours[7])
                        {
                            World.grassMap[x, y] = 33;
                        }
                        else
                        {
                            World.grassMap[x, y] = 32;
                        }
                    }
                    else if (airNeighbours[7])
                    {
                        World.grassMap[x, y] = 29;
                    }
                    else
                    {
                        World.grassMap[x, y] = 23;
                    }
                }
                else if (airNeighbours[5])
                {
                    if (airNeighbours[7])
                    {
                        World.grassMap[x, y] = 30;
                    }
                    else
                    {
                        World.grassMap[x, y] = 25;
                    }
                }
                else if (airNeighbours[7])
                {
                    World.grassMap[x, y] = 24;
                }
                else
                {
                    World.grassMap[x, y] = 0;
                }
            }
            else if (airNeighbours[2])
            {
                if (airNeighbours[7])
                {
                    if (airNeighbours[5])
                    {
                        World.grassMap[x, y] = 31;
                    }
                    else
                    {
                        World.grassMap[x, y] = 26;
                    }
                }
                else if (airNeighbours[5])
                {
                    World.grassMap[x, y] = 27;
                }
                else
                {
                    World.grassMap[x, y] = 1;
                }
            }
            else if (airNeighbours[7])
            {
                if (airNeighbours[5])
                {
                    World.grassMap[x, y] = 28;
                }
                else
                {
                    World.grassMap[x, y] = 2;
                }
            }
            else if (airNeighbours[5])
            {
                World.grassMap[x, y] = 3;
            }
        }// assigns the sprite that should be used based on its neighbours
        public static bool isGrassNeighbours(int x, int y)
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
                    else if (neighbourX < 0 || neighbourY < 0 || neighbourX >= World.worldWidth || neighbourY >= World.worldHeight)
                    {
                    }
                    else if (World.grassMap[neighbourX, neighbourY] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if the current blocks neighbour is grass
    }
}
