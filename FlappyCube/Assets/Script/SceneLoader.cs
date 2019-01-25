using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 50), "Retry"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}