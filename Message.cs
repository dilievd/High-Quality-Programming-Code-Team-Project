using System;

namespace Labyrinth
{
    internal struct Message
    {
        private static string invalidMove = "Invalid move!";
        private static string welcome = "Welcome to \"Labyrinth\" game. \n" +
            "Please try to escape. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n";
        private static string enterMove = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        private static string enterNameForScoreBoard = "\nPlease enter your name for the top scoreboard: ";
        private static string scoreBoardEmpty = "The scoreboard is empty.";
        private static string invalidCommand = "\nInvalid command!\n";
        private static string goodBye = "Good Bye";

        internal static string InvalidMove
        {
            get 
            {
                return invalidMove; 
            }            
        }        
        internal static string InvalidCommand
        {
            get
            {
                return invalidCommand; 
            }            
        }        
        internal static string ScoreBoardEmpty
        {
            get
            {
                return scoreBoardEmpty; 
            }           
        }
        internal static string EnterNameForScoreBoard
        {
            get 
            {
                return enterNameForScoreBoard; 
            }            
        }        
        internal static string GoodBye
        {
            get 
            {
                return goodBye;
            }            
        }
        internal static string EnterMove
        {
            get
            {
                return enterMove; 
            }            
        }        
        internal static string Welcome
        {
            get 
            {
                return welcome; 
            }
        }
    }
}