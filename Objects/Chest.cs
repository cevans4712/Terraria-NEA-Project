namespace TerrariaNEA
{
    public class Chest
    {
        //class contains the id and items stored of each chest
        protected ushort id;
        protected byte[] storedItems = new byte[40];
        protected int[] storedItemsQuantity = new int[40];
        public Chest()
        {
            id = 0;
            for (int i = 0; i < 40; i++)
            {
                storedItems[i] = 255;
            }
        }
        public ushort ID
        {
            get { return id; }
            set { id = value; }
        }
        public byte[] StoredItems
        {
            get { return storedItems; }
            set { storedItems = value; }
        }
        public int[] StoredItemsQuantity
        {
            get { return storedItemsQuantity; }
            set { storedItemsQuantity = value; }
        }
    }
}
