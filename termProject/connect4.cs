/*********************************************************
*                                                        *
*                      Kyle Taylor                       *
*                                                        *
**********************************************************/
using System;

//Declares the namespace
namespace connect4 {
    //Declares the c4 class
    class c4 {
        private int row, column, winLength;
        private int [,] board;
        
        //Constructor for the c4 class
        public c4 (int r, int c, int w, int [,] b) {
            row = r;
            column = c;
            winLength = w;
            board = b;
        }

        /*------------------------------------------------------------------------------
         * The main method is responsible for taking command line arguments and
         * dividing them up into the rows, columns, and win length that will be used
         * for the Connect 4 board.
         */
        static void Main(string[] args) {
            string[] rc;
            int rw = 0, cl = 0, wl = 0;
            // Takes command line arguments for rows, columns, and win length
            if (args.Length == 2) {
                wl = Int32.Parse(args[1]);
                rc = args[0].Split('x');
                rw = Int32.Parse(rc[0]);
                cl = Int32.Parse(rc[1]);
                // Invalid command line parameters
                if (rw > 16 || cl > 16 || rw < 2 || cl < 2 || wl < 2 || (wl > rw && wl > cl)) {
                    Console.WriteLine("Goodbye.");
                    System.Environment.Exit(1);
                }
            // Command line parameters are either in the wrong format or not given
            } else {
                rw = 6;
                cl = 7;
                wl = 4;
            }
            int [,] brd = new int[rw, cl];
            c4 properties = new c4(rw, cl, wl, brd);
            properties.playGame();
        }

        /*------------------------------------------------------------------------------
         * Starts the Connect 4 game
         */
        private void playGame() {
            Console.WriteLine("Connect 4 with {0}x{1} and {2}", row, column, winLength);
            // Console.WriteLine("{0}", board[0,0]);
            turn(1);
        }

        /*------------------------------------------------------------------------------
         * Prints out the column header for the Connect 4 board
         */
        private void printHeader() {
            //Prints out the column header based upon the number of columns
            for (int i = 0; i < column; i++) {
                Console.Write("{0} ", (char)(i + 65));
            }
            Console.WriteLine();
        }
        
        /*------------------------------------------------------------------------------
         * Prints out the Connect 4 board
         */
        private void printBoard() {
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < column; j++) {
                    Console.Write("{0} ", board[i,j]);
                }
                Console.WriteLine();
            }
        }

        /*------------------------------------------------------------------------------
         * Handles the players turn and takes user input for what column to drop a
         * token into.
         */
        private void turn(int player) {
            char dropColCh = 'a';
            int dropCol;
            printHeader();
            printBoard();
            Console.Write("Player {0}, which Column? ", player);
            dropColCh = Console.ReadLine()![0];
            // Ends the program when the user enters a q or Q.
            if (dropColCh == 'q' || dropColCh == 'Q') {
                Console.WriteLine("Goodbye.");
                System.Environment.Exit(1);
            // Determines column to drop token into based on user input.
            } else {
                dropCol = dropColCh - '0' - 17;
                // Allows for lowercase and uppercase column choices.
                if ((dropCol >= 0 && dropCol <= (column - 1)) || (dropCol >= 32 && dropCol <= (column - 1) + 32)) {
                    Console.Write(dropCol);
                // Column is invalid, the player will need to try again. 
                } else {
                    Console.WriteLine("Oops! Column {0} is invalid! Try again!", dropColCh);
                    turn(player);
                }
            }
            // dropToken(player, );
            turn(3 - player);
        }
    }
}