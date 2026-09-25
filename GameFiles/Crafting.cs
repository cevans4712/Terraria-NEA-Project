namespace TerrariaNEA
{
    public class Crafting
    {
        public static void checkVisibleRecipes()
        {
            byte[] visibleRecipes = new byte[255];
            for (int i = 0; i < visibleRecipes.Length; i++)
            {
                visibleRecipes[i] = 255;
            }
            byte recipesCount = 0;
            for(int i = 0; i < Game.recipes.Length; i++)
            {
                if (Game.recipes[i] == null)
                {
                    break;
                }
                bool visible = false;
                for (int j = 0; j < 40; j++)
                {
                    if (Game.recipes[i].Requirements.Contains(Inventory.inventory[j]))
                    {
                        visible = true;
                        break;
                    }
                }
                if (!checkStationInRange(i))
                {
                    visible = false;
                }
                if (visible)
                {
                    for (int l = 0; l < visibleRecipes.Length; l++)
                    {
                        if (visibleRecipes[l] == 255)
                        {
                            visibleRecipes[l] = (byte)i;
                            recipesCount++;
                            break;
                        }
                    }
                }
            }
            Game.visibleRecipesCount = recipesCount;
            for(int i = 0; i < visibleRecipes.Length; i++)
            {
                Game.visibleRecipes[i] = visibleRecipes[i];
            }
        }//checks if the player has an item that is in a recipe and is at the required crafting station
        public static void checkCraftableRecipes()
        {
            byte[] craftableRecipes = new byte[255];
            for(int i = 0; i < craftableRecipes.Length; i++)
            {
                craftableRecipes[i] = 255;
            }
            byte recipesCount = 0;
            for (int i = 0; i < Game.recipes.Length; i++)
            {
                if (Game.recipes[i] == null)
                {
                    break;
                }
                bool craftable = true;
                for (int j = 0; j < Game.recipes[i].Requirements.Length; j++)
                {
                    for(int k = 0; k < 40; k++)
                    {
                        if (Game.recipes[i].Requirements[j] == Inventory.inventory[k] && Game.recipes[i].RequirementQuantities[j] <= Inventory.inventoryQuantity[k])
                        {
                            break;
                        }
                        if(k == 39)
                        {
                            craftable = false;
                        }
                    }
                    if (!checkStationInRange(i))
                    {
                        craftable = false;
                    }
                    if(!craftable)
                    {
                        break;
                    }
                }
                if (craftable)
                {
                    for(int l = 0; l < craftableRecipes.Length; l++)
                    {
                        if (craftableRecipes[l] == 255)
                        {
                            craftableRecipes[l] = (byte)i;
                            recipesCount++;
                            break;
                        }
                    }
                }
            }
            Game.craftableRecipesCount = recipesCount;
            for(int i = 0; i < craftableRecipes.Length; i++)
            {
                Game.craftableRecipes[i] = craftableRecipes[i];
            }
        }//checks if the player has all items required to craft and is at the required crafting station
        public static bool checkStationInRange(int recipe)
        {
            byte station = Game.recipes[recipe].Station;
            if(station == 255)
            {
                return true;
            }
            else
            {
                for(int i = -6; i <= 6; i++)
                {
                    for (int j = -6; j <= 6; j++)
                    {
                        int x = Player.playerLocationX + i;
                        int y = Player.playerLocationY + j;
                        if (x >= 0 && x < World.worldWidth && y >= 0 && y < World.worldHeight)
                        {
                            if (World.blockMap[x, y] == station)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }//checks if the player is in range of the required station
        public static void attemptCraft(Point cursor)
        {
            int cursorX = cursor.X;
            int cursorY = cursor.Y;
            int selectionX = cursorX / 60;
            int selectionY = cursorY / 60;
            int selection = 5 * selectionX + selectionY;
            if (Game.craftableRecipesCount > selection)
            {
                craft(Game.craftableRecipes[selection]);
            }
        }//when the player clicks on the crafting menu check if there is a valid recipe and then craft it
        public static void craft(int selection)//removes the crafting requirements from the inventory and then drops the product
        {
            for (int i = 0; i < Game.recipes[selection].Requirements.Length; i++)
            {
                for(int j = 0; j < 40; j++)
                {
                    if (Inventory.inventory[j] == Game.recipes[selection].Requirements[i] && Inventory.inventoryQuantity[j] >= Game.recipes[selection].RequirementQuantities[i])
                    {
                        Inventory.inventoryQuantity[j] -= Game.recipes[selection].RequirementQuantities[i];
                        if (Inventory.inventoryQuantity[j] == 0)
                        {
                            Inventory.inventory[j] = 255;
                        }
                        break;
                    }
                }
            }
            DroppedItemBehaviour.dropItem(Game.recipes[selection].Product, Game.recipes[selection].ProductQuantity, Player.playerLocationX + 40, Player.playerLocationY + 23);
        }
    }
}