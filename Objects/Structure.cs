namespace TerrariaNEA
{
    public class Structure
    {
        //this class contains the blueprints for each sructure to be generated in the world
        protected byte[,] structureBlockMap;
        protected byte[,] structureWallMap;
        protected bool[,] structureCellMap;
        protected bool[,] structureSpaceMap;
        protected byte[,] structureBiomeMap;
        protected ushort[,] structureChestMap;
        public byte[,] StructureBlockMap
        {
            get { return structureBlockMap; }
            set { structureBlockMap = value; }
        }
        public byte[,] StructureWallMap
        {
            get { return structureWallMap; }
            set { structureWallMap = value; }
        }
        public byte[,] StructureBiomeMap
        {
            get { return structureBiomeMap; }
            set { structureBiomeMap = value; }
        }
        public bool[,] StructureCellMap
        {
            get { return structureCellMap; }
            set { structureCellMap = value; }
        }
        public bool[,] StructureSpaceMap
        {
            get { return structureSpaceMap; }
            set { structureSpaceMap = value; }
        }
        public ushort[,] StructureChestMap
        {
            get { return structureChestMap; }
            set { structureChestMap = value; }
        }
    }
    //below is where each structure is created
    public class UndergroundHouse : Structure
    {
        public UndergroundHouse()
        {
            structureBlockMap = new byte[15,8];
            structureCellMap = new bool[15,8];
            structureSpaceMap = new bool[15,8];
            structureWallMap = new byte[15,8];
            structureBiomeMap = new byte[15, 8];
            structureChestMap = new ushort[15, 8];
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    structureSpaceMap[x, y] = true;
                    structureBiomeMap[x, y] = 255;
                    structureWallMap[x, y] = 2;
                    if(x == 0 || y == 0 || x == 14 || y == 7)
                    {
                        structureBlockMap[x, y] = 19;
                        structureCellMap[x, y] = true;
                        structureSpaceMap[x, y] = false;
                    }
                    if ((y == 0 && x > 3 && x < 8) || (y > 3 && y < 7 && structureBlockMap[x, y] == 19))
                    {
                        structureBlockMap[x, y] = 28;
                    }
                }
            }
            ushort nextChest = 0;
            for(ushort i = 0; i < Game.chests.Length; i++)
            {
                if (Game.chests[i] == null)
                {
                    nextChest = i;
                    break;
                }
            }
            int chestX = Game.random.Next(3, 11);
            for (int i = 0; i < 2; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    structureChestMap[chestX + i, 6 + j] = nextChest;
                    structureBlockMap[chestX + i, 6 + j] = 10;
                    structureSpaceMap[chestX + i, 6 + j] = false;
                }
            }
            Treasure.fillChest(nextChest);
        }
    }
    public class UnderworldHouse : Structure
    {
        public UnderworldHouse()
        {
            structureBlockMap = new byte[15,10];
            structureCellMap = new bool[15,10];
            structureSpaceMap = new bool[15,10];
            structureWallMap = new byte[15,10];
            structureBiomeMap = new byte[15, 10];
            structureChestMap = new ushort[15, 10];
            for (int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    structureSpaceMap[x, y] = true;
                    structureBiomeMap[x, y] = 255;
                    structureWallMap[x, y] = 0;
                    if(x == 0 || y == 0 || x == 14 || y == 9)
                    {
                        structureBlockMap[x, y] = 8;
                        structureCellMap[x, y] = true;
                        structureSpaceMap[x, y] = false;
                    }
                    if((y == 0 || y == 9) && x > 3 && x < 11)
                    {
                        structureBlockMap[x, y] = 28;
                    }
                }
            }
            if(Game.random.NextDouble() < 0.02d)
            {
                ushort nextChest = 0;
                for (ushort i = 0; i < Game.chests.Length; i++)
                {
                    if (Game.chests[i] == null)
                    {
                        nextChest = i;
                        break;
                    }
                }
                int chestX = Game.random.Next(3, 11);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = -1; j < 1; j++)
                    {
                        structureChestMap[chestX + i, 8 + j] = nextChest;
                        structureBlockMap[chestX + i, 8 + j] = 10;
                        structureSpaceMap[chestX + i, 8 + j] = false;
                    }
                }
                Treasure.fillChest(nextChest);
            }
        }
    }
    //classes below are unused
    public class DungeonSurface : Structure
    {
        public DungeonSurface()
        {
            structureBlockMap = new byte[120, 60];
            structureCellMap = new bool[120, 60];
            structureSpaceMap = new bool[120, 60];
            structureWallMap = new byte[120, 60];
            structureBiomeMap = new byte[120, 60];
            for(int x = 0; x < structureCellMap.GetLength(0); x++)
            {
                for (int y = structureCellMap.GetLength(1) - 1; y > -1; y--)
                {
                    //trapezium base
                    if (y >= 40)
                    {
                        int depth = 59 - y;
                        if (x >= depth && x <= 119 - depth)
                        {
                            structureBlockMap[x, y] = 27;
                        }
                    }
                    else if (y >= 10)
                    {
                        //walls of the main room
                        if ((x > 20 && x < 26) || (x > 56 && x < 62))
                        {
                            structureBlockMap[x, y] = 27;
                        }
                        //outside part
                        if (x > 61 && x < 101)
                        {
                            if (y >= 20 && y <= 23)
                            {
                                structureBlockMap[x, y] = 27;
                            }
                            else if (y == 19)
                            {
                                if ((x - 62) / 5 % 2 == 0)
                                {
                                    structureBlockMap[x, y] = 27;
                                }
                            }
                            else if (y >= 15 && y <= 19)
                            {
                                if (x > 96)
                                {
                                    structureBlockMap[x, y] = 27;
                                    structureBlockMap[x, y + 1] = 27;
                                }
                            }
                        }
                    }
                    //roof of main room
                    else if (y >= 7)
                    {
                        if (x > 20 && x < 62)
                        {
                            structureBlockMap[x, y] = 27;
                        }
                    }
                    else if (y >= 3)
                    {
                        if (y == 6)
                        {
                            if ((x - 21) / 5 % 2 == 0)
                            {
                                if (x > 20 && x < 62)
                                {
                                    structureBlockMap[x, y] = 27;
                                }
                            }
                        }
                        if ((x > 20 && x < 26) || (x > 56 && x < 62))
                        {
                            structureBlockMap[x, y] = 27;
                        }
                    }
                    //all blocks have a hitbox
                    if (structureBlockMap[x, y] == 27)
                    {
                        structureCellMap[x, y] = true;
                    }
                    //all blocks have a wall behind them
                    if (structureCellMap[x, y])
                    {
                        structureWallMap[x, y] = 6;
                    }
                    if (y >= 10)
                    {
                        //walls of the main room
                        if (x > 20 && x < 62)
                        {
                            structureWallMap[x, y] = 6;
                            //add torches
                            if((x - 20) % 6 == 0 && (y - 20) % 6 == 0 && y < 40)
                            {
                                structureBlockMap[x, y] = 16;
                            }
                        }
                    }
                    //walls on the outside
                    if (x > 61 && x < 101)
                    {
                        if ((x - 62) / 5 % 2 == 0)
                        {
                            if(y > 19)
                            {
                                structureWallMap[x, y] = 6;
                            }
                        }
                    }
                    if (structureWallMap[x, y] == 6)
                    {
                        structureBiomeMap[x, y] = 9;
                    }
                    if (structureBlockMap[x, y] != 0)
                    {
                        structureSpaceMap[x, y] = false;
                    }
                }
            }
        }
    }
    public class DungeonCorridor : Structure
    {
        public DungeonCorridor(int length, int direction)
        {
            if(direction == 4)
            {
                direction = Game.random.Next(4);
            }
            int lengthX = 0;
            int lengthY = 0;
            switch (direction)
            {
                case 0:
                    lengthX = Convert.ToInt32(length * Math.Sin(45));
                    lengthY = lengthX;
                    break;
                case 1:
                    lengthX = 0;
                    lengthY = length;
                    break;
                case 2:
                    lengthX = length;
                    lengthY = 0;
                    break;
                case 3:
                    lengthX = Convert.ToInt32(length * Math.Sin(45));
                    lengthY = lengthX;
                    break;
            }
            bool[,] corridorCells = createCorridor(lengthX, lengthY, direction);
            structureBlockMap = new byte[corridorCells.GetLength(0), corridorCells.GetLength(1)];
            structureWallMap = new byte[corridorCells.GetLength(0), corridorCells.GetLength(1)];
            for(int x = 0; x < corridorCells.GetLength(0); x++)
            {
                for(int y = 0; y < corridorCells.GetLength(1); y++)
                {
                    if (corridorCells[x, y])
                    {
                        structureBlockMap[x, y] = 27;
                    }
                }
            }
            if(direction == 0 || direction == 3)
            {
                for (int x = 0; x < corridorCells.GetLength(0); x++)
                {
                    for (int y = 0; y < corridorCells.GetLength(1); y++)
                    {
                        if (corridorCells[x, y])
                        {
                            structureWallMap[x, y] = 6;
                            if (x < 10 || x > corridorCells.GetLength(0) - 11 || y < 10 || y > corridorCells.GetLength(1) - 11)
                            {
                                structureBlockMap[x, y] = 0;
                            }
                            if(Math.Abs(x - y) < World.currentCorridorWidth)
                            {
                                structureBlockMap[x, y] = 0;
                            }
                        }
                    }
                }
            }
            else if(direction == 1)
            {
                int blockCount = 0;
                int gapCount = 0;
                for (int y = 0; y < corridorCells.GetLength(1); y++)
                {
                    for (int x = 0; x < corridorCells.GetLength(0); x++)
                    {
                        if (corridorCells[x, y])
                        {
                            structureWallMap[x, y] = 6;
                            if ((x > 3 && x < corridorCells.GetLength(0) - 4) || y < 10 || y > corridorCells.GetLength(1) - 11)
                            {
                                structureBlockMap[x, y] = 0;
                            }
                        }
                        if (blockCount == 0)
                        {
                            if (corridorCells[x, y])
                            {
                                blockCount++;
                            }
                        }
                        else
                        {
                            if (gapCount != World.currentCorridorWidth * 2 - 5)
                            {
                                if (blockCount == 3)
                                {
                                    structureBlockMap[x, y] = 0;
                                    gapCount++;
                                }
                                else if (corridorCells[x, y])
                                {
                                    blockCount++;
                                }
                            }
                        }
                    }
                    blockCount = 0;
                    gapCount = 0;
                }

            }
        }
        public static bool[,] createCorridor(int width, int height, int direction)
        {
            World.currentCorridorWidth = Game.random.Next(8, 13);
            bool[,] quadrilateralArray = new bool[1, 1];
            if (direction == 0)
            {
                quadrilateralArray = new bool[width, height];
                // Define the corners of the quadrilateral
                int x0 = -World.currentCorridorWidth, y0 = World.currentCorridorWidth;
                int x1 = World.currentCorridorWidth, y1 = -World.currentCorridorWidth;
                int x2 = width + World.currentCorridorWidth, y2 = height - World.currentCorridorWidth;
                int x3 = width - World.currentCorridorWidth, y3 = height + World.currentCorridorWidth;
                // Fill the quadrilateral in the array
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (Biomes.isPointInsideQuadrilateral(x, y, x0, y0, x1, y1, x2, y2, x3, y3))
                        {
                            try
                            {
                                quadrilateralArray[x, y] = true;
                            }
                            catch { }
                        }
                    }
                }
            }
            else if(direction == 1)
            {
                quadrilateralArray = new bool[World.currentCorridorWidth * 2, height];
                for(int x = 0; x < quadrilateralArray.GetLength(0); x++)
                {
                    for (int y = 0; y < quadrilateralArray.GetLength(1); y++)
                    {
                        quadrilateralArray[x, y] = true;
                    }
                }
            }
            else if(direction == 2)
            {
                quadrilateralArray = new bool[width, World.currentCorridorWidth * 2];
                for(int x = 0; x < quadrilateralArray.GetLength(0); x++)
                {
                    for (int y = 0; y < quadrilateralArray.GetLength(1); y++)
                    {
                        quadrilateralArray[x, y] = true;
                    }
                }
            }
            else if(direction == 3)
            {
                quadrilateralArray = new bool[width, height];
                // Define the corners of the quadrilateral
                int x0 = -World.currentCorridorWidth, y0 = World.currentCorridorWidth;
                int x1 = World.currentCorridorWidth, y1 = -World.currentCorridorWidth;
                int x2 = width + World.currentCorridorWidth, y2 = height - World.currentCorridorWidth;
                int x3 = width - World.currentCorridorWidth, y3 = height + World.currentCorridorWidth;
                // Fill the quadrilateral in the array
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (Biomes.isPointInsideQuadrilateral(x, y, x0, y0, x1, y1, x2, y2, x3, y3))
                        {
                            try
                            {
                                quadrilateralArray[x, y] = true;
                            }
                            catch { }
                        }
                    }
                }

            }
            return quadrilateralArray;
        }
    }
}
