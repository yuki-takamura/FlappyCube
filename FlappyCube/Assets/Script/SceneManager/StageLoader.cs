using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public enum EScenes
{
    //Title,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
}

public class StageLoader : MonoBehaviour, IEndStageEventReceiver
{
    [SerializeField]
    string defaultStageName = null;

    string currentStageName;

    [SerializeField]
    string[] stageNames = null;

    Dictionary<string, EScenes> dic = new Dictionary<string, EScenes>();

    void Start()
    {
        for(int i = 0; i < stageNames.Length; i++)
        {
            dic.Add(stageNames[i], (EScenes)i);
        }

        SceneManager.LoadSceneAsync(defaultStageName, LoadSceneMode.Additive);
        currentStageName = defaultStageName;
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
        //ロードしてアンロードしないと一瞬レンダリングされない?
        //ビルド版だと今のところ大丈夫
        SceneManager.UnloadSceneAsync(currentStageName);

        SceneManager.LoadSceneAsync(currentStageName, LoadSceneMode.Additive);
    }

    public void ExecuteEndEvent(string endStageName)
    {
        SceneManager.UnloadSceneAsync(endStageName);

        //次のシーンをロード
        var current = (int)dic[endStageName] + 1;
        if(current >= stageNames.Length)
        {
            current = 0;
        }
        SceneManager.LoadSceneAsync(stageNames[current],
            LoadSceneMode.Additive);
        currentStageName = stageNames[current];
    }
}