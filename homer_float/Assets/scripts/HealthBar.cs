using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Health health;

    private Text healthText;

  
    void Start () {
        this.healthText = this.GetComponent<Text>();
    }
	
	
	void Update () {
        this.healthText.text = "Health: " + this.health.Value.ToString();
    }
}
