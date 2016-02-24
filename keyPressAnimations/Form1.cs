using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by ZEV
 * to demonstrate how to use key presses to control the animation
 * of an object on screen
 */

namespace keyPressAnimations
{
    public partial class Form1 : Form

    {
        Image[] guy = new Image[4];
        int guyNum;
        //initial starting points for black rectangle
        int drawX = 100;
        int drawY = 200;

        //determines whether a key is being pressed or not
        Boolean aArrowDown, sArrowDown, dArrowDown, wArrowDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
            guy[0] = Properties.Resources.RedGuyDown;
            guy[1] = Properties.Resources.RedGuyRight;
            guy[2] = Properties.Resources.RedGuyUp;
            guy[3] = Properties.Resources.RedGuyLeft;
            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aArrowDown = true;
                    break;
                case Keys.S:
                    sArrowDown = true;
                    break;
                case Keys.D:
                    dArrowDown = true;
                    break;
                case Keys.W:
                    wArrowDown = true;
                    break;
                default:
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aArrowDown = false;
                    break;
                case Keys.S:
                    sArrowDown = false;
                    break;
                case Keys.D:
                    dArrowDown = false;
                    break;
                case Keys.W:
                    wArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the rectangle appropriately
            if (aArrowDown == true)
            {
                drawX--;
                guyNum = 3;
            }
            if (sArrowDown == true)
            {
                drawY++;
                guyNum = 0;
            }
            if (dArrowDown == true)
            {
                drawX++;
                guyNum = 1;
            }
            if (wArrowDown == true)
            {
                drawY--;
                guyNum = 2;
            }

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            
            e.Graphics.DrawImage(guy[guyNum], drawX, drawY);

        }

    }

}
