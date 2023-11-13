using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie_Atk : StateMachineBehaviour
{
    Valkyrie valkyrie;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        valkyrie = animator.GetComponent<Valkyrie>();
        valkyrie.valkyrie_Effect.gameObject.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        valkyrie.valkyrie_Effect.gameObject.transform.position = new Vector3(valkyrie.gameObject.transform.position.x,
            valkyrie.gameObject.transform.position.y + 1f, valkyrie.gameObject.transform.position.z);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        valkyrie.valkyrie_Effect.gameObject.transform.position = new Vector3(valkyrie.gameObject.transform.position.x,
            valkyrie.gameObject.transform.position.y, valkyrie.gameObject.transform.position.z);
        valkyrie.valkyrie_Effect.gameObject.SetActive(false);
        valkyrie.atkDelay = valkyrie.atkCoolTime;
        valkyrie.valkyrie_effect_anima.SetBool("Is_Effect", false);

        valkyrie.ef1.enabled = false;

    }
}
