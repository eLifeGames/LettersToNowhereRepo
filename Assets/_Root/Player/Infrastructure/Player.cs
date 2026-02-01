using _Root.Player.Domain;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class Player : MonoBehaviour
    {
        private PlayerModel _playerModel;
        
        [Inject]
        private void Constuct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }
        // TODO
    }
}