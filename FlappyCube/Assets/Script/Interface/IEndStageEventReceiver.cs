using UnityEngine.EventSystems;

public interface IEndStageEventReceiver : IEventSystemHandler
{
    void ExecuteEndEvent(string currentSceneName);
}