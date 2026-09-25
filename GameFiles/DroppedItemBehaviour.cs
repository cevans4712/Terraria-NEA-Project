namespace TerrariaNEA
{
    public class DroppedItemBehaviour
    {
        public static void droppedItemControls()
        {
            for (int i = 0; i < Game.floorItems.Length; i++)
            {
                if (Game.floorItems[i] != null)
                {
                    if (Game.floorItems[i].TouchingPlayer())
                    {
                        Inventory.pickUpItem((byte)Game.floorItems[i].ItemID, Game.floorItems[i].Quantity, i);
                    }
                    else if (!World.cellMap[Game.floorItems[i].LocationX - 40, Game.floorItems[i].LocationY - 23])
                    {
                        Game.floorItems[i].Fall();
                    }
                    else
                    {
                        Game.floorItems[i].CanStack(i);
                    }
                }
            }
        }//controls how floor items act(fall, picked up or stack)
        public static void dropItem(byte item, int quantity, int x, int y)
        {
            FloorItem floorItem = new FloorItem();
            floorItem.Quantity = quantity;
            floorItem.LocationX = x;
            floorItem.LocationY = y;
            floorItem.ItemID = item;
            for(int i = 0; i < Game.floorItems.Length; i++)
            {
                if (Game.floorItems[i] == null)
                {
                    Game.floorItems[i] = floorItem;
                    break;
                }
                if(i == Game.floorItems.Length - 1)
                {
                    Game.floorItems[Game.random.Next(300)] = floorItem;
                }
            }
            Game.droppedItems[floorItem.LocationX, floorItem.LocationY] = true;
        }//adds an item to the array of floor items when it is either dropped by the player or npc
    }
}
