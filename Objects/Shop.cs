namespace TerrariaNEA
{
    public class Shop
    {
        //this class contains all the data relating to npc shops
        protected byte[] itemsSold = new byte[40];//what items are for sale
        protected int[] itemsCost = new int[40];//how much they cost
        public byte[] ItemsSold
        {
            get { return itemsSold; }
            set { itemsSold = value; }
        }
        public int[] ItemsCost
        {
            get { return itemsCost; }
            set { itemsCost = value; }
        }
    }
    //below is where each npc shop is created
    public class MerchantShop : Shop
    {
        public MerchantShop()
        {
            itemsSold[0] = 0;//copper pickaxe
            itemsSold[1] = 4;//copper axe
            itemsSold[2] = 15;//torch
            itemsSold[3] = 40;//furnace
            itemsSold[4] = 41;//anvil
            itemsSold[5] = 54;//woorden arrow
            itemsCost[0] = 500;
            itemsCost[1] = 500;
            itemsCost[2] = 50;
            itemsCost[3] = 300;
            itemsCost[4] = 5000;
            itemsCost[5] = 5;
            for (int i = 6; i < 40; i++)
            {
                itemsSold[i] = 255;
                itemsCost[i] = 0;
            }
        }
    }
}
