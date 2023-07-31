using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Projectile>())
        {
            this.GetComponent<Attaker>().SetMovementSpeed(-0.05f);
        }
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attaker>().Attack(otherObject);
        }
    }
}

