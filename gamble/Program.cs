using System;
using gamble;
class Program
{

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        UI UI = new UI(100, 30, 0, 0);
        GameManager gm = new GameManager();

        UI.InitSlot(true);
        UI.DrawSlot();
        UI.DrawStats(gm);
        UI.DrawMsgBoard("!WELCOME!");
        UI.DrawMenu();

        ConsoleKeyInfo key = Console.ReadKey(true);

        while (key.Key != ConsoleKey.X)
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Spacebar: gm.OnSpin(UI, gm); break;
                case ConsoleKey.UpArrow: gm.OnBet(gm.Bet + 10, UI); break;
                case ConsoleKey.DownArrow: gm.OnBet(gm.Bet - 10, UI); break;
                case ConsoleKey.LeftArrow: gm.OnMultiplier(gm.Multiplier - 1, UI); break;
                case ConsoleKey.RightArrow: gm.OnMultiplier(gm.Multiplier + 1, UI); break;
            }
            
            key = Console.ReadKey(true);

            if(gm.Balance <= 0)
            {
                Console.Clear();
                string lost = "YOU SPENT ALL YOUR MONEY!! LOOSER!";
                Console.SetCursorPosition(UI.Width / 2 - lost.Length / 2, UI.Height / 2);
                Console.WriteLine(lost);
                break;
            }
        }



    }

}