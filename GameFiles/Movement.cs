namespace TerrariaNEA
{
    public class Movement
    {
        public static void forceFall()
        {
            int x = Player.playerLocationX;
            int y = Player.playerLocationY;
            if (World.blockMap[x, y] == 28 && World.blockMap[x + 1, y] == 28)
            {
                fall();
            }
            else if(World.blockMap[x, y] == 28)
            {
                if(!World.cellMap[x + 1, y])
                {
                    fall();
                }
            }
            else if(World.blockMap[x + 1, y] == 28)
            {
                if(!World.cellMap[x, y])
                {
                    fall();
                }
            }

        }//if the player is stood on a platform force them to fall through
        public static void moveLeft()
        {
            if (Player.playerOnScreenX > 800)
            {
                Player.playerOnScreenX -= 20;
            }
            else
            {
                if (Player.playerX == 40)
                {
                    if (Player.playerOnScreenX != 0)
                    {
                        Player.playerOnScreenX -= 20;
                    }
                }
                else
                {
                    Player.playerX--;
                    Player.movedLeft = true;
                }
            }
        }//if player can move left then move left
        public static void moveRight()
        {
            if (Player.playerOnScreenX < 800)
            {
                Player.playerOnScreenX += 20;
            }
            else
            {
                if (Player.playerX == World.worldWidth - 40)
                {
                    if (Player.playerOnScreenX != 1580)
                    {
                        Player.playerOnScreenX += 20;
                    }
                }
                else
                {
                    Player.playerX++;
                    Player.movedRight = true;
                }
            }
        }//if player can move right then move right
        public static bool jump(bool jumped)
        {
            if (Player.playerOnScreenY > 420)
            {
                Player.playerOnScreenY -= 20;
                jumped = true;

            }
            else
            {
                if (Player.playerY == 27)
                {
                    if (Player.playerOnScreenY != 0)
                    {
                        Player.playerOnScreenY -= 20;
                        jumped = true;
                    }
                }
                else
                {
                    Player.playerY--;
                    jumped = true;
                    Player.movedUp = true;
                }
            }
            return jumped;
        }//if player can jump then jump
        public static void fall()
        {
            if (Player.playerOnScreenY < 420)
            {
                Player.playerOnScreenY += 20;
            }
            else
            {
                if (Player.playerY == World.worldHeight - 24)
                {
                    if (Player.playerOnScreenY != 860)
                    {
                        Player.playerOnScreenY += 20;
                    }
                }
                else
                {
                    Player.playerY++;
                    Player.movedDown = true;
                }
            }
            Player.fallDuration++;

        }//if player can fall then fall
        public static void movementControls()
        {
            Player.playerLocationX = Player.playerX + (Player.playerOnScreenX - 800) / 20;
            Player.playerLocationY = Player.playerY + (Player.playerOnScreenY - 420) / 20;
            Player.movedLeft = false;
            Player.movedRight = false;
            Player.movedDown = false;
            Player.movedUp = false;
            if (Player.movingLeft)
            {
                if (canMoveLeft(Player.playerLocationX, Player.playerLocationY))
                {
                    moveLeft();
                }
                Player.animationj = 1;
            }
            if (Player.movingRight)
            {
                if (canMoveRight(Player.playerLocationX, Player.playerLocationY))
                {
                    moveRight();
                }
                Player.animationj = 0;
            }
            Player.playerLocationX = Player.playerX + (Player.playerOnScreenX - 800) / 20;
            Player.playerLocationY = Player.playerY + (Player.playerOnScreenY - 420) / 20;
            bool jumped = false;
            if (Player.jumping == true)
            {
                if (canJump(Player.playerLocationX, Player.playerLocationY))
                {
                    jumped = jump(jumped);
                }
                Player.jumpTime++;
            }
            if (canFall(Player.playerLocationX, Player.playerLocationY) && jumped == false)
            {
                fall();
            }
            if (!canFall(Player.playerLocationX, Player.playerLocationY))
            {
                if (Player.fallDuration >= 20)
                {
                    Player.takeDamage((Player.fallDuration - 20) * 5);
                }
                Player.fallDuration = 0;
            }
            if (Player.jumpTime >= 6 || (World.cellMap[Player.playerLocationX, Player.playerLocationY - 4] && World.blockMap[Player.playerLocationX, Player.playerLocationY - 4] != 28) || (World.cellMap[Player.playerLocationX + 1, Player.playerLocationY - 4] && World.blockMap[Player.playerLocationX + 1, Player.playerLocationY - 4] != 28))
            {
                Player.jumping = false;
                Player.jumpTime = 0;
            }
        }//what movement is happening(seperate thread)
        public static bool canMoveLeft(int x, int y)
        {
            if (x - 1 >= 0)
            {
                if ((World.cellMap[x - 1, y - 1] == false || World.blockMap[x - 1, y - 1] == 28) && (World.cellMap[x - 1, y - 2] == false || World.blockMap[x - 1, y - 2] == 28) && (World.cellMap[x - 1, y - 3] == false || World.blockMap[x - 1, y - 3] == 28))
                {
                    if(!(Player.slowWalking && Game.totalFrames % 2 == 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }//if player can move left
        public static bool canMoveRight(int x, int y)
        {
            if (x + 2 < World.worldWidth)
            {
                if ((World.cellMap[x + 2, y - 1] == false || World.blockMap[x + 2, y - 1] == 28) && (World.cellMap[x + 2, y - 2] == false || World.blockMap[x + 2, y - 2] == 28) && (World.cellMap[x + 2, y - 3] == false || World.blockMap[x + 2, y - 3] == 28))
                {
                    if (!(Player.slowWalking && Game.totalFrames % 2 == 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }//if player can move right
        public static bool canJump(int x, int y)
        {
            if (y - 4 >= 0)
            {
                if (Player.jumpTime != 6 && (World.cellMap[x, y - 4] == false || World.blockMap[x, y - 4] == 28) && (World.cellMap[x + 1, y - 4] == false || World.blockMap[x + 1, y - 4] == 28))
                {
                    return true;
                }
            }
            return false;
        }//if player can jump
        public static bool canFall(int x, int y)
        {
            if (y < World.worldHeight)
            {
                if (World.cellMap[x, y] == false && World.cellMap[x + 1, y] == false)
                {
                    if (!(Player.slowWalking && Game.totalFrames % 2 == 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }//if player can fall
    }
}
