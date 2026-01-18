using _Root.Shared.Ports.Input;

using Zenject;

namespace _Root.Input.Infrastructure
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
            => Container.Bind<IInputPort>().To<InputPort>().AsSingle().NonLazy();
    }
}