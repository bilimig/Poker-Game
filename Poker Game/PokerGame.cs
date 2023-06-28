using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class PokerGame
    {
        
       
            private List<Player> players;
            private int currentPlayerIndex;
            private int roundNumber;
            private Round currentRound;

            public PokerGame(List<Player> players)
            {
                this.players = players;
                currentPlayerIndex = 0;
                roundNumber = 1;
                currentRound = null;
            }

            public void Start()
            {
                Console.WriteLine("Rozpoczyna się gra w pokera!");
                Console.WriteLine("=================================");
                Console.WriteLine();
                while (!IsGameOver())
                {
                    Console.WriteLine("Runda numer: " + roundNumber);
                    Console.WriteLine("--------------------------");
                    Console.WriteLine();



                if (roundNumber == 1)
                {
                    StartNewRound();

                }
                else if(roundNumber == 2)
                {
                    currentRound.DealTableCard(3);
                }
                else if (roundNumber == 3 || roundNumber == 4)
                {
                    currentRound.DealTableCard(1);
                }
               


                // Sprawdzenie warunków końca gry
                if (IsGameOver())
                    {
                        break;
                    }

                    // Przejście do następnego gracza
                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                    roundNumber++;

                    // dodac ruchy itd
                }

                // Wyświetlenie zwycięzcy
                Player winner = DetermineWinner();
                Console.WriteLine("=================================");
                Console.WriteLine("Gra zakończona! Zwycięzca: " + winner.Name);



            }
            private void StartNewRound()
            {
                Console.WriteLine("Nowa runda:");
                Console.WriteLine();
                
                currentRound = new Round(players);
                currentRound.Start();
            
                // dodanie obslugi zakladow podejmowanie decyzji itd
            }
            
            
            private bool IsGameOver()
            {

                return false;
            }

            private Player DetermineWinner()
            {


                // stworzyc how to win

                return players[0];
            }

            private Player CheckBestPatern()
            {




            return players[0];

            }

        
    }
}
