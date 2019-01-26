using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

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

#if UNITY_EDITOR
        if (target == null)
        {
            Time.timeScale = 0.0f;
            return;
        }
#endif

        var current = gameObject.scene.name;

        ExecuteEvents.Execute<IEndStageEventReceiver>(
            target: target,
            eventData: null,
            functor: (target, eventData) => target.ExecuteEndEvent(current)
            );
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(!Input.GetKeyDown(KeyCode.R))
            return;

        Reload();
    }

    private void OnGUI()
    {
        if (target != null)
            return;

        if (GUI.Button(new Rect(20, 20, 100, 50), "Reload"))
        {
            Reload();
        }
    }

    void Reload()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(gameObject.scene.name);
    }
#endif
}
