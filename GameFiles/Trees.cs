namespace TerrariaNEA
{
    public class Trees
    {
        public static void generateTrees()
        {
            float treeSpawnChance = 0.15f;
            for (int x = 3; x < World.worldWidth - 1; x++)
            {
                if (World.blockMap[x, World.surfaceHeight[x]] == 9 || World.blockMap[x, World.surfaceHeight[x]] == 17)
                {
                    if (Game.random.NextSingle() < treeSpawnChance && World.blockMap[x - 1, World.surfaceHeight[x - 1] - 1] != 14 && World.blockMap[x - 2, World.surfaceHeight[x - 2] - 1] != 14 && World.blockMap[x - 3, World.surfaceHeight[x - 3] - 1] != 14 && World.blockMap[x - 1, World.surfaceHeight[x - 1] - 1] != 20 && World.blockMap[x - 2, World.surfaceHeight[x - 2] - 1] != 20 && World.blockMap[x - 3, World.surfaceHeight[x - 3] - 1] != 20)
                    {
                        switch(World.blockMap[x, World.surfaceHeight[x]])
                        {
                            case 9:
                                World.blockMap[x, World.surfaceHeight[x] - 1] = 14;
                                World.spaceMap[x, World.surfaceHeight[x] - 1] = false;
                                break;
                            case 17:
                                World.blockMap[x, World.surfaceHeight[x] - 1] = 20;
                                World.spaceMap[x, World.surfaceHeight[x] - 1] = false;
                                break;
                        }
                    }
                }
            }
        }// places random stumps
        public static void treeHeightGenerator()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                World.treeHeight[x] = Convert.ToByte(Game.random.Next(7, 16));
            }
        }// generates a random height for each tree
        public static void growTrees()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                if (World.blockMap[x, World.surfaceHeight[x] - 1] == 14)
                {
                    for (int i = 0; i < World.treeHeight[x]; i++)
                    {
                        World.blockMap[x, World.surfaceHeight[x] - (1 + i)] = 14;
                        World.spaceMap[x, World.surfaceHeight[x] - (1 + i)] = false;
                    }
                }
                else if(World.blockMap[x, World.surfaceHeight[x] - 1] == 20)
                {
                    for (int i = 0; i < World.treeHeight[x]/2; i++)
                    {
                        World.blockMap[x, World.surfaceHeight[x] - (1 + i)] = 20;
                        World.spaceMap[x, World.surfaceHeight[x] - (1 + i)] = false;
                    }
                }
            }
        }//grows the trees based on their height
        public static void growLeaves()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                if (World.blockMap[x, World.surfaceHeight[x] - World.treeHeight[x]] == 14)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            int neighbourX = x + j;
                            int neighbourY = World.surfaceHeight[x] - World.treeHeight[x] + i;
                            if (World.cellMap[neighbourX, neighbourY] == false)
                            {
                                World.blockMap[neighbourX, neighbourY] = 15;
                                World.spaceMap[neighbourX, neighbourY] = false;
                            }
                        }
                    }
                }
            }
        }// grows leaves above the trees
    }
}
