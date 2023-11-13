using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_Walk : StateMachineBehaviour
{
    Pirate pirate;
    Transform pirate_transform;
    //���¿� �����Ҷ�
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pirate = animator.GetComponent<Pirate>();
        pirate_transform = animator.GetComponent<Transform>();
    }

    //���°� �������϶�
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(pirate.attack_zone.origin.transform.position, pirate_transform.position) > 6f)
        {
            pirate_transform.position = Vector2.MoveTowards(pirate_transform.position, pirate.attack_zone.origin.transform.position, Time.deltaTime * pirate.speed);
        }
        else
        {
            animator.SetBool("Is_Walk", false);
            if (pirate.atkDelay <= 0)
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
