using _Root.MovementFeature.Application;
using _Root.MovementFeature.Domain;
using UnityEngine;
using Zenject;

namespace _Root.MovementFeature.Infrastructure
{
    public class MovementInstaller : MonoInstaller
    {
        [SerializeField] private MovementAdapter _movementAdapter;
        [SerializeField] private MovementConfig _movementConfig;

        public override void InstallBindings()
        {
            // NOTE: Я использовал FromInstance вместо FromMethod
            Container.Bind<MovementModel>().FromInstance(_movementConfig.ToModel()).AsSingle().NonLazy();
            Container.Bind<MovementState>().AsSingle().NonLazy();
            Container.Bind<MovementUsecase>().AsSingle().NonLazy();
            Container.Bind<MovementSystem>().AsSingle().Lazy();

            Container.BindInterfacesAndSelfTo<MovementAdapter>().FromComponentInHierarchy().AsSingle();
            /// NOTE: Пока что так. Объяснил в /Assets/_Root/Player/Infrastructure/PlayerInstaller.cs
        }
    }
}