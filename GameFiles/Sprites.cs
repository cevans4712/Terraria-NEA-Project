namespace TerrariaNEA
{
    public class Sprites
    {
        //All code in this class is about assigning bitmaps to arrays for easy access during output
        public static void transparentImages()
        {
            //miscellaneous
            Game.runningAnimation[0, 0] = makeTransparent(Properties.Resources.PlayerRightIdle, Color.White, 5);
            Game.runningAnimation[0, 1] = makeTransparent(Properties.Resources.PlayerLeftIdle, Color.White, 5);
            Game.cracksIDs[0] = makeTransparent(Properties.Resources.Cracks1, Color.White, 5);
            Game.cracksIDs[1] = makeTransparent(Properties.Resources.Cracks2, Color.White, 5);
            Game.cracksIDs[2] = makeTransparent(Properties.Resources.Cracks3, Color.White, 5);
            Game.hotbarBG[0] = makeTransparent(Properties.Resources.Hotbar1, Color.White, 5);
            Game.hotbarBG[1] = makeTransparent(Properties.Resources.Hotbar2, Color.White, 5);
            Game.hotbarBG[2] = makeTransparent(Properties.Resources.Hotbar3, Color.White, 5);
            Game.hotbarBG[3] = makeTransparent(Properties.Resources.Hotbar4, Color.White, 5);
            //items
            //pickaxes
            Game.itemIDs[0] = makeTransparent(Properties.Resources.CopperPickaxe, Color.White, 5);
            Game.itemIDs[1] = makeTransparent(Properties.Resources.IronPickaxe, Color.White, 5);
            Game.itemIDs[2] = makeTransparent(Properties.Resources.SilverPickaxe, Color.White, 5);
            Game.itemIDs[3] = makeTransparent(Properties.Resources.GoldPickaxe, Color.White, 5);
            //axes
            Game.itemIDs[4] = makeTransparent(Properties.Resources.CopperAxe, Color.White, 5);
            Game.itemIDs[5] = makeTransparent(Properties.Resources.IronAxe, Color.White, 5);
            Game.itemIDs[6] = makeTransparent(Properties.Resources.SilverAxe, Color.White, 5);
            Game.itemIDs[7] = makeTransparent(Properties.Resources.GoldAxe, Color.White, 5);
            //blocks
            Game.itemIDs[8] = makeTransparent(Properties.Resources.Dirt, Color.White, 5);
            Game.itemIDs[9] = makeTransparent(Properties.Resources.Stone, Color.White, 5);
            Game.itemIDs[16] = makeTransparent(Properties.Resources.Wood, Color.White, 5);
            Game.itemIDs[28] = makeTransparent(Properties.Resources.CopperOre, Color.White, 5);
            Game.itemIDs[29] = makeTransparent(Properties.Resources.IronOre, Color.White, 5);
            Game.itemIDs[30] = makeTransparent(Properties.Resources.SilverOre, Color.White, 5);
            Game.itemIDs[31] = makeTransparent(Properties.Resources.GoldOre, Color.White, 5);
            Game.itemIDs[32] = makeTransparent(Properties.Resources.HellstoneOre, Color.White, 5);
            Game.itemIDs[33] = makeTransparent(Properties.Resources.Acorn, Color.White, 5);
            Game.itemIDs[39] = makeTransparent(Properties.Resources.WorkBench, Color.White, 5);
            Game.itemIDs[40] = makeTransparent(Properties.Resources.Furnace, Color.White, 5);
            Game.itemIDs[41] = makeTransparent(Properties.Resources.Anvil, Color.White, 5);
            Game.itemIDs[42] = makeTransparent(Properties.Resources.Mud, Color.White, 5);
            Game.itemIDs[43] = makeTransparent(Properties.Resources.Sand, Color.White, 5);
            Game.itemIDs[44] = makeTransparent(Properties.Resources.Snow, Color.White, 5);
            Game.itemIDs[45] = makeTransparent(Properties.Resources.Ice, Color.White, 5);
            Game.itemIDs[46] = makeTransparent(Properties.Resources.Ebonstone, Color.White, 5);
            Game.itemIDs[47] = makeTransparent(Properties.Resources.Ash, Color.White, 5);
            Game.itemIDs[48] = makeTransparent(Properties.Resources.Sandstone, Color.White, 5);
            Game.itemIDs[58] = makeTransparent(Properties.Resources.WoodenPlatform, Color.White, 5);
            Game.itemIDs[75] = makeTransparent(Properties.Resources.Chest, Color.White, 5);
            Game.itemIDs[76] = makeTransparent(Properties.Resources.Table, Color.White, 5);
            Game.itemIDs[77] = makeTransparent(Properties.Resources.Chair, Color.White, 5);
            //swords
            Game.itemIDs[10] = makeTransparent(Properties.Resources.WoodSword, Color.White, 5);
            Game.itemIDs[11] = makeTransparent(Properties.Resources.CopperSword, Color.White, 5);
            Game.itemIDs[12] = makeTransparent(Properties.Resources.IronSword, Color.White, 5);
            Game.itemIDs[13] = makeTransparent(Properties.Resources.SilverSword, Color.White, 5);
            Game.itemIDs[14] = makeTransparent(Properties.Resources.GoldSword, Color.White, 5);
            //torches
            Game.itemIDs[15] = makeTransparent(Properties.Resources.Torch, Color.White, 5);
            //coins
            Game.itemIDs[17] = makeTransparent(Properties.Resources.CopperCoin, Color.White, 5);
            Game.itemIDs[18] = makeTransparent(Properties.Resources.SilverCoin, Color.White, 5);
            Game.itemIDs[19] = makeTransparent(Properties.Resources.GoldCoin, Color.White, 5);
            Game.itemIDs[20] = makeTransparent(Properties.Resources.PlatinumCoin, Color.White, 5);
            //materials
            Game.itemIDs[21] = makeTransparent(Properties.Resources.Gel, Color.White, 5);
            Game.itemIDs[34] = makeTransparent(Properties.Resources.CopperBar, Color.White, 5);
            Game.itemIDs[35] = makeTransparent(Properties.Resources.IronBar, Color.White, 5);
            Game.itemIDs[36] = makeTransparent(Properties.Resources.SilverBar, Color.White, 5);
            Game.itemIDs[37] = makeTransparent(Properties.Resources.GoldBar, Color.White, 5);
            Game.itemIDs[38] = makeTransparent(Properties.Resources.HellstoneBar, Color.White, 5);
            Game.itemIDs[59] = makeTransparent(Properties.Resources.Lens, Color.White, 5);
            //walls
            Game.itemIDs[22] = makeTransparent(Properties.Resources.WoodWall, Color.White, 5);
            //hammers
            Game.itemIDs[23] = makeTransparent(Properties.Resources.WoodenHammer, Color.White, 5);
            Game.itemIDs[24] = makeTransparent(Properties.Resources.CopperHammer, Color.White, 5);
            Game.itemIDs[25] = makeTransparent(Properties.Resources.IronHammer, Color.White, 5);
            Game.itemIDs[26] = makeTransparent(Properties.Resources.SIlverHammer, Color.White, 5);
            Game.itemIDs[27] = makeTransparent(Properties.Resources.GoldHammer, Color.White, 5);
            //bows / arrows
            Game.itemIDs[49] = makeTransparent(Properties.Resources.WoodenBow, Color.White, 5);
            Game.itemIDs[50] = makeTransparent(Properties.Resources.CopperBow, Color.White, 5);
            Game.itemIDs[51] = makeTransparent(Properties.Resources.IronBow, Color.White, 5);
            Game.itemIDs[52] = makeTransparent(Properties.Resources.SilverBow, Color.White, 5);
            Game.itemIDs[53] = makeTransparent(Properties.Resources.GoldBow, Color.White, 5);
            Game.itemIDs[54] = makeTransparent(Properties.Resources.WoodenArrow, Color.White, 5);
            Game.itemIDs[55] = makeTransparent(Properties.Resources.FlamingArrow, Color.White, 5);
            //boss spawners]
            Game.itemIDs[56] = makeTransparent(Properties.Resources.SuspiciousLookingEye, Color.White, 5);
            //consumables
            Game.itemIDs[57] = makeTransparent(Properties.Resources.LifeCrystal, Color.White, 5);
            //demonite
            Game.itemIDs[60] = makeTransparent(Properties.Resources.DemoniteOre, Color.White, 5);
            Game.itemIDs[61] = makeTransparent(Properties.Resources.DemoniteBar, Color.White, 5);
            Game.itemIDs[62] = makeTransparent(Properties.Resources.LightsBane, Color.White, 5);
            Game.itemIDs[63] = makeTransparent(Properties.Resources.NightmarePickaxe, Color.White, 5);
            Game.itemIDs[64] = makeTransparent(Properties.Resources.WarAxeOfNight, Color.White, 5);
            Game.itemIDs[65] = makeTransparent(Properties.Resources.TheBreaker, Color.White, 5);
            Game.itemIDs[66] = makeTransparent(Properties.Resources.DemonBow, Color.White, 5);
            Game.itemIDs[67] = makeTransparent(Properties.Resources.UnholyArrow, Color.White, 5);
            //hellstone
            Game.itemIDs[68] = makeTransparent(Properties.Resources.FieryGreatSword, Color.White, 5);
            Game.itemIDs[69] = makeTransparent(Properties.Resources.MoltenPickaxe, Color.White, 5);
            Game.itemIDs[70] = makeTransparent(Properties.Resources.MoltenAxe, Color.White, 5);
            Game.itemIDs[71] = makeTransparent(Properties.Resources.MoltenHammer, Color.White, 5);
            Game.itemIDs[72] = makeTransparent(Properties.Resources.MoltenBow, Color.White, 5);
            Game.itemIDs[73] = makeTransparent(Properties.Resources.HellfireArrow, Color.White, 5);
            Game.itemIDs[74] = makeTransparent(Properties.Resources.HellForge, Color.White, 5);


            // --- blocks ---
            //single sprite blocks with transparent background
            for (int i = 0; i < 3; i++)
            {
                Game.blockIDs[16, i] = makeTransparent(Properties.Resources.Torch1, Color.White, 5);
                Game.blockIDs[19, i] = makeTransparent(Properties.Resources.Wood1, Color.White, 5);
                Game.blockIDs[28, i] = makeTransparent(Properties.Resources.WoodenPlatform1, Color.White, 5);
                Game.blockIDs[22, i] = makeTransparent(Properties.Resources.Sapling1, Color.White, 5);
                Game.blockIDs[23, i] = makeTransparent(Properties.Resources.WorkBench1, Color.White, 5);
                Game.blockIDs[25, i] = makeTransparent(Properties.Resources.Anvil1, Color.White, 5);
            }
            // --- miscellaneous ---
            Game.heartsBMPs[0] = makeTransparent(Properties.Resources.Heart25, Color.White, 5);
            Game.heartsBMPs[1] = makeTransparent(Properties.Resources.Heart50, Color.White, 5);
            Game.heartsBMPs[2] = makeTransparent(Properties.Resources.Heart75, Color.White, 5);
            Game.heartsBMPs[3] = makeTransparent(Properties.Resources.HeartFull, Color.White, 5);
            Game.bubblesBMPs[0] = makeTransparent(Properties.Resources.Bubble25, Color.White, 5);
            Game.bubblesBMPs[1] = makeTransparent(Properties.Resources.Bubble50, Color.White, 5);
            Game.bubblesBMPs[2] = makeTransparent(Properties.Resources.Bubble75, Color.White, 5);
            Game.bubblesBMPs[3] = makeTransparent(Properties.Resources.BubbleFull, Color.White, 5);
            // --- npcs ---
            Game.npcBMPs[0] = makeTransparent(Properties.Resources.GreenSlime, Color.White, 5);
            Game.npcBMPs[1] = makeTransparent(Properties.Resources.BlueSlime, Color.White, 5);
            Game.npcBMPs[2] = makeTransparent(Properties.Resources.PurpleSlime, Color.White, 5);
            Game.npcBMPs[3] = makeTransparent(Properties.Resources.IceSlime, Color.White, 5);
            Game.npcBMPs[4] = makeTransparent(Properties.Resources.SandSlime, Color.White, 5);
            Game.npcBMPs[5] = makeTransparent(Properties.Resources.JungleSlime, Color.White, 5);
            Game.npcBMPs[6] = makeTransparent(Properties.Resources.ZombieLeft, Color.White, 5);
            Game.npcBMPs[7] = makeTransparent(Properties.Resources.ZombieRight, Color.White, 5);
            Game.npcBMPs[8] = makeTransparent(Properties.Resources.EskimoLeft, Color.White, 5);
            Game.npcBMPs[9] = makeTransparent(Properties.Resources.EskimoRight, Color.White, 5);
            Game.npcBMPs[10] = makeTransparent(Properties.Resources.MummyLeft, Color.White, 5);
            Game.npcBMPs[11] = makeTransparent(Properties.Resources.MummyRight, Color.White, 5);
            Game.npcBMPs[12] = makeTransparent(Properties.Resources.SkeletonLeft, Color.White, 5);
            Game.npcBMPs[13] = makeTransparent(Properties.Resources.SkeletonRight, Color.White, 5);
            //demon eye
            Game.npcBMPs[14] = makeTransparent(Properties.Resources.DemonEye_RightDown, Color.White, 5);
            Game.npcBMPs[15] = makeTransparent(Properties.Resources.DemonEye_Down, Color.White, 5);
            Game.npcBMPs[16] = makeTransparent(Properties.Resources.DemonEye_LeftDown, Color.White, 5);
            Game.npcBMPs[17] = makeTransparent(Properties.Resources.DemonEye_Right, Color.White, 5);
            Game.npcBMPs[18] = makeTransparent(Properties.Resources.DemonEye_Left, Color.White, 5);
            Game.npcBMPs[19] = makeTransparent(Properties.Resources.DemonEye_RightUp, Color.White, 5);
            Game.npcBMPs[20] = makeTransparent(Properties.Resources.DemonEye_Up, Color.White, 5);
            Game.npcBMPs[21] = makeTransparent(Properties.Resources.DemonEye_LeftUp, Color.White, 5);
            //guide
            Game.npcBMPs[22] = makeTransparent(Properties.Resources.GuideLeft, Color.White, 5);
            Game.npcBMPs[23] = makeTransparent(Properties.Resources.GuideRight, Color.White, 5);
            //merchant
            Game.npcBMPs[24] = makeTransparent(Properties.Resources.MerchantLeft, Color.White, 5);
            Game.npcBMPs[25] = makeTransparent(Properties.Resources.MerchantRight, Color.White, 5);
            //nurse
            Game.npcBMPs[26] = makeTransparent(Properties.Resources.NurseLeft, Color.White, 5);
            Game.npcBMPs[27] = makeTransparent(Properties.Resources.NurseRight, Color.White, 5);

            // --- bosses ---
            Game.eyeOfClthuluBMPs[0] = makeTransparent(Properties.Resources.EyeOfClthulu_UpLeft, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[1] = makeTransparent(Properties.Resources.EyeOfClthulu_Up, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[2] = makeTransparent(Properties.Resources.EyeOfClthulu_UpRight, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[3] = makeTransparent(Properties.Resources.EyeOfClthulu_Left, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[4] = makeTransparent(Properties.Resources.EyeOfClthulu_Right, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[5] = makeTransparent(Properties.Resources.EyeOfClthulu_DownLeft, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[6] = makeTransparent(Properties.Resources.EyeOfClthulu_Down, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[7] = makeTransparent(Properties.Resources.EyeOfClthulu_DownRight, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[8] = makeTransparent(Properties.Resources.EyeOfClthulu_UpLeft2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[9] = makeTransparent(Properties.Resources.EyeOfClthulu_Up2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[10] = makeTransparent(Properties.Resources.EyeOfClthulu_UpRight2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[11] = makeTransparent(Properties.Resources.EyeOfClthulu_Left2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[12] = makeTransparent(Properties.Resources.EyeOfClthulu_Right2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[13] = makeTransparent(Properties.Resources.EyeOfClthulu_DownLeft2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[14] = makeTransparent(Properties.Resources.EyeOfClthulu_Down2, Color.FromArgb(255,0, 255, 0), 5);
            Game.eyeOfClthuluBMPs[15] = makeTransparent(Properties.Resources.EyeOfClthulu_DownRight2, Color.FromArgb(255,0, 255, 0), 5);

        }// transparent sprites

        //Any bitmap that needs to be transparent instead of a white background
        public static Bitmap makeTransparent(Bitmap bitmap, Color color, int tolerance)
        {
            Bitmap transparentImage = new Bitmap(bitmap);
            for (int i = 0; i < transparentImage.Size.Width - 1; i++)
            {
                for (int j = 0; j < transparentImage.Size.Height - 1; j++)
                {
                    Color currentColor = transparentImage.GetPixel(i, j);
                    if (Math.Abs(color.R - currentColor.R) < tolerance && Math.Abs(color.G - currentColor.G) < tolerance && Math.Abs(color.B - currentColor.B) < tolerance)
                    {
                        transparentImage.SetPixel(i, j, color);
                    }
                }
            }
            transparentImage.MakeTransparent(color);
            return transparentImage;
        }//turns white into transparent
        public static void blockImages()
        {
            //blocks
            Game.blockIDs[1, 0] = Properties.Resources.Dirt1;
            Game.blockIDs[1, 1] = Properties.Resources.Dirt2;
            Game.blockIDs[1, 2] = Properties.Resources.Dirt3;
            Game.blockIDs[2, 0] = Properties.Resources.Stone1;
            Game.blockIDs[2, 1] = Properties.Resources.Stone2;
            Game.blockIDs[2, 2] = Properties.Resources.Stone3;
            Game.blockIDs[3, 0] = Properties.Resources.Ash1;
            Game.blockIDs[3, 1] = Properties.Resources.Ash2;
            Game.blockIDs[3, 2] = Properties.Resources.Ash3;
            Game.blockIDs[15, 0] = Properties.Resources.Leaf1;
            Game.blockIDs[15, 1] = Properties.Resources.Leaf2;
            Game.blockIDs[15, 2] = Properties.Resources.Leaf3;
            Game.blockIDs[17, 0] = Properties.Resources.Sand1;
            Game.blockIDs[17, 1] = Properties.Resources.Sand2;
            Game.blockIDs[17, 2] = Properties.Resources.Sand3;
            Game.blockIDs[11, 0] = Properties.Resources.Snow1;
            Game.blockIDs[11, 1] = Properties.Resources.Snow2;
            Game.blockIDs[11, 2] = Properties.Resources.Snow3;
            Game.blockIDs[12, 0] = Properties.Resources.Ice1;
            Game.blockIDs[12, 1] = Properties.Resources.Ice2;
            Game.blockIDs[12, 2] = Properties.Resources.Ice3;
            Game.blockIDs[21, 0] = Properties.Resources.Mud1;
            Game.blockIDs[21, 1] = Properties.Resources.Mud2;
            Game.blockIDs[21, 2] = Properties.Resources.Mud3;
            Game.blockIDs[13, 0] = Properties.Resources.EbonstoneBlock1;
            Game.blockIDs[13, 1] = Properties.Resources.EbonstoneBlock2;
            Game.blockIDs[13, 2] = Properties.Resources.EbonstoneBlock3;
            //single sprite blocks
            for (int i = 0; i < 3; i++)
            {
                Game.blockIDs[4, i] = Properties.Resources.Copper1;
                Game.blockIDs[5, i] = Properties.Resources.Iron1;
                Game.blockIDs[6, i] = Properties.Resources.Silver1;
                Game.blockIDs[7, i] = Properties.Resources.Gold1;
                Game.blockIDs[8, i] = Properties.Resources.Hellstone1;
                Game.blockIDs[30, i] = Properties.Resources.Demonite1;
                Game.blockIDs[14, i] = Properties.Resources.Tree1;
                Game.blockIDs[18, i] = Properties.Resources.SandStone1;
                Game.blockIDs[20, i] = Properties.Resources.Cactus1;
                Game.wallIDs[2, i] = Properties.Resources.WoodWall1;
                Game.wallIDs[4, i] = Properties.Resources.SandWall1;
                Game.wallIDs[5, i] = Properties.Resources.MudWall1;
                Game.blockIDs[35, i] = Properties.Resources.Pot1;
            }
            //grass
            Game.grassSprites[0] = Properties.Resources.Grass1;
            Game.grassSprites[1] = Properties.Resources.Grass2;
            Game.grassSprites[2] = Properties.Resources.Grass3;
            Game.grassSprites[3] = Properties.Resources.Grass4;
            Game.grassSprites[4] = Properties.Resources.Grass5;
            Game.grassSprites[5] = Properties.Resources.Grass6;
            Game.grassSprites[6] = Properties.Resources.Grass7;
            Game.grassSprites[7] = Properties.Resources.Grass8;
            Game.grassSprites[8] = Properties.Resources.Grass9;
            Game.grassSprites[9] = Properties.Resources.Grass10;
            Game.grassSprites[10] = Properties.Resources.Grass11;
            Game.grassSprites[11] = Properties.Resources.Grass12;
            Game.grassSprites[12] = Properties.Resources.Grass13;
            Game.grassSprites[13] = Properties.Resources.Grass14;
            Game.grassSprites[14] = Properties.Resources.Grass15;
            Game.grassSprites[15] = Properties.Resources.Grass16;
            Game.grassSprites[16] = Properties.Resources.Grass17;
            Game.grassSprites[17] = Properties.Resources.Grass18;
            Game.grassSprites[18] = Properties.Resources.Grass19;
            Game.grassSprites[19] = Properties.Resources.Grass20;
            Game.grassSprites[20] = Properties.Resources.Grass21;
            Game.grassSprites[21] = Properties.Resources.Grass22;
            Game.grassSprites[22] = Properties.Resources.Grass23;
            Game.grassSprites[23] = Properties.Resources.Grass24;
            Game.grassSprites[24] = Properties.Resources.Grass25;
            Game.grassSprites[25] = Properties.Resources.Grass26;
            Game.grassSprites[26] = Properties.Resources.Grass27;
            Game.grassSprites[27] = Properties.Resources.Grass28;
            Game.grassSprites[28] = Properties.Resources.Grass29;
            Game.grassSprites[29] = Properties.Resources.Grass30;
            Game.grassSprites[30] = Properties.Resources.Grass31;
            Game.grassSprites[31] = Properties.Resources.Grass32;
            Game.grassSprites[32] = Properties.Resources.Grass33;
            Game.grassSprites[33] = Properties.Resources.Grass34;
            Game.grassSprites[34] = Properties.Resources.Grass35;
            Game.grassSprites[35] = Properties.Resources.Grass36;
            Game.grassSprites[36] = Properties.Resources.Grass37;
            Game.grassSprites[37] = Properties.Resources.Grass38;
            Game.grassSprites[38] = Properties.Resources.Grass39;
            Game.grassSprites[39] = Properties.Resources.Grass40;
            Game.grassSprites[40] = Properties.Resources.Grass41;
            Game.grassSprites[41] = Properties.Resources.Grass42;
            Game.grassSprites[42] = Properties.Resources.Grass43;
            Game.grassSprites[43] = Properties.Resources.Grass44;
            Game.grassSprites[44] = Properties.Resources.Grass45;
            Game.grassSprites[45] = Properties.Resources.Grass46;
            Game.corruptGrassSprites[0] = Properties.Resources.PurpleGrass1;
            Game.corruptGrassSprites[1] = Properties.Resources.PurpleGrass2;
            Game.corruptGrassSprites[2] = Properties.Resources.PurpleGrass3;
            Game.corruptGrassSprites[3] = Properties.Resources.PurpleGrass4;
            Game.corruptGrassSprites[4] = Properties.Resources.PurpleGrass5;
            Game.corruptGrassSprites[5] = Properties.Resources.PurpleGrass6;
            Game.corruptGrassSprites[6] = Properties.Resources.PurpleGrass7;
            Game.corruptGrassSprites[7] = Properties.Resources.PurpleGrass8;
            Game.corruptGrassSprites[8] = Properties.Resources.PurpleGrass9;
            Game.corruptGrassSprites[9] = Properties.Resources.PurpleGrass10;
            Game.corruptGrassSprites[10] = Properties.Resources.PurpleGrass11;
            Game.corruptGrassSprites[11] = Properties.Resources.PurpleGrass12;
            Game.corruptGrassSprites[12] = Properties.Resources.PurpleGrass13;
            Game.corruptGrassSprites[13] = Properties.Resources.PurpleGrass14;
            Game.corruptGrassSprites[14] = Properties.Resources.PurpleGrass15;
            Game.corruptGrassSprites[15] = Properties.Resources.PurpleGrass16;
            Game.corruptGrassSprites[16] = Properties.Resources.PurpleGrass17;
            Game.corruptGrassSprites[17] = Properties.Resources.PurpleGrass18;
            Game.corruptGrassSprites[18] = Properties.Resources.PurpleGrass19;
            Game.corruptGrassSprites[19] = Properties.Resources.PurpleGrass20;
            Game.corruptGrassSprites[20] = Properties.Resources.PurpleGrass21;
            Game.corruptGrassSprites[21] = Properties.Resources.PurpleGrass22;
            Game.corruptGrassSprites[22] = Properties.Resources.PurpleGrass23;
            Game.corruptGrassSprites[23] = Properties.Resources.PurpleGrass24;
            Game.corruptGrassSprites[24] = Properties.Resources.PurpleGrass25;
            Game.corruptGrassSprites[25] = Properties.Resources.PurpleGrass26;
            Game.corruptGrassSprites[26] = Properties.Resources.PurpleGrass27;
            Game.corruptGrassSprites[27] = Properties.Resources.PurpleGrass28;
            Game.corruptGrassSprites[28] = Properties.Resources.PurpleGrass29;
            Game.corruptGrassSprites[29] = Properties.Resources.PurpleGrass30;
            Game.corruptGrassSprites[30] = Properties.Resources.PurpleGrass31;
            Game.corruptGrassSprites[31] = Properties.Resources.PurpleGrass32;
            Game.corruptGrassSprites[32] = Properties.Resources.PurpleGrass33;
            Game.corruptGrassSprites[33] = Properties.Resources.PurpleGrass34;
            Game.corruptGrassSprites[34] = Properties.Resources.PurpleGrass35;
            Game.corruptGrassSprites[35] = Properties.Resources.PurpleGrass36;
            Game.corruptGrassSprites[36] = Properties.Resources.PurpleGrass37;
            Game.corruptGrassSprites[37] = Properties.Resources.PurpleGrass38;
            Game.corruptGrassSprites[38] = Properties.Resources.PurpleGrass39;
            Game.corruptGrassSprites[39] = Properties.Resources.PurpleGrass40;
            Game.corruptGrassSprites[40] = Properties.Resources.PurpleGrass41;
            Game.corruptGrassSprites[41] = Properties.Resources.PurpleGrass42;
            Game.corruptGrassSprites[42] = Properties.Resources.PurpleGrass43;
            Game.corruptGrassSprites[43] = Properties.Resources.PurpleGrass44;
            Game.corruptGrassSprites[44] = Properties.Resources.PurpleGrass45;
            Game.corruptGrassSprites[45] = Properties.Resources.PurpleGrass46;
            Game.jungleGrassSprites[0] = Properties.Resources.JungleGrass1;
            Game.jungleGrassSprites[1] = Properties.Resources.JungleGrass2;
            Game.jungleGrassSprites[2] = Properties.Resources.JungleGrass3;
            Game.jungleGrassSprites[3] = Properties.Resources.JungleGrass4;
            Game.jungleGrassSprites[4] = Properties.Resources.JungleGrass5;
            Game.jungleGrassSprites[5] = Properties.Resources.JungleGrass6;
            Game.jungleGrassSprites[6] = Properties.Resources.JungleGrass7;
            Game.jungleGrassSprites[7] = Properties.Resources.JungleGrass8;
            Game.jungleGrassSprites[8] = Properties.Resources.JungleGrass9;
            Game.jungleGrassSprites[9] = Properties.Resources.JungleGrass10;
            Game.jungleGrassSprites[10] = Properties.Resources.JungleGrass11;
            Game.jungleGrassSprites[11] = Properties.Resources.JungleGrass12;
            Game.jungleGrassSprites[12] = Properties.Resources.JungleGrass13;
            Game.jungleGrassSprites[13] = Properties.Resources.JungleGrass14;
            Game.jungleGrassSprites[14] = Properties.Resources.JungleGrass15;
            Game.jungleGrassSprites[15] = Properties.Resources.JungleGrass16;
            Game.jungleGrassSprites[16] = Properties.Resources.JungleGrass17;
            Game.jungleGrassSprites[17] = Properties.Resources.JungleGrass18;
            Game.jungleGrassSprites[18] = Properties.Resources.JungleGrass19;
            Game.jungleGrassSprites[19] = Properties.Resources.JungleGrass20;
            Game.jungleGrassSprites[20] = Properties.Resources.JungleGrass21;
            Game.jungleGrassSprites[21] = Properties.Resources.JungleGrass22;
            Game.jungleGrassSprites[22] = Properties.Resources.JungleGrass23;
            Game.jungleGrassSprites[23] = Properties.Resources.JungleGrass24;
            Game.jungleGrassSprites[24] = Properties.Resources.JungleGrass25;
            Game.jungleGrassSprites[25] = Properties.Resources.JungleGrass26;
            Game.jungleGrassSprites[26] = Properties.Resources.JungleGrass27;
            Game.jungleGrassSprites[27] = Properties.Resources.JungleGrass28;
            Game.jungleGrassSprites[28] = Properties.Resources.JungleGrass29;
            Game.jungleGrassSprites[29] = Properties.Resources.JungleGrass30;
            Game.jungleGrassSprites[30] = Properties.Resources.JungleGrass31;
            Game.jungleGrassSprites[31] = Properties.Resources.JungleGrass32;
            Game.jungleGrassSprites[32] = Properties.Resources.JungleGrass33;
            Game.jungleGrassSprites[33] = Properties.Resources.JungleGrass34;
            Game.jungleGrassSprites[34] = Properties.Resources.JungleGrass35;
            Game.jungleGrassSprites[35] = Properties.Resources.JungleGrass36;
            Game.jungleGrassSprites[36] = Properties.Resources.JungleGrass37;
            Game.jungleGrassSprites[37] = Properties.Resources.JungleGrass38;
            Game.jungleGrassSprites[38] = Properties.Resources.JungleGrass39;
            Game.jungleGrassSprites[39] = Properties.Resources.JungleGrass40;
            Game.jungleGrassSprites[40] = Properties.Resources.JungleGrass41;
            Game.jungleGrassSprites[41] = Properties.Resources.JungleGrass42;
            Game.jungleGrassSprites[42] = Properties.Resources.JungleGrass43;
            Game.jungleGrassSprites[43] = Properties.Resources.JungleGrass44;
            Game.jungleGrassSprites[44] = Properties.Resources.JungleGrass45;
            Game.jungleGrassSprites[45] = Properties.Resources.JungleGrass46;
            Game.mushroomGrassSprites[0] = Properties.Resources.MushroomGrass1;
            Game.mushroomGrassSprites[1] = Properties.Resources.MushroomGrass2;
            Game.mushroomGrassSprites[2] = Properties.Resources.MushroomGrass3;
            Game.mushroomGrassSprites[3] = Properties.Resources.MushroomGrass4;
            Game.mushroomGrassSprites[4] = Properties.Resources.MushroomGrass5;
            Game.mushroomGrassSprites[5] = Properties.Resources.MushroomGrass6;
            Game.mushroomGrassSprites[6] = Properties.Resources.MushroomGrass7;
            Game.mushroomGrassSprites[7] = Properties.Resources.MushroomGrass8;
            Game.mushroomGrassSprites[8] = Properties.Resources.MushroomGrass9;
            Game.mushroomGrassSprites[9] = Properties.Resources.MushroomGrass10;
            Game.mushroomGrassSprites[10] = Properties.Resources.MushroomGrass11;
            Game.mushroomGrassSprites[11] = Properties.Resources.MushroomGrass12;
            Game.mushroomGrassSprites[12] = Properties.Resources.MushroomGrass13;
            Game.mushroomGrassSprites[13] = Properties.Resources.MushroomGrass14;
            Game.mushroomGrassSprites[14] = Properties.Resources.MushroomGrass15;
            Game.mushroomGrassSprites[15] = Properties.Resources.MushroomGrass16;
            Game.mushroomGrassSprites[16] = Properties.Resources.MushroomGrass17;
            Game.mushroomGrassSprites[17] = Properties.Resources.MushroomGrass18;
            Game.mushroomGrassSprites[18] = Properties.Resources.MushroomGrass19;
            Game.mushroomGrassSprites[19] = Properties.Resources.MushroomGrass20;
            Game.mushroomGrassSprites[20] = Properties.Resources.MushroomGrass21;
            Game.mushroomGrassSprites[21] = Properties.Resources.MushroomGrass22;
            Game.mushroomGrassSprites[22] = Properties.Resources.MushroomGrass23;
            Game.mushroomGrassSprites[23] = Properties.Resources.MushroomGrass24;
            Game.mushroomGrassSprites[24] = Properties.Resources.MushroomGrass25;
            Game.mushroomGrassSprites[25] = Properties.Resources.MushroomGrass26;
            Game.mushroomGrassSprites[26] = Properties.Resources.MushroomGrass27;
            Game.mushroomGrassSprites[27] = Properties.Resources.MushroomGrass28;
            Game.mushroomGrassSprites[28] = Properties.Resources.MushroomGrass29;
            Game.mushroomGrassSprites[29] = Properties.Resources.MushroomGrass30;
            Game.mushroomGrassSprites[30] = Properties.Resources.MushroomGrass31;
            Game.mushroomGrassSprites[31] = Properties.Resources.MushroomGrass32;
            Game.mushroomGrassSprites[32] = Properties.Resources.MushroomGrass33;
            Game.mushroomGrassSprites[33] = Properties.Resources.MushroomGrass34;
            Game.mushroomGrassSprites[34] = Properties.Resources.MushroomGrass35;
            Game.mushroomGrassSprites[35] = Properties.Resources.MushroomGrass36;
            Game.mushroomGrassSprites[36] = Properties.Resources.MushroomGrass37;
            Game.mushroomGrassSprites[37] = Properties.Resources.MushroomGrass38;
            Game.mushroomGrassSprites[38] = Properties.Resources.MushroomGrass39;
            Game.mushroomGrassSprites[39] = Properties.Resources.MushroomGrass40;
            Game.mushroomGrassSprites[40] = Properties.Resources.MushroomGrass41;
            Game.mushroomGrassSprites[41] = Properties.Resources.MushroomGrass42;
            Game.mushroomGrassSprites[42] = Properties.Resources.MushroomGrass43;
            Game.mushroomGrassSprites[43] = Properties.Resources.MushroomGrass44;
            Game.mushroomGrassSprites[44] = Properties.Resources.MushroomGrass45;
            Game.mushroomGrassSprites[45] = Properties.Resources.MushroomGrass46;
                //walls
            Game.wallIDs[1, 0] = Properties.Resources.DirtWall1;
            Game.wallIDs[1, 1] = Properties.Resources.DirtWall2;
            Game.wallIDs[1, 2] = Properties.Resources.DirtWall3;
            Game.wallIDs[3, 0] = Properties.Resources.SnowWall1;
            Game.wallIDs[3, 1] = Properties.Resources.SnowWall2;
            Game.wallIDs[3, 2] = Properties.Resources.SnowWall3;
        }// block sprites
    }
}