using UnityEngine;

namespace Ingame
{
    public class PlaceableItem : MonoBehaviour
    {
        private PlayGroundCell _attachedCell;

        public void AttachCell(PlayGroundCell playGroundCell)
        {
            _attachedCell = playGroundCell;
        }

        public void RemoveCell()
        {
            _attachedCell = null;
        }
    }
}