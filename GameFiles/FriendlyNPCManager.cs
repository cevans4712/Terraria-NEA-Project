namespace TerrariaNEA
{
    public class FriendlyNPCManager
    {
        static int lowestX;
        static int lowestY;
        static int[,] currentRoom = new int[400, 4];
        static bool[,] roomCellMap;
        static byte[,] roomBlockMap;
        static byte[,] roomWallMap;
        static bool[,] roomLightMap;
        static bool[] filled = new bool[400];

        //  ------- Methods involved with checking for valid housing in the world. --------
        public static void checkHousingAroundPlayer(int x, int y)//when the player interacts with the world check if a house around the block that was placed or broken has become valid
        {
            int range = 1;
            for(int i = x - range; i <= x + range; i++)
            {
                for(int j = y - range; j <= y + range; j++)
                {
                    try
                    {
                        if (checkIfValidHousing(i, j))
                        {
                            addHouse();
                        }
                    }
                    catch { }
                }
            }
        }
        public static void addHouse()
        {
            int[] house = new int[5];
            house[0] = lowestX;
            house[1] = lowestY;
            house[2] = roomCellMap.GetLength(0);
            house[3] = roomCellMap.GetLength(1);
            house[4] = 0;
            if (!houseAlreadyInList(house))
            {
                Game.validHouses.Add(house);
            }
        }//adds details about the house to the list(location, size, current npc)
        public static bool houseAlreadyInList(int[] house)
        {
            for (int i = 0; i < Game.validHouses.Count; i++)
            {
                if (Game.validHouses[i][0] == house[0] && Game.validHouses[i][1] == house[1] && Game.validHouses[i][2] == house[2] && Game.validHouses[i][3] == house[3])
                {
                    return true;
                }
            }
            return false;
        }//checks if the house being added already exists
        public static bool checkIfValidHousing(int x, int y)
        {
            if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
            {
                currentRoom = new int[400, 4];
                filled = new bool[400];
                createRoom(x, y);
                if (meetsSizeRequirements())
                {
                    for (int i = 0; i < 400; i++)
                    {
                        if (filled[i])
                        {
                            int currentX = currentRoom[i, 0] - lowestX;
                            int currentY = currentRoom[i, 1] - lowestY;
                            roomCellMap[currentX, currentY] = World.cellMap[currentRoom[i, 0], currentRoom[i, 1]];
                            roomBlockMap[currentX, currentY] = Convert.ToByte(currentRoom[i, 2]);
                            roomWallMap[currentX, currentY] = Convert.ToByte(currentRoom[i, 3]);
                            roomLightMap[currentX, currentY] = World.lightBlocks[currentRoom[i, 0], currentRoom[i, 1]];
                        }
                    }
                    if (isValid())
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if the block being looked at is inside a valid house and turns the 1d array into a 2d array of the room as is in the world
        public static bool isValid()
        {
            if (isABox())
            {
                if (hasWalls())
                {
                    if (hasFurniture())
                    {
                        if (hasLight())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }//checks if the house meets all the requirements
        public static bool hasWalls()
        {
            for (int i = 0; i < roomCellMap.GetLength(0); i++)
            {
                for (int j = 0; j < roomCellMap.GetLength(1); j++)
                {
                    if (!roomCellMap[i, j] && roomWallMap[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }//checks all empty spaces are filled with walls
        public static bool hasFurniture()
        {
            bool hasTable = false;
            bool hasChair = false;
            for (int i = 0; i < roomCellMap.GetLength(0); i++)
            {
                for (int j = 0; j < roomCellMap.GetLength(1); j++)
                {
                    if(roomBlockMap[i, j] == 32)
                    {
                        hasTable = true;
                    }
                    else if (roomBlockMap[i, j] == 33 || roomBlockMap[i, j] == 23)
                    {
                        hasChair = true;
                    }
                }
            }
            if(hasChair && hasTable)
            {
                return true;
            }
            return false;
        }//checks the house has a table and chair
        public static bool hasLight()
        {
            for (int i = 0; i < roomCellMap.GetLength(0); i++)
            {
                for (int j = 0; j < roomCellMap.GetLength(1); j++)
                {
                    if (roomLightMap[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks the house has a light source
        public static bool isABox()
        {
            for(int i = 0; i < roomCellMap.GetLength(0); i++)
            {
                for(int j = 0; j < roomCellMap.GetLength(1); j++)
                {
                    if(i != 0 && i != roomCellMap.GetLength(0) - 1 && j != 0 && j != roomCellMap.GetLength(1) - 1 && roomCellMap[i, j])
                    {
                        return false;
                    }
                    else if ((i == 0 || i == roomCellMap.GetLength(0) - 1 || j == 0 || j == roomCellMap.GetLength(1)) && !roomCellMap[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }//checks the house is a complete box
        public static bool meetsSizeRequirements()
        {
            int minWidth = 5;
            int minHeight = 5;
            int maxWidth = 20;
            int maxHeight = 20;
            int largestX = 0;
            lowestX = int.MaxValue;
            int largestY = 0;
            lowestY = int.MaxValue;
            for (int i = 0; i < 400; i++)
            {
                if (filled[i])
                {
                    if (currentRoom[i, 0] > largestX)
                    {
                        largestX = currentRoom[i, 0];
                    }
                    else if (currentRoom[i, 0] < lowestX)
                    {
                        lowestX = currentRoom[i, 0];
                    }
                    if (currentRoom[i, 1] > largestY)
                    {
                        largestY = currentRoom[i, 1];
                    }
                    else if (currentRoom[i, 1] < lowestY)
                    {
                        lowestY = currentRoom[i, 1];
                    }
                }
            }
            int height = largestY - lowestY + 1;
            int width = largestX - lowestX + 1;
            if (height >= minHeight && height <= maxHeight && width >= minWidth && width <= maxWidth && width * height >= 60)
            {
                roomCellMap = new bool[width, height];
                roomLightMap = new bool[width, height];
                roomBlockMap = new byte[width, height];
                roomWallMap = new byte[width, height];
                return true;
            }
            return false;
        }//checks the box meets the size requirements
        public static void createRoom(int x, int y)
        {
            if(hasBeenVisited(x, y))
            {
            }
            else
            {
                int i;
                for (i = 0; i < 400; i++)
                {
                    if (!filled[i])
                    {
                        break;
                    }
                }
                if(i != 400)
                {
                    if(x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                    {
                        currentRoom[i, 0] = x;
                        currentRoom[i, 1] = y;
                        currentRoom[i, 2] = World.blockMap[x, y];
                        currentRoom[i, 3] = World.wallMap[x, y];
                        filled[i] = true;
                        if (!World.cellMap[x, y])
                        {
                            createRoom(x + 1, y);
                            createRoom(x, y + 1);
                            createRoom(x - 1, y);
                            createRoom(x, y - 1);
                            createRoom(x - 1, y - 1);
                            createRoom(x + 1, y + 1);
                            createRoom(x + 1, y - 1);
                            createRoom(x - 1, y + 1);
                        }
                    }
                }
            }
        }//flood fill - recursively creates a room from the starting position if the size is greater than 400 it breaks as that is outside the maximum room size
        public static bool hasBeenVisited(int x, int y)
        {
            for (int i = 0; i < filled.Length; i++)
            {
                bool xMatch = currentRoom[i, 0] == x;
                bool yMatch = currentRoom[i, 1] == y;
                bool isFilled = filled[i];
                if (xMatch && yMatch && isFilled)
                {
                    return true;
                }
            }
            return false;
        }//checks if the current tile has already been add to the room

        // ------- Methods involed with controlling the NPCs -------
        public static void attemptToSpawnNPCs()
        {
            double chanceToSpawn = Game.random.NextDouble();
            if(chanceToSpawn < 0.01)
            {
                if (canSpawnGuide())
                {
                    spawnGuide();
                }
            }
            else if(chanceToSpawn < 0.02)
            {
                if (canSpawnMerchant())
                {
                    spawnMerchant();
                }
            }
            else if(chanceToSpawn < 0.03)
            {
                if (canSpawnNurse())
                {
                    spawnNurse();
                }
            }
        }//attempts to spawn the npcs each tick
        public static bool canSpawnGuide()
        {
            if (Game.npcObjectives[0] && (Game.guide == null || Game.guide.NPCHouse == int.MaxValue))
            {
                if(Game.validHouses.Count == 0)
                {
                    return false;
                }
                for(int i = 0; i < Game.validHouses.Count; i++)
                {
                    if (Game.validHouses[i][4] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if the guide can be spawned
        public static bool canSpawnMerchant()
        {
            if (Game.npcObjectives[1] && Game.merchant == null)
            {
                if(Game.validHouses.Count == 0)
                {
                    return false;
                }
                for(int i = 0; i < Game.validHouses.Count; i++)
                {
                    if (Game.validHouses[i][4] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if the merchant can be spawned
        public static bool canSpawnNurse()
        {
            if (Game.npcObjectives[2] && Game.nurse == null)
            {
                if(Game.validHouses.Count == 0)
                {
                    return false;
                }
                for(int i = 0; i < Game.validHouses.Count; i++)
                {
                    if (Game.validHouses[i][4] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if the nurse can be spawned
        public static void spawnGuide()
        {
            int claimHouse = Game.random.Next(Game.validHouses.Count);
            while (Game.validHouses[claimHouse][4] != 0)
            {
                claimHouse = Game.random.Next(Game.validHouses.Count);
            }
            Game.validHouses[claimHouse][4] = 1;
            Guide friendlyNPC = new Guide(claimHouse);
            if (Math.Abs(Game.validHouses[claimHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[claimHouse][1] - Player.playerY) > 35)
            {
                friendlyNPC.Spawn();
            }
            else
            {
                friendlyNPC.WaitingToSpawn = true;
            }
            Game.guide = friendlyNPC;
        }//either spawns the guide or sets it to be waiting to spawn
        public static void spawnMerchant()
        {
            int claimHouse = Game.random.Next(Game.validHouses.Count);
            while (Game.validHouses[claimHouse][4] != 0)
            {
                claimHouse = Game.random.Next(Game.validHouses.Count);
            }
            Game.validHouses[claimHouse][4] = 1;
            Merchant friendlyNPC = new Merchant(claimHouse);
            if (Math.Abs(Game.validHouses[claimHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[claimHouse][1] - Player.playerY) > 35)
            {
                friendlyNPC.Spawn();
            }
            else
            {
                friendlyNPC.WaitingToSpawn = true;
            }
            Game.merchant = friendlyNPC;
        }//either spawns the merchant or sets it to be waiting to spawn
        public static void spawnNurse()
        {
            int claimHouse = Game.random.Next(Game.validHouses.Count);
            while (Game.validHouses[claimHouse][4] != 0)
            {
                claimHouse = Game.random.Next(Game.validHouses.Count);
            }
            Game.validHouses[claimHouse][4] = 1;
            Nurse friendlyNPC = new Nurse(claimHouse);
            if (Math.Abs(Game.validHouses[claimHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[claimHouse][1] - Player.playerY) > 35)
            {
                friendlyNPC.Spawn();
            }
            else
            {
                friendlyNPC.WaitingToSpawn = true;
            }
            Game.nurse = friendlyNPC;
        }//either spawns the nurse or sets it to be waiting to spawn
        public static void controlFriendlyNPCs()
        {
            if(Game.guide != null)
            {
                controlGuide();
            }
            if(Game.merchant != null)
            {
                controlMerchant();
            }
            if(Game.nurse != null)
            {
                controlNurse();
            }
        }//controls the movement of each friendly npc
        public static void controlGuide()
        {
            if(Game.guide.MoveTimer == Game.guide.NextMoveTime)
            {
                if(Game.guide.CurrentDirection == 0)
                {
                    Game.guide.CurrentDirection = Convert.ToSByte(Game.guide.LastDirection * -1);
                    if(Game.guide.NPCHouse != int.MaxValue)
                    {
                        if (Game.guide.CurrentDirection == -1)
                        {
                            Game.guide.CurrentTargetX = Game.validHouses[Game.guide.NPCHouse][0] + 2;
                        }
                        else
                        {
                            Game.guide.CurrentTargetX = Game.validHouses[Game.guide.NPCHouse][0] + Game.validHouses[Game.guide.NPCHouse][2] - 4;
                        }
                    }
                    else
                    {
                        if (Game.guide.CurrentDirection == -1)
                        {
                            Game.guide.CurrentTargetX = World.worldWidth;
                        }
                        else
                        {
                            Game.guide.CurrentTargetX = 0;
                        }
                    }
                    Game.guide.LastDirection = 0;
                }
                else
                {
                    Game.guide.LastDirection = Game.guide.CurrentDirection;
                    Game.guide.CurrentDirection = 0;
                }
                Game.guide.MoveTimer = 0;
                Game.guide.NextMoveTime = (byte)Game.random.Next(50, 100);
            }
            if(Game.guide.CurrentDirection == -1)
            {
                try
                {
                    Game.guide.MoveLeft();
                }
                catch { }
            }
            else if(Game.guide.CurrentDirection == 1)
            {
                try
                {
                    Game.guide.MoveRight();
                }
                catch { }
            }
            try
            {
                Game.guide.Fall();
            }
            catch { }
            Game.guide.MoveTimer++;
        }//controls the movement of the guide
        public static void controlNurse()
        {
            if (Game.nurse.MoveTimer == Game.nurse.NextMoveTime)
            {
                if (Game.nurse.CurrentDirection == 0)
                {
                    Game.nurse.CurrentDirection = Convert.ToSByte(Game.nurse.LastDirection * -1);
                    if (Game.nurse.CurrentDirection == -1)
                    {
                        Game.nurse.CurrentTargetX = Game.validHouses[Game.nurse.NPCHouse][0] + 2;
                    }
                    else
                    {
                        Game.nurse.CurrentTargetX = Game.validHouses[Game.nurse.NPCHouse][0] + Game.validHouses[Game.nurse.NPCHouse][2] - 4;
                    }
                    Game.nurse.LastDirection = 0;
                }
                else
                {
                    Game.nurse.LastDirection = Game.nurse.CurrentDirection;
                    Game.nurse.CurrentDirection = 0;
                }
                Game.nurse.MoveTimer = 0;
                Game.nurse.NextMoveTime = (byte)Game.random.Next(50, 100);
            }
            if (Game.nurse.CurrentDirection == -1)
            {
                try
                {
                    Game.nurse.MoveLeft();
                }
                catch { }
            }
            else if (Game.nurse.CurrentDirection == 1)
            {
                try
                {
                    Game.nurse.MoveRight();
                }
                catch { }
            }
            try
            {
                Game.nurse.Fall();
            }
            catch { }
            Game.nurse.MoveTimer++;
        }//controls the movement of the nurse
        public static void controlMerchant()
        {
            if (Game.merchant.MoveTimer == Game.merchant.NextMoveTime)
            {
                if (Game.merchant.CurrentDirection == 0)
                {
                    Game.merchant.CurrentDirection = Convert.ToSByte(Game.merchant.LastDirection * -1);
                    if (Game.merchant.CurrentDirection == -1)
                    {
                        Game.merchant.CurrentTargetX = Game.validHouses[Game.merchant.NPCHouse][0] + 2;
                    }
                    else
                    {
                        Game.merchant.CurrentTargetX = Game.validHouses[Game.merchant.NPCHouse][0] + Game.validHouses[Game.merchant.NPCHouse][2] - 4;
                    }
                    Game.merchant.LastDirection = 0;
                }
                else
                {
                    Game.merchant.LastDirection = Game.merchant.CurrentDirection;
                    Game.merchant.CurrentDirection = 0;
                }
                Game.merchant.MoveTimer = 0;
                Game.merchant.NextMoveTime = (byte)Game.random.Next(50, 100);
            }
            if (Game.merchant.CurrentDirection == -1)
            {
                try
                {
                    Game.merchant.MoveLeft();
                }
                catch { }
            }
            else if (Game.merchant.CurrentDirection == 1)
            {
                try
                {
                    Game.merchant.MoveRight();
                }
                catch { }
            }
            try
            {
                Game.merchant.Fall();
            }
            catch { }
            Game.merchant.MoveTimer++;

        }//controls the movement of the merchant
    }
}