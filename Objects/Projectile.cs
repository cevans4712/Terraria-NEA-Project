namespace TerrariaNEA
{
    public class Projectile
    {
        //contains all the data of each projectile currently flying
        protected bool friendly;//is the projectile shot from the player
        protected int damage;//how much damage the projectile does
        protected byte type;//what type of projectile
        protected int power;//magnitude of initial velocity
        protected float velocityX;
        protected float velocityY;
        protected float locationX;
        protected float locationY;
        protected int blockLocationX;
        protected int blockLocationY;
        protected double angle;
        public bool Friendly
        {
            get { return friendly; }
            set { friendly = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        } 
        public byte Type
        {
            get { return type; }
            set { type = value; }
        }
        public float VelocityX
        {
            get { return velocityX; }
            set { velocityX = value; }
        }
        public float VelocityY
        {
            get { return velocityY; }
            set { velocityY = value; }
        }
        public float LocationX
        {
            get { return locationX; }
            set { locationX = value; }
        }
        public float LocationY
        {
            get { return locationY; }
            set { locationY = value; }
        }
        public int BlockLocationX
        {
            get { return blockLocationX; }
            set { blockLocationX = value; }
        }
        public int BlockLocationY
        {
            get { return blockLocationY; }
            set { blockLocationY = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }
    }
    public class Arrow : Projectile
    {
        //this class relates to the movement of arrows
        public void Move()
        {
            velocityY += 10;
            // Maximum distance the arrow can move in one tick (based on velocity)
            float remainingDistanceX = velocityX;
            float remainingDistanceY = velocityY;
            int steps = (int)Math.Max(Math.Abs(remainingDistanceX), Math.Abs(remainingDistanceY));

            // Subdivide the movement into 'steps'
            for (int i = 0; i <= steps; i++)
            {
                // Calculate the incremental movement
                float stepX = remainingDistanceX / steps;
                float stepY = remainingDistanceY / steps;

                // Update position incrementally
                locationX += stepX;
                locationY += stepY;

                // Check for collisions at the current position
                CheckHitDuringMovement((int)locationX / 20, (int)LocationY / 20);
            }

            // After movement, check if the arrow is out of bounds
            if (locationX < 0 || locationX >= World.worldWidth * 20 || locationY < 0 || locationY >= World.worldHeight * 20)
            {
                Despawn();
            }
            else
            {
                // Update the new location on the grid
                int newLocationX = (int)locationX / 20;
                int newLocationY = (int)locationY / 20;
                blockLocationX = newLocationX;
                blockLocationY = newLocationY;
                UpdateAngle();
            }
        }//decreases the y velocity each tick to simulate a parabolic path. location is then changed based on x and y velocity. location is changed in steps to make sure arrow doesnt travel through walls or npcs inbetween ticks
        public void CheckHitDuringMovement(int x, int y)
        {
            if(x >= 0 && y - 2 >= 0 && x < World.worldWidth && y - 2 < World.worldHeight)
            {
                if (World.cellMap[x, y - 2])
                {
                    Despawn();
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (Game.slimes[i] != null)
                        {
                            Game.slimes[i].IsHitByProjectile(x, y);
                        }
                        if (Game.zombies[i] != null)
                        {
                            Game.zombies[i].IsHitByProjectile(x, y);
                        }
                        if (Game.flyingEnemies[i] != null)
                        {
                            Game.flyingEnemies[i].IsHitByProjectile(x, y);
                        }
                    }
                    if(Game.eyeOfCthulhu != null)
                    {
                        Game.eyeOfCthulhu.IsHitByProjectile(x, y);
                    }
                }
            }
            else
            {
                Despawn();
            }
        }//checks if arrow hit an npc during movement or collided with a block
        public void UpdateAngle()
        {
            if (velocityX == 0)
            {
                if (velocityY < 0)
                {
                    angle = -Math.PI / 2;
                }
                else
                {
                    angle = Math.PI / 2;
                }
            }
            else
            {
                if (velocityY == 0)
                {
                    if (velocityX < 0)
                    {
                        angle = Math.PI;
                    }
                    else
                    {
                        angle = 0;
                    }
                }
                else
                {
                    angle = Math.Atan((float)velocityY / (float)velocityX);
                    if (velocityX < 0 && velocityY < 0)
                    {
                        angle = -(Math.PI - angle);
                    }
                    if (velocityX < 0 && velocityY > 0)
                    {
                        angle = Math.PI + angle;
                    }
                }
            }
        }//updates the visible angle based on x and y velocity
        public void Despawn()
        {
            for(int i = 0; i < 100; i++)
            {
                if (Game.arrows[i] == this)
                {
                    Game.arrows[i] = null;
                }
            }
        }//remove itself from the array
    }
    //below is each type of arrow. with different power(affects initial velocity) and damage
    public class WoodenArrow : Arrow
    {
        public WoodenArrow()
        {
            friendly = true;
            type = 1;//arrow
            power = 100;
            damage = 4;
        }
    }
    public class FlamingArrow : Arrow
    {
        public FlamingArrow()
        {
            friendly = true;
            type = 1;//arrow
            power = 100;
            damage = 6;
        }
    }
    public class UnholyArrow : Arrow
    {
        public UnholyArrow()
        {
            friendly = true;
            type = 1;//arrow
            power = 125;
            damage = 12;
        }
    }
    public class HellfireArrow : Arrow
    {
        public HellfireArrow()
        {
            friendly = true;
            type = 1;//arrow
            power = 140;
            damage = 15;
        }
    }
}
