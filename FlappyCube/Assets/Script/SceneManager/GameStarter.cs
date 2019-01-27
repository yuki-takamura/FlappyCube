using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    GameObject manager = null;

    void Start()
    {
        manager = GameObject.Find("SceneManager");   
    }

    void Update()
    {
        
    }

    private void OnGUI()
    {
        var o_w = Screen.width / 2;
        var o_h = Screen.height / 2;
        var b_width = 100;
        var b_height = 50;
        if (GUI.Button(new Rect(o_w - b_width/2, o_h - b_height/2, b_width, b_height), "Start"))
        {
            manager.GetComponent<StageLoader>().enabled = true;
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }
    }
}
