using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Sword : MonoBehaviour {

    [SerializeField]
    private UnityEvent SwingStop;

    private WeaponData weaponData;
    public WeaponData WeaponData
    {
        set
        {
            this.weaponData = value;

            this.GetComponent<SpriteRenderer>().sprite = this.weaponData.Sprite;
        }
    }

    public string TargetTag;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == this.TargetTag) {
            Health health = coll.gameObject.GetComponent<Health>();
            if (health != null) {
                health.ModifyValue(-this.weaponData.Damage);
            }
        }
    }

    public void Swing()
    {
        this.StartCoroutine(this.Coroutine_Swing());
    }

    private IEnumerator Coroutine_Swing()
    {
        Animation anim = this.GetComponent<Animation>();
        anim.AddClip(this.weaponData.Animation, this.weaponData.Animation.name);
        anim.Play(this.weaponData.Animation.name);

        WaitForFixedUpdate wait = new WaitForFixedUpdate();
        while (anim.isPlaying)
        {
            yield return wait;
        }

        this.SwingStop.Invoke();
    }
}
