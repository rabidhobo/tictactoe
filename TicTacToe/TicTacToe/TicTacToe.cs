/**
 *  John Nau
 *  Assignment 1: TicTacToe
 *  CECS 475
 *  September 4, 2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private const int BOARDSIZE = 3; //size of board
        private int[,] board; //board representation

        public TicTacToe()
        {
            //intialize board to 0s
            board = new int[BOARDSIZE, BOARDSIZE];
            for (int i = 0; i < BOARDSIZE; i++)
                for (int j = 0; j < BOARDSIZE; j++)
                    board[i, j] = 0;
        } 

        //MY CODE
        public void PrintBoard()
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("|      |      |       |");
                if (board[i, 0] == 0) 
                    Console.Write("|      |");
                else 
                    Console.Write("|  " + board[i, 0] + "   |");
                if (board[i, 1] == 0)
                    Console.Write("      ");
                else
                    Console.Write("  " + board[i, 1] + "   ");
                if (board[i, 2] == 0)
                    Console.Write("|       |\n");
                else
                    Console.Write("|   " + board[i, 2] + "   |\n");
                Console.WriteLine("|      |      |       |");
            }
            Console.WriteLine("-----------------------");
        } //end PrintBoard

        public void Play()
        {
            bool done = false;
            
            while (!done) //game loop
            {
                //player 1
                move(1);
                PrintBoard();

                //check if there is a win or draw
                if (checkGameOver(1))
                {
                    Console.WriteLine("Player 1 wins");
                    done = true;
                }
                else if (checkStalemate())
                {
                    Console.WriteLine("The game is a draw.");
                    done = true;
                }
                else
                {
                    //player 2
                    move(2);
                    PrintBoard();

                    //check if there is a win or draw
                    if (checkGameOver(2))
                    {
                        Console.WriteLine("Player 2 wins");
                        done = true;
                    }
                }
            } //end  game loop

            Console.WriteLine("Press any key to terminate");
            Console.ReadLine();
        }//end Play

        private void move(int player)
        {
            int x = 0, y = 0;
            bool validMove = false;

            Console.WriteLine("Player " + player + "'s turn.");
            while (!validMove) //player input
            {
                Console.Write("Enter row (0 <= row < 3): ");
                bool valid = false;
                while (!valid) //x input
                {
                    try
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("Invalid input\nRenter row (0 <= row < 3): ");
                        x = -1;
                    }
                } // end x input

                Console.Write("Enter column (0 <= row < 3): ");
                valid = false;
                while (!valid) //y input
                {
                    try
                    {
                        y = Convert.ToInt32(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("Invalid input\nRenter column (0 <= row < 3): ");
                        y = -1;
                    }
                } //end y input

                //apply move
                if (x >= 0 && x < BOARDSIZE && y >= 0 && y < BOARDSIZE)
                {
                    if (board[x, y] != 0)
                        Console.WriteLine("Invalid move, try again.");
                    else
                        validMove = true;
                }
                else
                    Console.WriteLine("Invalid Position, try again.");
            } //end player input

            board[x, y] = player;
        }

        private bool checkGameOver(int player)
        {
            if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) return true;//top horizontal
            else if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) return true; //middle horizontal
            else if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) return true; //bottom horizontal
            else if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) return true; //left vertical
            else if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) return true; //middle vertical
            else if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) return true; //right vertical
            else if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true; //left/right diagnol
            else if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true; //right/left diagnol
            else return false; //no win
        } //end checkGameOver

        private bool checkStalemate()
        {
            for (int i = 0; i < BOARDSIZE; i++)
                for (int j = 0; j < BOARDSIZE; j++)
                    if (board[i, j] == 0) return false; //a possible move still exists
            return true; //all moves have been made
        }//end checkStalemate()
    }//end class
}//end namespace