namespace TerrariaNEA
{
    public class Recipe
    {
        //this class contains all the data about each crafting recipe
        public byte id;
        protected byte[] requirements;
        protected int[] requirementQuantities;
        protected byte product;
        protected int productQuantity;
        public byte station;
        public byte[] Requirements
        {
            get { return requirements; }
            set { requirements = value; }
        }
        public int[] RequirementQuantities
        {
            get { return requirementQuantities; }
            set { requirementQuantities = value; }
        }
        public byte Product
        {
            get { return product; }
            set { product = value; }
        }
        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }
        public byte Station
        {
            get { return station; }
            set { station = value; }
        }
        public byte ID
        {
            get { return id; }
            set { id = value; }
        }
    }
    //below is where each new crafting recipe is created and assigned its values
    public class CopperBarRecipe : Recipe
    {
        public CopperBarRecipe()
        {
            id = 0;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 28;
            requirementQuantities[0] = 3;
            product = 34;
            productQuantity = 1;
            station = 24;
        }
    }
    public class IronBarRecipe : Recipe
    {
        public IronBarRecipe()
        {
            id = 1;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 29;
            requirementQuantities[0] = 3;
            product = 35;
            productQuantity = 1;
            station = 24;
        }
    }
    public class SilverBarRecipe : Recipe
    {
        public SilverBarRecipe()
        {
            id = 2;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 30;
            requirementQuantities[0] = 4;
            product = 36;
            productQuantity = 1;
            station = 24;
        }
    }
    public class GoldBarRecipe : Recipe
    {
        public GoldBarRecipe()
        {
            id = 3;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 31;
            requirementQuantities[0] = 4;
            product = 37;
            productQuantity = 1;
            station = 24;
        }
    }
    public class HellstoneBarRecipe : Recipe
    {
        public HellstoneBarRecipe()
        {
            id = 4;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 32;
            requirementQuantities[0] = 5;
            product = 38;
            productQuantity = 1;
            station = 24;
        }
    }
    public class TorchRecipe : Recipe
    {
        public TorchRecipe()
        {
            id = 5;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 16;
            requirementQuantities[0] = 1;
            requirements[1] = 21;
            requirementQuantities[1] = 1;
            product = 15;
            productQuantity = 3;
            station = 255;
        }
    }
    public class WoodWallRecipe : Recipe
    {
        public WoodWallRecipe()
        {
            id = 6;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 1;
            product = 22;
            productQuantity = 4;
            station = 23;
        }
    }
    public class WorkBenchRecipe : Recipe
    {
        public WorkBenchRecipe()
        {
            id = 7;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 10;
            product = 39;
            productQuantity = 1;
            station = 255;
        }
    }
    public class FurnaceRecipe : Recipe
    {
        public FurnaceRecipe()
        {
            id = 8;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 9;
            requirementQuantities[0] = 20;
            requirements[1] = 15;
            requirementQuantities[1] = 3;
            product = 40;
            productQuantity = 1;
            station = 23;
        }
    }
    public class AnvilRecipe : Recipe
    {
        public AnvilRecipe()
        {
            id = 9;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 35;
            requirementQuantities[0] = 8;
            product = 41;
            productQuantity = 1;
            station = 23;
        }
    }
    public class CopperSwordRecipe : Recipe
    {
        public CopperSwordRecipe()
        {
            id = 10;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 34;
            requirementQuantities[0] = 5;
            product = 11;
            productQuantity = 1;
            station = 25;
        }
    }
    public class IronSwordRecipe : Recipe
    {
        public IronSwordRecipe()
        {
            id = 11;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 35;
            requirementQuantities[0] = 5;
            product = 12;
            productQuantity = 1;
            station = 25;
        }
    }
    public class SilverSwordRecipe : Recipe
    {
        public SilverSwordRecipe()
        {
            id = 12;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 36;
            requirementQuantities[0] = 5;
            product = 13;
            productQuantity = 1;
            station = 25;
        }
    }
    public class GoldSwordRecipe : Recipe
    {
        public GoldSwordRecipe()
        {
            id = 13;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 37;
            requirementQuantities[0] = 5;
            product = 14;
            productQuantity = 1;
            station = 25;
        }
    }
    public class WoodSwordRecipe : Recipe
    {
        public WoodSwordRecipe()
        {
            id = 14;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 8;
            product = 10;
            productQuantity = 1;
            station = 23;
        }
    }
    public class CopperPickaxeRecipe : Recipe
    {
        public CopperPickaxeRecipe()
        {
            id = 15;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 34;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 4;
            product = 0;
            productQuantity = 1;
            station = 25;
        }
    }
    public class IronPickaxeRecipe : Recipe
    {
        public IronPickaxeRecipe()
        {
            id = 16;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 35;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 4;
            product = 1;
            productQuantity = 1;
            station = 25;
        }
    }
    public class SilverPickaxeRecipe : Recipe
    {
        public SilverPickaxeRecipe()
        {
            id = 17;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 36;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 4;
            product = 2;
            productQuantity = 1;
            station = 25;
        }
    }
    public class GoldPickaxeRecipe : Recipe
    {
        public GoldPickaxeRecipe()
        {
            id = 18;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 37;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 4;
            product = 3;
            productQuantity = 1;
            station = 25;
        }
    }
    public class CopperAxeRecipe : Recipe
    {
        public CopperAxeRecipe()
        {
            id = 19;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 34;
            requirementQuantities[0] = 6;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 4;
            productQuantity = 1;
            station = 25;
        }
    }
    public class IronAxeRecipe : Recipe
    {
        public IronAxeRecipe()
        {
            id = 20;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 35;
            requirementQuantities[0] = 6;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 5;
            productQuantity = 1;
            station = 25;
        }
    }
    public class SilverAxeRecipe : Recipe
    {
        public SilverAxeRecipe()
        {
            id = 21;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 36;
            requirementQuantities[0] = 6;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 6;
            productQuantity = 1;
            station = 25;
        }
    }
    public class GoldAxeRecipe : Recipe
    {
        public GoldAxeRecipe()
        {
            id = 22;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 37;
            requirementQuantities[0] = 6;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 7;
            productQuantity = 1;
            station = 25;
        }
    }
    public class CopperHammerRecipe : Recipe
    {
        public CopperHammerRecipe()
        {
            id = 23;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 34;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 24;
            productQuantity = 1;
            station = 25;
        }
    }
    public class IronHammerRecipe : Recipe
    {
        public IronHammerRecipe()
        {
            id = 24;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 35;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 25;
            productQuantity = 1;
            station = 25;
        }
    }
    public class SilverHammerRecipe : Recipe
    {
        public SilverHammerRecipe()
        {
            id = 25;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 36;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 26;
            productQuantity = 1;
            station = 25;
        }
    }
    public class GoldHammerRecipe : Recipe
    {
        public GoldHammerRecipe()
        {
            id = 26;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 37;
            requirementQuantities[0] = 8;
            requirements[1] = 16;
            requirementQuantities[1] = 3;
            product = 27;
            productQuantity = 1;
            station = 25;
        }
    }
    public class WoodenHammerRecipe : Recipe
    {
        public WoodenHammerRecipe()
        {
            id = 27;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 8;
            product = 23;
            productQuantity = 1;
            station = 23;
        }
    }
    public class WoodenBowRecipe : Recipe
    {
        public WoodenBowRecipe()
        {
            id = 28;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 8;
            product = 49;
            productQuantity = 1;
            station = 23;
        }
    }
    public class CopperBowRecipe : Recipe
    {
        public CopperBowRecipe()
        {
            id = 29;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 34;
            requirementQuantities[0] = 8;
            product = 50;
            productQuantity = 1;
            station = 25;
        }
    }
    public class IronBowRecipe : Recipe
    {
        public IronBowRecipe()
        {
            id = 30;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 35;
            requirementQuantities[0] = 8;
            product = 51;
            productQuantity = 1;
            station = 25;
        }
    }
    public class SilverBowRecipe : Recipe
    {
        public SilverBowRecipe()
        {
            id = 31;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 36;
            requirementQuantities[0] = 8;
            product = 52;
            productQuantity = 1;
            station = 25;
        }
    }
    public class GoldBowRecipe : Recipe
    {
        public GoldBowRecipe()
        {
            id = 32;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 37;
            requirementQuantities[0] = 8;
            product = 53;
            productQuantity = 1;
            station = 25;
        }
    }
    public class WoodenArrowRecipe : Recipe
    {
        public WoodenArrowRecipe()
        {
            id = 33;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 16;
            requirements[1] = 9;
            requirementQuantities[0] = 1;
            requirementQuantities[1] = 1;
            product = 54;
            productQuantity = 25;
            station = 23;
        }
    }
    public class FlamingArrowRecipe : Recipe
    {
        public FlamingArrowRecipe()
        {
            id = 34;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 54;
            requirements[1] = 15;
            requirementQuantities[0] = 10;
            requirementQuantities[1] = 1;
            product = 55;
            productQuantity = 10;
            station = 23;
        }
    }
    public class WoodenPlatformRecipe : Recipe
    {
        public WoodenPlatformRecipe()
        {
            id = 35;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 1;
            product = 58;
            productQuantity = 2;
            station = 255;
        }
    }
    public class SuspiciousLookingEyeRecipe : Recipe
    {
        public SuspiciousLookingEyeRecipe()
        {
            id = 36;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 59;
            requirementQuantities[0] = 6;
            product = 56;
            productQuantity = 1;
            station = 29;
        }
    }
    public class TableRecipe : Recipe
    {
        public TableRecipe()
        {
            id = 37;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 8;
            product = 76;
            productQuantity = 1;
            station = 23;
        }
    }
    public class ChairRecipe : Recipe
    {
        public ChairRecipe()
        {
            id = 38;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 16;
            requirementQuantities[0] = 6;
            product = 77;
            productQuantity = 1;
            station = 23;
        }
    }
    public class DemoniteBarRecipe : Recipe
    {
        public DemoniteBarRecipe()
        {
            id = 39;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 60;
            requirementQuantities[0] = 3;
            product = 61;
            productQuantity = 1;
            station = 24;
        }
    }
    public class LightsBaneRecipe : Recipe
    {
        public LightsBaneRecipe()
        {
            id = 40;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 10;
            product = 62;
            productQuantity = 1;
            station = 25;
        }
    }
    public class NightmarePickaxeRecipe : Recipe
    {
        public NightmarePickaxeRecipe()
        {
            id = 41;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 16;
            product = 63;
            productQuantity = 1;
            station = 25;
        }
    }
    public class WarAxeOfNightRecipe : Recipe
    {
        public WarAxeOfNightRecipe()
        {
            id = 42;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 12;
            product = 64;
            productQuantity = 1;
            station = 25;
        }
    }
    public class TheBreakerRecipe : Recipe
    {
        public TheBreakerRecipe()
        {
            id = 43;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 16;
            product = 65;
            productQuantity = 1;
            station = 25;
        }
    }
    public class DemonBowRecipe : Recipe
    {
        public DemonBowRecipe()
        {
            id = 44;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 16;
            product = 66;
            productQuantity = 1;
            station = 25;
        }
    }
    public class UnholyArrowRecipe : Recipe
    {
        public UnholyArrowRecipe()
        {
            id = 45;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 61;
            requirementQuantities[0] = 1;
            product = 67;
            productQuantity = 25;
            station = 25;
        }
    }
    public class FieryGreatSwordRecipe : Recipe
    {
        public FieryGreatSwordRecipe()
        {
            id = 46;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 10;
            product = 68;
            productQuantity = 1;
            station = 31;
        }
    }
    public class MoltenPickaxeRecipe : Recipe
    {
        public MoltenPickaxeRecipe()
        {
            id = 47;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 16;
            product = 69;
            productQuantity = 1;
            station = 31;
        }
    }
    public class MoltenAxeRecipe : Recipe
    {
        public MoltenAxeRecipe()
        {
            id = 48;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 12;
            product = 70;
            productQuantity = 1;
            station = 31;
        }
    }
    public class MoltenHammerRecipe : Recipe
    {
        public MoltenHammerRecipe()
        {
            id = 49;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 16;
            product = 71;
            productQuantity = 1;
            station = 31;
        }
    }
    public class MoltenBowRecipe : Recipe
    {
        public MoltenBowRecipe()
        {
            id = 50;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 16;
            product = 72;
            productQuantity = 1;
            station = 31;
        }
    }
    public class HellfireArrowRecipe : Recipe
    {
        public HellfireArrowRecipe()
        {
            id = 51;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 38;
            requirementQuantities[0] = 1;
            product = 73;
            productQuantity = 25;
            station = 31;
        }
    }
    public class ChestRecipe : Recipe
    {
        public ChestRecipe()
        {
            id = 52;
            requirements = new byte[2];
            requirementQuantities = new int[2];
            requirements[0] = 16;
            requirementQuantities[0] = 8;
            requirements[1] = 35;
            requirementQuantities[1] = 2;
            product = 75;
            productQuantity = 25;
            station = 23;
        }
    }
    public class WoodRecipe1 : Recipe
    {
        public WoodRecipe1()
        {
            id = 53;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 58;
            requirementQuantities[0] = 2;
            product = 16;
            productQuantity = 1;
            station = 23;
        }
    }
    public class WoodRecipe2 : Recipe
    {
        public WoodRecipe2()
        {
            id = 54;
            requirements = new byte[1];
            requirementQuantities = new int[1];
            requirements[0] = 22;
            requirementQuantities[0] = 4;
            product = 16;
            productQuantity = 1;
            station = 23;
        }
    }
}
