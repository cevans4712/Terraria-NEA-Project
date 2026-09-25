namespace TerrariaNEA
{    public class Game
    {
        //this class contains all the data for the game to use

        // --- projectiles ---
        public static Arrow[] arrows = new Arrow[100];
        //public static Projectile[] bullets = new Projectile[100];
        // --- sprites ---
        public static Bitmap[,] runningAnimation = new Bitmap[10, 2];
        public static Bitmap[,] blockIDs = new Bitmap[255, 3];
        public static Bitmap[,] wallIDs = new Bitmap[255, 3];
        public static Bitmap[] grassSprites = new Bitmap[46];
        public static Bitmap[] corruptGrassSprites = new Bitmap[46];
        public static Bitmap[] jungleGrassSprites = new Bitmap[46];
        public static Bitmap[] mushroomGrassSprites = new Bitmap[46];
        public static Bitmap[] cracksIDs = new Bitmap[3];
        public static Bitmap[] hotbarBG = new Bitmap[4];
        public static Bitmap[] heartsBMPs = new Bitmap[4];
        public static Bitmap[] bubblesBMPs = new Bitmap[4];
        public static Bitmap[] npcBMPs = new Bitmap[255];
        public static Bitmap[] eyeOfClthuluBMPs = new Bitmap[16];
        // --- items ---
        public static Bitmap[] itemIDs = new Bitmap[255];
        public static Item[] items = new Item[255];
        public static Chest[] chests = new Chest[65535];
        public static byte currentItem = 0;
        public static FloorItem[] floorItems = new FloorItem[300];
        public static bool[,] droppedItems = new bool[5000, 1000];
        public static bool[,] currentDroppedItems = new bool[80, 48];
        // --- crafting ---
        public static Recipe[] recipes = new Recipe[255];
        public static byte[] visibleRecipes = new byte[255];
        public static byte[] craftableRecipes = new byte[255];
        public static byte visibleRecipesCount = 0;
        public static byte craftableRecipesCount = 0;
        // --- map ---
        public static int mapCurrentX;
        public static int mapCurrentY;
        public static bool isMapDragging;
        public static float mapZoomMultiplier = 4;
        public static int mapLastSizeX = 4;
        public static int mapLastSizeY = 4;
        public static int mapCurrentSizeX = 4;
        public static int mapCurrentSizeY = 4;
        // --- map colours ---
        public static Color[] blockColourIDs = {
            Color.FromArgb(255, 255, 255, 255),//Blank[0]
            Color.FromArgb(255, 61, 36, 00),//Dirt[1]
            Color.FromArgb(255, 60, 60, 60),//Stone[2]
            Color.FromArgb(255, 80, 80, 80),//Ash[3]
            Color.FromArgb(255, 184, 115, 51),//Copper[4]
            Color.FromArgb(255, 161, 157, 148),//Iron[5]
            Color.FromArgb(255, 197, 206, 212),//Silver[6]
            Color.FromArgb(255, 219, 172, 52),//Gold[7]
            Color.FromArgb(255, 255, 60, 20),//Hellstone[8]
            Color.FromArgb(255, 25, 128, 0),//Grass[9]
            Color.FromArgb(255, 160, 140, 30),//Chest[10]
            Color.FromArgb(255, 255, 255, 255),//Snow[11]
            Color.FromArgb(255, 180, 220, 255),//Ice[12]
            Color.FromArgb(255, 70, 15, 60),//EbonstoneBlock[13]
            Color.FromArgb(255, 72, 62, 40),//Tree[14]
            Color.FromArgb(255, 20, 100, 0),// Leaf[15]
            Color.FromArgb(255, 255, 165, 0),//Torch[16]
            Color.FromArgb(255, 194, 178, 128),//Sand[17]
            Color.FromArgb(255, 194, 100, 50),//SandStone[18]
            Color.FromArgb(255, 72, 62, 40),//Wood[19]
            Color.FromArgb(255, 0, 150, 0),//Cactus[20]
            Color.FromArgb(255, 66, 50, 60),//Mud[21]
            Color.FromArgb(255, 30, 160, 0),//Sapling[22]
            Color.FromArgb(255, 72, 62, 40),//WorkBench[23]
            Color.FromArgb(255, 70, 70, 70),//Furnace[24]
            Color.FromArgb(255, 80, 80, 80),//Anvil[25]
            Color.FromArgb(255, 255, 4, 41),//LifeCrystal[26]
            Color.FromArgb(255, 86, 119, 124),//DungeonBrick[27]
            Color.FromArgb(255, 80, 70, 46),//WoodenPlatform[28]
            Color.FromArgb(255, 100, 20, 90),//DemonAlter[29]
            Color.FromArgb(255, 120, 23, 113),//DemoniteOre[30]
            Color.FromArgb(255, 200, 50, 15),//HellForge[31]
            Color.FromArgb(255, 72, 62, 40),//Table[32]
            Color.FromArgb(255, 72, 62, 40),//Chair[33]
            Color.FromArgb(255, 40, 0, 40),//Obsidian[34]
            Color.FromArgb(255, 80, 70, 15),//Pot[35]
        };
        public static Color[] backgroundColourIDs = { 
            Color.FromArgb(255, 255, 255, 255),//Blank[0]
            Color.FromArgb(255, 30, 20, 0),//Dirt[1]
            Color.FromArgb(255, 30, 30, 30),//Stone[2]
            Color.FromArgb(255, 128, 30, 10),//Underworld[3]
            Color.FromArgb(255, 135, 206, 235),//Sky[4]
            Color.FromArgb(255, 48, 25, 52),//Corruption[5]
            Color.FromArgb(255, 0, 45, 0),//Jungle[6]
            Color.FromArgb(255, 0, 0, 87),//Mushroom[7]
            Color.FromArgb(255, 100, 90, 65),//Desert[8]
            Color.FromArgb(255, 150, 150, 255),//Ice[9]
        };
        public static Color[] wallColourIDs = {
            Color.FromArgb(255, 255, 255, 255),//Blank[0]
            Color.FromArgb(255, 30, 20, 0),//Dirt[1]
            Color.FromArgb(255, 50, 45, 35),//Wood[2]
            Color.FromArgb(255, 130, 130, 130),//Snow[3]
            Color.FromArgb(255, 95, 90, 65),//Sand[4]
            Color.FromArgb(255, 33, 25, 30),//Mud[5]
            Color.FromArgb(255, 43, 60, 62),//DungeonBrick[6]
        };
        // --- graphics bitmaps ---
        public static Bitmap screenBMP;
        public static Graphics Screen;
        public static Bitmap mapBMP;
        public static Graphics Map;
        public static Bitmap hotbarBMP;
        public static Graphics Hotbar;
        public static Bitmap inventoryBMP;
        public static Graphics Inventory;
        public static Bitmap chestUIBMP;
        public static Graphics ChestUI;
        public static Bitmap menuScreenBMP;
        public static Graphics MenuScreen;
        public static Bitmap craftingBMP;
        public static Graphics CraftingUI;
        public static Bitmap dialogueBMP;
        public static Graphics DialogueUI;
        public static Bitmap shopBMP;
        public static Graphics ShopUI;
        public static SolidBrush Brush = new SolidBrush(Color.Black);
        // --- threads ---
        public static Thread lightCalculation;
        public static Thread mouseControlsThread;
        public static Thread movementControlsThread;
        public static Thread inventoryThread;
        public static System.Threading.Timer lightingThread;
        public static Thread npcSpawnThread;
        public static Thread npcMovementThread;
        public static Thread sandGravityThread;
        public static Thread grassGrowthThread;
        public static Thread treeGrowthThread;
        public static Thread checkVisibleRecipesThread;
        public static Thread checkCraftableRecipesThread;
        public static Thread updateFluidsThread;
        public static Thread projectileThread;
        public static Thread friendlyNPCMovementThread;
        // --- npcs ---
        public static Slime[] slimes = new Slime[20];
        public static Fighter[] zombies = new Fighter[20];
        public static FlyingEnemy[] flyingEnemies = new FlyingEnemy[20];
        public static EyeOfCthulhu eyeOfCthulhu = null;
        public static List<int[]> validHouses = new List<int[]>();
        public static Guide guide = null;
        public static Merchant merchant = null;
        public static Nurse nurse = null;
        public static bool[] npcObjectives = {
            true, // Guide - player has entered world
            false, // Merchant - player has at least 50 silver coins
            false, // Nurse - player has used a life crystal
        };
        public static byte currentFriendlyNPC = 0;
        public static string currentDialogue = "";
        public static Shop currentShop;
        // --- fonts ---
        public static Font itemQuantityFont = new Font(new FontFamily("Arial"), 10);
        public static Brush itemQuantityFontsBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        // --- game ---
        public static bool gamePlaying = false;
        public static long totalFrames = 0;
        public static Random random = new Random();
        public static string user = "P218057";
    }
}
