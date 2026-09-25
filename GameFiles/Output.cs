using System.Drawing.Drawing2D;
namespace TerrariaNEA
{
	public class Output
	{
		public static void outputIfShopOpen()
		{
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (y < 4)
                    {
                        Game.ShopUI.DrawImage(Game.hotbarBG[0], x * 60, y * 60);
                    }
                    else
                    {
                        Game.ShopUI.DrawImage(Game.hotbarBG[3], x * 60, y * 60);
                    }
                    if (y < 4)
                    {
                        if (Inventory.inventory[y * 10 + x] != 255)
                        {
                            Game.ShopUI.DrawImage(Game.itemIDs[Inventory.inventory[y * 10 + x]], x * 60, y * 60);
                            Game.ShopUI.DrawString(Inventory.inventoryQuantity[y * 10 + x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60 + 5, y * 60 + 45);
                        }
                    }
                    else
                    {
                        if (Game.currentShop.ItemsSold[(y - 4) * 10 + x] != 255)
                        {
                            Game.ShopUI.DrawImage(Game.itemIDs[Game.currentShop.ItemsSold[(y - 4) * 10 + x]], x * 60, y * 60);
                            Game.ShopUI.DrawString(Game.currentShop.ItemsCost[(y - 4) * 10 + x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60 + 5, y * 60 + 45);
                        }
                    }
                }
            }
        }//displays the players inventory and the shop the player is interacting with
        public static void outputIfChestOpen()
		{
            Inventory.currentChest = Game.chests[Inventory.selectedChest].StoredItems;
            Inventory.currentChestQuantity = Game.chests[Inventory.selectedChest].StoredItemsQuantity;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (Inventory.inventoryUsage[x, y] == true)
                    {
                        Game.ChestUI.DrawImage(Game.hotbarBG[1], x * 60, y * 60);
                    }
                    else
                    {
                        if (y < 4)
                        {
                            Game.ChestUI.DrawImage(Game.hotbarBG[0], x * 60, y * 60);
                        }
                        else
                        {
                            Game.ChestUI.DrawImage(Game.hotbarBG[2], x * 60, y * 60);
                        }
                    }
                    if (y < 4)
                    {
                        if (Inventory.inventory[y * 10 + x] != 255)
                        {
                            Game.ChestUI.DrawImage(Game.itemIDs[Inventory.inventory[y * 10 + x]], x * 60, y * 60);
                            Game.ChestUI.DrawString(Inventory.inventoryQuantity[y * 10 + x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60 + 5, y * 60 + 45);
                        }
                    }
                    else
                    {
                        if (Inventory.currentChest[(y - 4) * 10 + x] != 255)
                        {
                            Game.ChestUI.DrawImage(Game.itemIDs[Inventory.currentChest[(y - 4) * 10 + x]], x * 60, y * 60);
                            Game.ChestUI.DrawString(Inventory.currentChestQuantity[(y - 4) * 10 + x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60 + 5, y * 60 + 45);
                        }
                    }
                }
            }
            if (Inventory.inventoryTemp != 255)
            {
                Game.ChestUI.DrawImage(Game.itemIDs[Inventory.inventoryTemp], Cursor.Position.X - 40, Cursor.Position.Y - 63);
            }
        }//displays the players inventory and the chest the player is interacting with
        public static void outputIfChestClosed()
		{
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (Inventory.inventoryUsage[x, y] == true)
                    {
                        Game.Inventory.DrawImage(Game.hotbarBG[1], x * 60, y * 60);
                    }
                    else
                    {
                        Game.Inventory.DrawImage(Game.hotbarBG[0], x * 60, y * 60);
                    }
                    if (Inventory.inventory[y * 10 + x] != 255)
                    {
                        Game.Inventory.DrawImage(Game.itemIDs[Inventory.inventory[y * 10 + x]], x * 60, y * 60);
                        Game.Inventory.DrawString(Inventory.inventoryQuantity[y * 10 + x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60 + 5, y * 60 + 45);
                    }
                }
            }
            if (Inventory.inventoryTemp != 255)
            {
                Game.Inventory.DrawImage(Game.itemIDs[Inventory.inventoryTemp], Cursor.Position.X - 40, Cursor.Position.Y - 63);
            }
        }//displays the players inventory
        public static void hotbarOutput()
		{
			for(int x = 0; x < 10; x++)
			{
                if (Inventory.inventoryUsage[x, 0] == false)
                {
                    Game.Hotbar.DrawImage(Game.hotbarBG[0], x * 60, 0);
                }
                else
                {
                    Game.Hotbar.DrawImage(Game.hotbarBG[1], x * 60, 0);
                }
                if (Inventory.inventory[x] != 255)
                {
                    Game.Hotbar.DrawImage(Game.itemIDs[Inventory.inventory[x]], x * 60, 0);
                    Game.Hotbar.DrawString(Inventory.inventoryQuantity[x].ToString(), Game.itemQuantityFont, Game.itemQuantityFontsBrush, x * 60, 45);
                }
            }
        }//displays what is currently in the player hotbar
        public static void inventoryOutput()
		{
			if(Game.currentShop != null)
			{
				outputIfShopOpen();
			}
			else if (World.chestOpen)
			{
				outputIfChestOpen();
			}
			else
			{
				outputIfChestClosed();
			}
			hotbarOutput();
			craftingOutput();
		}//displays the current menu ui(shop, chest or inventory)
		public static void output2x2(int x, int y, byte block)
		{
			bool output = true;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					if (x + i < 0 || y - j < 0 || x + i >= 80 || y - j >= 48)
					{
					}
					else
					{
						if (World.currentBlocks[x + i, y - j] != block)
						{
							output = false;
							break;
						}
					}
				}
			}
			if (output)
			{
				if (block == 10)
				{
					if (y < 330)
					{
						Game.Screen.DrawImage(Properties.Resources.Chest1, x * 20, y * 20 - 20);
					}
					else
					{
						Game.Screen.DrawImage(Properties.Resources.Chest2, x * 20, y * 20 - 20);
					}
				}
				else if (block == 24)
				{
					Game.Screen.DrawImage(Properties.Resources.Furnace1, x * 20, y * 20 - 20);
				}
				else if(block == 26)
				{
                    Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.LifeCrystal1, Color.White, 5), x * 20, y * 20 - 20);
                }
                else if (block == 29)
                {
                    Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.DemonAlter1, Color.White, 5), x * 20, y * 20 - 20);
                }
				else if (block == 31)
                {
                    Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.HellForge1, Color.White, 5), x * 20, y * 20 - 20);
                }
				else if (block == 32)
                {
                    Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.Table1, Color.White, 5), x * 20, y * 20 - 20);
                }
            }
		}//makes sure each 2x2 block is only displayed once
		public static void output1x2(int x, int y, byte block)
		{
			bool output = true;
			for (int i = 0; i < 2; i++)
			{
				{
					if (y + i < 0 || y + i >= 48)
					{
					}
					else
					{
						if (World.currentBlocks[x , y + i] != block)
						{
							output = false;
							break;
						}
					}
				}
			}
			if (output)
			{
				if(block == 33)
				{
                    Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.Chair1, Color.White, 5), x * 20, y * 20);
                }
            }
		}//outputs all 1x2 blocks
		public static void output2x1(int x, int y, byte block)
		{
			bool output = true;
			for (int i = 0; i < 2; i++)
			{
				{
					if (x + i < 0 || x + i >= 80)
					{
					}
					else
					{
						if (World.currentBlocks[x + i, y] != block)
						{
							output = false;
							break;
						}
					}
				}
			}
			if (output)
			{
				Game.Screen.FillRectangle(new SolidBrush(Game.backgroundColourIDs[World.currentBackgroundMap[x, y]]), x * 20, y * 20, 40, 20);
				if (World.currentWallMap[x, y] != 0)
				{
					if (block == 23)
					{
						Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.WorkBench1, Color.White, 5), x * 20, y * 20);
					}
					else if (block == 25)
					{
						Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.Anvil1, Color.White, 5), x * 20, y * 20);
					}
				}
				if (World.currentWallMap[x + 1, y] != 0)
				{
					Game.Screen.DrawImage(Game.wallIDs[World.currentWallMap[x, y], 0], x * 20 + 20, y * 20);
				}
				if (block == 23)
				{
					Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.WorkBench1, Color.White, 5), x * 20, y * 20);
				}
				else if (block == 25)
				{
					Game.Screen.DrawImage(Sprites.makeTransparent(Properties.Resources.Anvil1, Color.White, 5), x * 20, y * 20);
				}
			}
		}//outputs all 2x1 blocks
		public static void setCurrentScreen(int currentLocX, int currentLocY)
		{
            for (int x = currentLocX - 40; x < currentLocX + 40; x++)
            {
                for (int y = currentLocY - 24; y < currentLocY + 24; y++)
                {
                    World.currentBlocks[x - currentLocX + 40, y - currentLocY + 24] = World.blockMap[x, y];
                    World.currentGrass[x - currentLocX + 40, y - currentLocY + 24] = World.grassMap[x, y];
                    World.currentLight[x - currentLocX + 40, y - currentLocY + 24] = World.lightMap[x, y];
                    World.currentCracks[x - currentLocX + 40, y - currentLocY + 24] = World.cracksMap[x, y];
                    World.currentWalls[x - currentLocX + 40, y - currentLocY + 24] = World.wallMap[x, y];
                    World.currentBackgrounds[x - currentLocX + 40, y - currentLocY + 24] = World.backgroundMap[x, y];
                    Game.currentDroppedItems[x - currentLocX + 40, y - currentLocY + 24] = Game.droppedItems[x, y];
                    World.currentBiomes[x - currentLocX + 40, y - currentLocY + 24] = World.biomeMap[x, y];
                    World.currentWater[x - currentLocX + 40, y - currentLocY + 24] = World.waterMap[x, y];
                    World.currentLava[x - currentLocX + 40, y - currentLocY + 24] = World.lavaMap[x, y];
                    World.currentCells[x - currentLocX + 40, y - currentLocY + 24] = World.cellMap[x, y];
                }
            }
        }//sets the vallues of what the player can currently see
		public static void outputTransparent1x1Blocks(int currentLocX, int currentLocY, int x, int y)
		{
            if (World.currentWalls[x, y] != 0)
            {
                if (Game.wallIDs[World.currentWalls[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]] != null)
                {
                    Game.Screen.DrawImage(Game.wallIDs[World.currentWalls[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]], x * 20, y * 20);
                }
                else
                {
                    Game.Brush.Color = Game.wallColourIDs[World.currentWalls[x, y]];
                    Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
                }
            }
            else
            {
                Game.Brush.Color = Game.backgroundColourIDs[World.currentBackgrounds[x, y]];
                Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
            }
            Game.Screen.DrawImage(Game.blockIDs[World.currentBlocks[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]], x * 20, y * 20);
        }//outputs 1x1 blocks that have transparancy
        public static void outputGrass(int x, int y)
		{
            if (World.currentBiomes[x, y] == 3)
            {
                Game.Screen.DrawImage(Game.corruptGrassSprites[World.currentGrass[x, y]], x * 20, y * 20);
            }
            else if (World.currentBiomes[x, y] == 4)
            {
                Game.Screen.DrawImage(Game.jungleGrassSprites[World.currentGrass[x, y]], x * 20, y * 20);
            }
            else if (World.currentBiomes[x, y] == 5)
            {
                Game.Screen.DrawImage(Game.mushroomGrassSprites[World.currentGrass[x, y]], x * 20, y * 20);
            }
            else
            {
                Game.Screen.DrawImage(Game.grassSprites[World.currentGrass[x, y]], x * 20, y * 20);
            }
        }//outputs grass blocks based on biome
		public static void outputBackground(int x, int y)
		{
            Game.Brush.Color = Game.backgroundColourIDs[World.currentBackgrounds[x, y]];
            Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
        }//output the current backround
		public static void outputWall(int currentLocX, int currentLocY, int x, int y)
		{
            if (Game.wallIDs[World.currentWalls[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]] != null)
            {
                Game.Screen.DrawImage(Game.wallIDs[World.currentWalls[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]], x * 20, y * 20);
            }
            else
            {
                Game.Brush.Color = Game.wallColourIDs[World.currentWalls[x, y]];
                Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
            }
        }//outputs the current wall
		public static void outputBlock(int currentLocX, int currentLocY, int x, int y)
		{
            if (Game.blockIDs[World.currentBlocks[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]] != null)
            {
                Game.Screen.DrawImage(Game.blockIDs[World.currentBlocks[x, y], World.randomSprite[x + currentLocX - 40, y + currentLocY - 24]], x * 20, y * 20);
            }
            else
            {
                Game.Brush.Color = Game.blockColourIDs[World.currentBlocks[x, y]];
                Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
            }

        }//outputs the current block
		public static void moveFloorItems()
		{
            for (int x = 0; x < 80; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    if (Game.currentDroppedItems[x, y])
                    {
                        for (int i = 0; i < Game.floorItems.Length; i++)
                        {
                            if (Game.floorItems[i] != null)
                            {
                                if (Game.floorItems[i].LocationY == y + Player.playerY)
                                {
                                    if (Game.floorItems[i].LocationX == x + Player.playerX)
                                    {
                                        Game.Screen.DrawImage(Game.itemIDs[Game.floorItems[i].ItemID], x * 20, y * 20);
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//outputs the visible floor items
        public static void outputScreen()
		{
            int currentLocX = Player.playerX;
            int currentLocY = Player.playerY;
            setCurrentScreen(currentLocX, currentLocY);
			for (int x = 0; x < 80; x++)
			{
				for (int y = 0; y < 48; y++)
				{
					int brightness;
					if (World.currentBlocks[x, y] == 22 || World.currentBlocks[x, y] == 28)
					{
                        brightness = 255 - (World.currentLight[x, y] + 1) * 17;
                    }
					else
					{
                        brightness = 255 - World.currentLight[x, y] * 17;
                    }
                    if (brightness != 255)
					{
						World.blockDiscovered[currentLocX - 40 + x, currentLocY - 24 + y] = true;
						if (World.currentBlocks[x, y] == 9)
						{
							outputGrass(x, y);
						}
						else if (World.currentBlocks[x, y] == 16 || World.currentBlocks[x, y] == 22 || World.currentBlocks[x, y] == 28)
						{
							outputTransparent1x1Blocks(currentLocX, currentLocY, x, y);
						}
						else if (World.currentBlocks[x, y] == 0 && World.currentWalls[x, y] == 0)
						{
							outputBackground(x, y);
						}
						else if (World.currentBlocks[x, y] == 0)
						{
							outputWall(currentLocX, currentLocY, x, y);
						}
						else
						{
							outputBlock(currentLocX, currentLocY, x, y);
						}
					}
				}
			}
			for (int x = 0; x < 80; x++)
			{
				for (int y = 0; y < 48; y++)
				{
					output2x2(x, y, 10);//output chests
					output2x2(x, y, 24);//output furncaces
					output2x2(x, y, 26);//output life crystals
					output2x2(x, y, 29);//output demon alters
					output2x2(x, y, 32);//output tables
					output2x2(x, y, 31);//output hell forges
					output2x1(x, y, 23);//output workbenchs
					output2x1(x, y, 25);//output anvils
					output1x2(x, y, 33);//output chairs
				}
			}
			moveFloorItems();
			outputNPCs();
			outputProjectiles();
			outputFloorItems();
			//output the player
			//flashes if in immunity
			if (Player.immunity % 2 == 0)
			{
				Game.Screen.DrawImage(Game.runningAnimation[Player.animationi, Player.animationj], Player.playerOnScreenX, Player.playerOnScreenY, 40, 60);
			}
			outputFluids();
			outputShadows();
            outputBosses();
            outputBossHealthBars();
		}//displays the screen
		public static void outputShadows()
		{
            for (int x = 0; x < 80; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    int brightness = 255 - World.currentLight[x, y] * 17;
                    if (brightness > 0)
                    {
                        Game.Brush.Color = Color.FromArgb(brightness, 0, 0, 0);
                        Game.Screen.FillRectangle(Game.Brush, x * 20, y * 20, 20, 20);
                    }
                    if (World.currentCracks[x, y] != 3)
                    {
                        Game.Screen.DrawImage(Game.cracksIDs[World.currentCracks[x, y]], x * 20, y * 20);
                    }
                }
            }
        }//displays the lighting
		public static void outputMap()
		{
			SolidBrush waterBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
			SolidBrush lavaBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
			for (int x = 0; x < World.worldWidth; x++)
			{
				for (int y = 0; y < World.worldHeight; y++)
				{
					World.currentBlockMap[x, y] = World.blockMap[x, y];
					World.currentBackgroundMap[x, y] = World.backgroundMap[x, y];
					World.currentWallMap[x, y] = World.wallMap[x, y];
				}
			}
			for (int x = 0; x < World.worldWidth; x++)
			{
				for (int y = 0; y < World.worldHeight; y++)
				{
					if (World.currentBlockMap[x, y] == 10)
					{
						if (World.blockDiscovered[x, y])
						{
							Game.Brush.Color = Game.blockColourIDs[World.currentBlockMap[x, y]];
							Game.Map.FillRectangle(Game.Brush, x, y - 1, 2, 2);
							World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
						}
					}
					if (World.currentBlockMap[x, y] == 0 && World.currentWallMap[x, y] == 0)
					{
						if (World.currentBackgroundMap[x, y] != World.lastBackgroundMap[x, y])
						{
							if (World.blockDiscovered[x, y])
							{
								Game.Brush.Color = Game.backgroundColourIDs[World.currentBackgroundMap[x, y]];
								Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
								World.lastBackgroundMap[x, y] = World.currentBackgroundMap[x, y];
							}
						}
					}
					else if (World.currentBlockMap[x, y] == 0)
					{
						if (World.currentWallMap[x, y] != World.lastWallMap[x, y])
						{
							if (World.blockDiscovered[x, y])
							{
								Game.Brush.Color = Game.wallColourIDs[World.currentWallMap[x, y]];
								Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
								World.lastWallMap[x, y] = World.currentWallMap[x, y];
							}
						}
					}
					else
					{
						if (World.currentBlockMap[x, y] != World.lastBlockMap[x, y])
						{
							if (World.blockDiscovered[x, y])
							{
								if (World.blockMap[x, y] == 9)
								{
									if (World.biomeMap[x, y] == 3)
									{
										Game.Brush.Color = Color.FromArgb(255, 156, 79, 172);
										Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
										World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
									}
									else if (World.biomeMap[x, y] == 4)
									{
										Game.Brush.Color = Color.FromArgb(255, 32, 255, 37);
										Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
										World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
									}
									else if (World.biomeMap[x, y] == 5)
									{
										Game.Brush.Color = Color.FromArgb(255, 63, 72, 204);
										Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
										World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
									}
									else
									{
										Game.Brush.Color = Game.blockColourIDs[World.currentBlockMap[x, y]];
										Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
										World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
									}
								}
								else
								{
									Game.Brush.Color = Game.blockColourIDs[World.currentBlockMap[x, y]];
									Game.Map.FillRectangle(Game.Brush, x, y, 1, 1);
									World.lastBlockMap[x, y] = World.currentBlockMap[x, y];
								}
							}
						}
					}
					if (World.blockDiscovered[x, y])
					{
                        if (!World.cellMap[x, y])
                        {
                            if (World.waterMap[x, y] > 0.05)
                            {
                                Game.Map.FillRectangle(waterBrush, x, y, 1, 1);
                            }
							if (World.lavaMap[x, y] > 0.05)
                            {
                                Game.Map.FillRectangle(lavaBrush, x, y, 1, 1);
                            }
                        }
                    }
                }
			}
		}//updates the map each time its opened
		public static void outputHealth()
		{
			byte hearts = Convert.ToByte(Player.health / 20);
			byte remainder = Convert.ToByte(Player.health % 20 / 5);
			int xPos = 1380; //starting pos
			int yPos = 20;
			for (int i = 0; i < hearts; i++)
			{
				Game.Screen.DrawImage(Game.heartsBMPs[3], xPos, yPos);
				xPos += 20;
				if (i == 9)
				{
					yPos = 40;
					xPos = 1380;
				}
			}
			if (remainder != 0)
			{
				Game.Screen.DrawImage(Game.heartsBMPs[remainder - 1], xPos, yPos);
			}
		}//outputs player health
		public static void outputBreath()
		{
			byte bubbles = Convert.ToByte(Player.breath / 20);
			byte remainder = Convert.ToByte((Player.breath % 20) / 5);
			int xPos = Player.playerOnScreenX - 10;
			int yPos = Player.playerOnScreenY - 20;
			if (Player.breath != 100)
			{
                for (int i = 0; i < bubbles; i++)
                {
                    Game.Screen.DrawImage(Game.bubblesBMPs[3], xPos, yPos);
                    xPos += 10;
                }
                if (remainder != 0)
                {
                    Game.Screen.DrawImage(Game.bubblesBMPs[remainder - 1], xPos, yPos);
                }
            }
		}//outputs player breath
		public static void outputNPCs()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Game.slimes[i] != null)
				{
					int npcX = Game.slimes[i].LocationX;
					int npcY = Game.slimes[i].LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
					if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 21 && npcY <= playerY + 40)
					{
						int npcOnScreenX = npcX - playerX + 40;
						int npcOnScreenY = npcY - playerY + 21;
						if (Game.slimes[i].Immunity % 2 == 0)
						{
							switch (Game.slimes[i].ID)
							{
								case 1:
									Game.Screen.DrawImage(Game.npcBMPs[0], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
								case 2:
									Game.Screen.DrawImage(Game.npcBMPs[1], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
								case 3:
									Game.Screen.DrawImage(Game.npcBMPs[2], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
								case 4:
									Game.Screen.DrawImage(Game.npcBMPs[4], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
								case 5:
									Game.Screen.DrawImage(Game.npcBMPs[3], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
								case 6:
									Game.Screen.DrawImage(Game.npcBMPs[5], npcOnScreenX * 20, npcOnScreenY * 20);
									break;
							}
						}
					}
				}
				if (Game.zombies[i] != null)
				{
					int npcX = Game.zombies[i].LocationX;
					int npcY = Game.zombies[i].LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
					if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 21 && npcY <= playerY + 40)
					{
						int npcOnScreenX = npcX - playerX + 40;
						int npcOnScreenY = npcY - playerY + 21;
						if (Game.zombies[i].Immunity % 2 == 0)
						{
							switch (Game.zombies[i].ID)
							{
								case 7://zombie
									if (Game.zombies[i].DirectionX < 0)
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[6], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
									else
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[7], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
                                    break;
								case 8://mummy
									if (Game.zombies[i].DirectionX < 0)
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[10], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
									else
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[11], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
                                    break;
								case 9://eskimo
									if (Game.zombies[i].DirectionX < 0)
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[8], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
									else
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[9], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
                                    break;
								case 10://skeleton
									if (Game.zombies[i].DirectionX < 0)
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[12], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
									else
									{
                                        Game.Screen.DrawImage(Game.npcBMPs[13], npcOnScreenX * 20, npcOnScreenY * 20);
                                    }
                                    break;

							}
						}
					}
				}
				if (Game.flyingEnemies[i] != null)
				{
					int npcX = Game.flyingEnemies[i].LocationX;
					int npcY = Game.flyingEnemies[i].LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
					if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 21 && npcY <= playerY + 40)
					{
						int npcOnScreenX = npcX - playerX + 40;
						int npcOnScreenY = npcY - playerY + 21;
						if (Game.flyingEnemies[i].Immunity % 2 == 0)
						{
							switch (Game.flyingEnemies[i].ID)
							{
								case 12:
								case 13:
									Game.Screen.DrawImage(Game.npcBMPs[14 + demonEyeDirection(Game.flyingEnemies[i])], npcOnScreenX * 20, npcOnScreenY * 20);
									break;

                            }
                        }
                    }
				}
				if(Game.guide != null)
				{
					int npcX = Game.guide.LocationX;
					int npcY = Game.guide.LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
                    if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 30 && npcY <= playerY + 30)
                    {
                        int npcOnScreenX = npcX - playerX + 40;
                        int npcOnScreenY = npcY - playerY + 21;
						if(Game.guide.CurrentDirection == -1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[22], npcOnScreenX * 20, npcOnScreenY * 20);
                        }
						else if(Game.guide.CurrentDirection == 1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[23], npcOnScreenX * 20, npcOnScreenY * 20);
                        }
						else
						{
                            if (Game.guide.LastDirection == -1)
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[22], npcOnScreenX * 20, npcOnScreenY * 20);
                            }
                            else
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[23], npcOnScreenX * 20, npcOnScreenY * 20);
                            }
                        }
                    }
                }
				if(Game.merchant != null)
				{
					int npcX = Game.merchant.LocationX;
					int npcY = Game.merchant.LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
                    if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 30 && npcY <= playerY + 30)
                    {
                        int npcOnScreenX = npcX - playerX + 40;
                        int npcOnScreenY = npcY - playerY + 21;
						if(Game.merchant.CurrentDirection == -1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[24], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                        }
						else if(Game.merchant.CurrentDirection == 1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[25], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                        }
						else
						{
                            if (Game.merchant.LastDirection == -1)
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[24], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                            }
                            else
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[25], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                            }
                        }
                    }
                }
				if(Game.nurse != null)
				{
					int npcX = Game.nurse.LocationX;
					int npcY = Game.nurse.LocationY;
					int playerX = Player.playerX;
					int playerY = Player.playerY;
                    if (npcX > playerX - 42 && npcX <= playerX + 40 && npcY > playerY - 30 && npcY <= playerY + 30)
                    {
                        int npcOnScreenX = npcX - playerX + 40;
                        int npcOnScreenY = npcY - playerY + 21;
						if(Game.nurse.CurrentDirection == -1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[26], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                        }
						else if(Game.nurse.CurrentDirection == 1)
						{
                            Game.Screen.DrawImage(Game.npcBMPs[27], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                        }
						else
						{
                            if (Game.nurse.LastDirection == -1)
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[26], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                            }
                            else
                            {
                                Game.Screen.DrawImage(Game.npcBMPs[27], npcOnScreenX * 20, npcOnScreenY * 20, 40, 60);
                            }
                        }
                    }
                }
			}
		}//outputs all visible npcs
	    public static void outputBosses()
		{
			if(Game.eyeOfCthulhu != null)
			{
				EyeOfCthulhu boss = Game.eyeOfCthulhu;
                int npcX = boss.LocationX;
                int npcY = boss.LocationY;
                int playerX = Player.playerLocationX;
                int playerY = Player.playerLocationY;
				if (npcX > playerX - 60 && npcX <= playerX + 45 && npcY > playerY - 35 && npcY <= playerY + 25)
				{
					int npcOnScreenX = npcX - playerX + 40;
					int npcOnScreenY = npcY - playerY + 21;
					if(boss.Immunity % 2 == 0)
					{
						if(boss.ModeChangeTimer > 0)
						{
                            Game.Screen.DrawImage(Game.eyeOfClthuluBMPs[(boss.ModeChangeTimer % 8) + 8], npcOnScreenX * 20, npcOnScreenY * 20, 240, 240);
                        }
                        else
						{
                            if (boss.Mode == 1)
                            {
                                Game.Screen.DrawImage(Game.eyeOfClthuluBMPs[eyeOfCthulhuDirection(boss)], npcOnScreenX * 20, npcOnScreenY * 20, 240, 240);
                            }
                            else
                            {
                                Game.Screen.DrawImage(Game.eyeOfClthuluBMPs[eyeOfCthulhuDirection(boss) + 8], npcOnScreenX * 20, npcOnScreenY * 20, 240, 240);
                            }
                        }
                    }
                }
            }
        }//outputs all bosses
		public static void outputBossHealthBars()
		{
            if (Game.eyeOfCthulhu != null)
            {
                EyeOfCthulhu boss = Game.eyeOfCthulhu;
				Game.Screen.FillRectangle(new SolidBrush(Color.FromArgb(255, 30 ,30 ,30)), 600, 790, 400, 50);
				Game.Screen.FillRectangle(new SolidBrush(Color.FromArgb(255, 0 ,0 ,0)), 610, 800, 380, 30);
				float healthDecimal = (float)boss.Health / (float)boss.TotalHealth;
				int healthLength = Convert.ToInt32(healthDecimal * 380);
				SolidBrush brush = new SolidBrush(Color.Black);
				if(healthDecimal < 0.2)
				{
					brush.Color = Color.FromArgb(255, 255, 0, 0);
				}
				else if(healthDecimal < 0.4)
				{
					brush.Color = Color.FromArgb(255, 255, 165, 0);
                }
				else if(healthDecimal < 0.6)
				{
					brush.Color = Color.FromArgb(255, 255, 255, 0);
                }
				else if(healthDecimal < 0.8)
				{
					brush.Color = Color.FromArgb(255, 155, 205, 50);
                }
				else
				{
                    brush.Color = Color.FromArgb(255, 0, 255, 0);
                }
				Game.Screen.FillRectangle(brush, 610, 800, healthLength, 30);
            }
        }//if a boss is currently being fought display a health bar
        public static byte eyeOfCthulhuDirection(EyeOfCthulhu boss)
		{
			int aimX = boss.LocationX - Player.playerLocationX;
			int aimY = boss.LocationY - Player.playerLocationY;
			double angle = 0;
			if (aimX == 0)
			{
				if (aimY < 0)
				{
					angle = -Math.PI / 2;
				}
				else
				{
					angle = Math.PI / 2;
				}
			}
			else
			{
				if (aimY == 0)
				{
					if (aimX < 0)
					{
						angle = Math.PI;
					}
					else
					{
						angle = 0;
					}
				}
				else
				{
					angle = Math.Atan((float)aimY / (float)aimX);
					if (aimX < 0 && aimY < 0)
					{
						angle = -(Math.PI - angle);
					}
					if (aimX < 0 && aimY > 0)
					{
						angle = Math.PI + angle;
					}
				}
			}
			return handleAngle(angle);
        }//checks which direction the eye of cthulhu is facing
		public static byte demonEyeDirection(FlyingEnemy npc)
		{
			int aimX = npc.VelocityX;
			int aimY = npc.VelocityY;
            double angle = 0;
            if (aimX == 0)
            {
                if (aimY < 0)
                {
                    angle = -Math.PI / 2;
                }
                else
                {
                    angle = Math.PI / 2;
                }
            }
            else
            {
                if (aimY == 0)
                {
                    if (aimX < 0)
                    {
                        angle = Math.PI;
                    }
                    else
                    {
                        angle = 0;
                    }
                }
                else
                {
                    angle = Math.Atan((float)aimY / (float)aimX);
                    if (aimX < 0 && aimY < 0)
                    {
                        angle = -(Math.PI - angle);
                    }
                    if (aimX < 0 && aimY > 0)
                    {
                        angle = Math.PI + angle;
                    }
                }
            }
            return handleAngle(angle);

        }//checks which direction each demon eye is facing
        public static byte handleAngle(double angle)
		{
			byte value;
			if(Math.Abs(angle) <= Math.PI / 8)
			{
				value = 3;
			}
			else if(Math.Abs(angle) <= Math.PI / 8 * 3)
			{
				if(angle < 0)
				{
					value = 5;
				}
				else
				{
					value = 0;
				}
			}
			else if(Math.Abs(angle) <= Math.PI / 8 * 5)
			{
				if(angle < 0)
				{
					value = 6;
				}
				else
				{
					value = 1;
				}
			}
			else if(Math.Abs(angle) <= Math.PI / 8 * 7)
			{
				if(angle < 0)
				{
					value = 7;
				}
				else
				{
					value = 2;
				}
			}
			else
			{
				value = 4;
			}
			return value;
		}//turns and x and y value into an angle
        public static void outputFloorItems()
		{
			for (int i = 0; i < 300; i++)
			{
				if (Game.floorItems[i] != null)
				{
					int ix = Game.floorItems[i].LocationX;
					int iy = Game.floorItems[i].LocationY;
					int px = Player.playerLocationX;
					int py = Player.playerLocationY;
					if (ix > px && ix <= px + 80 && iy > py && iy <= py + 42)
					{
						int ilx = ix - px;
						int ily = iy - py;
						Game.Screen.DrawImage(Game.itemIDs[Game.floorItems[i].ItemID], ilx * 20, ily * 20, 20, 20);
					}

				}
			}
		}//displays the current floor items
		public static void craftingOutput()
		{
			int xPos = 0;
			int yPos = 0;
			byte[] onlyVisibleRecipes = new byte[255];
			byte visiblesRecipesCount = 0;
			for (int j = 0; j < onlyVisibleRecipes.Length; j++)
			{
				onlyVisibleRecipes[j] = 255;
				if (!Game.craftableRecipes.Contains(Game.visibleRecipes[j]))
				{
					onlyVisibleRecipes[visiblesRecipesCount] = Game.visibleRecipes[j];
					visiblesRecipesCount++;
				}
			}
			int iterateTo = Game.visibleRecipesCount / 5 * 5 + 5;
			if (Game.visibleRecipesCount % 5 == 0 && Game.visibleRecipesCount != 0)
			{
				iterateTo = Game.visibleRecipesCount / 5 * 5;
			}
			for (int i = 0; i < iterateTo; i++)
			{
				if (i % 5 == 0 && i != 0)
				{
					xPos += 60;
					yPos = 0;
				}
				byte item;
				if (Game.craftableRecipes[i] != 255)
				{
					if (Game.craftableRecipes[i] != 255)
					{
						item = Game.recipes[Game.craftableRecipes[i]].Product;
					}
					else
					{
						item = 255;
					}
				}
				else
				{
					if (onlyVisibleRecipes[i - Game.craftableRecipesCount] != 255)
					{
						item = Game.recipes[onlyVisibleRecipes[i - Game.craftableRecipesCount]].Product;
					}
					else
					{
						item = 255;
					}
				}
				byte recipe = 0;
				Game.CraftingUI.DrawImage(Game.hotbarBG[0], xPos, yPos);
				if (item != 255)
				{
					Game.CraftingUI.DrawImage(Game.itemIDs[item], xPos, yPos);
					for (byte j = 0; j < 255; j++)
					{
						if (Game.recipes[j].Product == item)
						{
							recipe = j;
							break;
						}
					}
					if (!Game.craftableRecipes.Contains(recipe))
					{
						Game.CraftingUI.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), xPos, yPos, 60, 60);
					}
				}
				else
				{
					Game.CraftingUI.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), xPos, yPos, 60, 60);
				}
				yPos += 60;
			}
		}//displays the crafting menu
		public static void outputFluids()
		{
			SolidBrush waterBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
			SolidBrush lavaBrush = new SolidBrush(Color.FromArgb(185, 255, 0, 0));
			for (int x = 0; x < 80; x++)
			{
				for (int y = 0; y < 48; y++)
				{
					//output water
					int amountFull = Convert.ToInt32(World.currentWater[x, y] * 20f);
					int start = 20 - amountFull;
					if(amountFull != 0 && !World.currentCells[x, y])
					{
						Game.Screen.FillRectangle(waterBrush, x * 20, y * 20 + start, 20, amountFull);
                    }
					//output lava
					amountFull = Convert.ToInt32(World.currentLava[x, y] * 20f);
					start = 20 - amountFull;
					if(amountFull != 0 && !World.currentCells[x, y])
					{
						Game.Screen.FillRectangle(lavaBrush, x * 20, y * 20 + start, 20, amountFull);
                    }
                }
			}
		}//displays lava and water on the screen
		public static void outputProjectiles()
		{
			for(int i = 0; i < 100; i++)
			{
				if (Game.arrows[i] != null)
				{
					if(Math.Abs(Game.arrows[i].BlockLocationX - Player.playerX) <= 40 && Math.Abs(Game.arrows[i].BlockLocationY - Player.playerY) <= 21)
					{
						drawArrow(Game.arrows[i].Angle, (Game.arrows[i].BlockLocationX - Player.playerX + 40) * 20 + 10, (Game.arrows[i].BlockLocationY - Player.playerY + 21) * 20 + 10);
					}
				}
			}
		}//outputs the projectiles currently on the screen
		public static void drawArrow(double angle, int centreX, int centreY)
		{
            double angleDifferencePoint = Math.Sin(0.2);
            double angleDifferenceFeatherBase = Math.Sin(1.0 / 3.0);
            double angleDifferenceFeatherTop = Math.Sin(1.0 / 6.0);
            int arrowPointDistance = (int)Math.Sqrt(2 * 2 + 16 * 16);
            int featherPointDistance = (int)Math.Sqrt(2 * 2 + 12 * 12);
            int featherPointDistance2 = (int)Math.Sqrt(2 * 2 + 20 * 20);
            GraphicsPath path = new GraphicsPath();
            //top half
            path.AddLine(centreX, centreY, centreX + (int)(16 * Math.Cos(angle)), centreY + (int)(16 * Math.Sin(angle)));
            // bottom half
            path.AddLine(centreX, centreY, centreX + -(int)(16 * Math.Cos(angle)), centreY + -(int)(16 * Math.Sin(angle)));
            //arrow head
            path.AddLine(centreX + (int)(16 * Math.Cos(angle)), centreY + (int)(16 * Math.Sin(angle)), centreX + (int)(arrowPointDistance * Math.Cos(angle - angleDifferencePoint)), centreY + (int)(arrowPointDistance * Math.Sin(angle - angleDifferencePoint)));
            path.AddLine(centreX + (int)(arrowPointDistance * Math.Cos(angle - angleDifferencePoint)), centreY + (int)(arrowPointDistance * Math.Sin(angle - angleDifferencePoint)), centreX + (int)(20 * Math.Cos(angle)), centreY + (int)(20 * Math.Sin(angle)));
            path.AddLine(centreX + (int)(20 * Math.Cos(angle)), centreY + (int)(20 * Math.Sin(angle)), centreX + (int)(arrowPointDistance * Math.Cos(angle + angleDifferencePoint)), centreY + (int)(arrowPointDistance * Math.Sin(angle + angleDifferencePoint)));
            path.AddLine(centreX + (int)(arrowPointDistance * Math.Cos(angle + angleDifferencePoint)), centreY + (int)(arrowPointDistance * Math.Sin(angle + angleDifferencePoint)), centreX + (int)(16 * Math.Cos(angle)), centreY + (int)(16 * Math.Sin(angle)));
            //arrow feather part 1
            path.AddLine(centreX + -(int)(10 * Math.Cos(angle)), centreY + -(int)(10 * Math.Sin(angle)), centreX + -(int)(featherPointDistance * Math.Cos(angle - angleDifferenceFeatherBase)), centreY + -(int)(featherPointDistance * Math.Sin(angle - angleDifferenceFeatherBase)));
            path.AddLine(centreX + -(int)(featherPointDistance * Math.Cos(angle - angleDifferenceFeatherBase)), centreY + -(int)(featherPointDistance * Math.Sin(angle - angleDifferenceFeatherBase)), centreX + -(int)(featherPointDistance2 * Math.Cos(angle - angleDifferenceFeatherTop)), centreY + -(int)(featherPointDistance2 * Math.Sin(angle - angleDifferenceFeatherTop)));
            path.AddLine(centreX + -(int)(featherPointDistance2 * Math.Cos(angle - angleDifferenceFeatherTop)), centreY + -(int)(featherPointDistance2 * Math.Sin(angle - angleDifferenceFeatherTop)), centreX + -(int)(16 * Math.Cos(angle)), centreY + -(int)(16 * Math.Sin(angle)));
            //arrow feather part 2
            path.AddLine(centreX + -(int)(10 * Math.Cos(angle)), centreY + -(int)(10 * Math.Sin(angle)), centreX + -(int)(featherPointDistance * Math.Cos(angle + angleDifferenceFeatherBase)), centreY + -(int)(featherPointDistance * Math.Sin(angle + angleDifferenceFeatherBase)));
            path.AddLine(centreX + -(int)(featherPointDistance * Math.Cos(angle + angleDifferenceFeatherBase)), centreY + -(int)(featherPointDistance * Math.Sin(angle + angleDifferenceFeatherBase)), centreX + -(int)(featherPointDistance2 * Math.Cos(angle + angleDifferenceFeatherTop)), centreY + -(int)(featherPointDistance2 * Math.Sin(angle + angleDifferenceFeatherTop)));
            path.AddLine(centreX + -(int)(featherPointDistance2 * Math.Cos(angle + angleDifferenceFeatherTop)), centreY + -(int)(featherPointDistance2 * Math.Sin(angle + angleDifferenceFeatherTop)), centreX + -(int)(16 * Math.Cos(angle)), centreY + -(int)(16 * Math.Sin(angle)));
            Game.Screen.DrawPath(new Pen(Color.Black, 2), path);
        }//draws an arrow based on its location and its heading
	}
}
