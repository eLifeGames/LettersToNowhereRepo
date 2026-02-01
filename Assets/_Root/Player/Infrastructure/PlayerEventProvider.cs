
using System;
using System.Collections.Generic;
using _Root.Player.Domain;
using _Root.Shared.Ports.Player;
using _Root.Shared.Ports.Player.Events;
using UnityEngine;

namespace _Root.Player.Infrastructure
{
    public class PlayerEventsProvider : IPlayerEventProvider
    {
        private readonly List<Action<PlayerEvent>> _subscribers = new();

        public IDisposable Subscribe<T>(Action<T> onEvent) where T : PlayerEvent
        {
            void Wrapper(PlayerEvent playerEvent)
            {
                if (playerEvent is T typedEvent)
                    onEvent(typedEvent);
            }

            _subscribers.Add(Wrapper);
            return new PlayerEventSubscription(() => _subscribers.Remove(Wrapper));
        }

        public void Raise<T>(T playerEvent) where T : PlayerEvent
        {
            foreach (var subscriber in _subscribers)
                subscriber(playerEvent);
        }
    }
}