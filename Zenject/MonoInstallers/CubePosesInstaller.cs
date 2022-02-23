using UnityEngine;
using Zenject;

namespace Game.Zenject.MonoInstallers
{
    public class CubePosesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _cubePosesImplement;

        public override void InstallBindings()
        {


        }
    }
}