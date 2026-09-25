using System.Runtime;

namespace TerrariaNEA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }
        private void gameLoad(object sender, EventArgs e)
        {
            AppContext.SetSwitch("System.GC.Server", true);
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
            Sprites.blockImages();
            Sprites.transparentImages();
            //items
            ItemAssignment.assignItemValues();
            //drawing bitmaps assignment
            Game.screenBMP = new Bitmap(screenPictureBox.ClientRectangle.Width, screenPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.Screen = Graphics.FromImage(Game.screenBMP);
            Game.mapBMP = new Bitmap(mapPictureBox.ClientRectangle.Width, mapPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.Map = Graphics.FromImage(Game.mapBMP);
            Game.hotbarBMP = new Bitmap(hotbarPictureBox.ClientRectangle.Width, hotbarPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.Hotbar = Graphics.FromImage(Game.hotbarBMP);
            Game.inventoryBMP = new Bitmap(inventoryPictureBox.ClientRectangle.Width, inventoryPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.Inventory = Graphics.FromImage(Game.inventoryBMP);
            Game.chestUIBMP = new Bitmap(chestUIPictureBox.ClientRectangle.Width, chestUIPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.ChestUI = Graphics.FromImage(Game.chestUIBMP);
            Game.menuScreenBMP = new Bitmap(menuScreenPictureBox.ClientRectangle.Width, menuScreenPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.MenuScreen = Graphics.FromImage(Game.menuScreenBMP);
            Game.dialogueBMP = new Bitmap(dialoguePictureBox.ClientRectangle.Width, dialoguePictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.DialogueUI = Graphics.FromImage(Game.dialogueBMP);
            Game.shopBMP = new Bitmap(shopPictureBox.ClientRectangle.Width, shopPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.ShopUI = Graphics.FromImage(Game.shopBMP);
            screenPictureBox.Image = Game.screenBMP;
            mapPictureBox.Image = Game.mapBMP;
            hotbarPictureBox.Image = Game.hotbarBMP;
            inventoryPictureBox.Image = Game.inventoryBMP;
            menuScreenPictureBox.Image = Game.menuScreenBMP;
            chestUIPictureBox.Image = Game.chestUIBMP;
            dialoguePictureBox.Image = Game.dialogueBMP;
            shopPictureBox.Image = Game.shopBMP;
            gameStart();
        }//gets the game ready to load by creating all items and sprites to be used in the game
        public void gameStart()
        {
            hotbarPictureBox.BringToFront();
            inventoryPictureBox.BringToFront();
            chestUIPictureBox.BringToFront();
            craftingPictureBox.BringToFront();
            dialoguePictureBox.BringToFront();
            mapBackground.BringToFront();
            mapBackground.Visible = false;
            mapPictureBox.BringToFront();
            loadVisual.BringToFront();
            gameTick.Enabled = false;
            gameTick.Interval = 100;
            menuScreenPictureBox.BringToFront();
            menuScreenPictureBox.Visible = true;
            Game.MenuScreen.DrawImage(Properties.Resources.Menu_Background, 0, 0);
            Game.MenuScreen.DrawString("New World", new Font(new FontFamily("Comic Sans MS"), 30), Game.Brush, 730, 250);
            Game.MenuScreen.DrawString("Load World", new Font(new FontFamily("Comic Sans MS"), 30), Game.Brush, 727, 310);
        }// displays the menu screen
        public void openWorld(bool newWorld)
        {
            if (newWorld)
            {
                generateWorld();
                loadVisual.Text = "Finalising...";
                Refresh();
                if (World.surfaceHeight[Player.playerX] < World.surfaceHeight[Player.playerX + 1])
                {
                    Player.playerY = World.surfaceHeight[Player.playerX];
                    Player.spawnY = World.surfaceHeight[Player.playerX];
                }
                else
                {
                    Player.playerY = World.surfaceHeight[Player.playerX + 1];
                    Player.spawnY = World.surfaceHeight[Player.playerX + 1];
                }
                for (int i = 0; i < 40; i++)
                {
                    Inventory.inventory[i] = 255;
                }
                PlayerInputs.assignInventory();
                Player.health = 100;
                Player.maxHealth = 100;
                Player.fallDuration = 0;
                Game.guide = new Guide(int.MaxValue);
                Game.guide.LocationX = Player.playerX;
                Game.guide.LocationY = Player.playerY;
            }
            else
            {
                try
                {
                    PlayerInputs.loadWorld();
                    loadVisual.Text = "Loading...";
                    Refresh();
                    int originalSpawnY = Player.spawnY;
                    while (!Player.spaceToSpawn())
                    {
                        if (Player.spawnY > 24)
                        {
                            Player.spawnY--;
                        }
                        else
                        {
                            Player.spawnY = originalSpawnY;
                            break;
                        }
                    }
                    Player.playerY = Player.spawnY;
                    Player.playerX = Player.spawnX;
                }
                catch
                {
                    MessageBox.Show("Cant't locate valid save file, try to create a new world.");
                    Application.Restart();
                }

            }
            Player.breath = 100;
            //enter game
            Output.outputMap();
            mapPictureBox.Size = new Size(Convert.ToInt32(World.worldWidth * Game.mapZoomMultiplier), Convert.ToInt32(World.worldHeight * Game.mapZoomMultiplier));
            Output.outputScreen();
            Game.currentItem = Inventory.inventory[0];
            Game.gamePlaying = true;
            gameTick.Enabled = true;
            Game.lightingThread = new System.Threading.Timer(Lighting.lightingTick, null, 0, 25);
            NPCBehavior.spawnNPC(1);
            Saving.saveWorld();
            loadVisual.Visible = false;
        }// opens the world if newWorld = true generates a new world else it loads from the file
        public void generateWorld()
        {
            loadVisual.Text = "Generating Terrain";
            Refresh();
            PrimaryWorldGen.generateTerrain();
            loadVisual.Text = "Generating Caves";
            Refresh();
            PrimaryWorldGen.generateCaves();
            Biomes.addCorruptionGeneration();
            Biomes.addDesertGeneration();
            loadVisual.Text = "Generating Cells";
            Refresh();
            World.cellMap = PrimaryWorldGen.initialiseMap(World.cellMap);
            for (int i = 0; i < 10; i++)
            {
                World.cellMap = PrimaryWorldGen.doSimulationStep(World.cellMap);
            }
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    World.lastBlockMap[x, y] = 255;
                    World.lastBackgroundMap[x, y] = 255;
                    World.lastWallMap[x, y] = 255;
                    World.randomSprite[x, y] = Convert.ToByte(Game.random.Next(0, 3));
                    World.cracksMap[x, y] = 3;
                }
            }
            loadVisual.Text = "Adding Biomes";
            Refresh();
            Biomes.generateOceans();
            Biomes.generateDesert();
            Biomes.generateIce();
            Biomes.generateJungle();
            Biomes.generateMushrooms();
            loadVisual.Text = "Generating Blocks";
            Refresh();
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    World.cellMap[x, 0] = false;
                }
            }
            SecondaryWorldGen.generateBlocks();
            SecondaryWorldGen.generateBackgrounds();
            Biomes.addBiomes();
            loadVisual.Text = "Generating Ores";
            Refresh();
            Ores.generateOres();
            for (int i = 0; i < 10; i++)
            {
                Ores.expandOres();
            }
            loadVisual.Text = "Growing Grass";
            Refresh();
            Grass.generateGrass();
            loadVisual.Text = "Adding lighting";
            Refresh();
            Lighting.lightBlocksGenerator();
            for (int i = 0; i < 20; i++)
            {
                Lighting.lightMapGenarator();
            }
            loadVisual.Text = "Bit More Biomes";
            Refresh();
            Biomes.outputBiomes();
            loadVisual.Text = "Placing Treasure";
            Refresh();
            Treasure.chestSpawn();
            Treasure.lifeCrystalSpawn();
            Treasure.demonAlterSpawn();
            Treasure.hellForgeSpawn();
            Treasure.generatePots();
            loadVisual.Text = "Growing Grass";
            Refresh();
            Grass.generateGrass();
            for (int x = 0; x < World.worldWidth; x++)
            {
                for (int y = 0; y < World.worldHeight; y++)
                {
                    if (World.blockMap[x, y] == 0)
                    {
                        World.spaceMap[x, y] = true;
                    }
                    else
                    {
                        World.spaceMap[x, y] = false;
                    }
                }
            }
            loadVisual.Text = "Settling Sand";
            Refresh();
            BlockGravity.settleSand();
            loadVisual.Text = "Growing Trees";
            Refresh();
            Trees.generateTrees();
            Trees.treeHeightGenerator();
            Trees.growTrees();
            Trees.growLeaves();
            loadVisual.Text = "Adding Structures";
            Refresh();
            StructureManagement.generateStructures();
            loadVisual.Text = "Adding Fluids";
            Refresh();
            Fluids.addFluidsToWorld();
            for (int i = 0; i < 300; i++)
            {
                Fluids.settleFluids();
            }
            Fluids.removeCactusFromWater();
            loadVisual.Text = "Finishing";
            Refresh();
            BlockHealth.blockHealthGenerator();
        }//all the methods involved in world generation
        public void inventoryOpenClose()
        {
            if (Inventory.inventoryOpen == false)
            {
                Inventory.inventoryOpen = true;
                inventoryPictureBox.Visible = true;
                craftingPictureBox.Visible = true;
            }
            else
            {
                Inventory.inventoryOpen = false;
                inventoryPictureBox.Visible = false;
                craftingPictureBox.Visible = false;
            }
            chestUIPictureBox.Visible = false;
            Game.currentShop = null;
            World.chestOpen = false;
        }//opens and closes the inventory
        public void chestOpenClose(int x, int y)
        {
            if (!World.chestOpen)
            {
                if (World.chestMap[x, y] != 0)
                {
                    Inventory.selectedChest = World.chestMap[x, y];
                    World.chestOpen = true;
                    chestUIPictureBox.Visible = true;
                    inventoryPictureBox.Visible = false;
                }
            }
            else
            {
                World.chestOpen = false;
                chestUIPictureBox.Visible = false;
                inventoryPictureBox.Visible = true;
            }
        }// opens or closes the chest menu
        public void keyPress(Point p1, KeyEventArgs e)
        {
            int blockX = Convert.ToInt16(p1.X / 20);
            int blockY = Convert.ToInt16(p1.Y / 20) + 1;
            int blockXFromPlayer = blockX - (Player.playerOnScreenX / 20);
            int blockYFromPlayer = blockY - ((Player.playerOnScreenY / 20) + 4);
            int x = blockXFromPlayer + Player.playerLocationX;
            int y = blockYFromPlayer + Player.playerLocationY;
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Space:
                    if (World.cellMap[Player.playerLocationX, Player.playerLocationY] == true || World.cellMap[Player.playerLocationX + 1, Player.playerLocationY] == true)
                    {
                        Player.jumping = true;
                        Player.jumpTime = 0;
                    }
                    break;
                case Keys.Left:
                case Keys.A:
                    Player.movingLeft = true;
                    break;
                case Keys.Right:
                case Keys.D:
                    Player.movingRight = true;
                    break;
                case Keys.Down:
                case Keys.S:
                    Movement.forceFall();
                    break;
                case Keys.M:
                    openCloseMap();
                    break;
                case Keys.Escape://exit back to menu
                    exitGame();
                    break;
                case Keys.D1:
                    PlayerInputs.itemSelection(0);
                    break;
                case Keys.D2:
                    PlayerInputs.itemSelection(1);
                    break;
                case Keys.D3:
                    PlayerInputs.itemSelection(2);
                    break;
                case Keys.D4:
                    PlayerInputs.itemSelection(3);
                    break;
                case Keys.D5:
                    PlayerInputs.itemSelection(4);
                    break;
                case Keys.D6:
                    PlayerInputs.itemSelection(5);
                    break;
                case Keys.D7:
                    PlayerInputs.itemSelection(6);
                    break;
                case Keys.D8:
                    PlayerInputs.itemSelection(7);
                    break;
                case Keys.D9:
                    PlayerInputs.itemSelection(8);
                    break;
                case Keys.D0:
                    PlayerInputs.itemSelection(9);
                    break;
                case Keys.Tab://open inventory
                    inventoryOpenClose();
                    break;
                case Keys.E://interact
                    if (blockXFromPlayer < -4 || blockYFromPlayer > 2 || blockXFromPlayer > 5 || blockYFromPlayer < -6)
                    {
                    }
                    else
                    {
                        if (!talkToNPC(x, y))
                        {
                            chestOpenClose(x, y);
                        }
                    }
                    break;
                case Keys.T://test
                    for (int i = 0; i < World.worldWidth; i++)
                    {
                        for (int j = 0; j < World.worldHeight; j++)
                        {
                            World.blockDiscovered[i, j] = true;
                        }
                    }
                    break;
            }
        }// turns player keyboard inputs into actions
        public bool talkToNPC(int x, int y)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = -3; j < 0; j++)
                {
                    if (Game.guide != null)
                    {
                        if (Game.guide.LocationX + i == x && Game.guide.LocationY + j == y)
                        {
                            dialoguePictureBox.Visible = true;
                            PlayerInputs.openDialogue(1);
                            return true;
                        }
                    }
                    if (Game.merchant != null)
                    {
                        if (Game.merchant.LocationX + i == x && Game.merchant.LocationY + j == y)
                        {
                            dialoguePictureBox.Visible = true;
                            PlayerInputs.openDialogue(2);
                            return true;
                        }
                    }
                    if (Game.nurse != null)
                    {
                        if (Game.nurse.LocationX + i == x && Game.nurse.LocationY + j == y)
                        {
                            dialoguePictureBox.Visible = true;
                            PlayerInputs.openDialogue(3);
                            return true;
                        }
                    }
                }
            }
            return false;
        }// checks if the player has interacte with an npc
        private void keyPressDown(object sender, KeyEventArgs e)
        {
            Point p1 = Cursor.Position;
            keyPress(p1, e);
        }// player keyboard inputs
        private void gameTick_Tick(object sender, EventArgs e)
        {
            PlayerInputs.checkNPCObjectives();
            PlayerInputs.setPlayerCurrentStats();
            PlayerInputs.reducePlayerAndNPCImmunity();
            setCraftingUISize();
            Fluids.controlPlayerAroundWater();
            Fluids.controlPlayerAroundLava();
            PlayerInputs.attemptToSpawnNPCs();
            setShopVisibility();
            FriendlyNPCManager.attemptToSpawnNPCs();
            Effects.performBlockEffects();
            Game.grassGrowthThread = new Thread(() => PlantGrowth.growGrass());
            Game.treeGrowthThread = new Thread(() => PlantGrowth.growTrees());
            Game.mouseControlsThread = new Thread(() => PlayerInputs.mouseControls());
            Game.movementControlsThread = new Thread(() => Movement.movementControls());
            Game.inventoryThread = new Thread(() => Output.inventoryOutput());
            Game.npcSpawnThread = new Thread(() => NPCBehavior.chanceToSpawnNPC());
            Game.npcMovementThread = new Thread(() => NPCBehavior.npcControls());
            Game.sandGravityThread = new Thread(() => BlockGravity.sandGravity());
            Game.checkVisibleRecipesThread = new Thread(() => Crafting.checkVisibleRecipes());
            Game.checkCraftableRecipesThread = new Thread(() => Crafting.checkCraftableRecipes());
            Game.updateFluidsThread = new Thread(() => Fluids.updateFluids());
            Game.projectileThread = new Thread(() => ProjectileManager.manageProjectiles());
            Game.friendlyNPCMovementThread = new Thread(() => FriendlyNPCManager.controlFriendlyNPCs());
            Game.checkVisibleRecipesThread.Start();
            Game.checkCraftableRecipesThread.Start();
            Game.mouseControlsThread.Start();
            Game.movementControlsThread.Start();
            Game.inventoryThread.Start();
            Game.npcSpawnThread.Start();
            Game.npcMovementThread.Start();
            Game.sandGravityThread.Start();
            Game.grassGrowthThread.Start();
            Game.treeGrowthThread.Start();
            Game.updateFluidsThread.Start();
            Game.projectileThread.Start();
            Game.friendlyNPCMovementThread.Start();
            Output.outputScreen();
            Output.outputHealth();
            Output.outputBreath();
            DroppedItemBehaviour.droppedItemControls();
            Game.totalFrames++;
            Refresh();
        }// the game tick
        private void keyPressUp(object sender, KeyEventArgs e)
        {
            PlayerInputs.keyRelease(e);
        }// keyboard release
        private void mouseClickDown(object sender, MouseEventArgs e)
        {
            PlayerInputs.mouseClick();
        }//mouse click
        private void mouseClickUp(object sender, MouseEventArgs e)
        {
            PlayerInputs.mouseRelease();
        }//mouse release
        private void hotbarClick(object sender, EventArgs e)
        {
            Point p1 = Cursor.Position;
            int cx = p1.X;
            byte selection = Convert.ToByte((cx - 20) / 60);
            PlayerInputs.itemSelection(selection);
        }//selecting item from the hotbar
        private void inventoryClickDown(object sender, MouseEventArgs e)
        {
            Point p1 = e.Location;
            PlayerInputs.inventoryClick(p1);
        }//moving item
        public void openCloseMap()
        {
            if (World.mapOpen == false)
            {
                Game.mapZoomMultiplier = 4;
                mapPictureBox.Size = new Size(Convert.ToInt32(World.worldWidth * Game.mapZoomMultiplier), Convert.ToInt32(World.worldHeight * Game.mapZoomMultiplier));
                int mapX = Convert.ToInt32(-Math.Abs(Player.playerLocationX) * Game.mapZoomMultiplier + 800);
                int mapY = Convert.ToInt32(-Math.Abs(Player.playerLocationY) * Game.mapZoomMultiplier + 440);
                mapPictureBox.Location = new Point(mapX, mapY);
                Output.outputMap();
                Refresh();
                World.mapOpen = true;
                mapPictureBox.Visible = true;
                mapBackground.Visible = true;
                gameTick.Enabled = false;
            }
            else
            {
                World.mapOpen = false;
                mapPictureBox.Visible = false;
                mapBackground.Visible = false;
                gameTick.Enabled = true;
            }
        }// opens or closes the map
        public void exitGame()
        {
            if (gameTick.Enabled || World.mapOpen)
            {
                gameTick.Enabled = false;
                loadVisual.BringToFront();
                loadVisual.Visible = true;
                loadVisual.Text = "Saving...";
                Refresh();
                Saving.saveWorld();
                Application.Restart();
            }
        }//player closes the game
        private void inventoryClickUp(object sender, MouseEventArgs e)
        {
            if (Inventory.inventoryTemp != 255)
            {
                Point p1 = e.Location;
                PlayerInputs.inventoryRelease(p1);
            }
        }//moving item
        private void chestUIClickDown(object sender, MouseEventArgs e)
        {
            Point p1 = e.Location;
            PlayerInputs.chestClick(p1);
        }//moving item
        private void chestUIClickUp(object sender, MouseEventArgs e)
        {
            if (Inventory.inventoryTemp != 255)
            {
                Point p1 = e.Location;
                PlayerInputs.chestRelease(p1);
            }
        }//moving item
        private void mapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Player.playerX = (int)(e.X / Game.mapZoomMultiplier);
            Player.playerY = (int)(e.Y / Game.mapZoomMultiplier);
            Game.isMapDragging = true;
            Game.mapCurrentX = e.X;
            Game.mapCurrentY = e.Y;
        }//dragging map
        private void mapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Game.isMapDragging = false;
        }//stop dragging map
        private void mapPictureBox_MouseScroll(object sender, MouseEventArgs e)
        {
            Point cursorPosition = e.Location;
            int cursorX = cursorPosition.X;
            int cursorY = cursorPosition.Y;
            if (e.Delta > 0)
            {
                zoomIn(cursorX, cursorY);
            }
            else
            {
                zoomOut(cursorX, cursorY);
            }
        }//zooming in/out of the map with scroll wheel
        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Game.isMapDragging)
            {
                mapPictureBox.Top += e.Y - Game.mapCurrentY;
                mapPictureBox.Left += e.X - Game.mapCurrentX;
            }
        }//dragging map
        public void zoomIn(int cursorX, int cursorY)
        {
            int originalSizeX = mapPictureBox.Width;
            int originalSizeY = mapPictureBox.Height;
            int locationX = mapPictureBox.Location.X;
            int locationY = mapPictureBox.Location.Y;
            if (World.mapOpen == true && Game.mapZoomMultiplier <= 8)
            {
                Game.mapZoomMultiplier *= 1.2f;
            }
            int newSizeX = Convert.ToInt32(World.worldWidth * Game.mapZoomMultiplier);
            int newSizeY = Convert.ToInt32(World.worldHeight * Game.mapZoomMultiplier);
            mapPictureBox.Size = new Size(newSizeX, newSizeY);
            locationX += (int)(cursorX - ((double)newSizeX / originalSizeX * cursorX));
            locationY += (int)(cursorY - ((double)newSizeY / originalSizeY * cursorY));
            mapPictureBox.Location = new Point(locationX, locationY);
        }// map zoom in
        public void zoomOut(int cursorX, int cursorY)
        {
            int originalSizeX = mapPictureBox.Width;
            int originalSizeY = mapPictureBox.Height;
            int locationX = mapPictureBox.Location.X;
            int locationY = mapPictureBox.Location.Y;
            if (World.mapOpen == true && Game.mapZoomMultiplier >= 0.5)
            {
                Game.mapZoomMultiplier *= 0.83f;
            }
            int newSizeX = Convert.ToInt32(World.worldWidth * Game.mapZoomMultiplier);
            int newSizeY = Convert.ToInt32(World.worldHeight * Game.mapZoomMultiplier);
            mapPictureBox.Size = new Size(newSizeX, newSizeY);
            locationX += (int)(cursorX - ((double)newSizeX / originalSizeX * cursorX));
            locationY += (int)(cursorY - ((double)newSizeY / originalSizeY * cursorY));
            mapPictureBox.Location = new Point(locationX, locationY);
        }// map zoom out
        private void time_Tick(object sender, EventArgs e)
        {
            //every second regenerate health
            if (Player.health < Player.maxHealth)
            {
                Player.health++;
            }
            //every second at 1 to time, 1 second = 1 minute in game
            World.timeOfDay += 1;//change number for testing
            if (World.timeOfDay == 1440)
            {
                //reset when gets to the end
                World.timeOfDay = 0;
            }
            // changing the background colour of the sky based on time
            if (World.timeOfDay >= 600 && World.timeOfDay <= 1020)
            {
                Game.backgroundColourIDs[4] = Color.FromArgb(255, 135, 206, 235);
            }
            else if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)
            {
                Game.backgroundColourIDs[4] = Color.FromArgb(255, 100, 160, 185);
            }
            else if (World.timeOfDay >= 360 && World.timeOfDay <= 1260)
            {
                Game.backgroundColourIDs[4] = Color.FromArgb(255, 80, 120, 150);
            }
            else
            {
                Game.backgroundColourIDs[4] = Color.FromArgb(255, 60, 80, 115);
            }
        }// 1 second passes changing the time of day
        private void menuScreenPictureBox_Click(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.Location;
            int mouseX = mouseLocation.X;
            int mouseY = mouseLocation.Y;
            if (mouseY < 100 || mouseX > 1500)
            {
                Close();
            }
            else if (mouseX > 732 && mouseX < 892)
            {
                if (mouseY > 266 && mouseY < 296)
                {
                    menuScreenPictureBox.Visible = false;
                    Refresh();
                    openWorld(true);
                }
                else if (mouseY > 326 && mouseY < 356)
                {
                    menuScreenPictureBox.Visible = false;
                    openWorld(false);
                }
            }
        }// player clicks on the menu screen
        private void craftingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point cursor = e.Location;
            Crafting.attemptCraft(cursor);
        }// player clicks on the crafting menu
        private void dialoguePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 450 && e.Location.Y < 50)
            {
                dialoguePictureBox.Visible = false;
            }
            else
            {
                PlayerInputs.npcInteraction(e);
            }
        }// player clicks on the npc dialogue box
        private void shopPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerInputs.shopInteraction(e);
        }// player clicks on the shop
        public void setCraftingUISize()
        {
            if (Game.visibleRecipesCount % 5 == 0 && Game.visibleRecipesCount != 0)
            {
                craftingPictureBox.Size = new Size(Game.visibleRecipesCount / 5 * 60, 300);
            }
            else
            {
                craftingPictureBox.Size = new Size(Game.visibleRecipesCount / 5 * 60 + 60, 300);
            }
            Game.craftingBMP = new Bitmap(craftingPictureBox.ClientRectangle.Width, craftingPictureBox.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Game.CraftingUI = Graphics.FromImage(Game.craftingBMP);
            craftingPictureBox.Image = Game.craftingBMP;
        }//sets the size of the crafting ui based on the ammount of craftable items
        public void setShopVisibility()
        {
            if (Game.currentShop == null)
            {
                shopPictureBox.Visible = false;
            }
            else
            {
                shopPictureBox.Visible = true;
                dialoguePictureBox.Visible = false;
            }
        }//shows the shop ui if there is a current shop else hides it
    }
}
