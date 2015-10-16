using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float MovementSpeed;
    public float RotationSpeed;
    public float AttackWithinDistance;
    public float AttackWithinAngle;

    private Rigidbody2D rigidBody;
    private Animator animator;


    void Awake() {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    void FixedUpdate() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            this.rigidBody.velocity = Vector2.zero;
            this.rigidBody.angularVelocity = 0;
            return;
        }

        // Look at player
        Vector2 worldUp = this.transform.up;
        Vector2 worldTarget = player.transform.position - this.transform.position;

        float deltaAngle = Vector2.Angle(worldUp, worldTarget);
        Vector3 cross = Vector3.Cross(worldUp, worldTarget);
        float crossSign = Mathf.Sign(cross.z);
        
        this.rigidBody.angularVelocity = this.RotationSpeed * deltaAngle * crossSign;

        // Move towards player
        this.rigidBody.velocity = worldUp * this.MovementSpeed;

        // Attack if close enough distance and angle to player
        AnimatorStateInfo animState = this.animator.GetCurrentAnimatorStateInfo(0);
        if (!animState.IsName("Attack") 
            && Vector2.Distance(this.transform.position, player.transform.position) <= this.AttackWithinDistance 
            && deltaAngle <= this.AttackWithinAngle) {
            this.animator.SetTrigger("Attack");
        } 
        
    }

}
