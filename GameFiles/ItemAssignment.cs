namespace TerrariaNEA
{
    public class ItemAssignment
    {
        //item ids for the guide
        public static byte[] toolValuesGuide = { 1, 2, 3, 5, 6, 7, 23, 24, 25, 26, 27, 63, 64, 65, 69, 70, 71 };
        public static byte[] oreValuesGuide = { 28, 29, 30, 31, 32, 60 };
        public static byte[] barValuesGuide = { 34, 35, 36, 37, 38, 61 };

        //item ids for chests
        public static byte[] toolIDs = { 0, 1, 2, 3, 4, 5, 6, 7, 23, 24, 25, 26, 27, 63, 64, 65, 69, 70, 71 };
        public static byte[] weaponIDs = { 10, 11, 12, 13, 14, 49, 50, 51, 52, 53, 62, 66, 68, 72 };
        public static byte[] ammoIDs = { 54, 55, 67, 73 };
        public static byte[] oreIDs = { 28, 29, 30, 31, 32, 60 };
        public static byte[] barIDs = { 34, 35, 36, 37, 38, 61 };
        public static byte[] currencyIDs = {17,18,19,20 };
        public static byte[] blockIDs = { 8, 9, 16, 22, 42, 43, 44, 45, 46, 47, 48, 58 };
        public static byte[] furnitureIDs = { 39, 40, 41, 74, 75, 76, 77 };
        public static byte[] miscellaneousIDs;

        // adds each item to the array of items to be used in the game
        public static void assignItemValues()
        {
            // place items in the array to be used
            Game.items[0] = new CopperPickaxe();
            Game.items[1] = new IronPickaxe();
            Game.items[2] = new SilverPickaxe();
            Game.items[3] = new GoldPickaxe();
            Game.items[4] = new CopperAxe();
            Game.items[5] = new IronAxe();
            Game.items[6] = new SilverAxe();
            Game.items[7] = new GoldAxe();
            Game.items[8] = new Dirt();
            Game.items[9] = new Stone();
            Game.items[10] = new WoodSword();
            Game.items[11] = new CopperSword();
            Game.items[12] = new IronSword();
            Game.items[13] = new SilverSword();
            Game.items[14] = new GoldSword();
            Game.items[15] = new Torch();
            Game.items[16] = new Wood();
            Game.items[17] = new CopperCoin();
            Game.items[18] = new SilverCoin();
            Game.items[19] = new GoldCoin();
            Game.items[20] = new PlatinumCoin();
            Game.items[21] = new Gel();
            Game.items[22] = new WoodWall();
            Game.items[23] = new WoodenHammer();
            Game.items[24] = new CopperHammer();
            Game.items[25] = new IronHammer();
            Game.items[26] = new SilverHammer();
            Game.items[27] = new GoldHammer();
            Game.items[28] = new CopperOre();
            Game.items[29] = new IronOre();
            Game.items[30] = new SilverOre();
            Game.items[31] = new GoldOre();
            Game.items[32] = new HellstoneOre();
            Game.items[33] = new Acorn();
            Game.items[34] = new CopperBar();
            Game.items[35] = new IronBar();
            Game.items[36] = new SilverBar();
            Game.items[37] = new GoldBar();
            Game.items[38] = new HellstoneBar();
            Game.items[39] = new WorkBench();
            Game.items[40] = new Furnace();
            Game.items[41] = new Anvil();
            Game.items[42] = new Mud();
            Game.items[43] = new Sand();
            Game.items[44] = new Snow();
            Game.items[45] = new Ice();
            Game.items[46] = new Ebonstone();
            Game.items[47] = new Ash();
            Game.items[48] = new Sandstone();
            Game.items[49] = new WoodenBow();
            Game.items[50] = new CopperBow();
            Game.items[51] = new IronBow();
            Game.items[52] = new SilverBow();
            Game.items[53] = new GoldBow();
            Game.items[54] = new WoodenArrowItem();
            Game.items[55] = new FlamingArrowItem();
            Game.items[56] = new SuspiciousLookingEye();
            Game.items[57] = new LifeCrystal();
            Game.items[58] = new WoodenPlatform();
            Game.items[59] = new Lens();
            Game.items[60] = new DemoniteOre();
            Game.items[61] = new DemoniteBar();
            Game.items[62] = new LightsBane();
            Game.items[63] = new NightmarePickaxe();
            Game.items[64] = new WarAxeOfNight();
            Game.items[65] = new TheBreaker();
            Game.items[66] = new DemonBow();
            Game.items[67] = new UnholyArrowItem();
            Game.items[68] = new FieryGreatSword();
            Game.items[69] = new MoltenPickaxe();
            Game.items[70] = new MoltenAxe();
            Game.items[71] = new MoltenHammer();
            Game.items[72] = new MoltenBow();
            Game.items[73] = new HellfireArrowItem();
            Game.items[74] = new HellForge();
            Game.items[75] = new ChestItem();
            Game.items[76] = new Table();
            Game.items[77] = new Chair();
            //place recipes in the array to be used
            Game.recipes[0] = new CopperBarRecipe();
            Game.recipes[1] = new IronBarRecipe();
            Game.recipes[2] = new SilverBarRecipe();
            Game.recipes[3] = new GoldBarRecipe();
            Game.recipes[4] = new HellstoneBarRecipe();
            Game.recipes[5] = new TorchRecipe();
            Game.recipes[6] = new WoodWallRecipe();
            Game.recipes[7] = new WorkBenchRecipe();
            Game.recipes[8] = new FurnaceRecipe();
            Game.recipes[9] = new AnvilRecipe();
            Game.recipes[10] = new CopperSwordRecipe();
            Game.recipes[11] = new IronSwordRecipe();
            Game.recipes[12] = new SilverSwordRecipe();
            Game.recipes[13] = new GoldSwordRecipe();
            Game.recipes[14] = new WoodSwordRecipe();
            Game.recipes[15] = new CopperPickaxeRecipe();
            Game.recipes[16] = new IronPickaxeRecipe();
            Game.recipes[17] = new SilverPickaxeRecipe();
            Game.recipes[18] = new GoldPickaxeRecipe();
            Game.recipes[19] = new CopperAxeRecipe();
            Game.recipes[20] = new IronAxeRecipe();
            Game.recipes[21] = new SilverAxeRecipe();
            Game.recipes[22] = new GoldAxeRecipe();
            Game.recipes[23] = new CopperHammerRecipe();
            Game.recipes[24] = new IronHammerRecipe();
            Game.recipes[25] = new SilverHammerRecipe();
            Game.recipes[26] = new GoldHammerRecipe();
            Game.recipes[27] = new WoodenHammerRecipe();
            Game.recipes[28] = new WoodenBowRecipe();
            Game.recipes[29] = new CopperBowRecipe();
            Game.recipes[30] = new IronBowRecipe();
            Game.recipes[31] = new SilverBowRecipe();
            Game.recipes[32] = new GoldBowRecipe();
            Game.recipes[33] = new WoodenArrowRecipe();
            Game.recipes[34] = new FlamingArrowRecipe();
            Game.recipes[35] = new WoodenPlatformRecipe();
            Game.recipes[36] = new SuspiciousLookingEyeRecipe();
            Game.recipes[37] = new TableRecipe();
            Game.recipes[38] = new ChairRecipe();
            Game.recipes[39] = new DemoniteBarRecipe();
            Game.recipes[40] = new LightsBaneRecipe();
            Game.recipes[41] = new NightmarePickaxeRecipe();
            Game.recipes[42] = new WarAxeOfNightRecipe();
            Game.recipes[43] = new TheBreakerRecipe();
            Game.recipes[44] = new DemonBowRecipe();
            Game.recipes[45] = new UnholyArrowRecipe();
            Game.recipes[46] = new FieryGreatSwordRecipe();
            Game.recipes[47] = new MoltenPickaxeRecipe();
            Game.recipes[48] = new MoltenAxeRecipe();
            Game.recipes[49] = new MoltenHammerRecipe();
            Game.recipes[50] = new MoltenBowRecipe();
            Game.recipes[51] = new HellfireArrowRecipe();
            Game.recipes[52] = new ChestRecipe();
            Game.recipes[53] = new WoodRecipe1();
            Game.recipes[54] = new WoodRecipe2();
        }//assigns each item and recipe to the array of items or recipes
    }
}