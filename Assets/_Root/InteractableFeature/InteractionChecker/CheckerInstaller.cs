using UnityEngine;
using Zenject;

namespace _Root.InteractableFeature.InteractionChecker
{
    public class CheckerInstaller : MonoInstaller
    {
        [SerializeField] private InteractionsDetector _interactionsDetector;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InteractionsDetector>().FromInstance(_interactionsDetector).AsSingle().NonLazy();
        }
    }
}