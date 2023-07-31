using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 3f, _damage = 50, _lifeTime = 5f;
    [SerializeField] GameObject _hitVFX;
    private void OnEnable()
    {
        StartCoroutine(AutoDeavtive());
    }
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        var health = otherCollision.GetComponent<Health>();
        var attacker = otherCollision.GetComponent<Attaker>();
        if (attacker && health)
        {
            health.DealDamage(_damage + Random.Range(2, 10));
            TriggerHitVFX();
            this.gameObject.SetActive(false);
            HitSoundSFX();
        }
    }
    IEnumerator AutoDeavtive()
    {
        yield return new WaitForSeconds(_lifeTime);

        this.gameObject.SetActive(false);
    }
    private void TriggerHitVFX()
    {
        if (!_hitVFX)
        {
            Debug.Log(this.gameObject.name + " no hit VFX");
            return;
        }
        GameObject hitVFX = ObjectPool.Instance.Get_Object(_hitVFX);
        hitVFX.transform.position = this.transform.position;
        hitVFX.transform.rotation = this.transform.rotation;
        hitVFX.SetActive(true);

    }
    void HitSoundSFX()
    {
        AudioManager.Instance.PlaySFX("HitSFX");
    }
}



