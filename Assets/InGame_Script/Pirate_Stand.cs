using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_Stand : StateMachineBehaviour
{
    Pirate pirate;
    Transform pirate_transform;
    //상태에 진입할때
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pirate = animator.GetComponent<Pirate>();
        pirate_transform = animator.GetComponent<Transform>();
    }

    //상태가 진행중일때
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(pirate.attack_zone.origin.transform.position, pirate_transform.position) > 4f)
        {
            animator.SetBool("Is_Walk", true);

        }
        else
        {
            animator.SetBool("Is_Walk", false);
            if (pirate.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
    }
}
