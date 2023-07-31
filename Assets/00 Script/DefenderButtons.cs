using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DefenderButtons : MonoBehaviour
{
    [SerializeField] GameObject _defenderPrefab;
    private void Start()
    {
        LableButtonCost();
    }

    private void LableButtonCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (costText == null) { Debug.Log(name + " no cost!"); }
        else
        {
            costText.text = _defenderPrefab.gameObject.GetComponent<Defender>().GetstarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButtons>();
        foreach (DefenderButtons button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        this.GetComponent<SpriteRenderer>().color = Color.white;
   
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(_defenderPrefab);

    }
}
