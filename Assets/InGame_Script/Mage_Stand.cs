using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Stand : StateMachineBehaviour
{
    Mage mage;
    Transform mage_transform;
    //상태에 진입할때
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mage = animator.GetComponent<Mage>();
        mage_transform = animator.GetComponent<Transform>();
    }

    //상태가 진행중일때
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (mage.skillDelay <= 0)
        {
            animator.SetTrigger("Is_Sk");
            return;
        }
        if (Vector2.Distance(mage.attack_zone.origin.gameObject.transform.position, mage_transform.position) > 15f)
        {
            mage_transform.position = Vector2.MoveTowards(mage_transform.position, mage.attack_zone.origin.gameObject.transform.position, Time.deltaTime * mage.speed);
        }
        else
        {
            if (mage.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
        
    }
}
