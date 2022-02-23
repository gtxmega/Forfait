using UnityEngine;

namespace Game.GeneratePoses
{
    [CreateAssetMenu(menuName = "Cube/Poses/Pose data", fileName = "Pose")]
    public class Pose : ScriptableObject
    {
        public Sprite SpriteView => _spriteView;
        public string PoseName => _poseName;
        public string PoseDescription => _poseDescription;


        [SerializeField] private Sprite _spriteView;
        [SerializeField] private string _poseName;
        [SerializeField] private string _poseDescription;
    }
}