namespace TerrariaNEA
{
    public class NPCBehavior
    {
        public static void spawnInSurface(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {
                if (spawnChance < 0.003)
                {
                    spawnNPC(1);//spawn Green Slime
                }
                else if (spawnChance < 0.0045)
                {
                    spawnNPC(2);//spawn Blue Slime
                }
                else if (spawnChance < 0.005 && Math.Abs(Player.playerLocationX - Player.spawnX) > 300)
                {
                    spawnNPC(3);//spawn Purple Slime
                }
            }
            else//night
            {
                if (spawnChance < 0.01)
                {
                    spawnNPC(7);//spawn Zombie
                }
                else if (spawnChance < 0.015)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }
        }//spawns npcs in the surface biome
        public static void spawnInDesert(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {
                if (spawnChance < 0.003)
                {
                    spawnNPC(4);//spawn Sand Slime
                }
                else if (spawnChance < 0.006)
                {
                    spawnNPC(8);//spawn Mummy
                }
            }
            else//night
            {
                if (spawnChance < 0.003)
                {
                    spawnNPC(8);//spawn Mummy
                }
                else if (spawnChance < 0.013)
                {
                    spawnNPC(7);//spawn Zombie
                }
                else if (spawnChance < 0.018)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }

        }//spawns npcs in the desert biome
        public static void spawnInIce(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {
                if (spawnChance < 0.005)
                {
                    spawnNPC(5);//spawn Ice Slime
                }
            }
            else//night
            {
                if (spawnChance < 0.01)
                {
                    spawnNPC(9);//spawn Eskimo
                }
                else if (spawnChance < 0.015)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }
        }//spawns npcs in the ice biome
        public static void spawnInCorruption(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {

            }
            else//night
            {
                if (spawnChance < 0.01)
                {
                    spawnNPC(7);//spawn Zombie
                }
                else if (spawnChance < 0.015)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }
        }//spawns npcs in the corruption biome
        public static void spawnInJungle(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {
                if (spawnChance < 0.005)
                {
                    spawnNPC(6);//spawn Jungle Slime
                }
            }
            else//night
            {
                if (spawnChance < 0.01)
                {
                    spawnNPC(7);//spawn Zombie
                }
                else if (spawnChance < 0.015)
                {
                    spawnNPC(6);//spawn Jungle Slime
                }
                else if (spawnChance < 0.02)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }
        }//spawns npcs in the jungle biome
        public static void spawnInMushroom(double spawnChance)
        {
            if (spawnChance < 0.003)
            {
                spawnNPC(10);//spawn Skeleton
            }
        }//spawns npcs in the mushroom biome
        public static void spawnInOcean(double spawnChance)
        {
            if (World.timeOfDay >= 480 && World.timeOfDay <= 1140)//day
            {
            }
            else//night
            {
                if (spawnChance < 0.01)
                {
                    spawnNPC(7);//spawn Jungle Slime
                }
                else if (spawnChance < 0.015)
                {
                    spawnNPC(12);//spawn Demon Eye
                }
            }
        }//spawns npcs in the ocean biome
        public static void spawnInUnderWorld(double spawnChance)
        {

        }//spawns npcs in the underworld biome
        public static void spawnInCaverns(double spawnChance)
        {
            if (spawnChance < 0.005)
            {
                spawnNPC(10);//spawn Skeleton
            }
        }//spawns npcs in the caverns biome
        public static void chanceToSpawnNPC()
        {
            double spawnChance = Game.random.NextDouble();
            if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 0)//surface
            {
                spawnInSurface(spawnChance);

            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 1)//desert
            {
                spawnInDesert(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 2)//ice
            {
                spawnInIce(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 3)//corruption
            {
                spawnInCorruption(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 4)//jungle
            {
                spawnInJungle(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 5)//mushroom
            {
                spawnInMushroom(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 6)//ocean
            {
                spawnInOcean(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 7)//underworld
            {
                spawnInUnderWorld(spawnChance);
            }
            else if (World.biomeMap[Player.playerLocationX, Player.playerLocationY] == 8)//caverns
            {
                spawnInCaverns(spawnChance);
            }
        }//spawns npcs randomly based on the players current biome
        public static void spawnNPC(byte npcID, int x, int y)
        {
            //Slime slime;
            //Fighter zombie;
            FlyingEnemy flyingEnemy;
            switch (npcID)
            {
                case 13:
                    flyingEnemy = new ServantOfCthulhu();
                    flyingEnemy.LocationX = x;
                    flyingEnemy.LocationY = y;
                    flyingEnemy.RealLocationX = x * 20;
                    flyingEnemy.RealLocationY = y * 20;
                    flyingEnemy.Spawn();
                    break;
            }
        }//spawns an npc in a certain position due to an occurence
        public static void spawnNPC(byte npcID)
        {
            Slime slime;
            Fighter zombie;
            FlyingEnemy flyingEnemy;
            int[] spawnXY;
            switch (npcID)
            {
                case 1://green slime
                    slime = new GreenSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 2://blue slime
                    slime = new BlueSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 3://purple slime
                    slime = new PurpleSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 4://sand slime
                    slime = new SandSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 5://ice slime
                    slime = new IceSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 6://jungle slime
                    slime = new JungleSlime();
                    spawnXY = spawnLocation(slime.SizeX, slime.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        slime.LocationX = spawnXY[0];
                        slime.LocationY = spawnXY[1];
                        slime.Spawn();
                    }
                    break;
                case 7://zombie
                    zombie = new Zombie();
                    spawnXY = spawnLocation(zombie.SizeX, zombie.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        zombie.LocationX = spawnXY[0];
                        zombie.LocationY = spawnXY[1];
                        zombie.Spawn();
                    }
                    break;
                case 8://mummy
                    zombie = new Mummy();
                    spawnXY = spawnLocation(zombie.SizeX, zombie.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        zombie.LocationX = spawnXY[0];
                        zombie.LocationY = spawnXY[1];
                        zombie.Spawn();
                    }
                    break;
                case 9://eskimo
                    zombie = new Eskimo();
                    spawnXY = spawnLocation(zombie.SizeX, zombie.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        zombie.LocationX = spawnXY[0];
                        zombie.LocationY = spawnXY[1];
                        zombie.Spawn();
                    }
                    break;
                case 10://skeleton
                    zombie = new Skeleton();
                    spawnXY = spawnLocation(zombie.SizeX, zombie.SizeY, true);
                    if (spawnXY[0] != -1)
                    {
                        zombie.LocationX = spawnXY[0];
                        zombie.LocationY = spawnXY[1];
                        zombie.Spawn();
                    }
                    break;
                case 11://eye of clthulu
                    Game.eyeOfCthulhu = new EyeOfCthulhu();
                    Game.eyeOfCthulhu.Spawn();
                    break;
                case 12://demon eye
                    flyingEnemy = new DemonEye();
                    spawnXY = spawnLocation(flyingEnemy.SizeX, flyingEnemy.SizeY, false);
                    if (spawnXY[0] != -1)
                    {
                        flyingEnemy.LocationX = spawnXY[0];
                        flyingEnemy.LocationY = spawnXY[1];
                        flyingEnemy.RealLocationX = flyingEnemy.LocationX * 20;
                        flyingEnemy.RealLocationY = flyingEnemy.LocationY * 20;
                        flyingEnemy.Spawn();
                    }
                    break;
                case 13://servant of cthulhu
                    flyingEnemy = new ServantOfCthulhu();
                    spawnXY = spawnLocation(flyingEnemy.SizeX, flyingEnemy.SizeY, false);
                    if (spawnXY[0] != -1)
                    {
                        flyingEnemy.LocationX = spawnXY[0];
                        flyingEnemy.LocationY = spawnXY[1];
                        flyingEnemy.RealLocationX = flyingEnemy.LocationX * 20;
                        flyingEnemy.RealLocationY = flyingEnemy.LocationX * 20;
                        flyingEnemy.Spawn();
                    }
                    break;
            }
        }//spawns an npc through random chance
        public static int[] spawnLocation(int sizeX, int sizeY, bool needsToSpawnOnGround)
        {
            int[] spawnXY = new int[2];
            int spawnSide = Game.random.Next(0, 2);
            if (spawnSide == 0)
            {
                for(int x = Player.playerX - 50; x < Player.playerX - 40; x++)
                {
                    for (int y = Player.playerY - 33; y < Player.playerY + 33; y++)
                    {
                        if (canSpawn(x, y, sizeX, sizeY, needsToSpawnOnGround))
                        {
                            spawnXY[0] = x;
                            spawnXY[1] = y;
                            return spawnXY;
                        }
                    }
                }
            }
            else
            {
                for (int x = Player.playerX + 41; x < Player.playerX + 51; x++)
                {
                    for (int y = Player.playerY - 33; y < Player.playerY + 33; y++)
                    {
                        if (canSpawn(x, y, sizeX, sizeY, needsToSpawnOnGround))
                        {
                            spawnXY[0] = x;
                            spawnXY[1] = y;
                            return spawnXY;
                        }
                    }
                }
            }
            spawnXY[0] = -1;
            spawnXY[1] = -1;
            return spawnXY;
        }//sets the spawn location of the npc
        public static bool canSpawn(int x, int y, int sizeX, int sizeY, bool needsToSpwanOnGround)
        {
            //check if space to spawn
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = -3; j < sizeY - 3; j++)
                {
                    if (i + x >= World.worldWidth || i + x < 0 || j + y < 0 || j + y >= World.worldHeight)
                    {
                        return false;
                    }
                    else if (World.cellMap[x + i, y + j])
                    {
                        return false;
                    }
                }
            }
            //check if on floor
            if (needsToSpwanOnGround)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    int ny = y + sizeY - 3;
                    if (i + x >= World.worldWidth || i + x < 0 || ny < 0 || ny >= World.worldHeight)
                    {
                        return false;
                    }
                    else if (!World.cellMap[x + i, ny])
                    {
                        return false;
                    }
                }
            }
            return true;
        }//checks the npc can spawn
        public static Slime controlSlime(Slime slime)
        {
            if (Math.Abs(slime.LocationX - Player.playerLocationX) > 60 || Math.Abs(slime.LocationY - Player.playerLocationY) > 60)
            {
                slime.Despawn();
            }
            else if (slime.JumpTime != 6 && slime.LandTime > slime.JumpDelay)
            {
                slime.Jump();
            }
            else if (World.cellMap[slime.LocationX, slime.LocationY - 1] || World.cellMap[slime.LocationX + 1, slime.LocationY - 1])
            {
                slime.LandTime++;
                slime.TargetPlayer();
            }
            else
            {
                slime.Fall();
            }
            if (slime != null)
            {
                if (slime.JumpTime == 6)
                {
                    slime.JumpTime = 0;
                    slime.LandTime = 0;
                }
                slime.QueryHitPlayer();
            }
            return slime;
        }//contols the behaviour of each slime
        public static Fighter controlZombie(Fighter zombie)
        {
            if (Math.Abs(zombie.LocationX - Player.playerLocationX) > 60 || Math.Abs(zombie.LocationY - Player.playerLocationY) > 60)
            {
                zombie.Despawn();
            }
            else if (World.cellMap[zombie.LocationX, zombie.LocationY] || World.cellMap[zombie.LocationX + 1, zombie.LocationY])
            {
                zombie.TargetPlayer();
            }
            if (zombie != null)
            {
                //decide if should jump
                if (Math.Abs(zombie.LocationX - Player.playerLocationX) < 3)
                {
                    if (Player.playerLocationY < zombie.LocationY && (World.cellMap[zombie.LocationX, zombie.LocationY] || World.cellMap[zombie.LocationX + 1, zombie.LocationY]))
                    {
                        zombie.IsJumping = true;
                    }
                }
                //moving left or right
                if (zombie.DelayTime == zombie.MaxDelay)
                {
                    zombie.Move();
                    zombie.DelayTime = 0;
                }
                else
                {
                    zombie.DelayTime++;
                }
                //jump or fall
                if (zombie.IsJumping)
                {
                    zombie.Jump();
                }
                else
                {
                    zombie.Fall();
                }
                //if jumped 6 blocks stop
                if (zombie.JumpTime == 6)
                {
                    zombie.IsJumping = false;
                    zombie.JumpTime = 0;
                }
                //check if touching player
                zombie.QueryHitPlayer();
            }
            return zombie;
        }//controls the behaviour of each fighter
        public static FlyingEnemy controlFlyingEnemy(FlyingEnemy flyingEnemy)
        {
            if (Math.Abs(flyingEnemy.LocationX - Player.playerLocationX) > 60 || Math.Abs(flyingEnemy.LocationY - Player.playerLocationY) > 60)
            {
                flyingEnemy.Despawn();
            }
            else
            {
                flyingEnemy.Move();
                flyingEnemy.QueryHitPlayer();
            }
            return flyingEnemy;
        }//controls the behaviour of each flying enemy
        public static EyeOfCthulhu controlEyeOfCthulhu(EyeOfCthulhu boss)
        {
            if (World.timeOfDay == 480)
            {
                boss.DespawnRitual();
            }
            if (!boss.Despawning)
            {
                if (boss.Mode == 1)
                {
                    if (boss.Health <= 1000)
                    {
                        boss.ModeChangeRitual();
                    }
                }
                if (boss.ModeChangeTimer > 0)
                {
                    boss.ModeChangeTimer--;
                }
                else
                {
                    if (boss.Timer != boss.NextDash && boss.Timer >= 0)
                    {
                        boss.TargetAbovePlayer();
                        if (boss.Timer >= 5 && boss.Timer <= 25)
                        {
                            if (boss.Timer % 5 == 0)
                            {
                                boss.SpawnServant();
                            }
                        }
                    }
                    else
                    {
                        if (boss.Timer >= 0)
                        {
                            boss.TargetDash();
                            boss.Timer = -30;
                            boss.NextDash = Game.random.Next(100, 150);
                        }
                    }
                    boss.Move();
                    boss.QueryHitPlayer();
                    boss.IsHitByProjectile();
                    boss.Timer++;
                }
            }
            else
            {
                boss.TargetOffScreen();
                boss.Move();
                if (Math.Abs(boss.LocationX - Player.playerX) > 50 || Math.Abs(boss.LocationY - Player.playerY) > 30)
                {
                    boss.Despawn();
                }
            }
            return boss;
        }//controls the movement of the eye of cthulhu
        public static void npcControls()
        {
            for(int i = 0; i < 20; i++)
            {
                Slime slime = Game.slimes[i];
                if (slime != null)
                {
                    slime = controlSlime(slime);
                    Game.slimes[i] = slime;
                }
                Fighter zombie = Game.zombies[i];
                if (zombie != null)
                {
                    zombie = controlZombie(zombie);
                    Game.zombies[i] = zombie;
                }
                FlyingEnemy flyingEnemy = Game.flyingEnemies[i];
                if(flyingEnemy != null)
                {
                    flyingEnemy = controlFlyingEnemy(flyingEnemy);
                    Game.flyingEnemies[i] = flyingEnemy;
                }
            }
            if(Game.eyeOfCthulhu != null)
            {
                EyeOfCthulhu boss = Game.eyeOfCthulhu;
                boss = controlEyeOfCthulhu(boss);
                Game.eyeOfCthulhu = boss;
            }
        }//controls the behaviour of each npc
    }
}