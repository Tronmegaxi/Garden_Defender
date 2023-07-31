using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour
{
    [SerializeField] GameObject _hitFx;
    [SerializeField] GameObject _gun;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Projectile>())
        {
            GameObject newHitFX = ObjectPool.Instance.Get_Object(_hitFx);
            newHitFX.transform.position = _gun.transform.position;
            newHitFX.transform.rotation = _gun.transform.rotation;
            newHitFX.SetActive(true);
        }
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attaker>().Attack(otherObject);
        }
    }











}
