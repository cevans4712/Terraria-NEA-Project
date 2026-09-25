namespace TerrariaNEA
{
    public class FriendlyNPCs : NPC
    {
        //class contains all the data that friendly npcs possess
        protected byte friendlyID;
        protected byte moveTimer;
        protected byte nextMoveTime;
        protected int currentTargetX;
        protected byte delayTime;
        protected byte maxDelay;
        protected int npcHouse;
        protected bool waitingToSpawn;
        protected sbyte currentDirection;
        protected sbyte lastDirection;
        protected string[] normalDialogue;
        protected string[] successfulInteractionDialogue;
        protected string[] unsuccessfulInteractionDialogue;

        public byte FriendlyID
        {
            get { return friendlyID; }
            set { friendlyID = value; }
        }
        public bool WaitingToSpawn
        {
            get { return waitingToSpawn; }
            set { waitingToSpawn = value; }
        }
        public int NPCHouse
        {
            get { return npcHouse; }
            set { npcHouse = value; }
        }
        public sbyte CurrentDirection
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }
        public sbyte LastDirection
        {
            get { return lastDirection; }
            set { lastDirection = value; }
        }
        public byte MoveTimer
        {
            get { return moveTimer; }
            set { moveTimer = value; }
        }
        public byte NextMoveTime
        {
            get { return nextMoveTime; }
            set { nextMoveTime = value; }
        }
        public int CurrentTargetX
        {
            get { return currentTargetX; }
            set { currentTargetX = value; }
        }
        public string[] NormalDialogue
        {
            get { return normalDialogue; }
            set { normalDialogue = value; }
        }
        public string[] SuccessfulInteractionDialogue
        {
            get { return successfulInteractionDialogue; }
            set { successfulInteractionDialogue = value; }
        }
        public string[] UnsuccessfulInteractionDialogue
        {
            get { return unsuccessfulInteractionDialogue; }
            set { unsuccessfulInteractionDialogue = value; }
        }
        public void Spawn()
        {
            locationX = Game.validHouses[npcHouse][0] + 2;
            locationY = Game.validHouses[npcHouse][1] + 4;
        }//sets its location to inside its house
        public void MoveRight()
        {
            if(locationX != currentTargetX)
            {
                if (World.cellMap[locationX + 2, locationY - 2] || World.cellMap[locationX + 2, locationY - 3])
                {
                }
                else if(World.cellMap[locationX + 2, locationY - 1])
                {
                    if (World.cellMap[locationX, locationY - 4] || World.cellMap[locationX + 1, locationY - 4])
                    {
                    }
                    else
                    {
                        locationY--;
                        if (World.cellMap[locationX + 2, locationY - 1] || World.cellMap[locationX + 2, locationY - 2] || World.cellMap[locationX + 2, locationY - 3])
                        {
                        }
                        else
                        {
                            if (delayTime == maxDelay)
                            {
                                locationX++;
                                delayTime = 0;
                            }
                            else
                            {
                                delayTime++;
                            }
                        }
                    }
                }
                else
                {
                    if (delayTime == maxDelay)
                    {
                        locationX++;
                        delayTime = 0;
                    }
                    else
                    {
                        delayTime++;
                    }
                }
            }
        }//if npc can move right then move right
        public void MoveLeft()
        {
            if(locationX != currentTargetX)
            {
                if (World.cellMap[locationX - 1, locationY - 2] || World.cellMap[locationX - 1, locationY - 3])
                {
                }
                else if (World.cellMap[locationX - 1, locationY - 1])
                {
                    if (World.cellMap[locationX, locationY - 4] || World.cellMap[locationX + 1, locationY - 4])
                    {
                    }
                    else
                    {
                        locationY--;
                        if (World.cellMap[locationX - 1, locationY - 1] || World.cellMap[locationX - 1, locationY - 2] || World.cellMap[locationX - 1, locationY - 3])
                        {
                        }
                        else
                        {
                            if (delayTime == maxDelay)
                            {
                                locationX--;
                                delayTime = 0;
                            }
                            else
                            {
                                delayTime++;
                            }
                        }
                    }
                }
                else
                {
                    if (delayTime == maxDelay)
                    {
                        locationX--;
                        delayTime = 0;
                    }
                    else
                    {
                        delayTime++;
                    }
                }
            }
        }//if npc can move left then move left
        public void Fall()
        {
            if (World.cellMap[locationX, locationY] || World.cellMap[locationX + 1, locationY])
            {
            }
            else
            {
                locationY++;
            }
        }//if the npc is stood on no supporting blocks then fall

    }
    //below is all the different friendly npcs
    //each npcs dialogue is different based on the circumstances
    public class Guide : FriendlyNPCs
    {
        public Guide(int house)
        {
            friendlyID = 1;
            npcHouse = house;
            maxDelay = 3;
            nextMoveTime = (byte)Game.random.Next(50, 100);
            lastDirection = -1;
            normalDialogue = new string[] {"Greetings. Is there something I can help you with?",  "I am here to give you advice on what to do next.  It is\nrecommended that you talk with me anytime you get stuck.", "They say there is a person who will tell you how\nto survive in this land... oh wait. That's me.", "You should stay indoors at night. It is very\ndangerous to be wandering around in the dark."};
            successfulInteractionDialogue = new string[] {
                /*If no tools(0-5)*/"You can use your pickaxe to dig through dirt, and\nyour axe to chop down trees. Just place your\ncursor over the tile and click!", "If you want to survive, you will need to create\nweapons and shelter. Start by chopping down trees\nand gathering wood.", "Press Tab to access your crafting menu. When you have\nenough wood, create a workbench. This will allow you to\ncreate more complicated things, as long as you\nare standing close to it.", "You can build a shelter by placing wood or other\nblocks in the world. Don't forget to create and\nplace walls.", "Once you have a wooden sword, you might try to\ngather some gel from the slimes. Combine wood and\ngel to make a torch!", "To interact with backgrounds, use a hammer!",
                /*If no tools, ores or bars(6)*/ "You should do some mining to find metal ore. You\ncan craft very useful things with it.", 
                /*no tools but at least one bar(7-8)*/"You will need an anvil to make most things out of\nmetal bars.", "Anvils can be crafted out of iron or lead, or\npurchased from a merchant.", 
                /*players max health is 100(9)*/"Underground are crystal hearts which can be used to\nincrease your max life. You can smash them with a\npickaxe.",
                /*no npcs(10-12)*/ "There are many different ways you can attract people to\nmove in to our town. They will of course need a home\nto live in.", "In order for a room to be considered a home, it\nneeds to have a door, a chair, a table, and a\nlight source.  Make sure the house has walls as\nwell.", "Two people will not live in the same home. Also,\nif their home is destroyed, they will look for a\nnew place to live.",
                /*no merchant(13)*/ "If you want a merchant to move in, you will need to\ngather plenty of money. 50 silver coins should do the\ntrick!",
                /*no nurse(14)*/ "For a nurse to move in, you might want to increase your\nmaximum life.",
                /*nothing else to do(15)*/"There is nothing left for me to guide you towards\non your journey!",
            };
        }
    }
    public class Merchant : FriendlyNPCs
    {
        public Merchant(int house)
        {
            friendlyID = 2;
            npcHouse = house;
            maxDelay = 3;
            nextMoveTime = (byte)Game.random.Next(50, 100);
            lastDirection = -1;
            normalDialogue = new string[] { "Sword beats paper! Get one today.", "You want apples? You want carrots? You want\npineapples? We got carrots.", "Check out my dirt blocks; they are extra dirty.", "The sun is high, but my prices are not.", "You have no idea how much dirt blocks sell for\noverseas.", "Ah, they will tell tales of you some day... good\nones I'm sure.", "Kosh, kaplek Mog. Oh sorry, that's klingon for 'Buy\nsomething or die.'", "The last guy who was here left me some junk... er\nI mean... treasures!", "I wonder if the moon is made of cheese...huh, what?\nOh yes, buy something!", "Did you say gold? I'll take that off of ya.", "I hear there's a secret treasure... oh never mind." };
        }
    }
    public class Nurse : FriendlyNPCs
    {
        public Nurse(int house)
        {
            friendlyID = 3;
            npcHouse = house;
            maxDelay = 3;
            nextMoveTime = (byte)Game.random.Next(50, 100);
            lastDirection = -1;
            normalDialogue = new string[] { "Show me where it hurts.", "Would you like a lollipop?", "That's not the biggest I've ever seen... Yes, I've\nseen bigger wounds for sure.", "Turn your head and cough." };
            successfulInteractionDialogue = new string[] { "That didn't hurt too bad, now did it?", "All better. I don't want to see you jumping off\nanymore cliffs.", "That's probably going to leave a scar.", "I managed to sew your face back on. Be more careful\nnext time." };
            unsuccessfulInteractionDialogue = new string[] { "I'm sorry, but you can't afford me.", "I'm gonna need more gold than that.", "I don't work for free you know." };
        }
    }
}
