using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Test
{
    class DerivedLabyrinthEngine : LabyrinthEngine
    {
        private int[,] labyrinthMatrix = new int[LABYRINTH_SIZE, LABYRINTH_SIZE];

        public DerivedLabyrinthEngine(int[,] matrix) : base()
        {
            this.labyrinthMatrix = matrix;
            this.CreateLabyrinth();
        }

        protected override void CreateLabyrinth()
        {
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {                    
                    if (this.labyrinthMatrix[row, column] == 0)
                    {
                        this.labyrinth[row, column] = new Cell(row, column, EMPTY_CELL);
                        this.dummyLabyrinth[row, column] = new Cell(row, column, EMPTY_CELL);
                    }
                    else
                    {
                        this.labyrinth[row, column] = new Cell(row, column, WALL_CELL);
                        this.dummyLabyrinth[row, column] = new Cell(row, column, WALL_CELL);
                    }
                }
            }
            this.labyrinth[this.CurrentCell.Row, this.CurrentCell.Column] =
                new Cell(this.CurrentCell.Row, this.CurrentCell.Column, PLAYER);
            this.dummyLabyrinth[this.CurrentCell.Row, this.CurrentCell.Column] =
                new Cell(this.CurrentCell.Row, this.CurrentCell.Column, PLAYER);
        }

    }
}
