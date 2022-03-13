using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value) {
      movement = value.Get<Vector2>();
    }

    void Movement() {
      Vector2 currentPos = rb.position;
      Vector2 adjustedPos = movement * playerSpeed;
      Vector2 newPos = currentPos + adjustedPos * Time.fixedDeltaTime;
      rb.MovePosition(newPos);

    }
    private void Animate() {
      animator.SetFloat("MovementX", movement.x);
      animator.SetFloat("MovementY", movement.y);
      //animator.SetFloat("LastMoviment", )
    }
    // Update is called once per frame
    void FixedUpdate() {
      Movement();
      Animate();
    }
}
