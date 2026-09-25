namespace TerrariaNEA
{
    public class World
    {
        //this class contains all the data relating to the world

        public static int seed;
        public static int worldWidth = 5000;
        public static int worldHeight = 1000;
        public static float[,] waterMap = new float[5000, 1000];//file
        public static float[,] lavaMap = new float[5000, 1000];//file
        public static bool[,] cellMap = new bool[5000, 1000];//file
        public static bool[,] spaceMap = new bool[5000, 1000];//file
        public static bool[,] lightBlocks = new bool[5000, 1000];
        public static ushort[,] chestMap = new ushort[5000, 1000];//file
        public static byte[,] blockMap = new byte[5000, 1000];//file
        public static byte[,] updatedBlockMap = new byte[5000, 1000];
        public static byte[,] wallMap = new byte[5000, 1000];//file
        public static byte[,] backgroundMap = new byte[5000, 1000];//file
        public static byte[,] updatedWallMap = new byte[5000, 1000];
        public static byte[,] grassMap = new byte[5000, 1000];
        public static byte[,] lightMap = new byte[5000, 1000];
        public static byte[,] cracksMap = new byte[5000, 1000];
        public static byte[,] lastLightMap = new byte[5000, 1000];
        public static byte[,] randomSprite = new byte[5000, 1000];
        public static bool[,] blockDiscovered = new bool[5000, 1000];//file
        public static int[,] blockTotalHealth = new int[5000, 1000];
        public static int[,] blockHealth = new int[5000, 1000];
        public static int[,] wallTotalHealth = new int[5000, 1000];
        public static int[,] wallHealth = new int[5000, 1000];
        public static byte[] treeHeight = new byte[5000];
        public static float chanceToStartAlive;
        public static bool mapOpen = false;
        public static bool chestOpen = false;
        public static float oreChance;
        public static float[] caveChance = new float[5000];
        public static byte[,] lastBlockMap = new byte[5000, 1000];
        public static byte[,] currentBlockMap = new byte[5000, 1000];
        public static byte[,] lastWallMap = new byte[5000, 1000];
        public static byte[,] currentWallMap = new byte[5000, 1000];
        public static byte[,] lastBackgroundMap = new byte[5000, 1000];
        public static byte[,] currentBackgroundMap = new byte[5000, 1000];
        public static byte[,] currentBlocks = new byte[80, 48];
        public static float[,] currentWater = new float[80, 48];
        public static float[,] currentLava = new float[80, 48];
        public static byte[,] currentGrass = new byte[80, 48];
        public static byte[,] currentLight = new byte[80, 48];
        public static byte[,] currentCracks = new byte[80, 48];
        public static byte[,] currentWalls = new byte[80, 48];
        public static byte[,] currentBackgrounds = new byte[80, 48];
        public static byte[,] currentBiomes = new byte[80, 48];
        public static bool[,] currentCells = new bool[80, 48];
        public static int[] dirtHeight = new int[5000];
        public static int[] stoneHeight = new int[5000];
        public static int[] ashHeight = new int[5000];
        public static int[] surfaceHeight = new int[5000];
        public static int timeOfDay = 600;
        public static int currentCorridorWidth = 0;
        // --- biomes ---
        public static byte[,] biomeMap = new byte[5000, 1000];//file
        //desert
        public static bool[,] desert;
        public static int desertWidth;
        public static int desertHeight;
        public static bool desertOnLeft = false;
        public static int desertStart;
        //ice
        public static bool[,] ice;
        public static int iceWidth;
        public static int iceHeight;
        public static bool iceOnLeft = false;
        //corruption
        public static bool[,] corruption;
        public static bool corruptionOnLeft = false;
        public static int corruptionStart;
        public static int corruptionWidth;
        public static bool[] corruptionChasms;
        //jungle
        public static bool[,] jungle;
        public static int jungleWidth;
        public static int jungleHeight;
        public static bool jungleOnLeft = false;
    }
}
