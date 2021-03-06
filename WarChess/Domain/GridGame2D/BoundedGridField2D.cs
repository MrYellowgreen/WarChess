﻿using System;
using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public class BoundedGridField2D<TCell>
        : IField<GridPosition2D, TCell>
        where TCell : ICell
    {
        public BoundedGridField2D(int rowsCnt, int columnsCnt) : this(rowsCnt, columnsCnt, new Point2D(0, 0))
        {
        }

        public BoundedGridField2D(int rowsCnt, int columnsCnt, Point2D center)
        {
            Grid = new TCell[rowsCnt, columnsCnt];
            Center = center;
        }

        private BoundedGridField2D(TCell[,] grid, Point2D center)
        {
            Center = center;
            Grid = grid;
        }

        private Point2D Center { get; }

        private TCell[,] Grid { get; }

        public TCell this[int x, int y] => this[new GridPosition2D(x, y)];

        public Size2D Size => new Size2D(Grid.GetLength(0), Grid.GetLength(1));

        public TCell this[GridPosition2D position]
        {
            get
            {
                if (!Contains(position))
                    throw new ArgumentException(nameof(position));
                var arrayPosition = (Point2D) position - Center;
                return Grid[arrayPosition.X, arrayPosition.Y];
            }
        }

        public bool Contains(GridPosition2D position)
        {
            var arrayPosition = (Point2D) position - Center;
            return Utilities.IsInInterval(arrayPosition.X, 0, Grid.GetLength(0)) &&
                   Utilities.IsInInterval(arrayPosition.Y, 0, Grid.GetLength(1));
        }

        public BoundedGridField2D<TCell> GetWith(TCell cell, GridPosition2D position)
        {
            var newGrid = (TCell[,]) Grid.Clone();
            position = (GridPosition2D) ((Point2D) position - Center);
            newGrid[position.X, position.Y] = cell;
            return new BoundedGridField2D<TCell>(newGrid, Center);
        }
    }
}