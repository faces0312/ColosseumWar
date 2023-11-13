using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Atk : StateMachineBehaviour
{
    Magician magician;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        magician = animator.GetComponent<Magician>();
        magician.magician_effect_anima.SetBool("Is_Effect", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (magician.magician_Effect.atk_end == true)
        {
            magician.magician_effect_anima.SetBool("Is_Effect", false);
            magician.magician_Effect.gameObject.SetActive(false);

            magician.ef1.enabled = false;

            magician.ef1.gameObject.SetActive(false);
            magician.ef2.gameObject.SetActive(false);
            magician.ef3.gameObject.SetActive(false);
            magician.ef4.gameObject.SetActive(false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        magician.magician_effect_anima.SetBool("Is_Effect", false);
        magician.magician_Effect.gameObject.SetActive(false);

        magician.ef1.enabled = false;
        magician.ef1.gameObject.SetActive(false);
        magician.ef2.gameObject.SetActive(false);
        magician.ef3.gameObject.SetActive(false);
        magician.ef4.gameObject.SetActive(false);
        magician.atkDelay = magician.atkCoolTime;
        magician.magician_Effect.atk_end = false;
    }
}
