namespace TerrariaNEA
{
    public class Fighter : NPC
    {
        //class contains all the data to do with the fighter type that other npcs dont require
        protected int directionX;
        protected int jumpTime;
        protected int delayTime;
        protected bool isJumping;
        protected int maxDelay;
        public int JumpTime
        {
            get { return jumpTime; }
            set { jumpTime = value; }
        }
        public int DirectionX
        {
            get { return directionX; }
            set { directionX = value; }
        }
        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }
        public int MaxDelay
        {
            get { return maxDelay; }
            set { maxDelay = value; }
        }
        public bool IsJumping
        {
            get { return isJumping; }
            set { isJumping = value; }
        }
        public void Spawn()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.zombies[i] == null)
                {
                    Game.zombies[i] = this;
                    break;
                }
            }
        }//adds itself to the array
        public void Despawn()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.zombies[i] == this)
                {
                    Game.zombies[i] = null;
                    break;
                }
            }
        }//removes itself from the array
        public void Die()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.zombies[i] == this)
                {
                    DropItems();
                    Game.zombies[i] = null;
                }
            }
        }//upon death drop items and despawn
        public void TargetPlayer()
        {
            if (Player.playerLocationX < locationX)
            {
                directionX = -1;
            }
            else
            {
                directionX = 1;
            }
        }//targets the players x coordinate
        public void Move()
        {
            if (directionX < 0)
            {
                if (locationX - 1 >= 0)
                {
                    if (!World.cellMap[locationX - 1, locationY - 3] && !World.cellMap[locationX - 1, locationY - 2] && !World.cellMap[locationX - 1, locationY - 1])
                    {
                        locationX--;
                    }
                    else
                    {
                        if (World.cellMap[locationX, locationY] || World.cellMap[locationX + 1, locationY])
                        {
                            isJumping = true;
                        }
                    }
                }
            }
            else
            {
                if (locationX + 2 < World.worldWidth)
                {
                    if (!World.cellMap[locationX + 2, locationY - 3] && !World.cellMap[locationX + 2, locationY - 2] && !World.cellMap[locationX + 2, locationY - 1])
                    {
                        locationX++;
                    }
                    else
                    {
                        if (World.cellMap[locationX, locationY] || World.cellMap[locationX + 1, locationY])
                        {
                            isJumping = true;
                        }
                    }
                }
            }
        }//moves towards its target
        public void Jump()
        {
            if (locationY - 4 >= 0)
            {
                if (!World.cellMap[locationX, locationY - 4] && !World.cellMap[locationX + 1, locationY - 4])
                {
                    locationY--;
                    jumpTime++;
                }
                else
                {
                    isJumping = false;
                    jumpTime = 0;
                }
            }
        }//if gets stuck attempt to jump out
        public void Fall()
        {
            if (locationY < World.worldWidth)
            {
                if (!World.cellMap[locationX, locationY] && !World.cellMap[locationX + 1, locationY])
                {
                    locationY++;
                }
            }
        }//if there are no blocks beneath fall
        public void QueryHitPlayer()
        {
            for (int px = 0; px <= 1; px++)
            {
                for (int py = -1; py <= 1; py++)
                {
                    for (int zx = 0; zx <= 1; zx++)
                    {
                        for (int zy = -1; zy <= 1; zy++)
                        {
                            if (px + Player.playerLocationX == zx + locationX && py + Player.playerLocationY == zy + locationY && Player.immunity == 0)
                            {
                                HitPlayer();
                                break;
                            }
                        }
                    }
                }
            }
        }//checks if hit player
        public void IsHitByProjectile(int x, int y)
        {
            if (immunity == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Game.arrows[i] != null)
                    {
                        bool hit = false;
                        for (int zx = 0; zx <= 1; zx++)
                        {
                            if (hit)
                            {
                                break;
                            }
                            for (int zy = -1; zy <= 1; zy++)
                            {
                                if (hit)
                                {
                                    break;
                                }
                                if (x == locationX + zx && y == locationY + zy)
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
        }//checks if was hit by a projectile
        public void HitPlayer()
        {
            Player.takeDamage(damage);
            directionX *= -1;
            isJumping = true;
            jumpTime = 3;
        }//damages player
    }
    //below is all different npcs that are all controlled by the fighter ai
    public class Zombie : Fighter
    {
        public Zombie()
        {
            id = 7;
            name = "Zombie";
            totalHealth = 45;
            health = 45;
            sizeX = 2;
            sizeY = 3;
            damage = 15;
            maxDelay = 2;
        }
    }
    public class Mummy : Fighter
    {
        public Mummy()
        {
            id = 8;
            name = "Mummy";
            totalHealth = 55;
            health = 55;
            sizeX = 2;
            sizeY = 3;
            damage = 16;
            maxDelay = 2;
        }
    }
    public class Eskimo : Fighter
    {
        public Eskimo()
        {
            id = 9;
            name = "Eskimo";
            totalHealth = 40;
            health = 40;
            sizeX = 2;
            sizeY = 3;
            damage = 12;
            maxDelay = 2;
        }
    }
    public class Skeleton : Fighter
    {
        public Skeleton()
        {
            id = 10;
            name = "Skeleton";
            totalHealth = 65;
            health = 65;
            sizeX = 2;
            sizeY = 3;
            damage = 18;
            maxDelay = 1;
        }
    }

}
