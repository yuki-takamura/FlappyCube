using UnityEngine.EventSystems;

public interface IAddScoreEventReceiver : IEventSystemHandler
{
    void OnExecuteAddEvent();
}