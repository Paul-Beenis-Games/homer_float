using UnityEngine;
using UnityEditor;
using System.Collections;

public class WeaponData : ScriptableObject
{
    private readonly int damage;
    public int Damage
    {
        get
        {
            return this.damage;
        }
    }

    private readonly string weaponName;
    public string WeaponName
    {
        get
        {
            return this.weaponName;
        }
    }

    private readonly Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return this.sprite;
        }
    }

    private readonly AnimationClip animation;
    public AnimationClip Animation
    {
        get
        {
            return this.animation;
        }
    }
}


	
