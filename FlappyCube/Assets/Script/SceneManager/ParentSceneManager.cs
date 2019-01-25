using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentSceneManager : MonoBehaviour
{
    [SerializeField]
    string[] dontDestroyScenes;

    [SerializeField]
    string[] defaultSceneNames;

    [SerializeField]
    Object[][] scenes;

    void Start()
    {
        foreach (var d in defaultSceneNames)
        {
            SceneManager.LoadSceneAsync(d, LoadSceneMode.Additive);
        }
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.R))
            return;

        Reload();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 50), "Retry"))
        {
            Reload();
        }

        //TODO:これはここで書くべきではないので修正する
        if (GUI.Button(new Rect(120, 20, 100, 50), "Pause"))
        {
            Time.timeScale = 0.0f;
        }
    }

    void Reload()
    {
        foreach (var d in defaultSceneNames)
        {
            SceneManager.LoadSceneAsync(d, LoadSceneMode.Additive);
        }

        foreach (var d in defaultSceneNames)
        {
            SceneManager.UnloadSceneAsync(d);
        }
    }
}
