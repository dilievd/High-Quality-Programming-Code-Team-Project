using System;

namespace Labyrinth
{
    internal enum Message
    {
        InvalidMoveMsg = "Invalid move!",
        InvalidCommandMsg = "\nInvalid command!\n",
        ScoreBoardEmptyMsg = "The scoreboard is empty.",
        EnterNameForScoreBoardMsg = "\nPlease enter your name for the top scoreboard: ",
        GoodByeMsg = "Good Bye",
        EnterMoveMsg = "\nEnter your move (L=left, R-right, U=up, D=down): ",
        WelcomeMsg = "Welcome to \"Labyrinth\" game. \n" +
           "Please try to escape. \n" +
           "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n"
    }
}