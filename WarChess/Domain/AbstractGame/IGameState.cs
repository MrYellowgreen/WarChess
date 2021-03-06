﻿namespace WarChess.Domain.AbstractGame
{
    public interface IGameState<out TField, in TPosition, TCell>
        where TField : IField<TPosition, TCell>
        where TPosition : IPosition
        where TCell : ICell
    {
        TField Field { get; }
    }
}