using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffectBehaviour : MonoBehaviour
{
    [SerializeField]
    Material material = null;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material == null)
            return;

        Graphics.Blit(src, dest, material);
    }
}