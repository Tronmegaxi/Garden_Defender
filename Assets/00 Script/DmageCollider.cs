using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().TakeLives();
        collision.gameObject.SetActive(false);
    }
}
