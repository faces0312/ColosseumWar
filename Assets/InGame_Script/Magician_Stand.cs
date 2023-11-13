using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Stand : StateMachineBehaviour
{
    Magician magician;
    Transform magician_transform;
    //���¿� �����Ҷ�
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        magician = animator.GetComponent<Magician>();
        magician_transform = animator.GetComponent<Transform>();
    }

    //���°� �������϶�
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(magician.attack_zone.origin.transform.position, magician_transform.position) > 6f)
        {
            animator.SetBool("Is_Walk", true);

        }
        else
        {
            animator.SetBool("Is_Walk", false);
            if (magician.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
    }
}
