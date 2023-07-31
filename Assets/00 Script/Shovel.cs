using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private  bool _isShovel=false;
    public bool IsShovel { get => _isShovel; }
    private void FixedUpdate()
    {
        chosenOne();
    }
    void chosenOne()
    {
        if(this.GetComponent<SpriteRenderer>().color== Color.white)
        {
            _isShovel=true;
        }
        else
        {
            _isShovel = false;
        }
    }


}
