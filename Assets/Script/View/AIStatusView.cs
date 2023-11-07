using UnityEngine;

namespace View
{
    public class AIStatusView : MonoBehaviour
    {
        [SerializeField] MeshRenderer _headObjectRenderer;
        public enum Status
        {
            Normal = 0, Listening, Thinking, Error
        }
        private Color[] _statusColors = new[]{Color.cyan, Color.white, Color.yellow, Color.red};

        public Status CurrentStatus
        {
            set
            {
                _headObjectRenderer.material.color = _statusColors[(int)value];
            }
        }
    }
}
        
