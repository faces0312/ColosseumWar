using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Atk_Effect1 : StateMachineBehaviour
{
    Skeleton skeleton;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeleton = animator.GetComponent<Skeleton>();
        if (skeleton.transform.localScale.x < 0)
        {
            skeleton.gameObject.transform.position = new Vector3(skeleton.gameObject.transform.position.x - 1f, skeleton.gameObject.transform.position.y);
        }
        else if (skeleton.transform.localScale.x > 0)
        {
            skeleton.gameObject.transform.position = new Vector3(skeleton.gameObject.transform.position.x + 1f, skeleton.gameObject.transform.position.y);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeleton.skeleton_speed = 0;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeleton.rigid.velocity = Vector3.zero;
        skeleton.skeleton_speed = Data.Instance.gameData.skeleton_speed;

        if (skeleton.cnt_combo == 1)
        {
            skeleton.ComboReset();
        }
    }

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
