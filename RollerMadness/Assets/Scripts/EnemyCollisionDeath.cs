using UnityEngine;
using System.Collections;

public class EnemyCollisionDeath : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
