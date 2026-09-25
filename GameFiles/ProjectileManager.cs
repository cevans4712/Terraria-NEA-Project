namespace TerrariaNEA
{
    public class ProjectileManager
    {
        public static void manageProjectiles()
        {
            for(int i = 0; i < 100; i++)
            {
                if (Game.arrows[i] != null)
                {
                    //if an arrow
                    if (Game.arrows[i].Type == 1)
                    {
                        Game.arrows[i].Move();
                        if (Game.arrows[i] != null)
                        {
                            if (World.cellMap[Game.arrows[i].BlockLocationX, Game.arrows[i].BlockLocationY - 2])
                            {
                                Game.arrows[i].Despawn();
                            }
                        }
                    }
                }
            }
        }// moves projectiles until they collide with block of which they despawn
        public static void newArrow(byte arrowID, double angle)
        {
            Arrow arrow = new WoodenArrow();
            switch (arrowID)
            {
                case 54://change to arrow item id
                    arrow = new WoodenArrow();
                    break;
                case 55://change to arrow item id
                    arrow = new FlamingArrow();
                    break;
                case 67:
                    arrow = new UnholyArrow();
                    break;
                case 73:
                    arrow = new HellfireArrow();
                    break;
            }
            arrow.LocationX = Player.playerLocationX * 20 + 20;
            arrow.LocationY = Player.playerLocationY * 20;
            arrow.VelocityX = (int)(arrow.Power * Math.Cos(angle));
            arrow.VelocityY = (int)(arrow.Power * Math.Sin(angle));
            arrow.BlockLocationX = (int)arrow.LocationX / 20;
            arrow.BlockLocationY = (int)arrow.LocationY / 20;
            arrow.Damage += Game.items[Game.currentItem].Damage;
            for(int i = 0; i < 100; i++)
            {
                if (Game.arrows[i] == null)
                {
                    Game.arrows[i] = arrow;
                    break;
                }
            }
        }//add the new arrow to the array
        public static void createArrow(byte arrow)
        {
            Point p1 = Cursor.Position;
            int blockX = Convert.ToInt16(p1.X / 20);
            int blockY = Convert.ToInt16(p1.Y / 20) + 1;
            double angle = 0;
            int aimX = blockX - 40;
            int aimY = blockY + 2 - 21;
            if (aimX == 0)
            {
                if (aimY < 0)
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
                if (aimY == 0)
                {
                    if (aimX < 0)
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
                    angle = Math.Atan((float)aimY / (float)aimX);
                    if (aimX < 0 && aimY < 0)
                    {
                        angle = -(Math.PI - angle);
                    }
                    if (aimX < 0 && aimY > 0)
                    {
                        angle = Math.PI + angle;
                    }
                }
            }
            newArrow(arrow, angle);
        }//creates a new arrow
    }
}
