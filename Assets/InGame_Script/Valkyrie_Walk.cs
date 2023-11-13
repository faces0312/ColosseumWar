using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie_Walk : StateMachineBehaviour
{
    Valkyrie valkyrie;
    Transform valkyrie_transform;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        valkyrie = animator.GetComponent<Valkyrie>();
        valkyrie_transform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (valkyrie.skillDelay <= 0)
        {
            animator.SetTrigger("Is_Sk");
            return;
        }
        if(Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_left.position, valkyrie_transform.position)
            >= Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_right.position, valkyrie_transform.position))
        {
            valkyrie_transform.position = Vector2.MoveTowards(valkyrie_transform.position, valkyrie.attack_zone.valkyrie_attack_zone_right.position, Time.deltaTime * valkyrie.speed);
        }
        else if (Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_left.position, valkyrie_transform.position)
            < Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_right.position, valkyrie_transform.position))
        {
            valkyrie_transform.position = Vector2.MoveTowards(valkyrie_transform.position, valkyrie.attack_zone.valkyrie_attack_zone_left.position, Time.deltaTime * valkyrie.speed);
        }
        if(Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_left.position, valkyrie_transform.position)<=0.3f||
             Vector2.Distance(valkyrie.attack_zone.valkyrie_attack_zone_right.position, valkyrie_transform.position)<=0.3f)
        {
            animator.SetBool("Is_Walk", false);
            if (valkyrie.atkDelay <= 0)
                animator.SetTrigger("Is_Atk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}
}
