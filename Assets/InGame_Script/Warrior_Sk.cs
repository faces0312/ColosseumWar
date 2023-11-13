using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Sk : StateMachineBehaviour
{
    Boss_Warrior warrior;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        warrior = animator.GetComponent<Boss_Warrior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        warrior.warrior_Effect.gameObject.transform.localScale = new Vector3(2f, 2f, warrior.warrior_Effect.gameObject.transform.localScale.z);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        warrior.warrior_effect_anima.SetBool("Is_Charging", false);
        warrior.warrior_Effect.gameObject.transform.localScale = new Vector3(1f, 1f, warrior.warrior_Effect.gameObject.transform.localScale.z);
        warrior.atkDelay = warrior.atkCoolTime;
        warrior.skillDelay = warrior.skillCoolTime;
    }

    
}
