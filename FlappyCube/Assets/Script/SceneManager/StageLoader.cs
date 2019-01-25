using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public enum Scenes
{
    Title,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
}

public class StageLoader : MonoBehaviour, IEndStageEventReceiver
{
    [SerializeField]
    string[] defaultSceneNames;

    [SerializeField]
    Object[][] scenes;

    [SerializeField]
    Dictionary<int, int> dic = null;

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
        //ロードしてアンロードしないと一瞬レンダリングされない
        foreach (var d in defaultSceneNames)
        {
            SceneManager.UnloadSceneAsync(d);
        }

        foreach (var d in defaultSceneNames)
        {
            SceneManager.LoadSceneAsync(d, LoadSceneMode.Additive);
        }
    }

    public void ExecuteEndEvent(string currentSceneName)
    {
        SceneManager.UnloadSceneAsync(currentSceneName);

        //次のシーンをロード
        SceneManager.LoadSceneAsync("TestScene", LoadSceneMode.Additive);
    }
}