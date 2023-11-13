using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Walk : StateMachineBehaviour
{
    Magician magician;
    Transform magician_transform;
    //상태에 진입할때
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        magician = animator.GetComponent<Magician>();
        magician_transform = animator.GetComponent<Transform>();
    }

    //상태가 진행중일때
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(magician.attack_zone.origin.transform.position, magician_transform.position) > 6f)
        {
            magician_transform.position = Vector2.MoveTowards(magician_transform.position, magician.attack_zone.origin.transform.position, Time.deltaTime * magician.speed);
        }
        else
        {
            animator.SetBool("Is_Walk", false);
            if (magician.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
