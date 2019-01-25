using UnityEngine;
using UnityEngine.EventSystems;

public class EndSceneEventDispatcher : MonoBehaviour
{
    GameObject target = null;

    void Start()
    {
        target = GameObject.Find("SceneManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        var current = gameObject.scene.name;

        ExecuteEvents.Execute<IEndStageEventReceiver>(
            target: target,
            eventData: null,
            functor: (target, eventData) => target.ExecuteEndEvent(current)
            );
    }
}
