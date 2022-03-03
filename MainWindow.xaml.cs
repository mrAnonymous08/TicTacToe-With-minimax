using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.IO;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        bool gameInProgress = false;
        string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        string botSymbol = "x"; 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void resetBoard()
        {
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";

            for (int i = 0; i < 9; i++)
            {
                board[i] = " ";
            }
        }
        private void makeAiMove(int move)
        {
            board[move] = "x";
            if (move == 0)
            {
                button1.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 1)
            {
                button2.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 2)
            {
                button3.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 3)
            {
                button4.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 4)
            {
                button5.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 5)
            {
                button6.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 6)
            {
                button7.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 7)
            {
                button8.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }
            else if (move == 8)
            {
                button9.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine( Directory.GetCurrentDirectory(), "x.png"))) };
            }

        }

        private void disableAllButton()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false; 
            button5.IsEnabled = false; 
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }

        private void enableAllButton()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled= true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled= true;
            button9.IsEnabled= true;
            button8.IsEnabled = true;
        }

        private void play_with_ai(object sender, RoutedEventArgs e)
        {
            if (gameInProgress == true)
            {
                MessageBoxResult result = MessageBox.Show("Do you Want to Abort this game", "Are Your Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    resetBoard();
                    enableAllButton();
                    plrLbl.Text = "AI Thinking";
                    gameInProgress = true;
                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);
                    plrLbl.Text = "Your Turn";
                }
            }
            else
            {
                resetBoard();
                enableAllButton();
                plrLbl.Text = "Ai Thinking";
                
                int move = TicTacToeHelper.aiMove(board, botSymbol);
                makeAiMove(move);
                plrLbl.Text = "Your Turn";
                gameInProgress = true;
            }

        }

        private void restart_click(object sender, RoutedEventArgs e)
        {
            resetBoard();
            gameInProgress = false;
            disableAllButton();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            if (TicTacToeHelper.spaceIsFree(board, 0) == true && gameInProgress == true)
            {
                
                button1.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[0] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress=false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 1) == true )
            {

                button2.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[1] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 2) == true && gameInProgress == true)
            {

                button3.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[2] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                MessageBox.Show("gameInProgress = true;");
                SystemSounds.Beep.Play();
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 3) == true && gameInProgress == true)
            {

                button4.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[3] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 4) == true && gameInProgress == true)
            {

                button5.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[4] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 5) == true && gameInProgress == true)
            {

                button6.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[5] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 6) == true && gameInProgress == true)
            {

                button7.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[6] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 7) == true && gameInProgress == true)
            {

                button8.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[7] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if (TicTacToeHelper.spaceIsFree(board, 8) == true && gameInProgress == true)
            {

                button9.Content = new Image { Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "o.png"))) };
                board[8] = "o";

                if (TicTacToeHelper.isWinner(board, "o") == true)
                {

                    MessageBox.Show("You Win", "Congrates", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else if (TicTacToeHelper.checkDraw(board) == true)
                {
                    MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetBoard();
                    disableAllButton();
                    gameInProgress = false;
                }
                else
                {
                    plrLbl.Text = "AI Thinking";

                    int move = TicTacToeHelper.aiMove(board, botSymbol);
                    makeAiMove(move);

                    if (TicTacToeHelper.isWinner(board, "x") == true)
                    {

                        MessageBox.Show("AI Wins", "You Lost", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }
                    else if (TicTacToeHelper.checkDraw(board) == true)
                    {
                        MessageBox.Show("Game Tied", "Draw", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetBoard();
                        disableAllButton();
                        gameInProgress = false;
                    }

                    plrLbl.Text = "Player O Turn";
                }

            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }
    }
}
