using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int _starCost = 100;
    public int GetstarCost()
    { return _starCost; }
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStar(amount);
    }
    private void OnMouseDown()
    {
        Shovel Shovel = FindObjectOfType<Shovel>();
        if (Input.GetMouseButtonDown(0) && Shovel.IsShovel)
        {
            this.gameObject.SetActive(false);
        }
    }
}