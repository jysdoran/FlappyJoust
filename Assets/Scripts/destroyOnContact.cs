using UnityEngine;
using System.Collections;

public class destroyOnContact : MonoBehaviour {

	void OnCollisionEnter2D (Collider2D other)
    {
        Destroy(other.gameObject);
        Debug.Log("Entered the collider!");
    }
}
