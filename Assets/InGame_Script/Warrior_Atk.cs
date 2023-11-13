using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Atk : StateMachineBehaviour
{
    Boss_Warrior warrior;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        warrior = animator.GetComponent<Boss_Warrior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{  
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        warrior.atkDelay = warrior.atkCoolTime;
        warrior.warrior_effect_anima.SetBool("Is_Effect", false);

        warrior.ef1.enabled = false;
    }

    
}
