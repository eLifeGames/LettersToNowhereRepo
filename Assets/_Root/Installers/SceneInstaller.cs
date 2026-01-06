using Zenject;

namespace Assets._Root.Installers
{
    /// <summary>
    /// Scene Dep Installer (Binder)
    /// </summary>
    public class SceneInstaller : MonoInstaller
    {
        public override bool IsEnabled => false;
        
        public override void InstallBindings()
        {
            // TODO: Пока нот юзед
        }
    }
}