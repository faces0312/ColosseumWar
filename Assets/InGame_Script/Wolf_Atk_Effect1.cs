using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Atk_Effect1 : StateMachineBehaviour
{
    Character wolf;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wolf=animator.GetComponent<Character>();
        if (wolf.transform.localScale.x < 0)
        {
            wolf.gameObject.transform.position = new Vector3(wolf.gameObject.transform.position.x + 1f, wolf.gameObject.transform.position.y);
        }

        else if (wolf.transform.localScale.x > 0)
        {
            wolf.gameObject.transform.position = new Vector3(wolf.gameObject.transform.position.x - 1f, wolf.gameObject.transform.position.y);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wolf.wolf_speed = 0;
        
            
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wolf.rigid.velocity = Vector3.zero;
        wolf.wolf_speed = Data.Instance.gameData.wolf_speed;
        if(wolf.cnt_combo==1)
        {
            wolf.ComboReset();
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
