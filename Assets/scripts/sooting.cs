using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sooting : MonoBehaviour
{
    [SerializeField]
    GameObject zucchini_prefab;
   
    spawner MyLaneSpawner;
    Animator cactusanim;
    private void Start()
    {
        SetAttackerSpawners();
        cactusanim = GetComponent<Animator>();
    }

    private void SetAttackerSpawners()
    {
        spawner[] attackers = GameObject.FindObjectsOfType<spawner>();
        foreach (var attacker in attackers)
        {
            print(attacker.transform.position.y-0.2);
            print(transform.position.y);
            bool İsCloseEnought = Mathf.Abs( attacker.transform.position.y-0.2f- transform.position.y) <= Mathf.Epsilon+0.1f;                        
            
            if (İsCloseEnought)
            {
                

                MyLaneSpawner = attacker;
            }
        }
    }

    private void Update()
    {
        if (İsAttackerİnLane())
        {
            cactusanim.SetBool("İsAttacking",true);
           
        }
        else
        {
            cactusanim.SetBool("İsAttacking", false);
        }
        
            
        
  
    }
    private bool İsAttackerİnLane()
    {
        if (MyLaneSpawner.transform.childCount<=0)
        {
           
            return false;
        }
        else
        {
            print(MyLaneSpawner);
            return true;
        }


    }
    public void soot(float damage)
    {
        Instantiate(zucchini_prefab,transform.position,transform.rotation);
       
    }
}
