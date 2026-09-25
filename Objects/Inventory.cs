namespace TerrariaNEA
{
    public class Inventory
    {
        //this class contains all data relating to the players inventory
        public static bool[,] inventoryUsage = new bool[10, 8];
        public static byte[] inventory = new byte[40];
        public static int[] inventoryQuantity = new int[40];
        public static bool inventoryOpen = false;
        public static byte inventoryTemp = 255;
        public static int inventoryQuantityTemp = 0;
        public static int inventoryTempID = 255;
        public static byte[] currentChest = new byte[40];
        public static int[] currentChestQuantity = new int[40];
        public static ushort selectedChest = 0;
        public static bool itemFromInventory;
        public static void pickUpItem(byte item, int quantity, int itemIndex)
        {
            bool itemNotInInventory = true;
            int itemQuantityToBeStored = 0;
            for(int i =  0; i < inventory.Length; i++)
            {
                if (inventory[i] == item && inventoryQuantity[i] != Game.items[item].Stack)
                {
                    if (inventoryQuantity[i] + quantity <= Game.items[item].Stack)
                    {
                        inventoryQuantity[i] += quantity;
                        Game.floorItems[itemIndex] = null;
                        itemNotInInventory = false;
                        break;
                    }
                    else
                    {
                        int totalQuantity = inventoryQuantity[i] + quantity;
                        if (item == 17 || item == 18 || item == 19)// if the item is a coin
                        {
                            Game.floorItems[itemIndex] = null;
                            DroppedItemBehaviour.dropItem((byte)(item + 1), totalQuantity / 100, Player.playerLocationX + 40, Player.playerLocationY + 23);
                            itemQuantityToBeStored = totalQuantity % 100;
                            inventory[i] = 255;
                            inventoryQuantity[i] = 0;
                        }
                        else
                        {
                            Game.floorItems[itemIndex] = null;
                            inventoryQuantity[i] = Game.items[item].Stack;
                            itemQuantityToBeStored = totalQuantity - inventoryQuantity[i];
                        }
                    }
                }
            }
            if (itemNotInInventory)
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] == 255)
                    {
                        inventory[i] = item;
                        inventoryQuantity[i] = itemQuantityToBeStored;
                        break;
                    }
                }
            }
        }//adds the item to the inventory. if the item is a coin and a stack is obtained drop the next tier coin(e.g. 100 copper = 1 silver)
    }
}
