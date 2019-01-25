using UnityEngine;

public class Move : MonoBehaviour, IHitEventReceiver
{
    [SerializeField]
    float speed = 1.0f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void Execute()
    {
        enabled = false;
    }
}
