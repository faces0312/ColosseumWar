using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Atk : StateMachineBehaviour
{
    Archer archer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        archer = animator.GetComponent<Archer>();
        archer.archer_effect_anima.SetBool("Is_Effect", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(archer.archer_Effect.atk_end==true)
        {
            archer.archer_effect_anima.SetBool("Is_Effect", false);
            archer.archer_Effect.gameObject.SetActive(false);

            archer.ef1.enabled = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        archer.archer_effect_anima.SetBool("Is_Effect", false);
        archer.archer_Effect.gameObject.SetActive(false);

        archer.ef1.enabled = false;
        archer.atkDelay = archer.atkCoolTime;
        archer.archer_Effect.atk_end = false;
    }
}
