namespace TerrariaNEA
{
    public class Biomes
    {
        // 0 = surface
        // 1 = desert
        // 2 = ice
        // 3 = corruption
        // 4 = jungle
        // 5 = mushroom
        // 6 = ocean
        // 7 = underworld
        // 8 = caverns
        // 9 = dungeon

        public static void addBiomes()
        {
            int iceStart = World.corruptionStart;
            while(Math.Abs(World.corruptionStart - iceStart) < 600)
            {
                if (World.iceOnLeft)
                {
                    iceStart = Game.random.Next(400, 1800);
                }
                else
                {
                    iceStart = Game.random.Next(2800, 4200);
                }
            }
            int jungleStart = World.desertStart;
            while (Math.Abs(World.desertStart - jungleStart) < 600 || Math.Abs(iceStart - jungleStart) < 600)
            {
                if (World.jungleOnLeft)
                {
                    jungleStart = Game.random.Next(400, 1600);
                }
                else
                {
                    jungleStart = Game.random.Next(2800, 4100);
                }
            }
            //build desert
            for (int i = 0; i < World.desertWidth; i++)
            {
                for (int j = 0; j < World.desertHeight; j++)
                {
                    if (World.desert[i, j])
                    {
                        World.biomeMap[i + World.desertStart, j] = 1;
                    }
                }
            }
            //build ice
            for (int i = 0; i < World.iceWidth; i++)
            {
                for (int j = 0; j < World.iceHeight; j++)
                {
                    if (World.ice[i, j])
                    {
                        World.biomeMap[i + iceStart, j] = 2;
                    }
                }
            }
            //build corruption
            for (int i = 0; i < World.corruptionWidth; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    if (World.corruption[i, j])
                    {
                        World.biomeMap[i + World.corruptionStart, j] = 3;
                    }
                }
            }
            //build jungle
            for (int i = 0; i < World.jungleWidth; i++)
            {
                for (int j = 0; j < World.jungleHeight; j++)
                {
                    if (World.jungle[i, j])
                    {
                        World.biomeMap[i + jungleStart, j] = 4;
                    }
                }
            }
            //build underworld/caverns
            for(int i = 0; i < World.worldWidth; i++)
            {
                for(int j = 0; j < World.worldHeight; j++)
                {
                    if (World.backgroundMap[i, j] == 3 && World.biomeMap[i, j] == 0)
                    {
                        World.biomeMap[i, j] = 7;
                    }
                    else if (World.backgroundMap[i, j] == 2 && World.biomeMap[i, j] == 0)
                    {
                        World.biomeMap[i, j] = 8;
                    }
                }
            }
        }// adds biomes to the world
        public static void outputBiomes()
        {
            int[] surfaceHeight = new int[World.worldWidth];
            int currentHeight = 0;
            for(int i = 0; i < World.worldWidth; i++)
            {
                if(!(i >= World.corruptionStart && i < World.corruptionStart + World.corruptionWidth))
                {
                    surfaceHeight[i] = World.surfaceHeight[i];
                    currentHeight = surfaceHeight[i];
                }
                else
                {
                    int index = i - World.corruptionStart;
                    if (World.corruptionChasms[index])
                    {
                        surfaceHeight[i] = currentHeight;
                    }
                    else
                    {
                        surfaceHeight[i] = World.surfaceHeight[i];
                        currentHeight = surfaceHeight[i];
                    }
                }
            }
            for(int x = 0; x < World.worldWidth; x++)
            {
                for(int y = 0; y < World.worldHeight; y++)
                {
                    if (World.biomeMap[x, y] == 1)//desert
                    {
                        if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1)
                        {
                            if (y < 920 - World.dirtHeight[x])
                            {
                                World.blockMap[x, y] = 17;
                            }
                            else
                            {
                                World.blockMap[x, y] = 18;
                            }
                        }
                        else if (World.blockMap[x, y] == 2)
                        {
                            World.blockMap[x, y] = 18;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 8;
                        }
                        if (World.wallMap[x, y] == 1)
                        {
                            World.wallMap[x, y] = 4;
                        }
                    }
                    if (World.biomeMap[x, y] == 2)//ice
                    {
                        if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1)
                        {
                            World.blockMap[x, y] = 11;
                        }
                        else if (World.blockMap[x, y] == 2)
                        {
                            World.blockMap[x, y] = 12;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 9;
                        }
                        if (World.wallMap[x, y] == 1)
                        {
                            World.wallMap[x, y] = 3;
                        }
                    }
                    if (World.biomeMap[x, y] == 3)//corruption
                    {
                        if (World.blockMap[x, y] == 2 || (World.blockMap[x, y] != 0 && y > surfaceHeight[x] + 30))
                        {
                            World.blockMap[x, y] = 13;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 5;
                        }
                    }
                    if (World.biomeMap[x, y] == 4)//jungle
                    {
                        if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1 || World.blockMap[x, y] == 2)
                        {
                            World.blockMap[x, y] = 21;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 6;
                        }
                        if(World.wallMap[x, y] == 1)
                        {
                            World.wallMap[x, y] = 5;
                        }
                    }
                    if (World.biomeMap[x, y] == 5)//mushroom
                    {
                        if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1 || World.blockMap[x, y] == 2)
                        {
                            World.blockMap[x, y] = 21;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 7;
                        }
                        if (World.wallMap[x, y] == 1)
                        {
                            World.wallMap[x, y] = 5;
                        }
                    }
                    if (World.biomeMap[x, y] == 6)//ocean
                    {
                        if (World.blockMap[x, y] == 9 || World.blockMap[x, y] == 1)
                        {
                            World.blockMap[x, y] = 17;
                        }
                        else if (World.blockMap[x, y] == 2)
                        {
                            World.blockMap[x, y] = 18;
                        }
                        if (World.backgroundMap[x, y] == 1 || World.backgroundMap[x, y] == 2)
                        {
                            World.backgroundMap[x, y] = 8;
                        }
                        if (World.wallMap[x, y] == 1)
                        {
                            World.wallMap[x, y] = 4;
                        }
                    }
                }
            }
        }// changes dirt and stone blocks to match the equivalent block for the biome
        // ---------------------------- Desert ---------------------------------
        public static void addDesertGeneration()
        {
            World.desertStart = World.corruptionStart;
            while (Math.Abs(World.desertStart - World.corruptionStart) < 500)
            {
                if (Game.random.Next(2) == 0)
                {
                    World.desertOnLeft = true;// if the desert generates on the left or right side
                }
                World.desertWidth = Game.random.Next(325, 400);
                World.desertHeight = Game.random.Next(600, 750);
                if (World.desertOnLeft)
                {
                    World.desertStart = Game.random.Next(400, 1800);
                }
                else
                {
                    World.desertStart = Game.random.Next(2800, 4200);
                }
                bool[,] initialDesert = generateInitialDesert();
                for (int i = 0; i < initialDesert.GetLength(0); i++)
                {
                    for (int j = 0; j < initialDesert.GetLength(1); j++)
                    {
                        if (World.cellMap[i + World.desertStart, j])
                        {
                            World.cellMap[i + World.desertStart, j] = initialDesert[i, j];
                        }
                    }
                }
            }
        }//generates the desert layout(size and location)
        public static bool[,] generateInitialDesert()
        {
            bool[,] initialDesert = new bool[World.desertWidth, World.desertHeight];
            for(int i = 0; i < World.desertWidth; i++)
            {
                for(int j = 0; j < World.desertHeight; j++)
                {
                    initialDesert[i, j] = true;
                }
            }
            int desertCentre = World.desertWidth / 2;
            int holeStart = Game.random.Next(desertCentre - 50, desertCentre);
            int holeWidth = Game.random.Next(50, 100);
            int holeDepth = 350;
            int holeGradient = holeDepth / (holeWidth / 2);
            for(int j = 0; j < holeDepth; j += holeGradient)
            {
                for (int i = 0; i < holeWidth; i++)
                {
                    for (int k = 0; k < holeGradient; k++)
                    {
                        initialDesert[i + holeStart, j + k] = false;
                    }
                }
                holeStart++;
                holeWidth -= 2;
            }
            return initialDesert;
        }//generates the desert chasm
        public static void generateDesert()
        {
            World.desert = createEllipseArray(World.desertWidth, World.desertHeight);
        }//creates an ellipse to act as the desert
        public static bool[,] createEllipseArray(int width, int height)//create an ellipse in an array to be the desert biome
        {
            bool[,] ellipseArray = new bool[width, height];

            double centerX = width / 2.0;
            double centerY = height / 2.0;
            double radiusX = width / 2.0;
            double radiusY = height / 2.0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double normalizedX = (i - centerX) / radiusX;
                    double normalizedY = (j - centerY) / radiusY;

                    double distanceSquared = normalizedX * normalizedX + normalizedY * normalizedY;

                    // Check if the point is inside the ellipse
                    ellipseArray[i, j] = distanceSquared <= 1.0;
                }
            }
            return ellipseArray;
        }
        // ------------------------------ ice ----------------------------------
        public static void generateIce()
        {
            if(World.desertOnLeft)
            {
                World.iceOnLeft = false;
            }
            else
            {
                World.iceOnLeft = true;// if the ice biome generates on the left or right side
            }
            World.iceWidth = Game.random.Next(400, 500);
            World.iceHeight = Game.random.Next(600, 750);
            World.ice = createQuadrilateralArray(World.iceWidth, World.iceHeight);
        }//generates the tundra layout and creates a trapezium to act as the tundra
        public static bool[,] createQuadrilateralArray(int width, int height)// creates a quadrilateral in an array
        {
            bool[,] quadrilateralArray = new bool[width, height];
            // Define the corners of the quadrilateral
            int x0 = Game.random.Next(51, 100), y0 = 0;
            int x1 = Game.random.Next(World.iceWidth - 100, World.iceWidth - 50), y1 = 0;
            int x2 = x1 + 50, y3 = World.iceHeight;
            int x3 = x0 - 50, y2 = World.iceHeight;
            // Fill the quadrilateral in the array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (isPointInsideQuadrilateral(x, y, x0, y0, x1, y1, x2, y2, x3, y3))
                    {
                        quadrilateralArray[x, y] = true;
                    }
                }
            }

            return quadrilateralArray;
        }
        public static bool isPointInsideQuadrilateral(int x, int y, int x0, int y0, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int[] px = { x0, x1, x2, x3 };
            int[] py = { y0, y1, y2, y3 };

            bool c0 = (y - py[0]) * (px[1] - px[0]) - (x - px[0]) * (py[1] - py[0]) < 0;
            bool c1 = (y - py[1]) * (px[2] - px[1]) - (x - px[1]) * (py[2] - py[1]) < 0;
            bool c2 = (y - py[2]) * (px[3] - px[2]) - (x - px[2]) * (py[3] - py[2]) < 0;
            bool c3 = (y - py[3]) * (px[0] - px[3]) - (x - px[3]) * (py[0] - py[3]) < 0;

            return c0 == c2 && c1 == c3;
        }// checks if the specified point is in the quadrilateral
        //----------------------------corruption -------------------------------
        public static void addCorruptionGeneration()
        {
            if (Game.random.Next(2) == 0)
            {
                World.corruptionStart = Game.random.Next(400, 1600);
                World.corruptionOnLeft = true;
            }
            else
            {
                World.corruptionStart = Game.random.Next(2800, 4100);
            }
            bool[,] initialCorruption = generateInitialCorruption();
            for(int i = 0; i < initialCorruption.GetLength(0); i++)
            {
                for(int j = 0;  j < initialCorruption.GetLength(1); j++)
                {
                    if (World.cellMap[i + World.corruptionStart, j])
                    {
                        World.cellMap[i + World.corruptionStart, j] = initialCorruption[i, j];
                    }
                }
            }

        }//generates the corruption layout
        public static bool[,] generateInitialCorruption()
        {
            int corruptionWidth = Game.random.Next(550, 700);
            bool[,] initialCorruption = new bool[corruptionWidth, 400];
            World.corruptionWidth = corruptionWidth;
            bool[] corruptionChasms = new bool[corruptionWidth];
            World.corruptionChasms = new bool[corruptionWidth];
            World.corruption = createEllipseArray(corruptionWidth, 400);
            List<int> chasmsList = new List<int>();
            int chasmsCount = 0;
            while (chasmsCount < 5)
            {
                chasmsList = new List<int>();
                chasmsCount = 0;
                for (int i = 0; i < corruptionWidth; i++)
                {
                    corruptionChasms[i] = true;
                    World.corruptionChasms[i] = false;
                }
                for (int i = 0; i < corruptionWidth; i++)
                {
                    if (Game.random.NextSingle() < 0.05 && i > 100 && i < corruptionWidth - 120)
                    {
                        int chasmWidth = Game.random.Next(10, 20);
                        int chasmDepth = Game.random.Next(200, 350);
                        for (int j = 0; j < chasmWidth; j++)
                        {
                            corruptionChasms[i + j] = false;
                            World.corruptionChasms[i + j] = true;
                            chasmsList.Add(chasmDepth);
                        }
                        i += chasmWidth + 15;
                        chasmsCount++;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < corruptionWidth; i++)
            {
                if (!corruptionChasms[i])
                {
                    count++;
                }
            }
            for(int x = 0; x < corruptionWidth; x++)
            {
                for(int y = 0; y < 400; y++)
                {
                    initialCorruption[x, y] = true;
                }
            }
            int[] chasms = new int[chasmsList.Count];
            for (int i = 0; i < chasmsList.Count; i++)
            {
                chasms[i] = chasmsList[i];
            }
            for (int y = 0; y < 300; y++)
            {
                int chasmsIndex = 0;
                for (int x = 0; x < corruptionWidth; x++)
                {
                    if (y < 100)
                    {
                        initialCorruption[x, y] = false;
                    }
                    else if (corruptionChasms[x] == false)
                    {
                        if (y < chasms[chasmsIndex])
                        {
                            initialCorruption[x, y] = false;
                        }
                        chasmsIndex++;
                    }
                }
            }
            bool[] undergroundLayer = new bool[corruptionWidth];
            int layerStart = Game.random.Next(50, 100);
            int layerEnd = Game.random.Next(corruptionWidth - 100, corruptionWidth - 50);
            int layerTop = Game.random.Next(200, 300);
            int layerHeight = Game.random.Next(10, 15);
            for (int i = 0; i < corruptionWidth; i++)
            {
                if (i < layerStart || i > layerEnd)
                {
                    undergroundLayer[i] = true;
                }
            }
            for (int x = 0; x < corruptionWidth; x++)
            {
                for (int y = 0; y < 400; y++)
                {
                    if (!undergroundLayer[x] && y > layerTop && y < layerTop + layerHeight)
                    {
                        initialCorruption[x, y] = false;
                    }
                }
            }
            return initialCorruption;
        }//creates the corruption chasms
        // ----------------------------- jungle --------------------------------
        public static void generateJungle()
        {
            if (World.corruptionOnLeft)
            {
                World.jungleOnLeft = false;
            }
            else
            {
                World.jungleOnLeft = true;
            }
            World.jungleWidth = Game.random.Next(550, 700);
            World.jungleHeight = Game.random.Next(800, 920);
            World.jungle = createEllipseArray(World.jungleWidth, World.jungleHeight);
        }//gererates the jungle layout
        // --------------------------- mushroom --------------------------------
        public static void generateMushrooms()
        {
            int numberOfMushrooms = Game.random.Next(5, 8);
            for(int i = 0; i < numberOfMushrooms; i++)
            {
                generateMushroom();
            }
        }//generates multiple mushroom biomes
        public static void generateMushroom()
        {
            int mushroomWidth = Game.random.Next(200, 350);
            int mushroomHeight = mushroomWidth / 2;
            int mushroomX = Game.random.Next(0, World.worldWidth - mushroomWidth);
            int mushroomY = Game.random.Next(300, World.worldHeight - 100 - mushroomHeight);
            if(isNoOverlap(mushroomX, mushroomY, mushroomWidth, mushroomHeight))
            {
                bool[,] mushroom = createEllipseArray(mushroomWidth, mushroomHeight);
                for(int i = 0; i < mushroom.GetLength(0); i++)
                {
                    for(int j = 0;j < mushroom.GetLength(1); j++)
                    {
                        if (mushroom[i, j])
                        {
                            World.biomeMap[mushroomX + i, mushroomY + j] = 5;
                        }
                    }
                }
            }
            else
            {
                generateMushroom();
            }
        }//creates an ellipse to act as a mushroom biome
        public static bool isNoOverlap(int x, int y, int width, int height)
        {
            for(int i = x; i < x + width; i++)
            {
                for(int j = y; j < y + height; j++)
                {
                    if (World.biomeMap[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }//checks the mushrooms dont overlap other biomes
        // ----------------------------- ocean ---------------------------------
        public static void generateOceans()
        {
            generateOcean(true);
            generateOcean(false);
        }//creates an ocean on the left and right hand side of the world
        public static void generateOcean(bool onLeft)
        {
            int oceanWidth = Game.random.Next(250,300);
            int oceanDepth = oceanWidth / 3;
            int oceanLeft;
            int oceanTop = 170;
            if(onLeft)
            {
                oceanLeft = 0;
            }
            else
            {
                oceanLeft = World.worldWidth - oceanWidth;
            }
            for (int x = 0; x < oceanWidth; x++)
            {
                for (int y = 0; y < 170; y++)
                {
                    World.cellMap[x + oceanLeft, y] = false;
                }
            }
            for (int x = 0; x < oceanWidth; x++)
            {
                for(int y = 0; y < oceanDepth; y++)
                {
                    if (onLeft)
                    {
                        if (oceanWidth - x > y * 3)
                        {
                            World.cellMap[x + oceanLeft, y + oceanTop] = false;
                        }
                    }
                    else
                    {
                        if (x > y * 3)
                        {
                            World.cellMap[x + oceanLeft, y + oceanTop] = false;
                        }
                    }
                }
            }
            if (!onLeft)
            {
                oceanLeft -= 50;
            }
            oceanWidth += 50;
            for(int x = oceanLeft; x < oceanLeft + oceanWidth; x++)
            {
                int y = 0;
                int depthUnderground = 0;
                bool underground = false;
                while (depthUnderground <= 50)
                {
                    if (World.cellMap[x, y])
                    {
                        underground = true;
                    }
                    if (underground)
                    {
                        depthUnderground++;
                    }
                    World.biomeMap[x, y] = 6;
                    y++;
                }
            }

        }//cuts out a tringle to be the ocean and starts the ocean biome 50 blocks further in land
    }
}
