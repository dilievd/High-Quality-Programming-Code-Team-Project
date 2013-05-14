High-Quality Code Construction "Escape from Labyrinth" Game
=========
<p>Your task is to write an interactive <strong>console-based game</strong> in which the play<strong>er should escape from a labyrinth of size 7 x 7 cells</strong>. Each cell is  either free (<strong>‘-‘</strong>) or occupied (<strong>‘X’</strong>). The labyrinth should consist of randomly  generated free and occupied cells and the player’s position is initially in its  center. The player is shown as <strong>‘*’</strong>.  In the <strong>randomly generated labyrinth</strong> at least one <strong>exit</strong> should always be  reachable by a sequence of moves in the standard 4 directions: left, right, up,  down. At each turn the player enters a single letter – the <strong>direction to follow</strong> (<strong>L</strong> -  left, <strong>R</strong> - right, <strong>U</strong> - up, <strong>D</strong> - down). Directions can be given by small or capital letters. As  a response the computer either moves the player position to the specified empty  cell or indicates that the cell is occupied and the requested move is illegal.  If the player’s position reaches some of the <strong>labyrinth’s walls</strong>, the game is considered finished. When the game  is finished, the number of moves is printed along with congratulations message  and a new game automatically starts.<br />
  The player can request starting a new game in a new  labyrinth by entering the command <strong>'restart'</strong>.  Your program should implement a <strong>local  top scoreboard</strong> which keeps the best results and the names of their authors.  Initially, at the program start, the scoreboard is empty. It keeps the <strong>top 5 results</strong> sorted in ascending order  by the number of valid moves performed. When a game is finished by exiting from  the labyrinth, the player’s result can enter in the top scoreboard if his or  her number of moves is less than some of the other achievements staying in the  top scoreboard. When the player’s result enters the scoreboard, the player  should enter his or her name or nickname. The player can request printing the  top scoreboard during the game by entering the command <strong>'top'</strong>. The player can request stopping the game and exiting from  the program the command <strong>'exit'</strong>.</p>


<pre>
Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game
and 'exit' to quit the game.
- - X X X X -
- X - - - - X
- X - X X - X
- X - * X - X
- X - X - - -
- X - - - X X
X - X - - X X
Enter your move (L=left, R-right, U=up, D=down):<i>L</i>
- - X X X X -
- X - - - - X
- X - X X - X
- X * - X - X
- X - X - - -
- X - - - X X
X - X - - X X
Enter your move (L=left, R-right, U=up, D=down): <i>L</i>
Invalid move!
Enter your move (L=left, R-right, U=up, D=down): <i>top</i>
The scoreboard is empty.
Enter your move (L=left, R-right, U=up, D=down): <i>D</i>
- - X X X X -
- X - - - - X
- X - X X - X
- X - - X - X
- X * X - - -
- X - - - X X
X - X - - X X
Enter your move (L=left, R-right, U=up, D=down):<i>D</i>
- - X X X X -
- X - - - - X
- X - X X - X
- X - - X - X
- X - X - - -
- X * - - X X
X - X - - X X
Enter your move (L=left, R-right, U=up, D=down):<i> R</i>
- - X X X X -
- X - - - - X
- X - X X - X
- X - - X - X
- X - X - - -
- X - * - X X
X - X - - X X
Enter your move (L=left, R-right, U=up, D=down): <i>D</i>
Congratulations! You escaped in 5 moves.
Please enter your name for the top scoreboard: Bay Ivan
Scoreboard:
1. Bay Ivan --> 5 moves
Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game
and 'exit' to quit the game.
- - X X - X -
X X - - - - X
- - X - X - X
- X - * X - X
- - - X - - -
- X - - - X -
X - X X - - -
Enter your move (L=left, R-right, U=up, D=down): <i>R</i>
Invalid move!
Enter your move (L=left, R-right, U=up, D=down): <i>win</i>
Invalid command!
Enter your move (L=left, R-right, U=up, D=down): <i>top</i>
Scoreboard:
1. Bay Ivan --> 5 moves
Enter your move (L=left, R-right, U=up, D=down): restart
Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game 
and 'exit' to quit the game.
- - X X - X -
X - X - X - X
X X - - - - X
- - X * X - X
X - - X - - -
- - - - - X -
X - X X - - -
Enter your move (L=left, R-right, U=up, D=down): <i>exit</i>
Good Bye!

</pre>

Some players could try to cheat by entering illegal moves, so be cautious and <b>prevent illegal input</b>.
