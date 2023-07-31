using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject defender;
    [SerializeField] GameObject defenderParent;

    private void OnMouseDown()
    {
        AttemptToDefenderAt(GetSquareClick());
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        //Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        //newDefender.transform.parent = defenderParent.transform;

        GameObject newDefender = ObjectPool.Instance.Get_Object(defender);
        newDefender.transform.position = worldPos;
        newDefender.transform.rotation = Quaternion.identity;
        newDefender.GetComponent<Health>().Reset_Health();
        newDefender.SetActive(true);
        newDefender.transform.parent = defenderParent.transform;
    }
    private Vector2 GetSquareClick()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 GridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return GridPos;
    }
    public void SetSelectedDefender(GameObject defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private void AttemptToDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.gameObject.GetComponent<Defender>().GetstarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendingStar(defenderCost);
        }
    }
}
