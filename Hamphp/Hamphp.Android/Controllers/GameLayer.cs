using System;
using System.Collections.Generic;
using CocosSharp;
using Hamphp.Android;
using Android.OS;
using System.IO;
using Android.Widget;

namespace Hamphp
{
	public class GameLayer : CCLayerColor
	{
        List<CCSprite> walls = new List<CCSprite>();
		bool pre = false , full = false;
        CCSprite menubutton1 , menubutton2, menubutton3;
		public bool finished = true;
		public bool nextlevel = false;
		public int lvlnr  =1 , goals = 0 ,nrtotalgoals =0;
		public CCSprite sprite ,wallsprite ,sokosprite , floorsprite ,packagesprite,packagesprite2,packagesprite3,packagesprite4,packagesprite5 , goalsprite;
		CCLabel testlabel , testlabel2 , testlabel3;// 19
		public int newposx, newposy ,number =1 , score =0;
		public int[][] a;
        public int[] undoPointsI; public int[] undoPointsJ; public int undoi = 0, undoj = 0;
        bool goLeft, goRight, goUp, goDown;
        float spike, spike2;
        bool moveX = false;
        bool moveY = false;
        public float sensorvalue;

        public GameLayer () : base (CCColor4B.AliceBlue)
		{
			Maps ();
			Schedule(RunGameLogic);

	     }
        private void RunGameLogic(float frameTimeInSeconds)
		{
			string xx = MainActivity.GetAxes.X ().ToString ();
			string yy = MainActivity.GetAxes.Y ().ToString ();
			float x, y; sensorvalue = SensorHandler.SensorManage.SV();
            if (sensorvalue < 6 || sensorvalue > 14) {
                sensorvalue = 10;
            }
			float.TryParse (xx, out x);
			float.TryParse (yy, out y);
			///////

			if (Math.Abs (x) > sensorvalue) {
				spike = x;
				moveX = true;
			}
			if (x > -2f && x < 2f && moveX)
			{
				if (spike > 0)
					goLeft = true;
				else
					goRight = true;
			}

			if (moveX) {
				if (goLeft) {
					goLeft = false;
					moveX = false;
					if (a [newposy] [newposx] == 4)
                    {
						if (a [newposy] [newposx - 1] == 1) {
							
						} 
						else if (a [newposy] [newposx - 1] == 5)
                        {
							a [newposy] [newposx - 1] = 4;
							a [newposy] [newposx] = 5;
							sokosprite.PositionX -= 60;
							newposx--; score++; ;undoi++;undoj++;
                        }
                        else if (a [newposy] [newposx - 1] == 2) {
							if (a [newposy] [newposx - 2] != 1) {
								if (a [newposy] [newposx - 2] == 3) {
									pre = true;
								} else {
									pre = false;
								}

									
								a [newposy] [newposx - 1] = 4;
								a [newposy] [newposx] = 5;
								a [newposy] [newposx - 2] = 2;
								sokosprite.PositionX -= 60;
								packagesprite.PositionX -= 60; 
								newposx--;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true && pre == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						}
                        else if (a [newposy] [newposx - 1] == 7)
                        {
							if (a [newposy] [newposx - 2] != 1) {
								if (a [newposy] [newposx - 2] == 3) {
									pre = true;
								} else {
									pre = false;
								}

								a [newposy] [newposx - 1] = 4;
								a [newposy] [newposx] = 5;
								a [newposy] [newposx - 2] = 7;
								sokosprite.PositionX -= 60;
								packagesprite2.PositionX -= 60; 
								newposx--;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						}
					}
	
				}	
				if (goRight) {
					goRight = false;
					moveX = false;
					//	testlabel2.Text = testlabel2.Text + " " + newposx; 
					if (a [newposy] [newposx] == 4) {
						if (a [newposy] [newposx + 1] == 1) {

						} else if (a [newposy] [newposx + 1] == 5) {
							a [newposy] [newposx + 1] = 4;
							a [newposy] [newposx] = 5;
							newposx++;
							score++;
							sokosprite.PositionX += 60;

						} else if (a [newposy] [newposx + 1] == 2) {
							if (a [newposy] [newposx + 2] != 1) {
								if (a [newposy] [newposx + 2] == 3) {
									pre = true;
								} else {
									pre = false;
								}
									
								a [newposy] [newposx + 1] = 4;
								a [newposy] [newposx] = 5;
								a [newposy] [newposx + 2] = 2;
								sokosprite.PositionX += 60;
								packagesprite.PositionX += 60; 
								newposx++;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						} else if (a [newposy] [newposx + 1] == 7) {
							if (a [newposy] [newposx + 2] != 1) {
								if (a [newposy] [newposx + 2] == 3) {
									pre = true;
								} else {
									pre = false;
								}

								a [newposy] [newposx + 1] = 4;
								a [newposy] [newposx] = 5;
								a [newposy] [newposx + 2] = 7;
								sokosprite.PositionX += 60;
								packagesprite2.PositionX += 60; 
								newposx++;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}

						}
					}
				}
				}
				/////
				if (Math.Abs (y) > sensorvalue) {
					spike2 = y;
					moveY = true;
				}
				if (y > 5f && y < 8f && moveY) {
					if (spike2 > 10) {
						goDown = true;
					} else if (spike2 < 10) {
						goUp = true;
					}
				}

				if (moveY) {

				if (goUp) {
					goUp = false;
					moveY = false;
					if (a [newposy] [newposx] == 4) {
						if (a [newposy + 1] [newposx] == 1) {
						
						} else if (a [newposy + 1] [newposx] == 5) {
							a [newposy + 1] [newposx] = 4;
							a [newposy] [newposx] = 5;
							newposy++;
							score++;
							sokosprite.PositionY += 60;
						} else if (a [newposy + 1] [newposx] == 2) {
							if (a [newposy + 2] [newposx] != 1) {
								if (a [newposy + 2] [newposx] == 3) {
									pre = true;
								} else {
									pre = false;
								}
								a [newposy + 1] [newposx] = 4;
								a [newposy] [newposx] = 5;
								a [newposy + 2] [newposx] = 2;
								sokosprite.PositionY += 60;
								packagesprite.PositionY += 60; 
								newposy++;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						} else if (a [newposy + 1] [newposx] == 7) {
							if (a [newposy + 2] [newposx] != 1) {
								if (a [newposy + 2] [newposx] == 3) {
									pre = true;
								} else {
									pre = false;
								}

								a [newposy + 1] [newposx] = 4;
								a [newposy] [newposx] = 5;
								a [newposy + 2] [newposx] = 7;
								sokosprite.PositionY += 60;
								packagesprite2.PositionY += 60; 
								newposy++;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						}
					}
				}

				if (goDown) {
					goDown = false;
					moveY = false;
					if (a [newposy] [newposx] == 4) {
						if (a [newposy - 1] [newposx] == 1) {

						} 
						else if (a [newposy - 1] [newposx] == 5) 
						{
							a [newposy - 1] [newposx] = 4;
							a [newposy] [newposx] = 5;
							newposy--;
							score++;
							sokosprite.PositionY -= 60;
						} 
						else if (a [newposy - 1] [newposx] == 2) {
							if (a [newposy - 2] [newposx] != 1) {

								if (a [newposy - 2] [newposx] == 3) {
									pre = true;
								} else {
									pre = false;
								}
								a [newposy - 1] [newposx] = 4;
								a [newposy] [newposx] = 5;
								a [newposy - 2] [newposx] = 2;
								sokosprite.PositionY -= 60;
								packagesprite.PositionY -= 60; 
								newposy--;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						} else if (a [newposy - 1] [newposx] == 7) {
							if (a [newposy - 2] [newposx] != 1) {

								if (a [newposy - 2] [newposx] == 3) {
									pre = true;
								} else {
									pre = false;
								}
								a [newposy - 1] [newposx] = 4;
								a [newposy] [newposx] = 5;
								a [newposy - 2] [newposx] = 7;
								sokosprite.PositionY -= 60;
								packagesprite2.PositionY -= 60; 
								newposy--;
								score++;
								if (pre == true) {
									full = true;
								}
								if (full == true) {
									goals++;
									pre = false;
									full = false;
								}
							}
						}
					}

				}
			}
			testlabel.Text ="Level " + lvlnr.ToString();
			testlabel2.Text = "Moves " + score.ToString();
			testlabel3.Text = "Goals " +goals + @" \ " + nrtotalgoals;
			if (goals == nrtotalgoals) {
				lvlnr++;
				nextlevel = true;
				goals = 0;

			}
			if (nextlevel == true) {
				score = 0;
				nrtotalgoals = 0;
				nextlevel = false;
				Maps ();
			}
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

            CCRect bounds = VisibleBoundsWorldspace;
			var touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesEnded = OnTouchesEnded;
			touchListener.OnTouchesMoved = HandleTouchesMoved;
			AddEventListener (touchListener, this);
		}

		private void HandleTouchesMoved(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{
            testlabel.Text = sensorvalue.ToString();
			
		}
		void OnTouchesEnded (List<CCTouch> touches, CCEvent touchEvent)
		{
            if (menubutton1.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
            {
                goals = 0;nrtotalgoals = 0;score = 0;
                Maps();
            }

        }

		public void Maps(){
			if (lvlnr == 1)
            {
                a = new int[][] { 
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11,10,11, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                   new int[]{ 0, 0, 0, 0, 11,10,11, 0, 0, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 9, 3, 9, 0, 0, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 9, 5, 9, 0, 0, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 9, 5, 9, 0, 0, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0 },
                   new int[]{ 0, 0, 0,11, 9, 5, 9, 10,10,10, 9, 5, 9, 10, 10, 11, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 1, 9, 5, 9, 1, 1, 1, 9, 5, 9, 1, 1, 1, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 5, 5, 5, 5, 4, 5, 5, 5, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 1, 1, 1, 5, 1, 1, 1, 1, 9, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 9, 0, 9, 5, 9, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 5, 5, 5, 9, 0, 9, 3, 9, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 9, 1, 1, 1, 9, 0, 9, 1, 9, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                
			}
			if (lvlnr == 3) {
				a = new int[][] {
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 1, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 1, 1, 2, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 0, 0 },
					new int[]{ 0, 0, 0, 0, 1, 5, 5, 1, 5, 5, 5, 1, 5, 5, 5, 3, 1, 0, 0 },
					new int[]{ 0, 0, 0, 0, 1, 5, 5, 5, 5, 4, 5, 1, 5, 5, 5, 3, 1, 0, 0 },
					new int[]{ 0, 0, 0, 0, 1, 1, 2, 1, 1, 5, 1, 1, 5, 5, 5, 3, 1, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 1, 1, 1, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 1, 5, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 5, 5, 5, 5, 5, 5, 1, 1, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };	
			}
			if (lvlnr == 4) {
				a = new int[][] {
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 1, 1, 1, 1, 1, 0, 1, 5, 1, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 1, 1, 1, 5, 5, 5, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 1, 1, 5, 5, 5, 5, 8, 5, 5, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 3, 5, 5, 5, 1, 1, 1, 1, 5, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 3, 5, 5, 5, 1, 5, 4, 5, 5, 1, 5, 1, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 3, 5, 5, 5, 1, 5, 5, 5, 2, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 1, 5, 5, 1, 1, 5, 1, 5, 7, 5, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 5, 5, 5, 5, 5, 5, 5, 1, 1, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 1, 1, 5, 5, 1, 5, 5, 5, 1, 0, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 5, 5, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };	
			}
			if (lvlnr == 2) {
				a = new int[][] {
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 5, 5, 5, 5, 5, 5, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 1, 1, 1, 1, 1, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 1, 5, 5, 5, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 1, 5, 1, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 1, 2, 3, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 5, 5, 5, 5, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 1, 1, 1, 5, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 5, 5, 5, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 1, 0, 0, 0 },
					new int[]{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };	
			}
			int posx= -60, posy =0;

			for (int i = 0; i <= 29; i++) {
				for(int j = 0;j <= 17;j++){
					if (a [i] [j] == 0) {
						

						sprite = new CCSprite ("space");
						sprite.PositionX = posx;
						sprite.PositionY = posy;
						AddChild (sprite);
					}
                    posx += 60;
				}
				posx = -60;
				posy += 60;
			}
            int posx0 = -60, posy0 = 0;
            for (int i = 0; i <= 29; i++)
            {
                for (int j = 0; j <= 17; j++)
                {
                    if (a[i][j] == 10)
                    {
                        sprite = new CCSprite("space");
                        sprite.PositionX = posx;
                        sprite.PositionY = posy;
                        AddChild(sprite);
                        sprite = new CCSprite("shadow");
                        sprite.PositionX = posx0;
                        sprite.PositionY = posy0;
                        AddChild(sprite);
                    }
                    if (a[i][j] == 11)
                    {
                        sprite = new CCSprite("space");
                        sprite.PositionX = posx;
                        sprite.PositionY = posy;
                        AddChild(sprite);
                        sprite = new CCSprite("shadow2");
                        sprite.PositionX = posx0;
                        sprite.PositionY = posy0;
                        AddChild(sprite);
                    }

                    posx0 += 60;
                }
                posx0 = -60;
                posy0 += 60;
            }
            int posx1= -60, posy1 =0;

			for (int i = 0; i <= 29; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 1) {


						wallsprite = new CCSprite ("wall");
						wallsprite.PositionX = posx1;
						wallsprite.PositionY = posy1;
						AddChild (wallsprite);
						walls.Add (wallsprite);
					}
                    if (a[i][j] == 9)
                    {


                        wallsprite = new CCSprite("wall2");
                        wallsprite.PositionX = posx1;
                        wallsprite.PositionY = posy1;
                        AddChild(wallsprite);
                        walls.Add(wallsprite);
                    }

                    posx1 += 60;
				}
				posx1 = -60;
				posy1 += 60;
			}
			int posx5= -60, posy5 =0;
			for (int i = 0; i <= 29; i++) {
				for (int j = 0; j <= 17; j++) {

					if (a [i] [j] == 5) {
						sprite = new CCSprite ("floor");
						sprite.PositionX = posx5;
						sprite.PositionY = posy5;
						AddChild (sprite);
					}
					posx5 += 60;
				}
				posx5 = -60;
				posy5 += 60;
			}
			int posx2= -60, posy2 =0;
			for (int i = 0; i <= 21; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 2) {

						sprite = new CCSprite ("floor");
						sprite.PositionX = posx2;
						sprite.PositionY = posy2;
						AddChild (sprite);
						packagesprite = new CCSprite ("package");
						packagesprite.PositionX = posx2;
						packagesprite.PositionY = posy2;
						AddChild (packagesprite);
					}
					posx2 += 60;
				}
				posx2 = -60;
				posy2 += 60;
			}
			int posxx2= -60, posyy2 =0;
			for (int i = 0; i <= 21; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 7) {

						sprite = new CCSprite ("floor");
						sprite.PositionX = posxx2;
						sprite.PositionY = posyy2;
						AddChild (sprite);
						packagesprite2 = new CCSprite ("package");
						packagesprite2.PositionX = posxx2;
						packagesprite2.PositionY = posyy2;
						AddChild (packagesprite2);
					}
					posxx2 += 60;
				}
		     

				posxx2 = -60;
				posyy2 += 60;
			}
			int posxxx2 = -60 , posyyy2 =0;
			for (int i = 0; i <= 29; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 8) {

						sprite = new CCSprite ("floor");
						sprite.PositionX = posxxx2;
						sprite.PositionY = posyyy2;
						AddChild (sprite);
						packagesprite3 = new CCSprite ("package");
						packagesprite3.PositionX = posxxx2;
						packagesprite3.PositionY = posyyy2;
						AddChild (packagesprite3);
					}
					posxxx2 += 60;
				}


				posxxx2 = -60;
				posyyy2 += 60;
			}
			int pposxx2 = -60 , pposyy2 =0;
			for (int i = 0; i <= 29; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 99) {

						sprite = new CCSprite ("floor");
						sprite.PositionX = pposxx2;
						sprite.PositionY = pposyy2;
						AddChild (sprite);
						packagesprite4 = new CCSprite ("package");
						packagesprite4.PositionX = pposxx2;
						packagesprite4.PositionY = pposyy2;
						AddChild (packagesprite4);
					}
					pposxx2 += 60;
				}


				pposxx2 = -60;
				pposyy2 += 60;
			}
			int posx3= -60, posy3 =0;

			for (int i = 0; i <= 21; i++) {
				for(int j = 0;j <= 17;j++){

					if (a [i] [j] == 3) {
						//testlabel2.Text = testlabel2.Text.ToString() + "b" + " ";

						goalsprite = new CCSprite ("goal");
						goalsprite.PositionX = posx3;
						goalsprite.PositionY = posy3;
						AddChild (goalsprite);
						nrtotalgoals++;
					}

					posx3 += 60;
				}
				posx3 = -60;
				posy3 += 60;
			}
			int posx4= -60, posy4 =0;
			for (int i = 0; i <= 29; i++) {
				for (int j = 0; j <= 17; j++) {

					if (a [i] [j] == 4) {
						sprite = new CCSprite ("floor");
						sprite.PositionX = posx4;
						sprite.PositionY = posy4;
						AddChild (sprite);
						sokosprite = new CCSprite ("soko_up");
						sokosprite.PositionX = posx4;
						sokosprite.PositionY = posy4;
						AddChild (sokosprite);
						newposx = j;
						newposy = i;
					}
					posx4 += 60;
				}
				posx4 = -60;
				posy4 += 60;
			}
            Initialize();
        }
        public void Initialize()
        {
            testlabel = new CCLabel("", "Arial", 40, CCLabelFormat.SystemFont);
            testlabel.PositionX = 200;
            testlabel.PositionY = 80;
            testlabel.Color = CCColor3B.Red;
            testlabel.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(testlabel);
            testlabel2 = new CCLabel("", "Arial", 40, CCLabelFormat.SystemFont);
            testlabel2.PositionX = 400;
            testlabel2.PositionY = 80;
            testlabel2.Color = CCColor3B.Red;
            testlabel2.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(testlabel2);
            testlabel3 = new CCLabel("", "Arial", 40, CCLabelFormat.SystemFont);
            testlabel3.Color = CCColor3B.Red;
            testlabel3.PositionX = 600;
            testlabel3.PositionY = 80;
            testlabel3.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(testlabel3);
            menubutton1 = new CCSprite("undo.png");
            menubutton1.PositionX = 40;
            menubutton1.PositionY = 60;
            AddChild(menubutton1);
            
        }
    }
}
