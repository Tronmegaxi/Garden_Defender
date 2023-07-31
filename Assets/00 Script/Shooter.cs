using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile, _gun;
    Animator animator;
    private void Start()
    {
        //SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        strikeAttacker();
    }
    public void Fire()
    {

        GameObject newProjectile = ObjectPool.Instance.Get_Object(_projectile);
        newProjectile.transform.position = _gun.transform.position;
        newProjectile.transform.rotation = _gun.transform.rotation;
        newProjectile.SetActive(true);
        FireSoundSFX();
    }
    private bool isAttakerInLane()
    {
        //// kiểm tra parent có active child nào không
        bool IsCloseEnough=false;
        Attaker[] Attacker = FindObjectsOfType<Attaker>();
        foreach (Attaker atker in Attacker)
        {
             if( (Mathf.Abs(atker.transform.position.y - this.transform.position.y) < 1) && atker.gameObject.activeInHierarchy)
            {
                IsCloseEnough = true;
            }
        }
        if (IsCloseEnough) { return true; }
        else { return false; }
    }
    private void strikeAttacker()
    {
        if (isAttakerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    void FireSoundSFX()
    {
        AudioManager.Instance.PlaySFX("Fire");
    }
}
