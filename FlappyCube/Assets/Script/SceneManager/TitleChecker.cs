using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChecker : MonoBehaviour
{
    void Start()
    {
        //この処理挟むならクラス名を変えたい
#if !UNITY_EDITOR
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
        return;
#endif

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
