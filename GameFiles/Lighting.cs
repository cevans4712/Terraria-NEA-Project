namespace TerrariaNEA
{
    public class Lighting
    {
        public static void lightMapGenarator()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.lightBlocks[x, y])
                    {
                        World.lightMap[x, y] = 15;
                    }
                    else if (World.cellMap[x, y] == false)
                    {
                        int light = findBrightestNeighbour(x, y) - 1;
                        if (light < 0)
                        {
                            light = 0;
                        }
                        World.lightMap[x, y] = Convert.ToByte(light);
                    }
                    else if (World.cellMap[x, y] == true)
                    {
                        int light = findBrightestNeighbour(x, y) - 3;
                        if (light < 0)
                        {
                            light = 0;
                        }
                        World.lightMap[x, y] = Convert.ToByte(light);
                    }
                }
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    World.lastLightMap[x, y] = World.lightMap[x, y];
                }
            }
        }//initially generating the lighting for the whole map
        public static void updateLightMap()
        {
            for (int x = Player.playerX - 50; x < Player.playerX + 50; x++)
            {
                for (int y = Player.playerY - 34; y < Player.playerY + 34; y++)
                {
                    if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                    {
                        World.lightBlocks[x, y] = false;
                        setLight(x, y);
                    }
                }
            }
            for (int x = Player.playerX - 50; x < Player.playerX + 50; x++)
            {
                for (int y = Player.playerY - 34; y < Player.playerY + 34; y++)
                {
                    if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                    {
                        World.lastLightMap[x, y] = World.lightMap[x, y];
                    }
                }
            }
        }//updates the lighting that is on the screen
        public static void setLight(int x, int y)
        {
            if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
            {
                if (Game.currentItem == 15)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            World.lightBlocks[Player.playerLocationX + i, Player.playerLocationY - j] = true;
                        }
                    }
                }
                if (World.blockMap[x, y] == 16 || (World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0 && World.backgroundMap[x, y] == 3))
                {
                    World.lightBlocks[x, y] = true;
                }
                if (!World.cellMap[x, y] && World.lavaMap[x, y] > 0.05f)
                {
                    World.lightBlocks[x, y] = true;
                }
                if (World.lightBlocks[x, y] || (World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0 && World.backgroundMap[x, y] == 4))
                {
                    World.lightMap[x, y] = 15;
                }
                if (!World.cellMap[x, y] && !World.lightBlocks[x, y])
                {
                    int light = findBrightestNeighbour(x, y) - 1;
                    if (light < 0)
                    {
                        light = 0;
                    }
                    if (World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0 && World.backgroundMap[x, y] == 4)
                    {
                        light = assignLightByTime(World.timeOfDay);
                    }
                    World.lightMap[x, y] = Convert.ToByte(light);
                }
                else if (World.cellMap[x, y] && !World.lightBlocks[x, y])
                {
                    int light = findBrightestNeighbour(x, y) - 3;
                    if (light < 0)
                    {
                        light = 0;
                    }
                    if (World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0 && World.backgroundMap[x, y] == 4)
                    {
                        light = assignLightByTime(World.timeOfDay);
                    }
                    World.lightMap[x, y] = Convert.ToByte(light);
                }
            }
        }// sets the value of light based on whether the block is solid or not how bright the brightest neighbour is
        public static byte assignLightByTime(int time)
        {
            byte light = 0;
            if (time >= 600 && time <= 1020)
            {
                if (light < 15)
                {
                    light = 15;
                }
            }
            else if (time >= 480 && time <= 1140)
            {
                if (light < 12)
                {
                    light = 12;
                }
            }
            else if (time >= 360 && time <= 1260)
            {
                if (light < 9)
                {
                    light = 9;
                }
            }
            else
            {
                if (light < 6)
                {
                    light = 6;
                }
            }
            return light;

        }// sets the light value of the sky based on teh time of day
        public static byte findBrightestNeighbour(int x, int y)
        {
            byte maxBrightness = 0;
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
                    }
                    else if (World.lastLightMap[neighbourX, neighbourY] > maxBrightness)
                    {
                        maxBrightness = World.lastLightMap[neighbourX, neighbourY];
                    }
                }
            }
            return maxBrightness;
        }//finds the brightest neighbouring cell
        public static void lightingTick(object state)
        {
            Game.lightCalculation = new Thread(() => updateLightMap());
            Game.lightCalculation.Start();
        }//seperate timer for lighting
        public static void lightBlocksGenerator()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.blockMap[x, y] == 0 && World.wallMap[x, y] == 0 && (World.backgroundMap[x, y] == 3 || World.backgroundMap[x, y] == 4))
                    {
                        World.lightBlocks[x, y] = true;
                    }
                }
            }
        }//if a block is a light source then true
    }
}
