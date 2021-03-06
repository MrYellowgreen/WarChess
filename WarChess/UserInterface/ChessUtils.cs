﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface
{
    public static class ChessUtils
    {
        /// <param name="row">Indexing from 0</param>
        /// <param name="column">Indexing from 0</param>
        /// <param name="rowCount">Total count of rows</param>
        /// <returns></returns>
        public static ChessPosition GetPosition(int row, int column, int rowCount)
        {
            return new ChessPosition(('a' + column).ToString() + ('0' + (rowCount - row))); 
        }

        public static Bitmap[,] SelectAllBoard<TCell>(IChessBoard<TCell> board, ICellBitmapSelector<TCell> selector) // not here
        {
            var bitmaps = new Bitmap[board.RowCount, board.ColumnCount];
            for (int row = 0; row < board.RowCount; ++row)
            for (int column = 0; column < board.ColumnCount; ++column)
                bitmaps[row, column] = selector.SelectBitmap(board[GetPosition(row, column, board.RowCount)]);
            return bitmaps;
        }
    }
}
