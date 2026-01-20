using System;
using _Root.Player.Factory;
using UnityEngine;
using Zenject;

namespace _Root.Player.Infrastructure
{
    public class PlayerSpawner : MonoBehaviour
    {
        private PlayerFactory _playerFactory;
        [Inject]
        private void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        private void Start()
        {
            _playerFactory.Create(transform);
        }
    }
}