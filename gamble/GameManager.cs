using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gamble
{
    internal class GameManager
    {
        private bool isWin;
        private double baseChance;
        private double chance;
        private int count;
        private long won;
        private long lost;
        private long balance;
        private int multiplier;
        private int bet = 30; // Default bet amount
        private Random rand;

        public int Count
        {
            get => count;
            set => count = value;
        }

        public long Won
        {
            get => won;
            set => won = value;
        }

        public long Lost
        {
            get => lost;
            set => lost = value;
        }

        public long Balance
        {
            get => balance;
            set => balance = value;
        }

        public int Bet
        {
            get => bet;
            set => bet = value;
        }

        public int Multiplier
        {
            get => multiplier;
            set => multiplier = value;
        }

        public bool IsWin
        {
            get => isWin;
            set => isWin = value;
        }

        public double Chance
        {
            get => chance;
            set => chance = value;
        }    


        public GameManager()
        {
            bet = 30;
            won = 0;
            lost = 0;
            balance = 1000; // Starting balance
            count = 0;
            multiplier = 2; // Default multiplier for win
            baseChance = 0.50;
            chance = baseChance / multiplier; //chance is relative to the multiplier
            rand = new Random();
        }
        public bool Gamble()
        {
            if (rand.NextDouble() < chance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnBet(int bet,UI ui)
        {
            if (bet <= balance && bet > 0)
            {
                this.bet = bet; // Set the bet amount
            }
            else
            {
                ui.DrawMsgBoard("                           ");
                ui.DrawMsgBoard("!!!INVALID BET!!!");
            }
            ui.DrawStats(this);
        }
        
        public void OnMultiplier(int multiplier,UI ui)
        {
            if (multiplier > 1)
            {
                this.multiplier = multiplier; // Set the multiplier
                chance = baseChance / multiplier;
            }
            else
            {
                ui.DrawMsgBoard("                           ");
                ui.DrawMsgBoard("!!!INVALID MULTIPLIER!!!");
            }
            ui.DrawStats(this);
            

        }

        public void OnSpin(UI ui, GameManager gm)
        {
            bool state = Gamble();
            if (state)
            {
                ui.DrawMsgBoard("                            ");
                isWin = true;
                balance += bet * multiplier; // Win: double the bet
                won += bet * multiplier;
                count++;
                ui.Spin();
                ui.InitSlot(state);
                ui.DrawSlot();
                ui.DrawStats(gm);
                ui.DrawMsgBoard("!YOU WON BUT KEEP GAMBLING!");
            }
            else
            {
                ui.DrawMsgBoard("                             ");
                isWin = false;
                balance -= bet; // Lose: subtract the bet
                lost += bet;
                count++;
                ui.Spin();
                ui.InitSlot(state);
                ui.DrawSlot();
                ui.DrawStats(gm);
                ui.DrawMsgBoard("!YOU LOST  KEEP GAMBLING!");
            }
            
            
        }
    }
}
