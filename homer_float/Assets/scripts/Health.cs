using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int MaxValue;

    private int value;

    public int Value {
        get {
            return this.value;
        }
    }

    void Awake() {
        this.value = this.MaxValue;
        this.ModifyValue(0);
    }

    public void ModifyValue(int amount) {
        this.value = Mathf.Clamp(this.value + amount, 0, this.MaxValue);
        if (this.value <= 0) {
            GameObject.Destroy(this.gameObject);
        }
    }



}
