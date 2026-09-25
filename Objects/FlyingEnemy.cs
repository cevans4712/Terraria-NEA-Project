namespace TerrariaNEA
{
    public class FlyingEnemy : NPC
    {
        //class contains all the data to do with the flying enemy type that other npcs dont require
        protected int speedInverse;
        protected int velocityX;
        protected int velocityY;
        protected float realLocationX;
        protected float realLocationY;
        protected int maxVelocity;
        public int SpeedInverse
        {
            get { return speedInverse; }
            set { speedInverse = value; }
        }
        public int VelocityX
        {
            get { return velocityX; }
            set { velocityX = value; }
        }
        public int VelocityY
        {
            get { return velocityY; }
            set { velocityY = value; }
        }
        public int MaxVelocity
        {
            get { return maxVelocity; }
            set { maxVelocity = value; }
        }
        public float RealLocationX
        {
            get { return realLocationX; }
            set { realLocationX = value; }
        }
        public float RealLocationY
        {
            get { return realLocationY; }
            set { realLocationY = value; }
        }
        public void Spawn()
        {
            for(int i = 0; i < 20; i++)
            {
                if (Game.flyingEnemies[i] == null)
                {
                    Game.flyingEnemies[i] = this;
                    break;
                }
            }
        }//add itself to the array
        public void Despawn()
        {
            for(int i = 0; i < 20; i++)
            {
                if (Game.flyingEnemies[i] == this)
                {
                    Game.flyingEnemies[i] = null;
                }
            }
        }//removes itself from the array
        public void Die()
        {
            DropItems();
            Despawn();
        }//drops items and despawns upon death
        public void Move()
        {
            int distanceXToPlayer = Player.playerLocationX * 20 - (int)realLocationX;
            int distanceYToPlayer = Player.playerLocationY * 20 - (int)realLocationY;
            velocityX += distanceXToPlayer / speedInverse;
            velocityY += distanceYToPlayer / speedInverse;
            if(velocityX > maxVelocity)
            {
                velocityX = maxVelocity;
            }
            if(velocityY > maxVelocity)
            {
                velocityY = maxVelocity;
            }
            // Maximum distance the npc can move in one tick (based on velocity)
            float remainingDistanceX = velocityX;
            float remainingDistanceY = velocityY;

            int steps = (int)Math.Max(Math.Abs(remainingDistanceX), Math.Abs(remainingDistanceY));

            // Subdivide the movement into steps
            if(steps != 0)
            {
                for (int i = 0; i <= steps; i++)
                {
                    // Calculate the incremental movement
                    float stepX = remainingDistanceX / steps;
                    float stepY = remainingDistanceY / steps;

                    // Update position incrementally
                    realLocationX += stepX;
                    realLocationY += stepY;

                    // Check for collisions at the current location
                    bool[] collisions = CheckCollision((int)realLocationX / 20, (int)realLocationY / 20);
                    bool collided = false;
                    //collisions = [up, right, down, left]
                    if (collisions[0])
                    {
                        velocityY = Math.Abs(velocityY) + 10;
                        collided = true;
                    }
                    if (collisions[1])
                    {
                        velocityX = -Math.Abs(velocityX) - 10;
                        collided = true;
                    }
                    if (collisions[2])
                    {
                        velocityY = -Math.Abs(velocityY) - 10;
                        collided = true;
                    }
                    if (collisions[3])
                    {
                        velocityX = Math.Abs(velocityX) + 10;
                        collided = true;
                    }
                    if (collided)
                    {
                        break;
                    }
                }
            }

            // After movement, check if the npc is out of bounds
            if (realLocationX < 0 || realLocationX >= World.worldWidth * 20 || realLocationY < 0 || realLocationY >= World.worldHeight * 20)
            {
                Despawn();
            }
            else
            {
                // Update the new location on the grid
                int newLocationX = (int)realLocationX / 20;
                int newLocationY = (int)realLocationY / 20;
                locationX = newLocationX;
                locationY = newLocationY;
            }
        }//accelarates towards the current target
        public bool[] CheckCollision(int x, int y)
        {
            bool[] collisions = new bool[4];//up, right, down, left
            try
            {
                if(World.cellMap[x + 1, y - 4] || World.cellMap[x, y - 4])//check collision above
                {
                    if(velocityY < 0)
                    {
                        collisions[0] = true;
                    }
                }
                if(World.cellMap[x + 2, y - 3] || World.cellMap[x + 2, y - 2])//check collision to the right
                {
                    if (velocityX > 0)
                    {
                        collisions[1] = true;
                    }
                }
                if (World.cellMap[x + 1, y - 1] || World.cellMap[x, y - 1])//check collision below
                {
                    if (velocityY > 0)
                    {
                        collisions[2] = true;
                    }
                }
                if (World.cellMap[x - 1, y - 3] || World.cellMap[x - 1, y - 2])//check collision to the left
                {
                    if (velocityX < 0)
                    {
                        collisions[3] = true;
                    }
                }
                //corners
                if (velocityX > 0)//travelling right
                {
                    if (velocityY > 0)//travelling down
                    {
                        if (World.cellMap[x + 2, y - 1])
                        {
                            collisions[1] = true;
                            collisions[2] = true;
                        }
                    }
                    else//travelling up
                    {
                        if (World.cellMap[x + 2, y - 4])
                        {
                            collisions[0] = true;
                            collisions[1] = true;
                        }
                    }
                }
                else//travelling left
                {
                    if (velocityY > 0)//travelling down
                    {
                        if (World.cellMap[x - 1, y - 1])
                        {
                            collisions[2] = true;
                            collisions[3] = true;
                        }
                    }
                    else//travelling up
                    {
                        if (World.cellMap[x - 1, y - 4])
                        {
                            collisions[3] = true;
                            collisions[0] = true;
                        }
                    }
                }
            }
            catch { }
            return collisions;
        }//checks for a collision with a block
        public void QueryHitPlayer()
        {
            for (int playerX = 0; playerX <= 1; playerX++)
            {
                for (int playerY = -1; playerY <= 1; playerY++)
                {
                    for (int enemyX = 0; enemyX <= 1; enemyX++)
                    {
                        for (int enemyY = -1; enemyY <= 0; enemyY++)
                        {
                            if (playerX + Player.playerLocationX == enemyX + locationX && playerY + Player.playerLocationY == enemyY + locationY && Player.immunity == 0)
                            {
                                HitPlayer();
                                break;
                            }
                        }
                    }
                }
            }
        }//checks if hit player
        public void HitPlayer()
        {
            Player.takeDamage(damage);
            velocityX = (int)(velocityX * -0.8);
            velocityY = (int)(velocityY * -0.8);
        }//damages player
        public void IsHitByProjectile(int x, int y)
        {
            if (immunity == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Game.arrows[i] != null)
                    {
                        bool hit = false;
                        for (int ex = 0; ex <= 1; ex++)
                        {
                            if (hit)
                            {
                                break;
                            }
                            for (int ey = -1; ey <= 0; ey++)
                            {
                                if (hit)
                                {
                                    break;
                                }
                                if (x == locationX + ex && y == locationY + ey)
                                {
                                    hit = true;
                                    immunity = 5;
                                    health -= Game.arrows[i].Damage;
                                    Game.arrows[i].Despawn();
                                    if (health <= 0)
                                    {
                                        Die();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }//checks if hit by a projectile
    }
    //below is all different npcs that are all controlled by the flying enemy ai
    public class DemonEye : FlyingEnemy
    {
        public DemonEye()
        {
            id = 12;
            name = "Demon Eye";
            totalHealth = 60;
            health = 60;
            sizeX = 2;
            sizeY = 2;
            damage = 15;
            speedInverse = 50;
            maxVelocity = 20;
        }
    }
    public class ServantOfCthulhu : FlyingEnemy
    {
        public ServantOfCthulhu()
        {
            id = 13;
            name = "Servant of Cthulhu";
            totalHealth = 5;
            health = 5;
            sizeX = 2;
            sizeY = 2;
            damage = 1;
            speedInverse = 50;
            maxVelocity = 20;
        }
    }
}
