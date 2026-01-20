using _Root.InteractableFeature.Door.Application.Interfaces;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class LocationLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILocationLoader>().To<LocationLoader>().AsSingle().NonLazy();
        }
    }
}