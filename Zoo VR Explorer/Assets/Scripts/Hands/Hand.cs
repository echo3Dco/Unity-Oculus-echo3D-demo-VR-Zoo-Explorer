using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Handle any hand actions*/
public class Hand : MonoBehaviour
{
    public float speed;

    Animator animator;
    SkinnedMeshRenderer meshRenderer;

    private float gripTarget;
    private float gripCurrent;
    private string animatorGripParam = "Grip";

    private float triggerTarget;
    private float triggerCurrent;
    private string animatorTriggerParam = "Trigger";



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        meshRenderer.enabled = !meshRenderer.enabled;
    }
}
