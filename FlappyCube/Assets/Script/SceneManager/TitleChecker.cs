using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChecker : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            //既にタイトルシーンが読み込まれているかを確認する
            var name = SceneManager.GetSceneAt(i).name;
            if (name == "Title")
            {
                return;
            }
        }

        GetComponent<StageLoader>().enabled = true;
    }
}
