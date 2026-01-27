using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPicker : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private int Variant;
    
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        Variant = Random.Range(0, 9);
        float offset = Random.Range(0f, 1f);

        Invoke("Starting", offset);
    }

    private void Starting()
    {
        animator.SetInteger("Variant", Variant);
    }
}
