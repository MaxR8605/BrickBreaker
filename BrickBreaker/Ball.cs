﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size, damage;
        public Color colour;
        public static Random rand = new Random();
        
        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec) && GameScreen.fireBallTimer == 0)
            {
                // Get the range of specific points it may hit
                if (x + (size / 2) <= b.x || x + (size / 2) >= b.x + b.width) // Hits either side
                {
                    xSpeed *= -1;

                    if (xSpeed > 0)
                    {
                        b.x = b.x - size;
                    }
                    else if (xSpeed < 0)
                    {
                        b.x = b.x + size;
                    }
                }   
                else // hits anywhere else
                {
                    ySpeed *= -1;

                    if (ySpeed > 0)
                    {
                        b.y = b.y + size;
                    }
                    else if (ySpeed < 0)
                    {
                        b.y = b.y - size;
                    }
                }
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if (ySpeed > 0)
                {
                    y = p.y - size;
                }

                ySpeed *= -1;
            }
            
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
                x = size;
                AdjustAngle("Y");
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeed *= -1;
                x = UC.Width - size;
                AdjustAngle("Y");
            }
            // Collision with top wall
            if (y <= 2)
            {
                ySpeed *= -1;
                AdjustAngle("X");
            }
        }

        public void AdjustAngle(string direction)
        {
            /**
             * Generate 3 numbers and depending on the result change the angle of the ball
             * The ball has its inital value and upon hitting a wall, it can adjust one of the speeds to be 1 above or below
             * the initial value or reset it back to that
             */

            int randomNum = rand.Next(0, 3);


        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
