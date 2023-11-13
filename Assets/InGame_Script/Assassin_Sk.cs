using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Sk : StateMachineBehaviour
{
    Assassin assassin;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        assassin = animator.GetComponent<Assassin>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        assassin.atkDelay = assassin.atkCoolTime;
        assassin.skillDelay = assassin.skillCoolTime;
    }
}
