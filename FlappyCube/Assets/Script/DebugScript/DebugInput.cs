using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    PostEffectBehaviour postEffect;

    bool isRunning = false;

    void Start()
    {
        postEffect = GetComponent<PostEffectBehaviour>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            postEffect.enabled = true;
            StartCoroutine(EnablePostEffect());
        }
    }

    IEnumerator EnablePostEffect()
    {
        if (isRunning)
            yield break;

        isRunning = true;

        yield return new WaitForSeconds(0.2f);

        postEffect.enabled = false;
        isRunning = false;
    }
}
