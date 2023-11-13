using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michael_Atk : StateMachineBehaviour
{
    Michael michael;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        michael = animator.GetComponent<Michael>();
        michael.michael_effect_anima.SetBool("Is_Effect", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        michael.michael_effect_anima.SetBool("Is_Effect", false);
        michael.atkDelay = michael.atkCoolTime;
    }
}
