using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [SerializeField] GameObject animationPlayer;
    [SerializeField] Canvas exitCanvas;

    void IncreseAnimationSize()
    {
        animationPlayer.transform.localScale = animationPlayer.transform.localScale * 1.2f;
    }

    void DeleteAnimation()
    {
        exitCanvas.gameObject.SetActive(true);
        Destroy(animationPlayer);
    }
}
