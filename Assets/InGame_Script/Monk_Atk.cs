using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_Atk : StateMachineBehaviour
{
    Monk monk;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monk = animator.GetComponent<Monk>();
        monk.monk_effect_anima.SetBool("Is_Effect", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monk.monk_effect_anima.SetBool("Is_Effect", false);
        monk.atkDelay = monk.atkCoolTime;
    }
}
