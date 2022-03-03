using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeHelper
    {
        public static bool isWinner(string[] board, string player)
        {
            if (board[0] == board[1] && board[1] == board[2] && board[2] == player)
            {
                return true;
            }
            else if (board[3] == board[4] && board[4] == board[5] && board[5] == player)
            {
                return true;
            }
            else if (board[6] == board[7] && board[7] == board[8] && board[8] == player)
            {
                return true;
            }
            else if (board[0] == board[3] && board[3] == board[6] && board[6] == player)
            {
                return true;
            }
            else if(board[1] == board[4] && board[4] == board[7] && board[7] == player)
            {
                return true;
            }
            else if (board[2] == board[5] && board[5] == board[8] && board[8] == player)
            {
                return true;
            }
            else if (board[0] == board[4] && board[4] == board[8] && board[8] == player)
            {
                return true;
            }
            else if(board[2] == board[4] && board[4] == board[6] && board[6] == player)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
        public static bool spaceIsFree(string[] board, int pos)
        {
            if (board[pos] != " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkDraw(string[] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                if (board[i] == " ")
                {
                    return false;
                }
            }
            return true;
        }

        public static bool insertIntoBoard(string[] board, int pos, string mark)
        {
            if (spaceIsFree(board, pos) == true)
            {
                board[pos] = mark;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private static int minimax(string[] board, int depth, bool isMaximizing, string botSymbol)
        {
            string humanSymbol = (botSymbol.ToLower() == "x") ? "o" : "x";
            
            if (isWinner(board, botSymbol) == true)
            {
                    return 1;
            }
            else if (isWinner(board, humanSymbol) == true)
            {
                return -1;
            }
            else if (checkDraw(board) == true)
            {
                return 0;
            }

            if (isMaximizing == true)
            {
                int bestScore = -800;
                for (int i = 0; i< board.Length;i++)
                {
                    if(board[i] == " ")
                    {
                        board[i] = botSymbol;
                        int score = minimax(board, depth + 1, false, botSymbol);
                        board[i] = " ";
                        if (score > bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 800;
                for (int i = 0; i< board.Length;i++)
                {
                    if(board[i] == " ")
                    {
                        board[i] = humanSymbol;
                        int score = minimax(board, depth + 1, true, botSymbol);
                        board[i] = " ";
                        if(score < bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }
                return bestScore;
            }
        }

        public static int aiMove(string[] board, string botSymbol)
        {
            int bestScore = -800;
            int bestMove = 0;

            for (int i=0; i< board.Length;i++)
            {
                if (board[i] == " ")
                {
                    board[i] = botSymbol;
                    int score = minimax(board, 0, false, botSymbol);
                    board[i] = " ";
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }
            return bestMove;
        }
    }

}
