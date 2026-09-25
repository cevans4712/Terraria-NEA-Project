namespace TerrariaNEA
{
    public class SecondaryWorldGen
    {
        public static void generateDirtLayer()
        {
            for (int i = 0; i < World.worldWidth; i++)
            {
                World.dirtHeight[i] = Game.random.Next(650, 750);
            }
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < World.worldWidth - 1; j++)
                {
                    World.dirtHeight[j] = Convert.ToInt16((World.dirtHeight[j] + World.dirtHeight[j + 1]) / 2);
                }
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.worldHeight - y - World.dirtHeight[x] > 0 && y >= World.surfaceHeight[x])
                    {
                        if (World.cellMap[x, y] == true)
                        {
                            World.blockMap[x, y] = 1;
                            World.updatedBlockMap[x, y] = 1;
                            World.wallMap[x, y] = 1;
                            World.updatedWallMap[x, y] = 1;
                        }
                        else
                        {
                            World.wallMap[x, y] = 1;
                            World.updatedWallMap[x, y] = 1;
                        }
                    }
                }
            }
        }//creates the layer of dirt
        public static void generateStoneLayer()
        {
            for (int i = 0; i < World.worldWidth; i++)
            {
                World.stoneHeight[i] = Game.random.Next(100, 200);
            }
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < World.worldWidth - 1; j++)
                {
                    World.stoneHeight[j] = Convert.ToInt16((World.stoneHeight[j] + World.stoneHeight[j + 1]) / 2);
                }
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.worldHeight - y - World.stoneHeight[x] > 0 && World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0)
                    {
                        if (World.cellMap[x, y] == true)
                        {
                            World.blockMap[x, y] = 2;
                            World.updatedBlockMap[x, y] = 2;
                        }
                    }
                }
            }
        }//creates the layer of stone
        public static void generateAshLayer()
        {
            for (int i = 0; i < World.worldWidth; i++)
            {
                World.ashHeight[i] = Game.random.Next(0, 0);
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.worldHeight - y - World.ashHeight[x] > 0 && World.blockMap[x, y] == 0)
                    {
                        if (World.cellMap[x, y] == true)
                        {
                            World.blockMap[x, y] = 3;
                            World.updatedBlockMap[x, y] = 3;
                        }
                    }
                }
            }
        }//creates the layer of ash
        public static void generateBlocks()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.cellMap[x, y] == true)
                    {
                        World.surfaceHeight[x] = y;
                        break;
                    }
                }
            }
            generateDirtLayer();
            generateStoneLayer();
            generateAshLayer();
        }//assigns a block id to each cell based on what block it is
        public static void generateBackgrounds()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (y < 200)
                    {
                        World.backgroundMap[x, y] = 4;
                    }
                    else if (y < 400)
                    {
                        World.backgroundMap[x, y] = 1;
                    }
                    else if (y < 850)
                    {
                        World.backgroundMap[x, y] = 2;
                    }
                    else
                    {
                        World.backgroundMap[x, y] = 3;
                    }
                }
            }
        }// generates the background based on depth 
    }
}