namespace TerrariaNEA
{
    public class Fluids
    {
        public static void addFluidsToWorld()
        {
            for(int x = 0; x < World.worldWidth; x++)
            {
                for(int y = 0; y < World.worldHeight; y++)
                {
                    if (!World.cellMap[x, y])
                    {
                        float chanceToPlaceWater = Game.random.NextSingle();
                        float chanceToPlaceLava = Game.random.NextSingle();
                        if (World.biomeMap[x, y] == 6)
                        {
                            if (y > 175)
                            {
                                World.waterMap[x, y] = 1f;
                            }
                        }
                        else if (World.biomeMap[x, y] == 3 || World.biomeMap[x, y] == 1)
                        {
                            //dont place water
                        }
                        else
                        {
                            if(y > 100)
                            {
                                if (chanceToPlaceWater < 0.0002)
                                {
                                    for (int i = 0; i < Game.random.Next(25, 100); i++)
                                    {
                                        if (y + i < World.worldHeight)
                                        {
                                            World.waterMap[x, y + i] = 1f;
                                        }
                                    }
                                }
                            }
                        }
                        if (y < 600)
                        {
                            //dont spawn lava
                        }
                        else if (y < 700)
                        {
                            if(chanceToPlaceLava < 0.01f)
                            {
                                World.lavaMap[x, y] = 1f;
                            }
                        }
                        else if (y < 800)
                        {
                            if(chanceToPlaceLava < 0.02f)
                            {
                                World.lavaMap[x, y] = 1f;
                            }
                        }
                        else if (y < 900)
                        {
                            if(chanceToPlaceLava < 0.04f)
                            {
                                World.lavaMap[x, y] = 1f;
                            }
                        }
                        else
                        {
                            if(chanceToPlaceLava < 0.08f)
                            {
                                World.lavaMap[x, y] = 1f;
                            }
                        }
                    }
                }
            }
        }//upon generation add lava and water to the world
        public static void updateFluids()
        {
            for(int x = Player.playerX - 50; x < Player.playerX + 50; x++)
            {
                for(int y = Player.playerY + 30; y > Player.playerY - 70; y--)
                {
                    fluidBehaviour(x, y);
                }
            }
        }//each tick control all the fluds around the player
        public static void settleFluids()
        {
            for(int x = 0; x < World.worldWidth; x++)
            {
                for(int y = 0; y < World.worldHeight; y++)
                {
                    fluidBehaviour(x, y);
                }
            }
        }//upon generation allow all the fluids to settle by updating them
        public static void removeCactusFromWater()
        {
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.waterMap[x, y] > 0.5f && World.blockMap[x, y] == 20)
                    {
                        for(int i = 0; i < 10; i++)
                        {
                            World.blockMap[x, y - i] = 0;
                        }
                    }
                }
            }
        }//upon generation if there is a cactus in water destroy it(to clear the oceans)
        public static bool waterCanMove(int x, int y)
        {
            if(y + 1 < World.worldHeight)
            {
                if(World.cellMap[x, y + 1] || World.waterMap[x, y + 1] == 1f)
                {
                    if (x - 1 >= 0)
                    {
                        if (World.cellMap[x - 1, y] || World.waterMap[x - 1, y] == 1f)
                        {
                            if(x + 1 < World.worldWidth)
                            {
                                if (World.cellMap[x + 1, y] || World.waterMap[x + 1, y] == 1f)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }//checks the water isnt trapped
        public static void fluidBehaviour(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < World.worldWidth && y < World.worldHeight)
            {
                if(!createObsidian(x, y))
                {
                    if (World.waterMap[x, y] != 0)
                    {
                        if (waterCanMove(x, y))
                        {
                            if (y + 1 < World.worldHeight)
                            {
                                //if space below is empty
                                if (Math.Abs(World.waterMap[x, y + 1] - 1f) < 0.001f || World.waterMap[x, y + 1] > 1f)
                                {
                                    World.waterMap[x, y + 1] = 1f;
                                }
                                if (y + 1 < World.worldHeight)
                                {
                                    if (World.cellMap[x, y + 1] == false && World.waterMap[x, y + 1] != 1f)
                                    {
                                        dropWater(x, y);
                                    }
                                    else
                                    {
                                        splitWater(x, y);
                                    }
                                }
                                //if there isnt space below
                                else
                                {
                                    splitWater(x, y);
                                }
                            }
                        }
                        if (World.biomeMap[x, y] == 7)
                        {
                            World.waterMap[x, y] /= 2;
                        }
                    }
                    if (World.lavaMap[x, y] != 0)
                    {
                        if (lavaCanMove(x, y))
                        {
                            if (y + 1 < World.worldHeight)
                            {
                                //if space below is empty
                                if (Math.Abs(World.lavaMap[x, y + 1] - 1f) < 0.001f || World.lavaMap[x, y + 1] > 1f)
                                {
                                    World.lavaMap[x, y + 1] = 1f;
                                }
                                if (y + 1 < World.worldHeight)
                                {
                                    if (World.cellMap[x, y + 1] == false && World.lavaMap[x, y + 1] != 1f)
                                    {
                                        dropLava(x, y);
                                    }
                                    else
                                    {
                                        splitLava(x, y);
                                    }
                                }
                                //if there isnt space below
                                else
                                {
                                    splitLava(x, y);
                                }
                            }
                        }
                    }
                }
            }
        }//controls how the fluid moves
        public static void splitWater(int x, int y)
        {
            float split = MathF.Round(World.waterMap[x, y] / 3f, 4);
            float original = split;
            //if block on left is empty
            if(x != 0)
            {
                if (World.cellMap[x - 1, y] == false)
                {
                    //if water on left is empty
                    if (World.waterMap[x - 1, y] == 0f)
                    {
                        World.waterMap[x - 1, y] = split;
                    }
                    else
                    {
                        float total = World.waterMap[x - 1, y] + split;
                        //if block wont overfill
                        if (total < 1f)
                        {
                            World.waterMap[x - 1, y] = total;
                        }
                        //if block overfills
                        else
                        {
                            World.waterMap[x - 1, y] = 1f;
                            original += MathF.Round(total - 1f, 4);
                        }
                    }
                }
                else
                {
                    original += split;
                }
            }
            else
            {
                original += split;
            }
            //if block on right is empty
            if(x != World.worldWidth - 1)
            {
                if (World.cellMap[x + 1, y] == false)
                {
                    //if water on right is empty
                    if (World.waterMap[x + 1, y] == 0f)
                    {
                        World.waterMap[x + 1, y] = split;
                    }
                    else
                    {
                        float total = World.waterMap[x + 1, y] + split;
                        //if block wont overfill
                        if (total < 1f)
                        {
                            World.waterMap[x + 1, y] = total;
                        }
                        //if block overfills
                        else
                        {
                            World.waterMap[x + 1, y] = 1f;
                            original += MathF.Round(total - 1f, 4);
                        }
                    }
                }
                else
                {
                    original += split;
                }
            }
            else
            {
                original += split;
            }
            original = MathF.Round(original, 4);
            World.waterMap[x, y] = original;
        }//splits the water with its 2 horizontal neighbours
        public static void dropWater(int x, int y)
        {
            //if water below is empty
            if (World.waterMap[x, y + 1] == 0f)
            {
                World.waterMap[x, y + 1] = World.waterMap[x, y];
                World.waterMap[x, y] = 0f;
            }
            //if there is water below
            else
            {
                float total = World.waterMap[x, y] + World.waterMap[x, y + 1];
                //if block wont overfill
                if (total < 1f)
                {
                    World.waterMap[x, y + 1] = MathF.Round(total, 4);
                    World.waterMap[x, y] = 0f;
                }
                //if block overfills
                else
                {
                    World.waterMap[x, y + 1] = 1f;
                    splitWater(x, y + 1);
                    World.waterMap[x, y] = MathF.Round(total - 1f, 4);
                }
            }
        }//drops the water below its current position
        public static void controlPlayerAroundWater()
        {
            if(playerInWater())
            {
                Player.slowWalking = true;
            }
            else if(!playerInLava())
            {
                Player.slowWalking = false;
            }
            if (playerUnderwater())
            {
                if(Player.breath > 0)
                {
                    Player.breath--;
                }
                else
                {
                    Player.takeDamage(2);
                    Player.immunity = 0;
                }
            }
            else
            {
                if(Player.breath < 100)
                {
                    Player.breath++;
                }
            }
        }//controls how the player interacts with water
        public static bool playerInWater()
        {
            for (int i = Player.playerLocationX; i < Player.playerLocationX + 2; i++)
            {
                for (int j = Player.playerLocationY - 3; j < Player.playerLocationY; j++)
                {
                    try
                    {
                        if (World.waterMap[i, j] > 0.25f)
                        {
                            return true;
                        }
                    }
                    catch { }
                }
            }
            return false;
        }//checks if the player is touching water
        public static bool playerUnderwater()
        {
            for(int i = Player.playerLocationX; i < Player.playerLocationX + 2; i++)
            {
                try
                {
                    if (World.waterMap[i, Player.playerLocationY - 3] > 0.5f)
                    {
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }//checks if the players head is under water
        public static void controlPlayerAroundLava()
        {
            if (playerInLava())
            {
                Player.slowWalking = true;
                Player.takeDamage(10);
                Player.immunity = 0;
            }
            else if (!playerInWater())
            {
                Player.slowWalking = false;
            }

        }//controls how the player interacts with lava
        public static bool playerInLava()
        {
            for (int i = Player.playerLocationX; i < Player.playerLocationX + 2; i++)
            {
                for (int j = Player.playerLocationY - 3; j < Player.playerLocationY; j++)
                {
                    try
                    {
                        if (World.lavaMap[i, j] > 0.05f)
                        {
                            return true;
                        }
                    }
                    catch { }
                }
            }
            return false;
        }//checks if the player is touching lava
        public static bool lavaCanMove(int x, int y)
        {
            if (y + 1 < World.worldHeight)
            {
                if (World.cellMap[x, y + 1] || World.lavaMap[x, y + 1] == 1f)
                {
                    if (x - 1 >= 0)
                    {
                        if (World.cellMap[x - 1, y] || World.lavaMap[x - 1, y] == 1f)
                        {
                            if (x + 1 < World.worldWidth)
                            {
                                if (World.cellMap[x + 1, y] || World.lavaMap[x + 1, y] == 1f)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }//checks the lava isnt trapped
        public static void splitLava(int x, int y)
        {
            float split = MathF.Round(World.lavaMap[x, y] / 3f, 4);
            float original = split;
            //if block on left is empty
            if (x != 0)
            {
                if (World.cellMap[x - 1, y] == false)
                {
                    //if lava on left is empty
                    if (World.lavaMap[x - 1, y] == 0f)
                    {
                        World.lavaMap[x - 1, y] = split;
                    }
                    else
                    {
                        float total = World.lavaMap[x - 1, y] + split;
                        //if block wont overfill
                        if (total < 1f)
                        {
                            World.lavaMap[x - 1, y] = total;
                        }
                        //if block overfills
                        else
                        {
                            World.lavaMap[x - 1, y] = 1f;
                            original += MathF.Round(total - 1f, 4);
                        }
                    }
                }
                else
                {
                    original += split;
                }
            }
            else
            {
                original += split;
            }
            //if block on right is empty
            if (x != World.worldWidth - 1)
            {
                if (World.cellMap[x + 1, y] == false)
                {
                    //if lava on right is empty
                    if (World.lavaMap[x + 1, y] == 0f)
                    {
                        World.lavaMap[x + 1, y] = split;
                    }
                    else
                    {
                        float total = World.lavaMap[x + 1, y] + split;
                        //if block wont overfill
                        if (total < 1f)
                        {
                            World.lavaMap[x + 1, y] = total;
                        }
                        //if block overfills
                        else
                        {
                            World.lavaMap[x + 1, y] = 1f;
                            original += MathF.Round(total - 1f, 4);
                        }
                    }
                }
                else
                {
                    original += split;
                }
            }
            else
            {
                original += split;
            }
            original = MathF.Round(original, 4);
            World.lavaMap[x, y] = original;
        }//splits the lava with its 2 horizontal neighbours
        public static void dropLava(int x, int y)
        {
            //if lava below is empty
            if (World.lavaMap[x, y + 1] == 0f)
            {
                World.lavaMap[x, y + 1] = World.lavaMap[x, y];
                World.lavaMap[x, y] = 0f;
            }
            //if there is lava below
            else
            {
                float total = World.lavaMap[x, y] + World.lavaMap[x, y + 1];
                //if block wont overfill
                if (total < 1f)
                {
                    World.lavaMap[x, y + 1] = MathF.Round(total, 4);
                    World.lavaMap[x, y] = 0f;
                }
                //if block overfills
                else
                {
                    World.lavaMap[x, y + 1] = 1f;
                    splitLava(x, y + 1);
                    World.lavaMap[x, y] = MathF.Round(total - 1f, 4);
                }
            }
        }//drops the lava to the position below it
        public static bool createObsidian(int x, int y)
        {
            if (World.waterMap[x, y] > 0.05f && World.lavaMap[x, y] > 0.05f)
            {
                World.waterMap[x, y] = 0;
                World.lavaMap[x, y] = 0;
                World.blockMap[x, y] = 34;
                World.spaceMap[x, y] = false;
                World.cellMap[x, y] = true;
                return true;
            }
            return false;
        }//if lava and water collide create obsidian
    }
}
