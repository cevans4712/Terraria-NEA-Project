namespace TerrariaNEA
{
    public class Player
    {
        //contains all the data relating to the player
        public static int health;
        public static int maxHealth;
        public static int breath;
        public static int defence;
        public static short fallDuration;
        public static int playerX = 2500;
        public static int playerY = 90;
        public static int spawnX = 2500;
        public static int spawnY;
        public static int playerLocationX;
        public static int playerLocationY;
        public static int playerOnScreenX = 800;
        public static int playerOnScreenY = 420;
        public static bool movingLeft = false;
        public static bool movingRight = false;
        public static bool jumping = false;
        public static int jumpTime = 0;
        public static bool building = false;
        public static bool buildingWall = false;
        public static bool breaking = false;
        public static bool breakingWall = false;
        public static byte animationi = 0;
        public static byte animationj = 0;
        public static bool movedRight;
        public static bool movedLeft;
        public static bool movedDown;
        public static bool movedUp;
        public static byte immunity;
        public static int currentPickaxePower = 0;
        public static int currentAxePower = 0;
        public static int currentHammerPower = 0;
        public static int currentDamage = 0;
        public static bool slowWalking = false;
        public static void takeDamage(int damage)
        {
            health -= damage;
            immunity = 5;
            if(health < 0)
            {
                health = 0;
                playerDeath();
            }
        }//reduces the players health and gives them 5 frames of immunity
        public static void playerDeath()
        {
            Game.eyeOfCthulhu = null;
            int originalSpawnY = spawnY;
            playerOnScreenX = 800;
            playerOnScreenY = 420;
            while (!spaceToSpawn())
            {
                if(spawnY > 24)
                {
                    spawnY--;
                }
                else
                {
                    spawnY = originalSpawnY;
                    break;
                }
            }
            playerX = spawnX;
            playerY = spawnY;
            playerLocationX = spawnX;
            playerLocationY = spawnY;
            health = maxHealth;
            immunity = 10;
        }//upon player death: respawn them at their spawn point, set their health back to full and despawn any bosses
        public static bool spaceToSpawn()
        {
            for(int i = 0; i < 2; i++)
            {
                for(int j = 1; j < 4; j++)
                {
                    if (World.cellMap[spawnX + i, spawnY + j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }//check there is space for the player to spawn
        public static void Attack(byte damage)
        {
            for(int i = -3; i < 4; i++)
            {
                for (int j = -6; j < 2; j++)
                {
                    int x = playerLocationX + i;
                    int y = playerLocationY + j;
                    for (int k = 0; k < 20; k++)
                    {
                        if (Game.slimes[k] != null)
                        {
                            if (Game.slimes[k].LocationX == x && Game.slimes[k].LocationY == y)
                            {
                                if (Game.slimes[k].Immunity == 0)
                                {
                                    Game.slimes[k].Health -= damage;
                                    if (Game.slimes[k].Health <= 0)
                                    {
                                        Game.slimes[k].Die();
                                    }
                                    else
                                    {
                                        Game.slimes[k].TargetPlayer();
                                        Game.slimes[k].DirectionX *= -1;
                                        Game.slimes[k].Jump();
                                        Game.slimes[k].Immunity = 5;
                                    }
                                }
                            }
                        }
                        if (Game.zombies[k] != null)
                        {
                            if (Game.zombies[k].LocationX == x && Game.zombies[k].LocationY == y)
                            {
                                if (Game.zombies[k].Immunity == 0)
                                {
                                    Game.zombies[k].Health -= damage;
                                    if (Game.zombies[k].Health <= 0)
                                    {
                                        Game.zombies[k].Die();
                                    }
                                    else
                                    {
                                        Game.zombies[k].TargetPlayer();
                                        Game.zombies[k].DirectionX *= -1;
                                        Game.zombies[k].Jump();
                                        Game.zombies[k].Immunity = 5;
                                    }
                                }
                            }
                        }
                        if (Game.flyingEnemies[k] != null)
                        {
                            if (Game.flyingEnemies[k].LocationX == x && Game.flyingEnemies[k].LocationY == y)
                            {
                                if (Game.flyingEnemies[k].Immunity == 0)
                                {
                                    Game.flyingEnemies[k].Health -= damage;
                                    if (Game.flyingEnemies[k].Health <= 0)
                                    {
                                        Game.flyingEnemies[k].Die();
                                    }
                                    else
                                    {
                                        Game.flyingEnemies[k].VelocityX *= -1;
                                        Game.flyingEnemies[k].VelocityY *= -1;
                                        Game.flyingEnemies[k].Immunity = 5;
                                    }
                                }
                            }
                        }
                    }
                    if (Game.eyeOfCthulhu != null)
                    {
                        for(int i2 = 0; i2 <= 11; i2++)
                        {
                            for(int j2 = -1; j2 <= 10; j2++)
                            {
                                if (Game.eyeOfCthulhu.LocationX == x && Game.eyeOfCthulhu.LocationY == y)
                                {
                                    if (Game.eyeOfCthulhu.Immunity == 0)
                                    {
                                        Game.eyeOfCthulhu.Health -= damage;
                                        if (Game.eyeOfCthulhu.Health <= 0)
                                        {
                                            Game.eyeOfCthulhu.Die();
                                        }
                                        else
                                        {
                                            Game.eyeOfCthulhu.Immunity = 5;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }//when the player uses an item that deals damage all npcs in the surrounding area take that damage
        public static void ShootArrow()
        {
            for(int i = 0; i < 40; i++)
            {
                if (IsArrow(i))
                {
                    byte arrow = Inventory.inventory[i];
                    ProjectileManager.createArrow(arrow);
                    Inventory.inventoryQuantity[i]--;
                    if(Inventory.inventoryQuantity[i] == 0)
                    {
                        Inventory.inventory[i] = 255;
                    }
                    break;
                }
            }
        }//if the player uses a bow go through the inventory until an arrow is found and then shoot it as a projectile. if no arrow is found nothing happens
        public static bool IsArrow(int index)
        {
            if (Inventory.inventory[index] == 54 || Inventory.inventory[index] == 55 || Inventory.inventory[index] == 67 || Inventory.inventory[index] == 73)
            {
                return true;
            }
            return false;
        }//checks if the item being looked at is an arrow
    }
}
