using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
       Attaker attacker=otherCollider.GetComponent<Attaker>();
        if (attacker)
        {

        }
    }
}
