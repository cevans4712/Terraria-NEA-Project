namespace TerrariaNEA
{
    public class Saving
    {
        public static void loadWorld()
        {
            string file = @"\\prioryacademies.co.uk\priory\Users\Students\218\" + Game.user + @"\Terraria\Player.bin";
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                for (int i = 0; i < 40; i++)
                {
                    Inventory.inventory[i] = reader.ReadByte();
                }
                for (int i = 0; i < 40; i++)
                {
                    Inventory.inventoryQuantity[i] = reader.ReadInt32();
                }
                Player.maxHealth = reader.ReadInt32();
                Player.health = reader.ReadInt32();
                Player.spawnX = reader.ReadInt32();
                Player.spawnY = reader.ReadInt32();
            }
            file = @"\\prioryacademies.co.uk\priory\Users\Students\218\" + Game.user + @"\Terraria\World.bin";
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                World.timeOfDay = reader.ReadInt32();
                for (int i = 0; i < World.worldWidth; i++)
                {
                    for (int j = 0; j < World.worldHeight; j++)
                    {
                        World.backgroundMap[i, j] = reader.ReadByte();
                        World.biomeMap[i, j] = reader.ReadByte();
                        World.blockDiscovered[i, j] = reader.ReadBoolean();
                        World.blockMap[i, j] = reader.ReadByte();
                        World.cellMap[i, j] = reader.ReadBoolean();
                        World.chestMap[i, j] = reader.ReadUInt16();
                        World.grassMap[i, j] = reader.ReadByte();
                        World.spaceMap[i, j] = reader.ReadBoolean();
                        World.wallMap[i, j] = reader.ReadByte();
                        World.waterMap[i, j] = reader.ReadSingle();
                        World.lavaMap[i, j] = reader.ReadSingle();
                        World.lightMap[i, j] = reader.ReadByte();
                    }
                }
                int maxValue = reader.ReadUInt16();
                for (int i = 1; i < maxValue; i++)
                {
                    Chest chest = new Chest();
                    chest.ID = (ushort)i;
                    for (int j = 0; j < 40; j++)
                    {
                        chest.StoredItems[j] = reader.ReadByte();
                        chest.StoredItemsQuantity[j] = reader.ReadInt32();
                    }
                    Game.chests[i] = chest;
                }
                int numberOfHouses = reader.ReadInt32();
                for (int i = 0; i < numberOfHouses; i++)
                {
                    int[] house = {reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32() };
                    Game.validHouses.Add(house);
                }
                if(reader.ReadBoolean() == true)
                {
                    Game.guide = new Guide(0);
                    Game.guide.LocationX = reader.ReadInt32();
                    Game.guide.LocationY = reader.ReadInt32();
                    Game.guide.FriendlyID = reader.ReadByte();
                    Game.guide.WaitingToSpawn = reader.ReadBoolean();
                    Game.guide.NPCHouse = reader.ReadInt32();
                    Game.guide.CurrentDirection = reader.ReadSByte();
                    Game.guide.LastDirection = reader.ReadSByte();
                    Game.guide.MoveTimer = reader.ReadByte();
                    Game.guide.NextMoveTime = reader.ReadByte();
                    Game.guide.CurrentTargetX = reader.ReadInt32();
                }
                if(reader.ReadBoolean() == true)
                {
                    Game.merchant = new Merchant(0);
                    Game.merchant.LocationX = reader.ReadInt32();
                    Game.merchant.LocationY = reader.ReadInt32();
                    Game.merchant.FriendlyID = reader.ReadByte();
                    Game.merchant.WaitingToSpawn = reader.ReadBoolean();
                    Game.merchant.NPCHouse = reader.ReadInt32();
                    Game.merchant.CurrentDirection = reader.ReadSByte();
                    Game.merchant.LastDirection = reader.ReadSByte();
                    Game.merchant.MoveTimer = reader.ReadByte();
                    Game.merchant.NextMoveTime = reader.ReadByte();
                    Game.merchant.CurrentTargetX = reader.ReadInt32();
                }
                if(reader.ReadBoolean() == true)
                {
                    Game.nurse = new Nurse(0);
                    Game.nurse.LocationX = reader.ReadInt32();
                    Game.nurse.LocationY = reader.ReadInt32();
                    Game.nurse.FriendlyID = reader.ReadByte();
                    Game.nurse.WaitingToSpawn = reader.ReadBoolean();
                    Game.nurse.NPCHouse = reader.ReadInt32();
                    Game.nurse.CurrentDirection = reader.ReadSByte();
                    Game.nurse.LastDirection = reader.ReadSByte();
                    Game.nurse.MoveTimer = reader.ReadByte();
                    Game.nurse.NextMoveTime = reader.ReadByte();
                    Game.nurse.CurrentTargetX = reader.ReadInt32();
                }
            }
        }//loads player and world data from the binary files
        public static void saveWorld()
        {
            try
            {
                string file = @"\\prioryacademies.co.uk\priory\Users\Students\218\" + Game.user + @"\Terraria\Player.bin";
                using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    //player inventory
                    for (int i = 0; i < 40; i++)
                    {
                        writer.Write(Inventory.inventory[i]);
                    }
                    //player inventory quantity
                    for (int i = 0; i < 40; i++)
                    {
                        writer.Write(Inventory.inventoryQuantity[i]);
                    }
                    //player general information
                    writer.Write(Player.maxHealth);
                    writer.Write(Player.health);
                    writer.Write(Player.spawnX);
                    writer.Write(Player.spawnY);
                }
                file = @"\\prioryacademies.co.uk\priory\Users\Students\218\" + Game.user + @"\Terraria\World.bin";
                using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    //world general info
                    writer.Write(World.timeOfDay);
                    //world block info
                    ushort maxValue = 0;
                    for (int i = 0; i < World.worldWidth; i++)
                    {
                        for (int j = 0; j < World.worldHeight; j++)
                        {
                            writer.Write(World.backgroundMap[i, j]);
                            writer.Write(World.biomeMap[i, j]);
                            writer.Write(World.blockDiscovered[i, j]);
                            writer.Write(World.blockMap[i, j]);
                            writer.Write(World.cellMap[i, j]);
                            writer.Write(World.chestMap[i, j]);
                            writer.Write(World.grassMap[i, j]);
                            writer.Write(World.spaceMap[i, j]);
                            writer.Write(World.wallMap[i, j]);
                            writer.Write(World.waterMap[i, j]);
                            writer.Write(World.lavaMap[i, j]);
                            writer.Write(World.lightMap[i, j]);
                            if (World.chestMap[i, j] > maxValue)
                            {
                                maxValue = World.chestMap[i, j];
                            }
                        }
                    }
                    //world chests
                    writer.Write(maxValue);
                    for (int i = 1; i < maxValue; i++)
                    {
                        for (int j = 0; j < 40; j++)
                        {
                            writer.Write(Game.chests[i].StoredItems[j]);
                            writer.Write(Game.chests[i].StoredItemsQuantity[j]);
                        }
                    }
                    int numberOfHouses = Game.validHouses.Count;
                    writer.Write(numberOfHouses);
                    for (int i = 0; i < numberOfHouses; i++)
                    {
                        for(int j = 0; j < 5; j++)
                        {
                            writer.Write(Game.validHouses[i][j]);
                        }
                    }
                    // --- friendly npcs ---
                    if (Game.guide != null)
                    {
                        writer.Write(true);
                        writer.Write(Game.guide.LocationX);
                        writer.Write(Game.guide.LocationY);
                        writer.Write(Game.guide.FriendlyID);
                        writer.Write(Game.guide.WaitingToSpawn);
                        writer.Write(Game.guide.NPCHouse);
                        writer.Write(Game.guide.CurrentDirection);
                        writer.Write(Game.guide.LastDirection);
                        writer.Write(Game.guide.MoveTimer);
                        writer.Write(Game.guide.NextMoveTime);
                        writer.Write(Game.guide.CurrentTargetX);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                    if (Game.merchant != null)
                    {
                        writer.Write(true);
                        writer.Write(Game.merchant.LocationX);
                        writer.Write(Game.merchant.LocationY);
                        writer.Write(Game.merchant.FriendlyID);
                        writer.Write(Game.merchant.WaitingToSpawn);
                        writer.Write(Game.merchant.NPCHouse);
                        writer.Write(Game.merchant.CurrentDirection);
                        writer.Write(Game.merchant.LastDirection);
                        writer.Write(Game.merchant.MoveTimer);
                        writer.Write(Game.merchant.NextMoveTime);
                        writer.Write(Game.merchant.CurrentTargetX);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                    if (Game.nurse != null)
                    {
                        writer.Write(true);
                        writer.Write(Game.nurse.LocationX);
                        writer.Write(Game.nurse.LocationY);
                        writer.Write(Game.nurse.FriendlyID);
                        writer.Write(Game.nurse.WaitingToSpawn);
                        writer.Write(Game.nurse.NPCHouse);
                        writer.Write(Game.nurse.CurrentDirection);
                        writer.Write(Game.nurse.LastDirection);
                        writer.Write(Game.nurse.MoveTimer);
                        writer.Write(Game.nurse.NextMoveTime);
                        writer.Write(Game.nurse.CurrentTargetX);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Save failed. Can't locate file.");
            }
        }//saves player and world data to the binary files
    }
}
