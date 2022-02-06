using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookController : MonoBehaviour {
    public Animator animator;
    public GameObject frontBook;

    public void openBook(int choice) {
      frontBook.SetActive(false);
      choose(choice);
      animator.SetBool("isOpen", true);

    }

    public void closeBook() {
      choose(0);
      animator.SetBool("isOpen", false);
    }

    private void choose(int choice) {
      animator.SetInteger("menuChoice", choice);
    }


}
