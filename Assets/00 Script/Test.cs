using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject[] _spawner;
    [SerializeField] GameObject[] _attacker;
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f, waitToLoad = 5f;

    private void Start()
    {
        StartCoroutine(InvokeAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<int, GameObject> _attacker = new Dictionary<int, GameObject>();
    }
    private void SpawnAttacker()
    {
        int SpawnerIndex = Random.Range(0, _spawner.Length);
        int AttackerIndex = Random.Range(0, _attacker.Length);
        GameObject newAttacker = ObjectPool.Instance.Get_Object(_attacker[AttackerIndex]);
        newAttacker.GetComponent<Health>().Reset_Health();
        newAttacker.transform.position = _spawner[SpawnerIndex].transform.position;
        newAttacker.transform.rotation = this.transform.rotation;
        newAttacker.SetActive(true);
    }
    public void StopSpwaning()
    {
        spawn = false;
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
