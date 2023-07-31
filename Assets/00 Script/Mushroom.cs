using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class Mushroom : MonoBehaviour
{
    [SerializeField] float _damage = 5000;
    [SerializeField] float _boomRange = 2;

    Health _health;
    Attaker _attacker;
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        this.GetComponent<Health>().DealDamage(10f);
        if (_boomRange > 0)
        {
            var hitColliiders = Physics2D.OverlapCircleAll(this.transform.position, _boomRange);
            foreach (var hit in hitColliiders)
            {
                _health = hit.GetComponent<Health>();
                _attacker = hit.GetComponent<Attaker>();
                DealDamage();
            }
        }
        AudioManager.Instance.PlaySFX("Mushroom");
    }
    void DealDamage()
    {
        if (_attacker && _health)
        {
            _health.DealDamage(_damage);
        }
    }

    
}
