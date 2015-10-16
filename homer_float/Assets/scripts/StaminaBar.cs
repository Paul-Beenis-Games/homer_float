using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour {

    public Player player;

    private Text uiText;

    void Awake()
    {
        this.uiText = this.GetComponent<Text>();
    }
    
	void Update()
    {
        this.uiText.text = "Stamina: " + this.player.Stamina.ToString();
	}
}
