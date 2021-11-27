using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayGroundCell : MonoBehaviour
    {
        private const float GIZMOS_SPHERE_SIZE = .3f;
        
        private Dictionary<Direction, PlayGroundCell> _neighbourCells = new Dictionary<Direction, PlayGroundCell>();
        private PlaceableItem _attachedPlaceableItem;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, GIZMOS_SPHERE_SIZE);
            
            if(_neighbourCells.Count < 1)
                return;

            foreach (var cellPair in _neighbourCells)
            {
                if(cellPair.Value == null)
                    continue;
                
                Gizmos.DrawLine(transform.position, cellPair.Value.transform.position);
            }
        }

        public void AssignNeighbourCell(Direction cellDirectionRelativeToThisCell, PlayGroundCell cellToAdd)
        {
            _neighbourCells.Add(cellDirectionRelativeToThisCell, cellToAdd);
        }

        public void AttachPlaceableItem(PlaceableItem _placeableItem)
        {
            _attachedPlaceableItem = _placeableItem;
        }
    }

    public enum Direction
    {
        OnRight,
        OnLeft,
        OnUp,
        OnDown
    }
}