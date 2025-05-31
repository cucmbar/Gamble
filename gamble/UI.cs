using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace gamble
{
    internal class UI
    {
        private int height;
        private int width;
        private int x;
        private int y;
        private Random rnd;
        private char[] chars;
        private char[] ch;

        public UI(int width, int height, int x, int y)
        {
            this.height = height;
            this.width = width;
            Console.SetWindowSize(width, height);
            this.x = x;
            this.y = y;
            this.chars = new char[6] { '@', '#', '&', '$', '7', '!' };
            this.ch = new char[9];
            this.rnd = new Random();
        }

        public void InitSlot(bool status) // win or lose
        {  
            if (!status)
            {
                for (int i = 0; i < 9; i++)
                {
                    this.ch[i] = this.chars[rnd.Next(this.chars.Length)];
                }
            }
            else
            {
                for (int i = 0; i <= 2; i++)
                {
                    this.ch[i] = this.chars[rnd.Next(this.chars.Length)];
                }
                int win_ch = rnd.Next(this.chars.Length);
                for (int i = 3; i <= 5; i++)
                {
                    this.ch[i] = this.chars[win_ch];
                }
                for (int i = 6; i <= 8; i++)
                {
                    this.ch[i] = this.chars[rnd.Next(this.chars.Length)];
                }
            }
        }

        public void Spin()
        {
            for(int time = 100; time <= 600; time += 50) // cycles slowing down the animation and repeating it
            {
                for (int i = 0; i < 9; i++)
                {
                    this.ch[i] = this.chars[rnd.Next(this.chars.Length)];
                }
                DrawSlot();
                Thread.Sleep(time);
            }
        }

        public void DrawSlot()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] slotArt = new string[]
            {
                "╔═════════════════╗",
                "║   SLOT MACHINE  ║",
                "╠═════════════════╣",
                $"║  {ch[0]}  │  {ch[1]}  │  {ch[2]}  ║",
                "║─────┼─────┼─────║",
                $"║  {ch[3]}  │  {ch[4]}  │  {ch[5]}  ║",
                "║─────┼─────┼─────║",
                $"║  {ch[6]}  │  {ch[7]}  │  {ch[8]}  ║",
                "╚═════════════════╝"
            };

            int slotX = this.width / 2 - slotArt[1].Length / 2;
            int slotY = this.height / 2 - slotArt.Length / 2;

            for (int i = 0; i < slotArt.Length; i++)
            {
                Console.SetCursorPosition(slotX, slotY + i);
                Console.WriteLine(slotArt[i]);
            }
            Console.ResetColor();
        }

        public void DrawStats(GameManager gm)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] statsArt = new string[]
            {
                "╔═════════════════════════╗",
                "║       Casino Stats      ║",
                "╠═════════════════════════╣",
                $"║ Balance    : {gm.Balance,10} ║",
                $"║ Bet        : {gm.Bet,10} ║",
                $"║ Multiplier : {gm.Multiplier,10} ║",
                $"║ Chance     : {gm.Chance * 100,8:F2} % ║",
                $"║ Games      : {gm.Count,10} ║",
                $"║ Wins       : {gm.Won,10} ║",
                $"║ Losses     : {gm.Lost,10} ║",
                "╚═════════════════════════╝"
            };

            int statsX = this.width - statsArt[0].Length;
            ;
            int statsY = y;
            Console.SetCursorPosition(statsX, statsY);

            foreach (var line in statsArt)
            {
                Console.SetCursorPosition(statsX, statsY++);
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
        public void DrawMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int menuX = x;

            string[] menuArt = new string[]
            {
                "╔════════════════════════════════════════════════╗",
                "║                   Main Menu                    ║",
                "╠════════════════════════════════════════════════╣",
                "║ {Space} to Spin                                ║",
                "║ {↑   ↓} to Change Bet Amount                   ║",
                "║ {<- ->} to Change the multiplier               ║",
                "║ {x}     to Exit                                ║",
                "╚════════════════════════════════════════════════╝"
            };
            int menuY = this.height - menuArt.Length;

            for (int i = 0; i < menuArt.Length; i++)
            {
                Console.SetCursorPosition(menuX, menuY + i);
                Console.WriteLine(menuArt[i]);
            }
        }

        public void DrawMsgBoard(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            string[] MsgArt = new string[]
            {
                "═══════════════════════",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                $" {message,15}",
                "═══════════════════════"
            };

            int statsX = x;
            int statsY = y;
            Console.SetCursorPosition(statsX, statsY);

            foreach (var line in MsgArt)
            {
                Console.SetCursorPosition(statsX, statsY++);
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }

    }
}
