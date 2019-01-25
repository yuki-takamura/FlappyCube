using UnityEngine;
using UnityEngine.EventSystems;

public class HitBrockBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject eventTarget = null;

    void Start() => eventTarget = GameObject.Find("Mover");

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        ExecuteEvents.Execute<IHitEventReceiver>(
            target: eventTarget,
            eventData: null,
            functor: (eventTarget, eventData) => eventTarget.Execute()
            );
    }
}
