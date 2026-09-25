namespace TerrariaNEA
{
    public class PlayerInputs
    {
        //procedure that takes in all player keyboard inputs
        public static void keyRelease(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                Player.movingLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Player.movingRight = false;
            }
            else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                Player.jumping = false;
            }
        }// stops moving
        public static void mouseClick()
        {
            if (Game.currentItem != 255)
            {
                if (Game.items[Game.currentItem].Buildable != 0 && Game.items[Game.currentItem].Effect == 0)
                {
                    Player.building = true;
                }
                else if (Game.items[Game.currentItem].BuildableWall != 0)
                {
                    Player.buildingWall = true;
                }
                else if (Game.items[Game.currentItem].PickaxePower != 0 || Game.items[Game.currentItem].AxePower != 0)
                {
                    Player.breaking = true;
                }
                else if (Game.items[Game.currentItem].HammerPower != 0)
                {
                    Player.breakingWall = true;
                }
                if (Game.items[Game.currentItem].Damage != 0)
                {
                    if (Game.currentItem == 49 || Game.currentItem == 50 || Game.currentItem == 51 || Game.currentItem == 52 || Game.currentItem == 53 || Game.currentItem == 66 || Game.currentItem == 72)
                    {
                        Player.ShootArrow();
                    }
                    else
                    {
                        Player.Attack(Game.items[Game.currentItem].Damage);
                    }
                }
                if (Game.items[Game.currentItem].Effect != 0)
                {
                    bool canBeUsed = Effects.performItemEffects(Game.items[Game.currentItem].Effect);
                    if (canBeUsed)
                    {
                        int currentSpace = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (Inventory.inventoryUsage[i, j])
                                {
                                    currentSpace = j * 10 + i;
                                }
                            }
                        }
                        Inventory.inventoryQuantity[currentSpace]--;
                        if (Inventory.inventoryQuantity[currentSpace] == 0)
                        {
                            Inventory.inventory[currentSpace] = 255;
                        }
                    }
                }
            }
        }// decides what to do when the mouse is clicked based on the current item
        public static void mouseRelease()
        {
            Player.building = false;
            Player.breaking = false;
            Player.buildingWall = false;
            Player.breakingWall = false;
        }// stops building/ breaking
        public static void itemSelection(byte selection)
        {
            if (Inventory.inventory[selection] != 255)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Inventory.inventoryUsage[i, j] = false;
                    }
                }
                Inventory.inventoryUsage[selection, 0] = true;
                Game.currentItem = Inventory.inventory[selection];
            }
        }// what item is currently selected
        public static void itemSelection(byte selection1, byte selection2)
        {
            if (Inventory.inventory[selection2 * 10 + selection1] != 255)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Inventory.inventoryUsage[i, j] = false;
                    }
                }
                Inventory.inventoryUsage[selection1, selection2] = true;
                Game.currentItem = Inventory.inventory[selection2 * 10 + selection1];
            }
        }// what item is currently selected
        public static void inventoryClick(Point cursorLocation)
        {
            int cx = cursorLocation.X;
            int cy = cursorLocation.Y;
            byte ix = Convert.ToByte(cx / 60);
            byte iy = Convert.ToByte(cy / 60);
            Inventory.inventoryTempID = iy * 10 + ix;
            if (Inventory.inventoryTempID < 40)
            {
                if (Inventory.inventory[Inventory.inventoryTempID] != 255)
                {
                    Inventory.inventoryTemp = Game.items[Inventory.inventory[Inventory.inventoryTempID]].ID;
                    Inventory.inventoryQuantityTemp = Inventory.inventoryQuantity[Inventory.inventoryTempID];
                    Inventory.inventory[Inventory.inventoryTempID] = 255;
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = 0;
                }
            }
            else
            {
                Inventory.inventoryTempID = 255;
            }
        }// where the mouse is clicked
        public static void inventoryRelease(Point cursorLocation)
        {
            int cx = cursorLocation.X;
            int cy = cursorLocation.Y;
            byte ix = Convert.ToByte(cx / 60);
            byte iy = Convert.ToByte(cy / 60);
            if (ix < 0 || ix >= 10 || iy < 0 || iy >= 4)
            {
                //if item released outside of inventory drop it
                ix = Convert.ToByte(cx / 20);
                iy = Convert.ToByte(cy / 20);
                DroppedItemBehaviour.dropItem(Inventory.inventoryTemp, Inventory.inventoryQuantityTemp, ix + Player.playerX, iy + Player.playerY);
                Inventory.inventoryTemp = 255;
            }
            else
            {
                //item released in inventory
                if (Inventory.inventory[iy * 10 + ix] == 255)
                {
                    //empty space so no replacement required
                    Inventory.inventory[iy * 10 + ix] = Inventory.inventoryTemp;
                    Inventory.inventoryQuantity[iy * 10 + ix] = Inventory.inventoryQuantityTemp;
                    Inventory.inventoryTemp = 255;
                    Inventory.inventoryQuantityTemp = 0;
                }
                else
                {
                    inventoryItemReplacement(ix, iy);
                }
                itemSelection(ix, iy);
            }
        }// where the mouse is released
        public static void inventoryItemReplacement(int ix, int iy)
        {
            // if item is swapped with another item
            if (Inventory.inventory[iy * 10 + ix] == Inventory.inventoryTemp)
            {//if both items are the same add up the total and then add them to the same slot
             //if there is overflow add the extra to the original space
                int totalQuantity = Inventory.inventoryQuantity[iy * 10 + ix] + Inventory.inventoryQuantityTemp;
                if (totalQuantity <= Game.items[Inventory.inventoryTemp].Stack)
                {
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = 0;
                    Inventory.inventoryQuantity[iy * 10 + ix] = totalQuantity;
                }
                else
                {
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = totalQuantity - Game.items[Inventory.inventoryTemp].Stack;
                    Inventory.inventory[Inventory.inventoryTempID] = Inventory.inventoryTemp;
                    Inventory.inventoryQuantity[iy * 10 + ix] = Game.items[Inventory.inventoryTemp].Stack;
                }
            }
            else
            {
                Inventory.inventory[Inventory.inventoryTempID] = Inventory.inventory[iy * 10 + ix];
                Inventory.inventoryQuantity[Inventory.inventoryTempID] = Inventory.inventoryQuantity[iy * 10 + ix];
                Inventory.inventory[iy * 10 + ix] = Inventory.inventoryTemp;
                Inventory.inventoryQuantity[iy * 10 + ix] = Inventory.inventoryQuantityTemp;
            }
            Inventory.inventoryTemp = 255;
            Inventory.inventoryQuantityTemp = 0;
        }// moves items around in the inventory
        public static void chestClick(Point cursorLocation)
        {
            int cx = cursorLocation.X;
            int cy = cursorLocation.Y;
            byte ix = Convert.ToByte(cx / 60);
            byte iy = Convert.ToByte(cy / 60);
            if (iy < 4)
            {
                Inventory.inventoryTempID = iy * 10 + ix;
                if (Inventory.inventory[Inventory.inventoryTempID] != 255)
                {
                    Inventory.inventoryTemp = Game.items[Inventory.inventory[Inventory.inventoryTempID]].ID;
                    Inventory.inventoryQuantityTemp = Inventory.inventoryQuantity[Inventory.inventoryTempID];
                    Inventory.inventory[Inventory.inventoryTempID] = 255;
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = 0;
                }
                else
                {
                    Inventory.inventoryTempID = 255;
                }
                Inventory.itemFromInventory = true;
            }
            else
            {
                Inventory.inventoryTempID = iy * 10 + ix - 40;
                if (Inventory.currentChest[Inventory.inventoryTempID] != 255)
                {
                    Inventory.inventoryTemp = Game.items[Inventory.currentChest[Inventory.inventoryTempID]].ID;
                    Inventory.inventoryQuantityTemp = Inventory.currentChestQuantity[Inventory.inventoryTempID];
                    Inventory.currentChest[Inventory.inventoryTempID] = 255;
                    Inventory.currentChestQuantity[Inventory.inventoryTempID] = 0;
                }
                else
                {
                    Inventory.inventoryTempID = 255;
                }
                Inventory.itemFromInventory = false;
            }
        }// where the mouse is clicked
        public static void chestRelease(Point p1)
        {
            int cx = p1.X;
            int cy = p1.Y;
            byte ix = Convert.ToByte(cx / 60);
            byte iy = Convert.ToByte(cy / 60);
            if (iy * 10 + ix < 0 || iy * 10 + ix >= 80)
            {//change to drop items
                ix = Convert.ToByte(cx / 20);
                iy = Convert.ToByte(cy / 20);
                DroppedItemBehaviour.dropItem(Inventory.inventoryTemp, Inventory.inventoryQuantityTemp, ix + Player.playerX, iy + Player.playerY);
                Inventory.inventoryTemp = 255;
                Inventory.inventoryQuantityTemp = 0;
            }
            else
            {
                if (iy < 4)//released over inventory
                {
                    chestReleaseOverInventory(ix, iy);
                }
                else//released over chest
                {
                    chestReleaseOverChest(ix, iy);
                }
            }
        }// where the mouse is released
        public static void chestReleaseOverInventory(byte ix, byte iy)
        {
            if (Inventory.itemFromInventory)
            {
                if (Inventory.inventory[iy * 10 + ix] == 255)
                {
                    Inventory.inventory[iy * 10 + ix] = Inventory.inventoryTemp;
                    Inventory.inventoryQuantity[iy * 10 + ix] = Inventory.inventoryQuantityTemp;
                    Inventory.inventoryTemp = 255;
                    Inventory.inventoryQuantityTemp = 0;
                }
                else
                {
                    inventoryItemReplacement(ix, iy);
                }
            }
            else//item not from inventory
            {
                if (Inventory.inventory[iy * 10 + ix] == 255)
                {
                    Inventory.inventory[iy * 10 + ix] = Inventory.inventoryTemp;
                    Inventory.inventoryQuantity[iy * 10 + ix] = Inventory.inventoryQuantityTemp;
                    Inventory.inventoryTemp = 255;
                    Inventory.inventoryQuantityTemp = 0;
                }
                else
                {
                    chestToInventoryItemReplacement(ix, iy);
                }
            }
            itemSelection(ix, iy);
        }// placing an item from the current chest into the inventory
        public static void chestReleaseOverChest(byte ix, byte iy)
        {
            if (Inventory.itemFromInventory)
            {
                if (Inventory.currentChest[iy * 10 + ix - 40] == 255)
                {
                    Inventory.currentChest[iy * 10 + ix - 40] = Inventory.inventoryTemp;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = Inventory.inventoryQuantityTemp;
                    Inventory.inventoryTemp = 255;
                    Inventory.inventoryQuantityTemp = 0;
                }
                else
                {
                    inventoryToChestItemReplacement(ix, iy);
                }
            }
            else//item from chest
            {
                if (Inventory.currentChest[iy * 10 + ix - 40] == 255)
                {
                    Inventory.currentChest[iy * 10 + ix - 40] = Inventory.inventoryTemp;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = Inventory.inventoryQuantityTemp;
                    Inventory.inventoryTemp = 255;
                    Inventory.inventoryQuantityTemp = 0;
                }
                else
                {
                    chestItemReplacement(ix, iy);
                }
            }
        }//placing an item from the current chest into the current chest
        public static void chestToInventoryItemReplacement(byte ix, byte iy)
        {
            if (Inventory.inventory[iy * 10 + ix] == Inventory.inventoryTemp)
            {
                int totalQuantity = Inventory.inventoryQuantity[iy * 10 + ix] + Inventory.inventoryQuantityTemp;
                if (totalQuantity <= Game.items[Inventory.inventoryTemp].Stack)
                {
                    Inventory.currentChestQuantity[Inventory.inventoryTempID] = 0;
                    Inventory.inventoryQuantity[iy * 10 + ix] = totalQuantity;
                }
                else
                {
                    Inventory.currentChestQuantity[Inventory.inventoryTempID] = totalQuantity - Game.items[Inventory.inventoryTemp].Stack;
                    Inventory.currentChest[Inventory.inventoryTempID] = Inventory.inventoryTemp;
                    Inventory.inventoryQuantity[iy * 10 + ix] = Game.items[Inventory.inventoryTemp].Stack;
                }
            }
            else
            {
                Inventory.currentChest[Inventory.inventoryTempID] = Inventory.inventory[iy * 10 + ix];
                Inventory.currentChestQuantity[Inventory.inventoryTempID] = Inventory.inventoryQuantity[iy * 10 + ix];
                Inventory.inventory[iy * 10 + ix] = Inventory.inventoryTemp;
                Inventory.inventoryQuantity[iy * 10 + ix] = Inventory.inventoryQuantityTemp;
            }
            Inventory.inventoryTemp = 255;
            Inventory.inventoryQuantityTemp = 0;
        }// takes items from the current chest and stores them in the inventory
        public static void chestItemReplacement(byte ix, byte iy)
        {
            if (Inventory.currentChest[iy * 10 + ix - 40] == Inventory.inventoryTemp)
            {
                int totalQuantity = Inventory.currentChestQuantity[iy * 10 + ix - 40] + Inventory.inventoryQuantityTemp;
                if (totalQuantity <= Game.items[Inventory.inventoryTemp].Stack)
                {
                    Inventory.currentChestQuantity[Inventory.inventoryTempID] = 0;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = totalQuantity;
                }
                else
                {
                    Inventory.currentChestQuantity[Inventory.inventoryTempID] = totalQuantity - Game.items[Inventory.inventoryTemp].Stack;
                    Inventory.currentChest[Inventory.inventoryTempID] = Inventory.inventoryTemp;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = Game.items[Inventory.inventoryTemp].Stack;
                }
            }
            else
            {
                Inventory.currentChest[Inventory.inventoryTempID] = Inventory.currentChest[iy * 10 + ix - 40];
                Inventory.currentChestQuantity[Inventory.inventoryTempID] = Inventory.currentChestQuantity[iy * 10 + ix - 40];
                Inventory.currentChest[iy * 10 + ix - 40] = Inventory.inventoryTemp;
                Inventory.currentChestQuantity[iy * 10 + ix - 40] = Inventory.inventoryQuantityTemp;
            }
            Inventory.inventoryTemp = 255;
            Inventory.inventoryQuantityTemp = 0;
        }// moves items around in a chest
        public static void inventoryToChestItemReplacement(byte ix, byte iy)
        {
            if (Inventory.currentChest[iy * 10 + ix - 40] == Inventory.inventoryTemp)
            {
                int totalQuantity = Inventory.currentChestQuantity[iy * 10 + ix - 40] + Inventory.inventoryQuantityTemp;
                if (totalQuantity <= Game.items[Inventory.inventoryTemp].Stack)
                {
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = 0;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = totalQuantity;
                }
                else
                {
                    Inventory.inventoryQuantity[Inventory.inventoryTempID] = totalQuantity - Game.items[Inventory.inventoryTemp].Stack;
                    Inventory.inventory[Inventory.inventoryTempID] = Inventory.inventoryTemp;
                    Inventory.currentChestQuantity[iy * 10 + ix - 40] = Game.items[Inventory.inventoryTemp].Stack;
                }

            }
            else
            {
                Inventory.inventory[Inventory.inventoryTempID] = Inventory.currentChest[iy * 10 + ix - 40];
                Inventory.inventoryQuantity[Inventory.inventoryTempID] = Inventory.currentChestQuantity[iy * 10 + ix - 40];
                Inventory.currentChest[iy * 10 + ix - 40] = Inventory.inventoryTemp;
                Inventory.currentChestQuantity[iy * 10 + ix - 40] = Inventory.inventoryQuantityTemp;
            }
            Inventory.inventoryTemp = 255;
            Inventory.inventoryQuantityTemp = 0;
        }// takes an item from the inventory and store it in the current chest
        public static void mouseControls()
        {
            Point p1 = Cursor.Position;
            int blockX = Convert.ToInt16(p1.X / 20);
            int blockY = Convert.ToInt16(p1.Y / 20) + 1;
            int blockXFromPlayer = blockX - (Player.playerOnScreenX / 20);
            int blockYFromPlayer = blockY - ((Player.playerOnScreenY / 20) + 4);
            int x = blockXFromPlayer + Player.playerLocationX;
            int y = blockYFromPlayer + Player.playerLocationY;
            if (blockXFromPlayer < -4 || blockYFromPlayer > 2 || blockXFromPlayer > 5 || blockYFromPlayer < -6)
            {
            }
            else
            {
                if (Player.building == true && World.spaceMap[x, y] == true)
                {
                    if (Game.currentItem != 15)
                    {
                        if (WorldInteraction.checkNotFloating(x, y) == true)
                        {
                            WorldInteraction.blockBuilt(x, y);
                        }
                    }
                    else
                    {
                        if (WorldInteraction.checkOnWall(x, y) == true || WorldInteraction.checkNotFloating(x, y) == true)
                        {
                            WorldInteraction.blockBuilt(x, y);
                        }
                    }
                }
                if (Player.buildingWall == true && World.wallMap[x, y] == 0)
                {
                    if (WorldInteraction.checkWallNotFloating(x, y) == true)
                    {
                        WorldInteraction.wallBuilt(x, y);
                    }
                }
                if (Player.breaking == true)
                {
                    WorldInteraction.blockDamaged(x, y);
                }
                if (Player.breakingWall)
                {
                    WorldInteraction.wallDamaged(x, y);
                }
            }
        }//what the mouse is doing
        public static void assignInventory()
        {
            Inventory.inventory[0] = 0;
            Inventory.inventoryQuantity[0] = 1;
            Inventory.inventory[1] = 4;
            Inventory.inventoryQuantity[1] = 1;
            Inventory.inventory[2] = 11;
            Inventory.inventoryQuantity[2] = 1;
        }// assigns items to the inventory on world generation(copper pickaxe, copper axe, copper sword)
        public static void loadWorld()
        {
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
            Saving.loadWorld();
            BlockHealth.blockHealthGenerator();
        }// loads the world and player data from the file
        public static void npcInteraction(MouseEventArgs e)
        {
            if (e.Location.X > 360 && e.Location.X < 460 && e.Location.Y > 120 && e.Location.Y < 160)
            {
                string dialogue;
                switch (Game.currentFriendlyNPC)
                {
                    case 1:
                        Game.DialogueUI.DrawImage(Properties.Resources.DialogueBox, 0, 0);
                        Game.DialogueUI.DrawImage(Properties.Resources.Help_Button, 360, 120, 100, 40);
                        Game.DialogueUI.DrawString(getGuideDialogue(), new Font(new FontFamily("Comic Sans MS"), 12), new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 20, 20);
                        break;
                    case 2:
                        Game.currentShop = new MerchantShop();
                        break;
                    case 3:
                        int amountToHeal = Player.maxHealth - Player.health;
                        int amountToPay = amountToHeal * 50;
                        if (payMoney(amountToPay))
                        {
                            Player.health = Player.maxHealth;
                            dialogue = Game.nurse.SuccessfulInteractionDialogue[Game.random.Next(Game.nurse.SuccessfulInteractionDialogue.Length)];
                        }
                        else
                        {
                            dialogue = Game.nurse.UnsuccessfulInteractionDialogue[Game.random.Next(Game.nurse.UnsuccessfulInteractionDialogue.Length)];
                            Game.DialogueUI.DrawImage(Properties.Resources.DialogueBox, 0, 0);
                            Game.DialogueUI.DrawImage(Properties.Resources.HealButton, 360, 120, 100, 40);
                            Game.DialogueUI.DrawString(dialogue, new Font(new FontFamily("Comic Sans MS"), 12), new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 20, 20);
                        }
                        Game.DialogueUI.DrawImage(Properties.Resources.DialogueBox, 0, 0);
                        Game.DialogueUI.DrawImage(Properties.Resources.HealButton, 360, 120, 100, 40);
                        Game.DialogueUI.DrawString(dialogue, new Font(new FontFamily("Comic Sans MS"), 12), new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 20, 20);
                        break;
                    default:
                        break;
                }
            }
        }// gives the npc interaction button function. guide - offers help. merchant - opens a shop. nurse - heals
        public static string getGuideDialogue()
        {
            List<int> potentialDialogue = new List<int>();
            bool isATool = false;
            bool isMerchant = false;
            bool isNurse = false;
            bool isMaxLifeAbove100 = false;
            bool isABar = false;
            bool isAnOre = false;
            bool isAnNPC = false;
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < ItemAssignment.toolValuesGuide.Length; j++)
                {
                    if (Inventory.inventory[i] == ItemAssignment.toolValuesGuide[j])
                    {
                        isATool = true;
                    }
                }
                for (int j = 0; j < ItemAssignment.oreValuesGuide.Length; j++)
                {
                    if (Inventory.inventory[i] == ItemAssignment.oreValuesGuide[j])
                    {
                        isAnOre = true;
                    }
                }
                for (int j = 0; j < ItemAssignment.oreValuesGuide.Length; j++)
                {
                    if (Inventory.inventory[i] == ItemAssignment.oreValuesGuide[j])
                    {
                        isABar = true;
                    }
                }
            }
            if (Game.merchant != null)
            {
                isMerchant = true;
            }
            if (Game.nurse != null)
            {
                isNurse = true;
            }
            if (isNurse || isMerchant)
            {
                isAnNPC = true;
            }
            if (Player.maxHealth > 100)
            {
                isMaxLifeAbove100 = true;
            }
            if (!isATool)
            {
                potentialDialogue.AddRange(new List<int> { 0, 1, 2, 3, 4, 5 });
            }
            if (!isAnOre && !isABar)
            {
                potentialDialogue.Add(6);
            }
            else if (!isABar)
            {
                potentialDialogue.AddRange(new List<int> { 7, 8 });
            }
            if (!isMaxLifeAbove100)
            {
                potentialDialogue.Add(9);
            }
            if (!isAnNPC)
            {
                potentialDialogue.AddRange(new List<int> { 10, 11, 12 });
            }
            if (!isMerchant)
            {
                potentialDialogue.Add(13);
            }
            if (!isNurse)
            {
                potentialDialogue.Add(14);
            }
            if (potentialDialogue.Count == 0)
            {
                return Game.guide.SuccessfulInteractionDialogue[15];
            }
            else
            {
                int dialogueNumber = potentialDialogue[Game.random.Next(potentialDialogue.Count)];
                return Game.guide.SuccessfulInteractionDialogue[dialogueNumber];
            }

        }// returns certain dialogue depending what the guide can help the player with
        public static void shopInteraction(MouseEventArgs e)
        {
            if (e.Location.Y > 240)
            {
                int selectionX = e.Location.X / 60;
                int selectionY = (e.Location.Y / 60) - 4;
                int shopSelection = selectionY * 10 + selectionX;
                if (Game.currentShop.ItemsSold[shopSelection] != 255)
                {
                    buyItem(shopSelection);
                }
            }
            else
            {
                int selectionX = e.Location.X / 60;
                int selectionY = e.Location.Y / 60;
                int inventorySelection = selectionY * 10 + selectionX;
                sellItem(inventorySelection);
            }
        }// either buys or sells an item
        public static void buyItem(int itemIndex)
        {
            if (payMoney(Game.currentShop.ItemsCost[itemIndex]))
            {
                DroppedItemBehaviour.dropItem(Game.currentShop.ItemsSold[itemIndex], 1, Player.playerLocationX + 40, Player.playerLocationY + 23);
            }
        }// buys an item from an npc shop
        public static void sellItem(int itemIndex)
        {
            DroppedItemBehaviour.dropItem(17, Game.items[Inventory.inventory[itemIndex]].SellValue, Player.playerLocationX + 40, Player.playerLocationY + 23);
            Inventory.inventoryQuantity[itemIndex]--;
            if (Inventory.inventoryQuantity[itemIndex] == 0)
            {
                Inventory.inventory[itemIndex] = 255;
            }
        }// sells an item from inventory to an npc
        public static bool payMoney(int amountToPay)
        {
            int coinCount = 0;
            for (int i = 0; i < 40; i++)
            {
                switch (Inventory.inventory[i])
                {
                    case 17:
                        coinCount += 1 * Inventory.inventoryQuantity[i];
                        break;
                    case 18:
                        coinCount += 100 * Inventory.inventoryQuantity[i];
                        break;
                    case 19:
                        coinCount += 10000 * Inventory.inventoryQuantity[i];
                        break;
                    case 20:
                        coinCount += 1000000 * Inventory.inventoryQuantity[i];
                        break;
                }
            }
            bool payed = false;
            if (coinCount >= amountToPay)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (Inventory.inventory[i] == 17)
                    {
                        if (amountToPay <= Inventory.inventoryQuantity[i])
                        {
                            Inventory.inventoryQuantity[i] -= amountToPay;
                            if (Inventory.inventoryQuantity[i] == 0)
                            {
                                Inventory.inventory[i] = 255;
                            }
                            payed = true;
                            break;
                        }
                    }
                }
                if (!payed)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if (Inventory.inventory[i] == 18)
                        {
                            if (amountToPay <= Inventory.inventoryQuantity[i] * 100)
                            {
                                int total = Inventory.inventoryQuantity[i] * 100;
                                int totalAfterPayment = total - amountToPay;
                                DroppedItemBehaviour.dropItem(17, totalAfterPayment, Player.playerLocationX + 40, Player.playerLocationY + 23);
                                Inventory.inventory[i] = 255;
                                Inventory.inventoryQuantity[i] = 0;
                                payed = true;
                                break;
                            }
                        }
                    }
                }
                if (!payed)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if (Inventory.inventory[i] == 19)
                        {
                            if (amountToPay <= Inventory.inventoryQuantity[i] * 10000)
                            {
                                int total = Inventory.inventoryQuantity[i] * 10000;
                                int totalAfterPayment = total - amountToPay;
                                DroppedItemBehaviour.dropItem(17, totalAfterPayment, Player.playerLocationX + 40, Player.playerLocationY + 23);
                                Inventory.inventory[i] = 255;
                                Inventory.inventoryQuantity[i] = 0;
                                payed = true;
                                break;
                            }
                        }
                    }
                }
                if (!payed)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if (Inventory.inventory[i] == 20)
                        {
                            if (amountToPay <= Inventory.inventoryQuantity[i] * 1000000)
                            {
                                int total = Inventory.inventoryQuantity[i] * 10000;
                                int totalAfterPayment = total - amountToPay;
                                DroppedItemBehaviour.dropItem(17, totalAfterPayment, Player.playerLocationX + 40, Player.playerLocationY + 23);
                                Inventory.inventory[i] = 255;
                                Inventory.inventoryQuantity[i] = 0;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }// removes coins from inventory. returns true if payment can be made. returns false if cant
        public static void openDialogue(int npc)
        {
            Game.DialogueUI.DrawImage(Properties.Resources.DialogueBox, 0, 0);
            string dialogue = "";
            if (npc == 1)
            {
                Game.DialogueUI.DrawImage(Properties.Resources.Help_Button, 360, 120, 100, 40);
                dialogue = Game.guide.NormalDialogue[Game.random.Next(Game.guide.NormalDialogue.Length)];
                Game.currentFriendlyNPC = 1;
            }
            if (npc == 2)
            {
                dialogue = Game.merchant.NormalDialogue[Game.random.Next(Game.merchant.NormalDialogue.Length)];
                Game.DialogueUI.DrawImage(Properties.Resources.ShopButton, 360, 120, 100, 40);
                Game.currentFriendlyNPC = 2;
            }
            if (npc == 3)
            {
                Game.DialogueUI.DrawImage(Properties.Resources.HealButton, 360, 120, 100, 40);
                dialogue = Game.nurse.NormalDialogue[Game.random.Next(Game.nurse.NormalDialogue.Length)];
                Game.currentFriendlyNPC = 3;
            }
            Game.DialogueUI.DrawString(dialogue, new Font(new FontFamily("Comic Sans MS"), 12), new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 20, 20);
        }// displays the correct dialogue when talking to an npc
        public static void reducePlayerAndNPCImmunity()
        {
            if (Player.immunity > 0)
            {
                Player.immunity -= 1;
            }
            for (int i = 0; i < 20; i++)
            {
                if (Game.slimes[i] != null)
                {
                    if (Game.slimes[i].Immunity > 0)
                    {
                        Game.slimes[i].Immunity -= 1;
                    }
                }
                if (Game.zombies[i] != null)
                {
                    if (Game.zombies[i].Immunity > 0)
                    {
                        Game.zombies[i].Immunity -= 1;
                    }
                }
                if (Game.flyingEnemies[i] != null)
                {
                    if (Game.flyingEnemies[i].Immunity > 0)
                    {
                        Game.flyingEnemies[i].Immunity -= 1;
                    }
                }
            }
            if (Game.eyeOfCthulhu != null)
            {
                if (Game.eyeOfCthulhu.Immunity > 0)
                {
                    Game.eyeOfCthulhu.Immunity -= 1;
                }
            }
        }//each tick npc and player immunity time is reduced by one
        public static void attemptToSpawnNPCs()
        {
            if (Game.guide != null)
            {
                if (Game.guide.WaitingToSpawn)
                {
                    if (Math.Abs(Game.validHouses[Game.guide.NPCHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[Game.guide.NPCHouse][1] - Player.playerY) > 35)
                    {
                        Game.guide.Spawn();
                        Game.guide.WaitingToSpawn = false;
                    }
                }
            }
            if (Game.merchant != null)
            {
                if (Game.merchant.WaitingToSpawn)
                {
                    if (Math.Abs(Game.validHouses[Game.merchant.NPCHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[Game.merchant.NPCHouse][1] - Player.playerY) > 35)
                    {
                        Game.merchant.Spawn();
                        Game.merchant.WaitingToSpawn = false;
                    }
                }
            }
            if (Game.nurse != null)
            {
                if (Game.nurse.WaitingToSpawn)
                {
                    if (Math.Abs(Game.validHouses[Game.nurse.NPCHouse][0] - Player.playerX) > 50 || Math.Abs(Game.validHouses[Game.nurse.NPCHouse][1] - Player.playerY) > 35)
                    {
                        Game.nurse.Spawn();
                        Game.nurse.WaitingToSpawn = false;
                    }
                }
            }
        }//each tick attempts to find a house for npcs that are waiting to spawn
        public static void setPlayerCurrentStats()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Inventory.inventoryUsage[i, j])
                    {
                        Game.currentItem = Inventory.inventory[j * 10 + i];
                        break;
                    }
                }
            }
            if (Game.currentItem != 255)
            {
                Player.currentAxePower = Game.items[Game.currentItem].AxePower;
                Player.currentPickaxePower = Game.items[Game.currentItem].PickaxePower;
                Player.currentHammerPower = Game.items[Game.currentItem].HammerPower;
            }
            else
            {
                Player.currentAxePower = 0;
                Player.currentPickaxePower = 0;
                Player.currentHammerPower = 0;
            }
        }//each tick sets the current atats of the player based on what item is held
        public static void checkNPCObjectives()
        {
            if (!Game.npcObjectives[2])
            {
                if (Player.health > 100)
                {
                    Game.npcObjectives[2] = true;
                }
            }
            if (!Game.npcObjectives[1])
            {
                int coinCount = 0;
                for (int i = 0; i < 40; i++)
                {
                    switch (Inventory.inventory[i])
                    {
                        case 17:
                            coinCount += 1 * Inventory.inventoryQuantity[i];
                            break;
                        case 18:
                            coinCount += 100 * Inventory.inventoryQuantity[i];
                            break;
                        case 19:
                            coinCount += 10000 * Inventory.inventoryQuantity[i];
                            break;
                        case 20:
                            coinCount += 1000000 * Inventory.inventoryQuantity[i];
                            break;
                    }
                }
                if (coinCount > 5000)
                {
                    Game.npcObjectives[1] = true;
                }
            }
        }//each tick checks for completion of npc objectives
    }
}
