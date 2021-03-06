﻿using System;
using System.Drawing;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface.WarChessUI
{
    public class WarChessCellBitmapSelector : ICellBitmapSelector<IChessAlikePiece>
    {   // PROBABLY IT'S ENOUGH TO USE USUAL CHESS BITMAP SELECTOR
        // INSTEAD OF WAR CHESS APP WE CAN USE IChessAlikeApp
        private readonly IChessStyle style;

        private readonly ChessApp app;

        // здесь нужен не IWarChessGame, а класс с уровня application
        public WarChessCellBitmapSelector(IChessStyle style, ChessApp app)
        {
            // if piece is visible - select bitmap, othervise - transparent bitmap
            this.style = style;
            this.app = app;
        }

        public int BitmapWidth => style.BitmapWidth;
        public int BitmapHeight => style.BitmapHeight;

        public Bitmap SelectBitmap(IChessAlikePiece alikePiece)
        {
            // Тут, видимо, будет визитор.
            throw new NotImplementedException();
        }
    }
}
