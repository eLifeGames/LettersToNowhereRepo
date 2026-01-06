using Assets.Settings;
using Zenject;

namespace Assets._Root.Installers
{
    /// <summary>
    /// Global Dep Installer (Binder)
    /// </summary>
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProjectInputActions>().FromNew().AsSingle().NonLazy();
        }
    }
}