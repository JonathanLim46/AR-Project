using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    [SerializeField] private Animator targetAnimator;

    public void PlayAnimation(string anim)
    {
        targetAnimator.SetTrigger(anim);
    }

}
