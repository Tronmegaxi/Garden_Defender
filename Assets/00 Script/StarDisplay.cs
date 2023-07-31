using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarDisplay : MonoBehaviour
{
    [SerializeField] int _star = 100;
    Text starText;
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        starText.text = _star.ToString();
    }
    public void AddStar(int amount)
    {
        _star += amount;
        UpdateDisplay();
    }
    public void SpendingStar(int amount)
    {
        if (_star >= amount)
        {
            _star -= amount;
            UpdateDisplay();
        }
    }
    public bool HaveEnoughStars(int amount)
    {
        return (_star >= amount);
    }
}
