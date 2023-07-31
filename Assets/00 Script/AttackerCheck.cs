using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackerCheck : MonoBehaviour
{
    //[SerializeField] private bool _isAttackerDone = false;

    //public bool IsAttackerDone { get => _isAttackerDone; }
    //public void Start()
    //{
    //    InvokeRepeating("Attacker_Check", 12f, 2f);
    //}

    public bool Attacker_Check()
    {
        //int a = 0;
        GameObject[] ChildObjArray = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            ChildObjArray[i] = this.transform.GetChild(i).gameObject;
        }
        // Debug.Log("attacker check :" + _isAttackerDone);
        foreach (GameObject obj in ChildObjArray)
        {
            if (obj.activeSelf)
            {
                //_isAttackerDone = false; 
                return false;
            }
        }
        //_isAttackerDone = true;
        return true;
    }
}
