using System;

namespace Labyrinth
{
    internal struct Message
    {
        private static string invalidMoveMsg = "Invalid move!";
        private static string welcomeMsg = "Welcome to \"Labyrinth\" game. \n" +
            "Please try to escape. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n";
        private static string enterMoveMsg = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        private static string enterNameForScoreBoardMsg = "\nPlease enter your name for the top scoreboard: ";
        private static string scoreBoardEmptyMsg = "The scoreboard is empty.";
        private static string invalidCommandMsg = "\nInvalid command!\n";
        private static string goodByeMsg = "Good Bye";

        internal static string InvalidMoveMsg
        {
            get 
            {
                return invalidMoveMsg; 
            }            
        }        
        internal static string InvalidCommandMsg
        {
            get
            {
                return invalidCommandMsg; 
            }            
        }        
        internal static string ScoreBoardEmptyMsg
        {
            get
            {
                return scoreBoardEmptyMsg; 
            }           
        }
        internal static string EnterNameForScoreBoardMsg
        {
            get 
            {
                return enterNameForScoreBoardMsg; 
            }            
        }        
        internal static string GoodByeMsg
        {
            get 
            {
                return goodByeMsg;
            }            
        }
        internal static string EnterMoveMsg
        {
            get
            {
                return enterMoveMsg; 
            }            
        }        
        internal static string WelcomeMsg
        {
            get 
            {
                return welcomeMsg; 
            }
        }
    }
}