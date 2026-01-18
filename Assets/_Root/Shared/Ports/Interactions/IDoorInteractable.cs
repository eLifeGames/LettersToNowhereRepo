
namespace _Root.Shared.Ports.Interactions
{
    public interface IDoorInteractable : IInteractable
    {
        void SetupMovementLock();
    }
}