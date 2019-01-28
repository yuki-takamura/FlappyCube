using UnityEngine;

[ExecuteInEditMode]
public class PostEffectBehaviour : MonoBehaviour
{
    [SerializeField]
    Material material;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, material);
    }
}