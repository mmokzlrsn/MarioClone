using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    const string RUN = "Run";
    const string JUMP = "Jump";
    const string DEATH = "Death";
    
    public void PlayRunState()
    {
        ChangeAnimationState(RUN);
    }

    public void PlayJumpState()
    {
        ChangeAnimationState(JUMP);
    }

    public void PlayDeathState()
    {
        ChangeAnimationState(DEATH);
    }


}
