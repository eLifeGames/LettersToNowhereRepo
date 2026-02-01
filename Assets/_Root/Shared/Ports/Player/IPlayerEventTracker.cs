
using System;
using _Root.Shared.Ports.Player.Events;

namespace _Root.Shared.Ports.Player
{
    public interface IPlayerEventProvider
    {
        IDisposable Subscribe<T>(Action<T> onEvent) where T : PlayerEvent;
    }
}