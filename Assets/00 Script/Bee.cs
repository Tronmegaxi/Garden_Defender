using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bee : MonoBehaviour
{
    Animator animator;
    [SerializeField] float _Speed = 7f;
    bool _isAttacker = false;
    private void FixedUpdate()
    {
        Move();
    }
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if (!otherCollision.GetComponent<Attaker>())
        {
            return;
        }
        else
        {
            _isAttacker = true;

            otherCollision.gameObject.SetActive(false);
        }
        if (_isAttacker)
        {
            this.GetComponent<Animator>().SetBool("IsAttacking", true);
        }
        AudioManager.Instance.PlaySFX("BeeAttack");
    }
    void Move()
    {
        if (_isAttacker)
        {
            this.transform.Translate(Vector2.right * _Speed * Time.deltaTime);
        }
    }
}
