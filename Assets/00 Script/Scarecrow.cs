using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if (otherCollision.GetComponent<Defender>() || otherCollision.GetComponent<Projectile>()) { return; }
        this.GetComponent<Health>().DealDamage(30f);
        AudioManager.Instance.PlaySFX("Scarecrow");
    }
}

