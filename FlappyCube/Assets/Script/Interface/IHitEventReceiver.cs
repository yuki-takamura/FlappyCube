using UnityEngine.EventSystems;

public interface IHitEventReceiver : IEventSystemHandler
{
    void Execute();
}
