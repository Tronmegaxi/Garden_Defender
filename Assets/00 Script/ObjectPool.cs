using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Singleton

    private static ObjectPool _instance = null;
    public static ObjectPool Instance { get => _instance; }
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    Dictionary<GameObject, List<GameObject>> _poolObject = new Dictionary<GameObject, List<GameObject>>();
    public GameObject Get_Object(GameObject key)
    {
        List<GameObject> _itemPool = new List<GameObject>();
        if (!_poolObject.ContainsKey(key))
        {
            _poolObject.Add(key, _itemPool);
        }
        else
        {
            _itemPool = _poolObject[key];
        }
        foreach (GameObject g in _itemPool)
        {
            if (g.activeSelf) { continue; }
            else { return g; }
        }
        GameObject g2=Instantiate(key,this.transform.position,Quaternion.identity);
        _poolObject[key].Add(g2);
        return g2;
    }
}
