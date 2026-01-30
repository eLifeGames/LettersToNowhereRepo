using _Root.InteractableFeature.Door.Application;
using _Root.InteractableFeature.Door.Domain;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class DoorInstaller : MonoInstaller
    {
        [SerializeField] private DoorView _doorView;
        [SerializeField] private DoorConfig _doorConfig;
        public override void InstallBindings()
        {
            Container.Bind<DoorModel>().FromInstance(_doorConfig.ToModel()).AsSingle().NonLazy();
            Container.Bind<ToggleMovementSetupUseCase>().AsSingle().NonLazy();
            Container.Bind<RequestTransitionUseCase>().AsSingle().NonLazy();
            Container.Bind<DoorView>().FromInstance(_doorView).AsSingle().NonLazy();
        }
    }
}