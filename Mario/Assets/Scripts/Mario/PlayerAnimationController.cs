using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    const string RUN = "Run";
    const string JUMP = "Jump";
    public void PlayRunState()
    {
        ChangeAnimationState(RUN);
    }

    public void PlayJumpState()
    {
        ChangeAnimationState(JUMP);
    }
}
