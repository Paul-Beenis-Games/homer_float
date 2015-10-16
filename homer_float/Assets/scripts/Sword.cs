using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    public string TargetTag;
    public int AttackDamage;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == this.TargetTag) {
            Health health = coll.gameObject.GetComponent<Health>();
            if (health != null) {
                health.ModifyValue(-this.AttackDamage);
            }
        }

        
    }
}
