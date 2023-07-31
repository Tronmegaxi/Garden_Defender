using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] public float HealthAtker;
    [SerializeField] GameObject _deathVFX;
    public void DealDamage(float damage)
    {
        HealthAtker -= damage;
        Death();
    }
    void Death()
    {
        //Debug.Log(this.gameObject.name + HealthAtker);
        if (HealthAtker <= 0)
        {

            this.gameObject.SetActive(false);
            DeathVFX();
        }
    }
    private void DeathVFX()
    {
        if (!_deathVFX)
        {
            Debug.Log(this.gameObject.name + " no death VFX");
        }
        GameObject hitVFX = ObjectPool.Instance.Get_Object(_deathVFX);
        hitVFX.transform.position = this.transform.position;
        hitVFX.transform.rotation = this.transform.rotation;
        hitVFX.SetActive(true);
    }
  public  void Reset_Health()
    {
        HealthAtker = _health;
    }
}
