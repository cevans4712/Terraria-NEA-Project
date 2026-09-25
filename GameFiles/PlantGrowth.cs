namespace TerrariaNEA
{
    public class PlantGrowth
    {
        public static void growGrass()
        {
            for(int x = Player.playerX - 80 ; x < Player.playerX + 80; x++)
            {
                for(int y = Player.playerY - 40; y < Player.playerX + 40; y++)
                {
                    if(x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                    {
                        if (Game.random.NextDouble() < 0.004f)
                        {
                            if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1)
                            {
                                int neighbours = PrimaryWorldGen.countAliveNeighbours(World.cellMap, x, y);
                                if (neighbours != 8 && Grass.isGrassNeighbours(x, y))
                                {
                                    World.blockMap[x, y] = 9;
                                    Grass.assignGrassValue(x, y, Grass.findAirNeighbours(x, y));
                                }
                                else
                                {
                                    World.blockMap[x, y] = 1;
                                    World.grassMap[x, y] = 0;
                                }
                            }
                        }
                    }
                }
            }
        }//if the current mud or dirt is neighboured by grass have a chance to become grass as well
        public static void growTrees()
        {
            for (int x = Player.playerX - 80; x < Player.playerX + 80; x++)
            {
                for (int y = Player.playerY - 40; y < Player.playerX + 40; y++)
                {
                    if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                    {
                        if (World.blockMap[x, y] == 22)
                        {
                            //every tick 1 in 10000 chance to try to grow each sapling
                            if (Game.random.NextSingle() < 0.0001f)
                            {
                                growTree(x, y);
                            }
                        }
                    }
                }
            }
        }//check for saplings and then randomly grows them into trees
        public static void growTree(int x, int y)
        {
            int treeHeight = Game.random.Next(8, 15);
            if(spaceToGrow(x, y, treeHeight))
            {
                for (int i = 0; i <= treeHeight; i++)
                {
                    World.blockMap[x, y - i] = 14;
                    World.spaceMap[x, y - i] = false;
                }
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int neighbourX = x + j;
                        int neighbourY = y - treeHeight + i;
                        if (World.cellMap[neighbourX, neighbourY] == false)
                        {
                            World.blockMap[neighbourX, neighbourY] = 15;
                            World.spaceMap[neighbourX, neighbourY] = false;
                        }
                    }
                }
            }

        }//grows a tree from a sapling 
        public static bool spaceToGrow(int x, int y, int treeHeight)
        {
            const int leafLayer = 3;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = 5; j <= treeHeight + leafLayer; j++)
                {
                    if (!World.spaceMap[x + i, y - j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }//checks there is space to grow a tree
    }
}
