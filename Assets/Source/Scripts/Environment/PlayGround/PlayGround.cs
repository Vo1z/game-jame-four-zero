using System;
using UnityEngine;

namespace Ingame
{
    public class PlayGround : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int rowSize;
        [SerializeField] [Min(0)] private int columnSize;
        [SerializeField] [Min(0)] private float cellSpacing;
        [Space]
        [SerializeField] private PlayGroundCell[] cells;

        private Vector3 _initialPosition;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void Start()
        {
            PlaceCells();
        }

        private void PlaceCells()
        {
            var cellsArray = new PlayGroundCell[rowSize, columnSize];
            
            int cellIndex = 0;

            for (var column = 0; column < columnSize; column++)
            {
                for (var row = 0; row < rowSize; row++)
                {
                    if (cellIndex >= cells.Length)
                        return;

                    var cellPos = _initialPosition + Vector3.up * column * cellSpacing + Vector3.right * row * cellSpacing;
                    var selectedCell = cells[cellIndex];
                    
                    selectedCell.transform.position = cellPos;
                    cellsArray[column, row] = selectedCell;

                    if (column != 0 && column != columnSize - 1)
                    {
                        // selectedCell.AssignNeighbourCell();
                    }

                    cellIndex++;
                }
            }
        }
    }
}