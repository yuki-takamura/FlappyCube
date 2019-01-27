#if UNITY_EDITOR
using UnityEngine;

public class EditorOnlyBlockBehaviour : MonoBehaviour
{
    [SerializeField]
    Mesh mesh = null;

    void Start()
    {
        var meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        var renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Custom/DebugScoreCube"));
    }
}
#endif //UNITY_EDITOR