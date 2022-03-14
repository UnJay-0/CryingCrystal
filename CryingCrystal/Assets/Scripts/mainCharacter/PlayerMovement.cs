using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// Script per il movimento del player all'interno della scena.
    /// </summary>
    /// <param name="playerSpeed"> Velocità di movimento del giocatore </param>
    public float playerSpeed;

    /// <param name="rb"> rigidbody del player </param>
    private Rigidbody2D rb;

    /// <param name="movement"> direzione di movimento in input </param>
    private Vector2 movement;

    /// <param name="animator"> animatore del player</param>
    public Animator animator;


    private void Awake() {
      /// <summary>
      /// Metodo Awake chiamato nel momento il gameObject è caricato in scena.
      /// Modifica this, inizializzando il rb.
      /// </summary>
      rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value) {
      /// <summary>
      ///  Permette la gestione di un input, chiamato dal InputSystem nel momento
      ///  nel quale viene premuto un pulsante del relativo sistema di riferimento.
      ///  Modifica animator e movement.
      /// </summary>
      /// <param name="value"> valore del input </param>
      movement = value.Get<Vector2>();
      float val = ((4 + movement.x + movement.y * 4) / 8);
      if (val < 0.4 || val > 0.6) {
        animator.SetFloat("LastMovement", val);
      }

    }

    void Movement() {
      /// <summary>
      /// Calcola la posizione del player.
      /// Modifica rb.
      /// </summary>
      Vector2 currentPos = rb.position;
      Vector2 adjustedPos = movement * playerSpeed;
      Vector2 newPos = currentPos + adjustedPos * Time.fixedDeltaTime;
      rb.MovePosition(newPos);
    }

    private void Animate() {
      /// <summary>
      /// Specifica i parametri per la determinazione dell'animazione
      /// da avviare in scena. Modifica animator.
      /// </summary>
      /// <param name="Param name">Param description</param>
      /// <returns>
      /// Return value description
      /// </returns>
      animator.SetFloat("MovementX", movement.x);
      animator.SetFloat("MovementY", movement.y);
    }

    // Update is called once per frame
    void FixedUpdate() {
      Movement();
      Animate();
    }
}
