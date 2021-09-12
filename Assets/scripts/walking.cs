using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] 
    float eventspeed=0;
    GameObject currenttarget;
    levelcontroller levelcontroller;
    private void Awake()
    {

        levelcontroller=GameObject.FindObjectOfType<levelcontroller>();
        levelcontroller.attackerSpawner();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.left * eventspeed*Time.deltaTime );

    }
    public void animationspeed(float speed)
    {
        eventspeed = speed;
    }
    public void attack(GameObject target)
    { 
       GetComponent<Animator>().SetTrigger("ĘsAttacking");
        

        
        currenttarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currenttarget) { return; }
        healthy health = currenttarget.GetComponent<healthy>();
        if (health)
        {
            health.dealdamage(damage);
            
        }
        
        
    }

}
