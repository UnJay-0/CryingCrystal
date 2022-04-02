using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnder : MonoBehaviour {
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start() {
      sp = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Player")
        sp.color = new Color(1, 1, 1, 0.4f);
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.gameObject.tag == "Player")
        sp.color = new Color(1, 1, 1, 1);
    }
}
