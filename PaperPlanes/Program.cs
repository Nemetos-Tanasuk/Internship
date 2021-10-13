using System;
using System.Collections.Generic;

namespace PaperPlanes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter player 1 name:");
            var player1 = new Player(Console.ReadLine());

            Console.WriteLine("Enter player 2 name:");
            var player2 = new Player(Console.ReadLine());

            var game = new Game(player1, player2);
            player1.Board = new Board(8, 8);
            player2.Board = new Board(8, 8);

            Console.WriteLine($"{player1.Name} select plane position (x,y):");
            var positionPlayer1 = Console.ReadLine();
            var positionsPlayer1 = positionPlayer1.Split(",");
            var xPlayer1 = int.Parse(positionsPlayer1[0]);
            var yPlayer1 = int.Parse(positionsPlayer1[1]);

            player1.DrawPlane(xPlayer1, yPlayer1);
            player1.DrawBoard();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine($"{player2.Name} select plane position (x,y):");
            var positionPlayer2 = Console.ReadLine();
            var positionsPlayer2 = positionPlayer2.Split(",");
            var xPlayer2 = int.Parse(positionsPlayer2[0]);
            var yPlayer2 = int.Parse(positionsPlayer2[1]);

            player2.DrawPlane(xPlayer2, yPlayer2);

            player2.DrawBoard();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();

            var currentPlayer = player1;
            var otherPlayer = player2;
            while (!game.IsOver())
            {
                Console.WriteLine($"{currentPlayer.Name} press any key to start game...");
                Console.ReadKey();

                currentPlayer.DrawBoard();

                Console.WriteLine($"{currentPlayer.Name} select square to hit (x,y):");
                var position = Console.ReadLine();
                var positions = position.Split(",");
                var x = int.Parse(positions[0]);
                var y = int.Parse(positions[1]);

                var isHit = otherPlayer.Board.DrawPlaneHit(x, y);
                Console.WriteLine(isHit ? "Target hit!" : "Missed...");

                currentPlayer = currentPlayer.Name == player1.Name ? player2 : player1;
                otherPlayer = otherPlayer.Name == player1.Name ? player2 : player1;

                Console.WriteLine("Press any key for next player...");
                Console.ReadKey();

                Console.Clear();
            }

            Console.WriteLine($"Game Over! {otherPlayer.Name} has won!");
            Console.WriteLine("------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
