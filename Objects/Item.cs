namespace TerrariaNEA
{
    public class Item
    {
        //this class contains all the data about each item
        protected string name = "";
        protected byte id = 255;
        protected byte pickaxePower = 0;
        protected byte axePower = 0;
        protected byte hammerPower = 0;
        protected byte damage = 0;
        protected byte buildable = 0;
        protected bool hasHitbox = false;
        protected float critChance = 0;
        protected int stack = 1;
        protected byte buildableWall = 0;
        protected byte effect = 0;
        protected int sellValue = 0;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public byte ID
        {
            get { return id; }
            set { id = value; }
        }
        public byte PickaxePower
        {
            get { return pickaxePower; }
            set { pickaxePower = value; }
        }
        public byte AxePower
        {
            get { return axePower; }
            set { axePower = value; }
        }
        public byte HammerPower
        {
            get { return hammerPower; }
            set { hammerPower = value; }
        }
        public byte Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public byte Buildable
        {
            get { return buildable; }
            set { buildable = value; }
        }
        public bool HasHitbox
        {
            get { return hasHitbox; }
            set { hasHitbox = value; }
        }
        public float CritChance
        {
            get { return critChance; }
            set { critChance = value; }
        }
        public int Stack
        {
            get { return stack; }
            set { stack = value; }
        }
        public byte BuildableWall
        {
            get { return buildableWall; }
            set { buildableWall = value; }
        }
        public byte Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        public int SellValue
        {
            get { return sellValue; }
            set { sellValue = value; }
        }
    }
    //below is where each new item is created and assigned its values
    public class CopperPickaxe : Item
    {
        public CopperPickaxe()
        {
            name = "Copper Pickaxe";
            id = 0;
            pickaxePower = 4;
            damage = 2;
            sellValue = 100;
        }
    }
    public class IronPickaxe : Item
    {
        public IronPickaxe()
        {
            name = "Iron Pickaxe";
            id = 1;
            pickaxePower = 6;
            damage = 3;
            critChance = 0.02f;
            sellValue = 200;
        }
    }
    public class SilverPickaxe : Item
    {
        public SilverPickaxe()
        {
            name = "Silver Pickaxe";
            id = 2;
            pickaxePower = 8;
            damage = 4;
            critChance = 0.04f;
            sellValue = 300;
        }
    }
    public class GoldPickaxe : Item
    {
        public GoldPickaxe()
        {
            name = "Gold Pickaxe";
            id = 3;
            pickaxePower = 10;
            axePower = 0;
            damage = 5;
            critChance = 0.06f;
            sellValue = 400;
        }
    }
    public class CopperAxe : Item
    {
        public CopperAxe()
        {
            name = "Copper Axe";
            id = 4;
            pickaxePower = 0;
            axePower = 4;
            damage = 3;
            sellValue = 100;
        }
    }
    public class IronAxe : Item
    {
        public IronAxe()
        {
            name = "Iron Axe";
            id = 5;
            axePower = 6;
            damage = 5;
            critChance = 0.02f;
            sellValue = 200;
        }
    }
    public class SilverAxe : Item
    {
        public SilverAxe()
        {
            name = "Silver Axe";
            id = 6;
            axePower = 8;
            damage = 7;
            critChance = 0.04f;
            sellValue = 300;
        }
    }
    public class GoldAxe : Item
    {
        public GoldAxe()
        {
            name = "Gold Axe";
            id = 7;
            axePower = 10;
            damage = 9;
            critChance = 0.06f;
            sellValue = 400;
        }
    }
    public class Dirt : Item
    {
        public Dirt()
        {
            name = "Dirt";
            id = 8;
            buildable = 1;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Stone : Item
    {
        public Stone()
        {
            name = "Stone";
            id = 9;
            buildable = 2;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class WoodSword : Item
    {
        public WoodSword()
        {
            name = "Wooden Sword";
            id = 10;
            damage = 6;
            critChance = 0.04f;
            sellValue = 50;
        }
    }
    public class CopperSword : Item
    {
        public CopperSword()
        {
            name = "Copper Sword";
            id = 11;
            damage = 5;
            critChance = 0.02f;
            sellValue = 100;
        }
    }
    public class IronSword : Item
    {
        public IronSword()
        {
            name = "Iron Sword";
            id = 12;
            damage = 8;
            critChance = 0.06f;
            sellValue = 200;
        }
    }
    public class SilverSword : Item
    {
        public SilverSword()
        {
            name = "Silver Sword";
            id = 13;
            damage = 10;
            critChance = 0.08f;
            sellValue = 300;
        }
    }
    public class GoldSword : Item
    {
        public GoldSword()
        {
            name = "Gold Sword";
            id = 14;
            damage = 12;
            critChance = 0.1f;
            sellValue = 400;
        }
    }
    public class Torch : Item
    {
        public Torch()
        {
            name = "Torch";
            id = 15;
            buildable = 16;
            stack = 9999;
            sellValue = 10;
        }
    }
    public class Wood : Item
    {
        public Wood()
        {
            name = "Wood";
            id = 16;
            buildable = 19;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class CopperCoin : Item
    {
        public CopperCoin()
        {
            name = "Copper Coin";
            id = 17;
            stack = 100;
        }
    }
    public class SilverCoin : Item
    {
        public SilverCoin()
        {
            name = "Silver Coin";
            id = 18;
            stack = 100;
        }
    }
    public class GoldCoin : Item
    {
        public GoldCoin()
        {
            name = "Gold Coin";
            id = 19;
            stack = 100;
        }
    }
    public class PlatinumCoin : Item
    {
        public PlatinumCoin()
        {
            name = "Platinum Coin";
            id = 20;
            stack = 9999;
        }
    }
    public class Gel : Item
    {
        public Gel()
        {
            name = "Gel";
            id = 21;
            stack = 9999;
            sellValue = 1;
        }
    }
    public class WoodWall : Item
    {
        public WoodWall()
        {
            name = "Wood Wall";
            id = 22;
            stack = 9999;
            buildableWall = 2;
        }
    }
    public class WoodenHammer : Item
    {
        public WoodenHammer()
        {
            name = "Wooden Hammer";
            id = 23;
            hammerPower = 3;
            damage = 2;
            sellValue = 50;
        }
    }
    public class CopperHammer : Item
    {
        public CopperHammer()
        {
            name = "Copper Hammer";
            id = 24;
            hammerPower = 4;
            damage = 3;
            sellValue = 100;
        }
    }
    public class IronHammer : Item
    {
        public IronHammer()
        {
            name = "Iron Hammer";
            id = 25;
            hammerPower = 6;
            damage = 4;
            sellValue = 200;
        }
    }
    public class SilverHammer : Item
    {
        public SilverHammer()
        {
            name = "Silver Hammer";
            id = 26;
            hammerPower = 8;
            damage = 6;
            sellValue = 300;
        }
    }
    public class GoldHammer : Item
    {
        public GoldHammer()
        {
            name = "Gold Hammer";
            id = 27;
            hammerPower = 10;
            damage = 8;
            sellValue = 400;
        }
    }
    public class CopperOre : Item
    {
        public CopperOre()
        {
            name = "Copper Ore";
            id = 28;
            buildable = 4;
            hasHitbox = true;
            stack = 9999;
            sellValue = 10;
        }
    }
    public class IronOre : Item
    {
        public IronOre()
        {
            name = "Iron Ore";
            id = 29;
            buildable = 5;
            hasHitbox = true;
            stack = 9999;
            sellValue = 20;
        }
    }
    public class SilverOre : Item
    {
        public SilverOre()
        {
            name = "Silver Ore";
            id = 30;
            buildable = 6;
            hasHitbox = true;
            stack = 9999;
            sellValue = 30;
        }
    }
    public class GoldOre : Item
    {
        public GoldOre()
        {
            name = "Gold Ore";
            id = 31;
            buildable = 7;
            hasHitbox = true;
            stack = 9999;
            sellValue = 40;
        }
    }
    public class HellstoneOre : Item
    {
        public HellstoneOre()
        {
            name = "Hellstone Ore";
            id = 32;
            buildable = 8;
            hasHitbox = true;
            stack = 9999;
            sellValue = 100;
        }
    }
    public class Acorn : Item
    {
        public Acorn()
        {
            name = "Acorn";
            id = 33;
            buildable = 22;
            stack = 9999;
        }
    }
    public class CopperBar : Item
    {
        public CopperBar()
        {
            name = "Copper Bar";
            id = 34;
            stack = 9999;
            sellValue = 50;
        }
    }
    public class IronBar : Item
    {
        public IronBar()
        {
            name = "Iron Bar";
            id = 35;
            stack = 9999;
            sellValue = 100;
        }
    }
    public class SilverBar : Item
    {
        public SilverBar()
        {
            name = "Silver Bar";
            id = 36;
            stack = 9999;
            sellValue = 150;
        }
    }
    public class GoldBar : Item
    {
        public GoldBar()
        {
            name = "Gold Bar";
            id = 37;
            stack = 9999;
            sellValue = 200;
        }
    }
    public class HellstoneBar : Item
    {
        public HellstoneBar()
        {
            name = "Hellstone Bar";
            id = 38;
            stack = 9999;
            sellValue = 500;
        }
    }
    public class WorkBench : Item
    {
        public WorkBench()
        {
            name = "Workbench";
            id = 39;
            buildable = 23;
            stack = 9999;
        }
    }
    public class Furnace : Item
    {
        public Furnace()
        {
            name = "Furnace";
            id = 40;
            buildable = 24;
            stack = 9999;
            sellValue = 100;
        }
    }
    public class Anvil : Item
    {
        public Anvil()
        {
            name = "Anvil";
            id = 41;
            buildable = 25;
            stack = 9999;
            sellValue = 1000;
        }
    }
    public class Mud : Item
    {
        public Mud()
        {
            name = "Mud";
            id = 42;
            buildable = 21;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Sand : Item
    {
        public Sand()
        {
            name = "Sand";
            id = 43;
            buildable = 17;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Snow : Item
    {
        public Snow()
        {
            name = "Snow";
            id = 44;
            buildable = 11;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Ice : Item
    {
        public Ice()
        {
            name = "Ice";
            id = 45;
            buildable = 12;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Ebonstone : Item
    {
        public Ebonstone()
        {
            name = "Ebonstone";
            id = 46;
            buildable = 13;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Ash : Item
    {
        public Ash()
        {
            name = "Ash";
            id = 47;
            buildable = 3;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Sandstone : Item
    {
        public Sandstone()
        {
            name = "Sandstone";
            id = 48;
            buildable = 18;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class WoodenBow : Item
    {
        public WoodenBow()
        {
            name = "Wooden Bow";
            id = 49;
            damage = 8;
            critChance = 0.04f;
            sellValue = 50;
        }
    }
    public class CopperBow : Item
    {
        public CopperBow()
        {
            name = "Copper Bow";
            id = 50;
            damage = 10;
            critChance = 0.06f;
            sellValue = 100;
        }
    }
    public class IronBow : Item
    {
        public IronBow()
        {
            name = "Iron Bow";
            id = 51;
            damage = 12;
            critChance = 0.08f;
            sellValue = 200;
        }
    }
    public class SilverBow : Item
    {
        public SilverBow()
        {
            name = "Silver Bow";
            id = 52;
            damage = 14;
            critChance = 0.10f;
            sellValue = 300;
        }
    }
    public class GoldBow : Item
    {
        public GoldBow()
        {
            name = "Gold Bow";
            id = 53;
            damage = 16;
            critChance = 0.12f;
            sellValue = 400;
        }
    }
    public class WoodenArrowItem : Item
    {
        public WoodenArrowItem()
        {
            name = "Wooden Arrow";
            id = 54;
            stack = 9999;
            sellValue = 1;
        }
    }
    public class FlamingArrowItem : Item
    {
        public FlamingArrowItem()
        {
            name = "Flaming Arrow";
            id = 55;
            stack = 9999;
            sellValue = 5;
        }
    }
    public class SuspiciousLookingEye : Item
    {
        public SuspiciousLookingEye()
        {
            name = "Suspicious Looking Eye";
            id = 56;
            stack = 9999;
            effect = 1;
        }
    }
    public class LifeCrystal : Item
    {
        public LifeCrystal()
        {
            name = "Life Crystal";
            id = 57;
            stack = 9999;
            effect = 2;
            buildable = 26;
            sellValue = 5000;
        }
    }
    public class WoodenPlatform : Item
    {
        public WoodenPlatform()
        {
            name = "Wooden Platform";
            id = 58;
            buildable = 28;
            hasHitbox = true;
            stack = 9999;
        }
    }
    public class Lens : Item
    {
        public Lens()
        {
            name = "Lens";
            id = 59;
            stack = 9999;
            sellValue = 100;
        }
    }
    public class DemoniteOre : Item
    {
        public DemoniteOre()
        {
            name = "Demonite Ore";
            id = 60;
            buildable = 30;
            hasHitbox = true;
            stack = 9999;
            sellValue = 70;
        }
    }
    public class DemoniteBar : Item
    {
        public DemoniteBar()
        {
            name = "Demonite Bar";
            id = 61;
            stack = 9999;
            sellValue = 350;
        }
    }
    public class LightsBane : Item
    {
        public LightsBane()
        {
            name = "Lights Bane";
            id = 62;
            damage = 20;
            critChance = 0.1f;
            sellValue = 700;
        }
    }
    public class NightmarePickaxe : Item
    {
        public NightmarePickaxe()
        {
            name = "Nightmare Pickaxe";
            id = 63;
            pickaxePower = 15;
            damage = 10;
            critChance = 0.08f;
            sellValue = 700;
        }
    }
    public class WarAxeOfNight : Item
    {
        public WarAxeOfNight()
        {
            name = "War Axe Of Night";
            id = 64;
            axePower = 15;
            damage = 15;
            critChance = 0.08f;
            sellValue = 700;
        }
    }
    public class TheBreaker : Item
    {
        public TheBreaker()
        {
            name = "The Breaker";
            id = 65;
            hammerPower = 15;
            damage = 10;
            critChance = 0.08f;
            sellValue = 700;
        }
    }
    public class DemonBow : Item
    {
        public DemonBow()
        {
            name = "Demon Bow";
            id = 66;
            damage = 22;
            critChance = 0.15f;
            sellValue = 700;
        }
    }
    public class UnholyArrowItem : Item
    {
        public UnholyArrowItem()
        {
            name = "Unholy Arrow";
            id = 67;
            stack = 9999;
            sellValue = 100;

        }
    }
    public class FieryGreatSword : Item
    {
        public FieryGreatSword()
        {
            name = "Fiery Great Sword";
            id = 68;
            damage = 30;
            critChance = 0.15f;
            sellValue = 1000;
        }
    }
    public class MoltenPickaxe : Item
    {
        public MoltenPickaxe()
        {
            name = "Molten Pickaxe";
            id = 69;
            pickaxePower = 22;
            damage = 15;
            critChance = 0.08f;
            sellValue = 1000;
        }
    }
    public class MoltenAxe : Item
    {
        public MoltenAxe()
        {
            name = "Molten Axe";
            id = 70;
            axePower = 22;
            damage = 15;
            critChance = 0.08f;
            sellValue = 1000;
        }
    }
    public class MoltenHammer : Item
    {
        public MoltenHammer()
        {
            name = "Molten Hammer";
            id = 71;
            hammerPower = 22;
            damage = 15;
            critChance = 0.08f;
            sellValue = 1000;
        }
    }
    public class MoltenBow : Item
    {
        public MoltenBow()
        {
            name = "Molten Bow";
            id = 72;
            damage = 30;
            critChance = 0.15f;
            sellValue = 1000;
        }
    }
    public class HellfireArrowItem : Item
    {
        public HellfireArrowItem()
        {
            name = "Hellfire Arrow";
            id = 73;
            stack = 9999;
            sellValue = 200;
        }
    }
    public class HellForge : Item
    {
        public HellForge()
        {
            name = "Hell Forge";
            id = 74;
            buildable = 31;
            stack = 9999;
            sellValue = 1000;
        }
    }
    public class ChestItem : Item
    {
        public ChestItem()
        {
            name = "Chest";
            id = 75;
            buildable = 10;
            stack = 9999;
        }
    }
    public class Table : Item
    {
        public Table()
        {
            name = "Table";
            id = 76;
            buildable = 32;
            stack = 9999;
        }
    }
    public class Chair : Item
    {
        public Chair()
        {
            name = "Chair";
            id = 77;
            buildable = 33;
            stack = 9999;
        }
    }
}
//add recipes for all new items
