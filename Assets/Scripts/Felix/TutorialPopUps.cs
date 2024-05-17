using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopUps : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}