using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log(this.gameObject.name + " collie " + otherCollider.gameObject.name);
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Scarecrow>())
        {
            this.gameObject.GetComponent<Animator>().SetBool("Backward", true);
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (otherObject.GetComponent<DeactiveCollider>())
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
