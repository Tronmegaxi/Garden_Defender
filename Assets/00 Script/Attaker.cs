using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float _currentSpeed = 1f;
    [SerializeField] GameObject[] _specialSkill;
    [SerializeField] GameObject _gun;
    GameObject currentTarget;

    void Update()
    {
        Move();
        UpdateAnimationState();
    }
    void Move( )
    {
       // Debug.Log(this.gameObject.name + " local scale " + this.gameObject.transform.localScale.x);
       // Debug.Log(this.gameObject.name + " _curentSpeed  " + _currentSpeed);

        transform.Translate(Vector2.left  *_currentSpeed * Time.deltaTime);
    }
    public void SetMovementSpeed(float speed)
    {
       // Debug.Log(this.gameObject.name + " local speed " + speed);
        _currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
        SpecialSkill();
        //if (target != null) { Debug.Log(this.gameObject.name + " target " + target.gameObject.name); }
        //else { Debug.Log(this.gameObject.name + " no target"); }
    }
    public void UpdateAnimationState()
    {
        if (currentTarget == null) { return; }
        else if (!currentTarget.gameObject.activeSelf) { GetComponent<Animator>().SetBool("isAttacking", false); }
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }




    public void SpecialSkill()
    {if(_specialSkill==null || !_gun)
        {
            return;
        }
        else
        {
            int skillIndex = Random.Range(0, _specialSkill.Length);
            GameObject newSkill = ObjectPool.Instance.Get_Object(_specialSkill[skillIndex]);
            newSkill.transform.position = _gun.transform.position;
            newSkill.transform.rotation = _gun.transform.rotation;
            newSkill.SetActive(true);
        }
    }


}
