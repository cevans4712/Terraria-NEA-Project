namespace TerrariaNEA
{
    public class EyeOfCthulhu : NPC
    {
        //class contains all the data to do with the eye of cthulhu boss fight that other npcs dont require
        protected byte mode;
        protected int targetX;
        protected int targetY;
        protected int timer;
        protected int nextDash;
        protected sbyte positionAbovePlayer;
        protected sbyte direction;
        protected int realLocationX;
        protected int realLocationY;
        protected bool dashing = false;
        protected bool despawning = false;
        protected sbyte modeChangeTimer;
        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int NextDash
        {
            get { return nextDash; }
            set { nextDash = value; }
        }
        public byte Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        public sbyte ModeChangeTimer
        {
            get { return modeChangeTimer; }
            set { modeChangeTimer = value; }
        }
        public bool Despawning
        {
            get { return despawning; }
            set { despawning = value; }
        }
        public EyeOfCthulhu()
        {
            id = 11;
            name = "Eye of Cthulhu";
            totalHealth = 2000;
            health = 2000;
            sizeX = 120;
            sizeY = 120;
            damage = 12;
            mode = 1;
            timer = 30;
            positionAbovePlayer = -10;
            direction = 1;
            nextDash = Game.random.Next(100, 150);
        }
        public void Spawn()
        {
            // location set to -1, -1 so the while loop starts
            locationX = -1;
            locationY = -1;
            while(locationX < 0 || locationX >= World.worldWidth || locationY < 0 || locationY >= World.worldHeight)
            {
                int spawnPosition = Game.random.Next(4);
                switch (spawnPosition)
                {
                    case 0:
                        locationX = Player.playerX - 50;
                        locationY = Player.playerY - 31;
                        break;
                    case 1:
                        locationX = Player.playerX + 50;
                        locationY = Player.playerY - 31;
                        break;
                    case 2:
                        locationX = Player.playerX - 50;
                        locationY = Player.playerY + 31;
                        break;
                    case 3:
                        locationX = Player.playerX + 50;
                        locationY = Player.playerY + 31;
                        break;
                }
            }
            realLocationX = locationX * 20;
            realLocationY = locationY * 20;
        }//spawn the boss in a random place around the player and checks its in the world
        public void Die()
        {
            DropItems();
            Despawn();
        }//upon defeat drop items and despawn
        public void Despawn()
        {
            Game.eyeOfCthulhu = null;
        }//if daytime or out of range of player despawn
        public void TargetAbovePlayer()
        {
            targetX = (Player.playerLocationX - 6) * 20;
            for (int i = 0; i <= 10; i++)
            {
                int targetYtemp = Player.playerLocationY - 20 + i;
                if(targetYtemp >= 0)
                {
                    targetY = 20 * targetYtemp;
                    break;
                }
            }
            positionAbovePlayer += direction;
            if(positionAbovePlayer > 10 || positionAbovePlayer < -10)
            {
                direction *= -1;
            }
            targetX += positionAbovePlayer * 20;
        }//when idle target above the player and wait until next attack
        public void TargetDash()
        {
            int distanceXToPlayer = Player.playerLocationX - locationX - 6;
            int distanceYToPlayer = Player.playerLocationY - locationY;
            targetX = 20 * (locationX + (3 * distanceXToPlayer));
            targetY = 20 * (locationY + (3 * distanceYToPlayer));
        }//when dashing target behind the player from current location
        public void SpawnServant()
        {
            NPCBehavior.spawnNPC(13, locationX + 6, locationY + 3);
        }//spawns a servant of cthulhu
        public void TargetOffScreen()
        {
            targetX = 20 * locationX;
            targetY = 20 * (locationY - 40);
        }//when despawning due to day leave the screen
        public void Move()
        {
            int distanceToGoX = targetX - realLocationX;
            int distanceToGoY = targetY - realLocationY;
            if (!dashing)
            {
                realLocationX += distanceToGoX / 10;
                realLocationY += distanceToGoY / 10;
            }
            else
            {
                realLocationX += distanceToGoX / 6;
                realLocationY += distanceToGoY / 6;
            }
            locationX = realLocationX / 20;
            locationY = realLocationY / 20;
        }//accelarate towards the target location
        public void DespawnRitual()
        {
            despawning = true;
        }//initialise the despawning process once day
        public void ModeChangeRitual()
        {
            modeChangeTimer = 24;
            mode = 2;
            damage = 25;
        }//initialises the mode change process once half health
        public void QueryHitPlayer()
        {
            for (int px = 0; px <= 1; px++)
            {
                for (int py = -1; py <= 1; py++)
                {
                    for (int ex = 0; ex <= 11; ex++)
                    {
                        for (int ey = -1; ey <= 10; ey++)
                        {
                            if (px + Player.playerLocationX == ex + locationX && py + Player.playerLocationY == ey + locationY && Player.immunity == 0)
                            {
                                HitPlayer();
                                break;
                            }
                        }
                    }
                }
            }
        }//checks if player has been hit
        public void HitPlayer()
        {
            Player.takeDamage(damage);
        }//damages the player
        public void IsHitByProjectile()
        {
            if (immunity == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Game.arrows[i] != null)
                    {
                        bool hit = false;
                        for (int x = 0; x <= 11; x++)
                        {
                            if (hit)
                            {
                                break;
                            }
                            for (int y = -1; y <= 10; y++)
                            {
                                if (hit)
                                {
                                    break;
                                }
                                if (Game.arrows[i].BlockLocationX == locationX + x && Game.arrows[i].BlockLocationY == locationY + y)
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
        public void IsHitByProjectile(int x, int y)
        {
            if (immunity == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Game.arrows[i] != null)
                    {
                        bool hit = false;
                        for (int zx = 0; zx <= 11; zx++)
                        {
                            if (hit)
                            {
                                break;
                            }
                            for (int zy = -1; zy <= 10; zy++)
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
    }
}
