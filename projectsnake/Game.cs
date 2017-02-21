using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ProjectSnake
{
    public partial class Game : Form
    {
        
        //creats a a enum for direction that can be the given bellow
        enum Direction { Right, Left, Down, Up }
       
        
        public Game()
        {
            InitializeComponent();
            //setts the parameters that can be coosen in settning for the game.   
            speed = MenuOne.speed;
            accelerating = MenuOne.acc;
            wall = MenuOne.wall;
            //wall = true;


            //setts upp the music and setts the given size to the window
            simpleSound.PlayLooping();
            pbCanvas.Height = 900;
            pbCanvas.Width = 900;

            // creats a head to the snake by clear any existing parts and givs it new coodinats
            Snake.Clear();
            Coord head = new Coord();
            head.X = 420;
            head.Y = 420;
            Snake.Add(head);
            
            //sett up a new timer for the game
            gameTimer.Interval = 1000/speed;
            gameTimer.Start();
            
            //creats a new start food
            GenerateFood(Snake);
            foodSpc.X = 1000;
            foodSpc.Y = 1000;
            
            stopGame = false;
            score = 0;
            
        }
        //the parameters and variables for the game
        public static bool stopGame = false;
        public static int score;
        List<Coord> Snake = new List<Coord>();
        static Coord food;
        static Coord foodSpc = new Coord();
        static int foodTimer = 0; 
        
        Direction direction = Direction.Down; //setts the starting direction to down
        int speed;
        bool accelerating;
        bool wall;
        bool spcVisible = false;
        public static int genereted = 5;  
        Direction newdirection;
        public static SoundPlayer simpleSound = new SoundPlayer("LTYH.wav");
        public static int s = 0;
       
        //The game timer: 
        //Moves the snake. 
        // Check collisins 
        //eat and creates new food
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //setts the direction to the latest presst correct direction
            direction = newdirection;
           //move the snake
            for (int i = Snake.Count()-1; i >= 0; i-- )
            {
                //move the head in a chosen direction
                if (i == 0)
                {
                    switch (direction)
                    {
                        case Direction.Up:
                            Snake[i].Y -= 30;
                            break;
                        case Direction.Down:
                            Snake[i].Y += 30;
                            break;
                        case Direction.Left:
                            Snake[i].X -= 30;
                            break;
                        case Direction.Right:
                            Snake[i].X += 30;
                            break;
                    }
                    //Get maximum x and y position of the window
                    int maxYpos = pbCanvas.Size.Height;
                    int maxXpos = pbCanvas.Size.Width;

                    // detect colition with walls
                    // if walls turned off
                    //the snake gets the opposits sides position
                    if (!wall)
                    {
                        if (Snake[i].X < 0)
                            Snake[i].X = maxXpos - 30;
                        else if (Snake[i].Y < 0)
                            Snake[i].Y = maxYpos - 30;
                        else if (Snake[i].Y >= maxYpos)
                            Snake[i].Y = 0;
                        else if (Snake[i].X >= maxXpos)
                            Snake[i].X = 0;
                    }
                    //if walls are of the snake dies with collition 
                    else if (wall)
                    {
                        if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].Y >= maxYpos || Snake[i].X >= maxXpos)
                            Die();
                    }
                    
                    //detect collition wit itself if collition die
                    for (int j = 1; j < Snake.Count()-1; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                            
                        }

                    }

                    //detect collition with food
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                        Eat();
                    //detect collision with special food if a special food is active
                    // adds the food to the body 
                    //and remove the food from the game.
                    if (spcVisible && Snake[i].X == foodSpc.X && Snake[i].Y == foodSpc.Y)
                    {
                        score += 4;
                        Coord newPart = new Coord();
                        newPart.X = Snake[Snake.Count() - 1].X;
                        newPart.Y = Snake[Snake.Count() - 1].Y;
                        Snake.Add(newPart);
                        foodSpc.X = 1000;
                        foodSpc.Y = 1000;
                        spcVisible = false;
                    }
                    
                }
                else // move body by giving each part the coordnats of the one infrot it
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;

                }
            }
            // redraw the picturebox
            
            pbCanvas.Invalidate();
        }
        //method Die
        //stops the game and open a gameover window and closes the gameform when the 
        //gameover form is closed.
        private void Die()
        {
            GameOver go = new GameOver();
            simpleSound.Stop();
            gameTimer.Stop();
            go.ShowDialog(this);
            this.Close();
        }
        //method eat
        //adds the foodpart to the snake. 
        // generate a new food
        private void Eat()
        {
            // give score for eating
            score += MenuOne.points;
            // if snakemasterextreme mood activated the speed will increas for every 5 eaten apple.
            if (score % 5 == 0)
            {
                if (accelerating)
                {
                    speed += 5;
                    gameTimer.Interval = 1000 / speed;

                    if (MenuOne.points < 5)
                        MenuOne.points++;
                }

            }
            // adds the food too the snake
            Coord newPart = new Coord();
            newPart.X = Snake[Snake.Count() -1].X;
            newPart.Y = Snake[Snake.Count() -1].Y;
            Snake.Add(newPart);
            //generate new food
            GenerateFood(Snake);
            Random random = new Random();
            
            //creates a new speciell food if the score is evenly diveded by the given number..
            if (!spcVisible && score % genereted == 0)
            {
                GenerateSpcFood();
                spcVisible = true;
                genereted = random.Next(6,15);
                timerFood.Interval = 700;
                timerFood.Start();
            }
            
        }
        // method for repainting the picturebox
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            //draw the snake
            for (int i = 0; i < Snake.Count(); i++)
            {
                if (i == 0) // draw head
                //diffrent heads for each direction of movement for the snake.
                {
                    if (direction == Direction.Down)
                        e.Graphics.DrawImage(Bitmap.FromFile("headdown.png"), new Point(Snake[i].X, Snake[i].Y));
                    else if (direction == Direction.Up)
                        e.Graphics.DrawImage(Bitmap.FromFile("headup.png"), new Point(Snake[i].X, Snake[i].Y));
                    else if (direction == Direction.Right)
                        e.Graphics.DrawImage(Bitmap.FromFile("headright.png"), new Point(Snake[i].X, Snake[i].Y));
                    else if (direction == Direction.Left)
                        e.Graphics.DrawImage(Bitmap.FromFile("headleft.png"), new Point(Snake[i].X, Snake[i].Y));
                }

                else // draw body
                    e.Graphics.DrawImage(Bitmap.FromFile("body.png"), new Point(Snake[i].X, Snake[i].Y));
            }
            // draw food
            e.Graphics.DrawImage(Bitmap.FromFile("food.png"), new Point(food.X, food.Y));


            //draw specialfood if active
            if(spcVisible)
            {
                e.Graphics.DrawImage(Bitmap.FromFile("food-extra.png"), new Point(foodSpc.X, foodSpc.Y));
            }
            

        }
        //MEthod for detecting a pressed key
        //check if a current arrowkey is pressed and the opposit direction isn't applyed.
        // if okej the direction will be chanced
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyData == Keys.Up && direction != Direction.Down)
                newdirection = Direction.Up;

            else if (e.KeyData == Keys.Down && direction != Direction.Up)
                newdirection = Direction.Down;

            else if (e.KeyData == Keys.Right && direction != Direction.Left)
                newdirection = Direction.Right;

            else if (e.KeyData == Keys.Left && direction != Direction.Right)
                newdirection = Direction.Left;
            
            //close the window if esc is pressed
            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
                simpleSound.Stop();
            }
            else if (e.KeyData == Keys.W && direction != Direction.Down)
                newdirection = Direction.Up;

            else if (e.KeyData == Keys.S && direction != Direction.Up)
                newdirection = Direction.Down;

            else if (e.KeyData == Keys.D && direction != Direction.Left)
                newdirection = Direction.Right;

            else if (e.KeyData == Keys.A && direction != Direction.Right)
                newdirection = Direction.Left;
            
            //opens a pause window when space is pressed and stops the game and starts the game 
                //when teh pause window is closed
            else if (e.KeyData == Keys.Space)
            {
                Pause p = new Pause();
                gameTimer.Stop();

                p.ShowDialog(this);

                gameTimer.Start();
                if (stopGame)
                    this.Close();


            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
           
        }

        // Method for generate a food 
        //creates a random and ramdomly gives new coodninates to the food in the reach of the window size.
        //Check if the new coordinates is already occupied by the snake if so generates new ones.
        static void GenerateFood(List<Coord> snake)
        {
            //generata a new food object with random coordinates
            Random random = new Random();
            food = new Coord();
            bool okej = false;
           
            
            while (!okej)
            {
                int X = random.Next(0, 25) * 30;
                int Y = random.Next(0, 25) * 30;
                // Check if the coordninats exist in the snake
                if (!snake.Exists(x => x.Y == Y) && !snake.Exists(x => x.Y == Y))
                {
                    food.X = X;
                    food.Y = Y;
                    okej = true;
                }
            }
          
            
        }
        // Method for generate a specialfood 
        //creates a random and ramdomly gives new coodninates to the food in the reach of the window size.
        //Check if the new coordinates is already occupied by the snake if so generates new ones.
        public void GenerateSpcFood()
        {
           
            Random random = new Random();
           
            bool okej = false;

                while (!okej)
                {
                    int X = random.Next(0, 25) * 30;
                    int Y = random.Next(0, 25) * 30;
                    // Check if the coordninats exist in the snake
                    if (!Snake.Exists(x => x.Y == Y) && !Snake.Exists(x => x.Y == Y) && X != food.X && Y != food.Y)
                    {
                        foodSpc.X = X;
                        foodSpc.Y = Y;
                        okej = true;
                    }
                }

            
        }
        //method for the timer for the specialfood
        //each tick adds to a variable and after five ticcks the food will disapere from the game. 
        private void timerFood_Tick(object sender, EventArgs e)
        {
            foodTimer += 1; 
            if ( foodTimer == 5)
            {
                foodTimer =0;
                spcVisible=false;
                timerFood.Stop();
            }
        }
        
            
    }
}
