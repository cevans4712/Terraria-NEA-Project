namespace TerrariaNEA
{
    public class BlockGravity
    {
        public static void settleSand()
        {
            for(int i = 0; i < 100; i++)
            {
                for(int x = 0; x < World.worldWidth; x++)
                {
                    for(int y = 0; y < World.worldHeight; y++)
                    {
                        if (y + 1 != World.worldHeight)
                        {
                            if(World.blockMap[x, y] == 17)
                            {
                                if (!World.cellMap[x, y + 1])
                                {
                                    World.blockMap[x, y + 1] = 17;
                                    World.cellMap[x, y + 1] = true;
                                    World.spaceMap[x, y + 1] = false;
                                }
                            }
                        }
                    }
                }
            }
        }//upon world generation make sure no sand is floating by filling in the gaps below
        public static void sandGravity()
        {
            for(int i = Player.playerX - 100; i < Player.playerX + 100; i++)
            {
                for(int j = World.worldHeight - 1; j >= 0; j--)
                {
                    if(i >= 0 && i < World.worldWidth)
                    {
                        if (World.blockMap[i, j] == 17)
                        {
                            if (j + 1 != World.worldHeight && i >= 0 && i < World.worldWidth)
                            {
                                if (!World.cellMap[i, j + 1])
                                {
                                    World.blockMap[i, j] = 0;
                                    World.cellMap[i, j] = false;
                                    World.spaceMap[i, j] = true;
                                    World.blockMap[i, j + 1] = 17;
                                    World.cellMap[i, j + 1] = true;
                                    World.spaceMap[i, j + 1] = false;
                                    BlockHealth.blockHealthUpdater(i, j + 1);
                                }
                            }
                        }
                    }
                }
            }
        }//if sand is floating remove the block from its current position and place it one lower
    }
}
