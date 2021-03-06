﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.Application
{
    public class ChessApp : ChessBoardApp<ChessGame, IChessAlikePiece>, 
        IChessAlikeApp<ChessGame, IChessAlikePiece>
    {
        public ChessPosition SelectedPiecePosition { get; set; }
        public override event Action StateChanged;

        public ChessApp(ChessGame game) : base(game)
        {
        }

        private void Select(ChessPosition position)
        {
            SelectedPiecePosition = position;
            StateChanged?.Invoke();
        }

        public override void ClickAt(ChessPosition position)
        {
            if (SelectedPiecePosition == position)
                Select(null);
            var piece = game.Board[position];
            if (piece?.Color == game.WhoseTurn)
                Select(position);
            if (SelectedPiecePosition != null && piece != null)
            {
                if (game.TryMakeMove(SelectedPiecePosition, position))
                {
                    // maybe increment move number or something else
                    SelectedPiecePosition = null;
                    StateChanged?.Invoke();
                }
                else
                    Select(null);
            }
        }
    }
}
