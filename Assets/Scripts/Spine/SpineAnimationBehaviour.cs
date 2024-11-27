using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationBehaviour : StateMachineBehaviour
{
    public AnimationClip motion;
    string clipName;
    bool loop;

    public int layerNum = 0;
    public float timeScale = 1.0f;

    SkeletonAnimation skelAnimation;
    Spine.AnimationState spineAnimationState;
    Spine.TrackEntry trackEntry;

    private void Awake()
    {
        if (motion != null)
            clipName = motion.name;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (skelAnimation == null)
        {
            skelAnimation = animator.GetComponentInChildren<SkeletonAnimation>();
            spineAnimationState = skelAnimation.state;
        }

        if (clipName != null)
        {
            loop = stateInfo.loop;
            trackEntry = spineAnimationState.SetAnimation(layerNum, clipName, loop);
            trackEntry.TimeScale = timeScale;
        }
    }
}
