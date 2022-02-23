using UnityEngine;

namespace Game.GenerateForfeit
{
    [CreateAssetMenu(menuName = "Forfeit/Forfeit", fileName = "Forfeit data")]
    public class Forfeit : ScriptableObject
    {
        public string Description => _description;

        [SerializeField] private string _description;
    }
}