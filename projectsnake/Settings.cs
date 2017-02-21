using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnake
{
    enum Direction { Right, Left, Down, Up }
    class Settings
    {
        

        public static int speed { get; set; }
        public static int score { get; set; }
        public static int hight { get; set; }
        public static int width { get; set; }
        public static int points { get; set; }
        public static bool gameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            width = 10;
            hight = 10;
            speed = 5;
            score = 0;
            points = 10;
            gameOver = false;
            direction = Direction.Down;

        }
    }
}
