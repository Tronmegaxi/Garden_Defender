using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject=otherCollider.gameObject;
        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Attaker>().Attack(otherObject);
        }
    }

}
