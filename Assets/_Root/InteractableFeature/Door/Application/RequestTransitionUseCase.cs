using _Root.InteractableFeature.Door.Application.Interfaces;
using _Root.InteractableFeature.Door.Domain;
using Cysharp.Threading.Tasks;

namespace _Root.InteractableFeature.Door.Application
{
    public class RequestTransitionUseCase
    {
        private readonly DoorModel _doorModel;
        private ILocationLoader _locationLoader;

        public RequestTransitionUseCase(DoorModel doorModel, ILocationLoader locationLoader)
        {
            _doorModel = doorModel;
            _locationLoader = locationLoader;
        }

        public async UniTask ChangeLocationAsync()
        {
            await _locationLoader.LoadLocation(_doorModel.Transition.LocationToID);
        }
    }
}