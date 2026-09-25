namespace TerrariaNEA
{
    public class FloorItem
    {
        //class contains data about all floor items in the world(isnt saved upon leaving)
        protected int locationX;
        protected int locationY;
        protected int itemID;
        protected int quantity;
        public int LocationX
        { 
            get { return locationX; }
            set { locationX = value; }
        }
        public int LocationY
        { 
            get { return locationY; }
            set { locationY = value; }
        }
        public int ItemID
        { 
            get { return itemID; }
            set { itemID = value; }
        }
        public int Quantity
        { 
            get { return quantity; }
            set { quantity = value; }
        }
        public void Fall()
        {
            Game.droppedItems[locationX, locationY] = false;
            locationY++;
            Game.droppedItems[locationX, locationY] = true;
        }//checks if can fall
        public bool TouchingPlayer()
        {
            for(int i = -3; i < 1; i++)
            {
                for(int j = -1; j < 4; j++)
                {
                    if(locationX - 42 == Player.playerLocationX + i && locationY - 21 == Player.playerLocationY + j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }//checks if is touching the player
        public void CanStack(int currentIndex)
        {
            for(int i = 0; i < Game.floorItems.Length; i++)
            {
                if (Game.floorItems[i] != null)
                {
                    if (Game.floorItems[i].ItemID == itemID && i != currentIndex)
                    {
                        if(Game.floorItems[i].LocationX == locationX && Game.floorItems[i].LocationY == locationY)
                        {
                            int totalQuantity = Game.floorItems[i].Quantity + quantity;
                            if(totalQuantity <= Game.items[itemID].Stack)
                            {
                                Game.floorItems[i] = null;
                                quantity = totalQuantity;
                            }
                            else
                            {
                                quantity = Game.items[itemID].Stack;
                                Game.floorItems[i].Quantity = totalQuantity - Game.items[itemID].Stack;
                            }
                        }
                    }
                }
            }
        }//checks if can stack with another item in contact with it
    }
}
