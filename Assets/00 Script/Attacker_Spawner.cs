using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker_Spawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f, waitToLoad = 5f;
    [SerializeField] GameObject _attackerParent;
    [SerializeField] GameObject[] _attackerPrefabArray;
    private void Start()
    {
        StartCoroutine(InvokeAfterTime());
    }
    public void StopSpwaning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, _attackerPrefabArray.Length);
        GameObject newAttacker = ObjectPool.Instance.Get_Object(_attackerPrefabArray[attackerIndex]);
        newAttacker.transform.position = this.transform.position;
        newAttacker.transform.rotation = this.transform.rotation;
        newAttacker.GetComponent<Health>().Reset_Health();
        newAttacker.SetActive(true);
        newAttacker.transform.parent = _attackerParent.transform;
    }
    IEnumerator InvokeAfterTime()
    {
        yield return new WaitForSeconds(waitToLoad);
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
}
