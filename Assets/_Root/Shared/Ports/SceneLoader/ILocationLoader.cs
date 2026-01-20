using Cysharp.Threading.Tasks;

namespace _Root.InteractableFeature.Door.Application.Interfaces
{
    public interface ILocationLoader
    {
        UniTask LoadLocation(string location);
    }
}