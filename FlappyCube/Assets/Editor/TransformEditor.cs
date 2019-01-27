//参考　https://qiita.com/r-ngtm/items/bc0843e2f8a7c610353a

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{
    //グリッドの幅
    public const float Grid = 1.0f;

    void OnSceneGUI()
    {
        //グリッドの色
        Color color = Color.cyan * 0.7f;

        //グリッドの中心座標
        Vector3 orig = Vector3.zero;

        const int num = 10;
        const float size = Grid * num;

        Vector3 right = new Vector3(1f, 0f, 0f);
        Vector3 up = new Vector3(0f, 0f, 1f);
        Vector3 left = -right;
        Vector3 down = -up;
        //グリッド描画
        for (int x = -num; x <= num; x++)
        {
            Vector3 pos = orig + right * x * Grid;
            Debug.DrawLine(pos + up * size, pos + down * size, color);
        }
        for (int y = -num; y <= num; y++)
        {
            Vector3 pos = orig + up * y * Grid;
            Debug.DrawLine(pos + left * size, pos + right * size, color);
        }

        foreach (Transform transform in Selection.transforms)
        {
            //グリッドの位置にそろえる
            var posGrid = Grid * 0.5f;
            Vector3 position = transform.transform.position;
            position.x = Mathf.Floor(position.x / posGrid) * posGrid;
            position.y = Mathf.Floor(position.y / posGrid) * posGrid;
            position.z = Mathf.Floor(position.z / posGrid) * posGrid;
            transform.transform.position = position;

            Vector3 scale = transform.transform.localScale;
            scale.x = Mathf.Floor(scale.x / Grid) * Grid;
            scale.y = Mathf.Floor(scale.y / Grid) * Grid;
            scale.z = Mathf.Floor(scale.z / Grid) * Grid;
            transform.transform.localScale = scale;
        }

        //Sceneビュー更新
        EditorUtility.SetDirty(target);
    }

    //フォーカスが外れたときに実行
    void OnDisable()
    {
        //Sceneビュー更新
        EditorUtility.SetDirty(target);
    }
}
#endif //UNITY_EDITOR