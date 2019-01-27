using UnityEngine;
using UnityEngine.EventSystems;

public class AddScoreEventDispatcher : MonoBehaviour
{
    GameObject target = null;

    private void Start()
    {
        target = GameObject.Find("ScoreManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        ExecuteEvents.Execute<IAddScoreEventReceiver>(
            target: target,
            eventData: null,
            functor: (target, eventData) => target.OnExecuteAddEvent()
            );

        gameObject.SetActive(false);
    }
}
