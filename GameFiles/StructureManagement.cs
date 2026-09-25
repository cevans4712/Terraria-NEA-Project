namespace TerrariaNEA
{
    internal class StructureManagement
    {
        public static void generateStructures()
        {
            generateUndergroundHouses();
            generateUnderworldHouses();
        }//generates all the structures in the world upon generation
        public static void generateUnderworldHouses()
        {
            for(int x = 1500; x < 3500; x++)
            {
                if(Game.random.NextDouble() < 0.05d)
                {
                    int houseHeight = Game.random.Next(4, 10);
                    for(int i = 0; i < houseHeight; i++)
                    {
                        Structure structure = new UnderworldHouse();
                        int structureX = x;
                        int structureY = 1000 - (i * 9);
                        spawnStructure(structure, structureX, structureY);
                    }
                    x += 14;
                }
            }
        }//generates the underworld houses
        public static void generateUndergroundHouses()
        {
            for (int i = 0; i < Game.random.Next(20, 31); i++)
            {
                Structure structure = new UndergroundHouse();
                int structureX = Game.random.Next(0, World.worldWidth - structure.StructureCellMap.GetLength(0));
                int structureY = Game.random.Next(300, 800);
                spawnStructure(structure, structureX, structureY);
            }
        }//generates the underground houses
        public static void spawnStructure(Structure structure, int structureX, int structureY)
        {
            for (int x = 0; x < structure.StructureCellMap.GetLength(0); x++)
            {
                for (int y = 0; y < structure.StructureCellMap.GetLength(1); y++)
                {
                    if(structureX + x >= 0 && structureX + x < World.worldWidth && structureY + y >= 0 && structureY + y < World.worldHeight)
                    {
                        World.blockMap[structureX + x, structureY + y] = structure.StructureBlockMap[x, y];
                        World.cellMap[structureX + x, structureY + y] = structure.StructureCellMap[x, y];
                        World.spaceMap[structureX + x, structureY + y] = structure.StructureSpaceMap[x, y];
                        World.wallMap[structureX + x, structureY + y] = structure.StructureWallMap[x, y];
                        World.chestMap[structureX + x, structureY + y] = structure.StructureChestMap[x, y];
                        if (structure.StructureBiomeMap[x, y] != 255)
                        {
                            World.biomeMap[structureX + x, structureY + y] = structure.StructureBiomeMap[x, y];
                        }
                    }
                }
            }

        }

        //public static void generateDungeon()
        //{
        //    generateDungeonSurface();
        //    generateDungeonCorridor();
        //}
        //public static void generateDungeonSurface()
        //{
        //    Structure structure = new DungeonSurface();
        //    for (int x = 0; x < structure.StructureCellMap.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < structure.StructureCellMap.GetLength(1); y++)
        //        {
        //            if (structure.StructureBlockMap[x, y] != 0)
        //            {
        //                World.blockMap[x, y] = structure.StructureBlockMap[x, y];
        //            }
        //            if (structure.StructureWallMap[x, y] != 0)
        //            {
        //                World.wallMap[x, y] = structure.StructureWallMap[x, y];
        //            }
        //            if (structure.StructureBiomeMap[x, y] != 0)
        //            {
        //                World.biomeMap[x, y] = structure.StructureBiomeMap[x, y];
        //            }
        //            if (structure.StructureCellMap[x, y])
        //            {
        //                World.cellMap[x, y] = structure.StructureCellMap[x, y];
        //            }
        //            if (!structure.StructureSpaceMap[x, y])
        //            {
        //                World.spaceMap[x, y] = structure.StructureSpaceMap[x, y];
        //            }
        //        }
        //    }
        //}
        //public static void generateDungeonCorridor()
        //{
        //    Structure structure = new DungeonCorridor(200, 3);
        //    for (int x = 0; x < structure.StructureBlockMap.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < structure.StructureBlockMap.GetLength(1); y++)
        //        {
        //            if (structure.StructureBlockMap[x, y] != 0)
        //            {
        //                World.blockMap[x + 500, y + 500] = structure.StructureBlockMap[x, y];
        //            }
        //            if (structure.StructureWallMap[x, y] != 0)
        //            {
        //                World.wallMap[x + 500, y + 500] = structure.StructureWallMap[x, y];
        //            }
        //        }
        //    }
        //}
    }
}
