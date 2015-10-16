using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : MonoBehaviour
{
    //Global Variables

    public int MaxStamina;
    public float FatigueSpeed;
    public float MovementSpeed;
    public float RollDuration;
    public float RollSpeed;
    public int RollStaminaCost;
    private float timeSinceLastRegen;
    public int regenStamAmount;
    public float stamRegenPeriod;


    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool rolling = false;
    private float rollStartTime;

    private int stamina;
    public int Stamina
    {
        get
        {
            return this.stamina;
        }
    }

    void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.stamina = this.MaxStamina;
        this.timeSinceLastRegen = 0;
    }

    void FixedUpdate()
    {
        timeSinceLastRegen = Time.deltaTime + timeSinceLastRegen;
        if (this.rolling) {
            this.rigidBody.velocity = this.rigidBody.velocity.normalized * this.RollSpeed;
        } else {
            // Look at mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.LookAt(mousePosition);

            // Movement
            Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            float movementScale = Mathf.Clamp01(movementInput.magnitude);
            float movementSpeed = this.MovementSpeed;
            if (this.Stamina < 0)
            {
                movementSpeed = this.FatigueSpeed;
            }
            this.rigidBody.velocity = movementInput.normalized * movementSpeed * movementScale;

            this.rigidBody.angularVelocity = 0;
        }
        if (rolling == false && timeSinceLastRegen >= stamRegenPeriod)
        {
            timeSinceLastRegen = timeSinceLastRegen - stamRegenPeriod;
            ModifyStamina(regenStamAmount);
                }
    }
    
    void Update()
    {
        AnimatorStateInfo animState = this.animator.GetCurrentAnimatorStateInfo(0);
        if (this.rolling) {
            if (Time.time - this.rollStartTime >= this.RollDuration) {
                this.rolling = false;
            }
        } else {
            if (Input.GetButtonDown("Roll") && this.stamina > 0 && animState.IsName("Idle")) {
                this.ModifyStamina(-this.RollStaminaCost);
                this.rollStartTime = Time.time;
                this.rolling = true;
            } else if (Input.GetButtonDown("Fire1") && !animState.IsName("Attack")) {
                this.animator.SetTrigger("Attack");
            }
        }
    }

    private void LookAt(Vector2 worldPosition) {
        Vector2 targetDirection = worldPosition - (Vector2) this.transform.position;
        float rotationZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, 0, rotationZ - 90);
    }

    private void ModifyStamina(int amount) {
        this.stamina = Mathf.Min(this.stamina + amount,  this.MaxStamina);
    }

}