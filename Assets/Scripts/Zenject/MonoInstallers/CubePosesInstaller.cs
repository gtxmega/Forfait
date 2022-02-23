using UnityEngine;
using Zenject;

using Game.GeneratePoses;

namespace Assets.Scripts.Zenject.MonoInstallers
{
    public class CubePosesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _cubePosesObject;

        public override void InstallBindings()
        {
            Container
                .Bind<IGeneratePose>()
                .To<GeneratePose>()
                .FromComponentsOn(_cubePosesObject)
                .AsSingle();
        }
    }
}