namespace TerrariaNEA
{
    public class Slime : NPC
    {
        //class contains all the data to do with the slime type that other npcs dont require
        protected int directionX = 0;
        protected int jumpTime = 0;
        protected int landTime = 0;
        protected int jumpDelay = 0;
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
        public int LandTime
        {
            get { return landTime; }
            set { landTime = value; }
        }
        public int JumpDelay
        {
            get { return jumpDelay; }
            set { jumpDelay = value; }
        }
        public void Spawn()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.slimes[i] == null)
                {
                    Game.slimes[i] = this;
                    Game.slimes[i].jumpDelay = Game.random.Next(15, 25);
                    break;
                }
            }
        }//adds itself to the array
        public void Despawn()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.slimes[i] == this)
                {
                    Game.slimes[i] = null;
                    break;
                }
            }
        }//removes iself from the array
        public void Die()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Game.slimes[i] == this)
                {
                    DropItems();
                    Game.slimes[i] = null;
                }
            }
        }//drops items and despawns upon death
        public void Fall()
        {
            if (locationY - 1 < World.worldWidth)
            {
                if (!World.cellMap[locationX, locationY - 1] && !World.cellMap[locationX + 1, locationY - 1])
                {
                    locationY++;
                    if (directionX < 0)
                    {
                        if (locationX - 1 >= 0)
                        {
                            if (!World.cellMap[locationX - 1, locationY - 3] && !World.cellMap[locationX - 1, locationY - 2])
                            {
                                locationX--;
                            }
                        }
                    }
                    else
                    {
                        if (locationX + 2 < World.worldWidth)
                        {
                            if (!World.cellMap[locationX + 2, locationY - 3] && !World.cellMap[locationX + 2, locationY - 2])
                            {
                                locationX++;
                            }
                        }
                    }
                }
            }
        }//fall if there is no block beneath
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
        }//changes direction depending on if the player is to the left or right
        public void Jump()
        {
            if (locationY - 4 >= 0)
            {
                if (!World.cellMap[locationX, locationY - 4] && !World.cellMap[locationX + 1, locationY - 4])
                {
                    locationY--;
                }
            }
            if (directionX < 0)
            {
                if (locationX - 1 >= 0)
                {
                    if (!World.cellMap[locationX - 1, locationY - 3] && !World.cellMap[locationX - 1, locationY - 2])
                    {
                        locationX--;
                    }
                }
            }
            else
            {
                if (locationX + 2 < World.worldWidth)
                {
                    if (!World.cellMap[locationX + 2, locationY - 3] && !World.cellMap[locationX + 2, locationY - 2])
                    {
                        locationX++;
                    }
                }
            }
            jumpTime++;
        }//if can jump, jump towards player
        public void QueryHitPlayer()
        {
            for (int px = 0; px <= 1; px++)
            {
                for (int py = -1; py <= 1; py++)
                {
                    for (int sx = 0; sx <= 1; sx++)
                    {
                        for (int sy = -1; sy <= 0; sy++)
                        {
                            if (px + Player.playerLocationX == sx + locationX && py + Player.playerLocationY == sy + locationY && Player.immunity == 0)
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
                        for (int sx = 0; sx <= 1; sx++)
                        {
                            if (hit)
                            {
                                break;
                            }
                            for (int sy = -1; sy <= 0; sy++)
                            {
                                if (hit)
                                {
                                    break;
                                }
                                if (x == locationX + sx && y == locationY + sy)
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
            Jump();
        }//damages player
    }
    //below is all different npcs that are all controlled by the slime ai
    public class GreenSlime : Slime
    {
        public GreenSlime()
        {
            id = 1;
            name = "Green Slime";
            totalHealth = 14;
            health = 14;
            sizeX = 2;
            sizeY = 2;
            damage = 6;
        }
    }
    public class BlueSlime : Slime
    {
        public BlueSlime()
        {
            id = 2;
            name = "Blue Slime";
            totalHealth = 25;
            health = 25;
            sizeX = 2;
            sizeY = 2;
            damage = 7;
        }
    }
    public class PurpleSlime : Slime
    {
        public PurpleSlime()
        {
            id = 3;
            name = "Purple Slime";
            totalHealth = 40;
            health = 40;
            sizeX = 2;
            sizeY = 2;
            damage = 12;
        }
    }
    public class SandSlime : Slime
    {
        public SandSlime()
        {
            id = 4;
            name = "Sand Slime";
            totalHealth = 50;
            health = 50;
            sizeX = 2;
            sizeY = 2;
            damage = 15;
        }
    }
    public class IceSlime : Slime
    {
        public IceSlime()
        {
            id = 5;
            name = "Ice Slime";
            totalHealth = 30;
            health = 30;
            sizeX = 2;
            sizeY = 2;
            damage = 8;
        }
    }
    public class JungleSlime : Slime
    {
        public JungleSlime()
        {
            id = 6;
            name = "Jungle Slime";
            totalHealth = 60;
            health = 60;
            sizeX = 2;
            sizeY = 2;
            damage = 18;
        }
    }

}
