using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michael_Walk : StateMachineBehaviour
{
    Michael michael;
    Transform michael_transform;
    //상태에 진입할때
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        michael = animator.GetComponent<Michael>();
        michael_transform = animator.GetComponent<Transform>();
    }

    //상태가 진행중일때
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(michael.attack_zone.mob_attack_zone_left.position, michael_transform.position)
            >= Vector2.Distance(michael.attack_zone.mob_attack_zone_right.position, michael_transform.position))
        {
            michael_transform.position = Vector2.MoveTowards(michael_transform.position, michael.attack_zone.mob_attack_zone_right.position, Time.deltaTime * michael.speed);
        }
        else if (Vector2.Distance(michael.attack_zone.mob_attack_zone_left.position, michael_transform.position)
            < Vector2.Distance(michael.attack_zone.mob_attack_zone_right.position, michael_transform.position))
        {
            michael_transform.position = Vector2.MoveTowards(michael_transform.position, michael.attack_zone.mob_attack_zone_left.position, Time.deltaTime * michael.speed);
        }
        if (Vector2.Distance(michael.attack_zone.mob_attack_zone_left.position, michael_transform.position) <= 0.3f ||
             Vector2.Distance(michael.attack_zone.mob_attack_zone_right.position, michael_transform.position) <= 0.3f)
        {
            animator.SetBool("Is_Walk", false);
            if (michael.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
    }
}
