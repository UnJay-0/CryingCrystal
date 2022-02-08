using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettings : StateMachineBehaviour {
    private int menuChoice;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      menuChoice = animator.GetInteger("menuChoice");
      controlMenu(menuChoice, animator, true);
    }

    private void controlMenu(int menuChoice, Animator animator, bool control) {
      if (menuChoice == 0) {
        GameObject frontBook = animator.gameObject.transform.GetChild(0).gameObject;
        frontBook.SetActive(control);
      } else {
        GameObject insideBook = animator.gameObject.transform.GetChild(1).gameObject;
        insideBook.transform.GetChild(menuChoice - 1).gameObject.SetActive(control);
      }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      controlMenu(menuChoice, animator, false);
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
