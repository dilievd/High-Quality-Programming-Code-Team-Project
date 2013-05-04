﻿using System;

namespace Labyrinth
{
    class Cell
    {
        public const char EMPTY_CELL = '-';
        public const char WALL_CELL = 'X';

        public int Row { get; set; }
        public int Col { get; set; }
        public char ValueChar { get; set; }

        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.ValueChar = value;
        }

        public bool IsEmpty()
        {
            if(this.ValueChar == EMPTY_CELL)
            {
                return true;
            }

            return false;
        }
    }
}
