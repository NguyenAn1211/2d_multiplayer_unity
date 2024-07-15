using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static IEnumerator PlayAnimandSetStateWhenFinished(GameObject parent, Animator animator, string clipName,
        bool activeStateatTheEnd = true)
    {
        animator.Play(clipName);
        var animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
        parent.SetActive(activeStateatTheEnd);
    }
}
