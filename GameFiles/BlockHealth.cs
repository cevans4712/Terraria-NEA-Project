namespace TerrariaNEA
{
    public class BlockHealth
    {
        public static void wallHealthUpdater(int x, int y)
        {
            switch(World.wallMap[x, y])
            {
                case 1:
                    World.wallTotalHealth[x, y] = 50;
                    break;
                case 2:
                    World.wallTotalHealth[x, y] = 75;
                    break;
                case 3:
                    World.wallTotalHealth[x, y] = 50;
                    break;
                default:
                    World.wallTotalHealth[x, y] = 0;
                    break;
            }
            World.wallHealth[x, y] = World.wallTotalHealth[x, y];
        }//decides the health of a block when placed
        public static void blockHealthUpdater(int x, int y)
        {
            switch (World.blockMap[x, y])
            {
                case 1:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 2:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 3:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 4:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 5:
                    World.blockTotalHealth[x, y] = 125;
                    break;
                case 6:
                    World.blockTotalHealth[x, y] = 150;
                    break;
                case 7:
                    World.blockTotalHealth[x, y] = 175;
                    break;
                case 8:
                    World.blockTotalHealth[x, y] = 200;
                    break;
                case 9:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 10:
                    World.blockTotalHealth[x, y] = 150;
                    break;
                case 11:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 12:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 13:
                    World.blockTotalHealth[x, y] = 200;
                    break;
                case 14:
                    World.blockTotalHealth[x, y] = 75;
                    break;
                case 15:
                    World.blockTotalHealth[x, y] = 1;
                    break;
                case 17:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 18:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 19:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 20:
                    World.blockTotalHealth[x, y] = 75;
                    break;
                case 21:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 23:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 24:
                    World.blockTotalHealth[x, y] = 125;
                    break;
                case 25:
                    World.blockTotalHealth[x, y] = 125;
                    break;
                case 26:
                    World.blockTotalHealth[x, y] = 100;
                    break;
                case 27:
                    World.blockTotalHealth[x, y] = 250;
                    break;
                case 28:
                    World.blockTotalHealth[x, y] = 75;
                    break;
                case 29:
                    World.blockTotalHealth[x, y] = int.MaxValue;
                    break;
                case 30:
                    World.blockTotalHealth[x, y] = 200;
                    break;
                case 31:
                    World.blockTotalHealth[x, y] = 200;
                    break;
                case 32:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 33:
                    World.blockTotalHealth[x, y] = 50;
                    break;
                case 34:
                    World.blockTotalHealth[x, y] = 200;
                    break;
                default:
                    World.blockTotalHealth[x, y] = 0;
                    break;
            }
            World.blockHealth[x, y] = World.blockTotalHealth[x, y];
        }//decides the health of a block when placed
        public static void blockHealthGenerator()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    blockHealthUpdater(x, y);
                    wallHealthUpdater(x, y);
                }
            }
        }//the initial health of each block on the map
    }
}
