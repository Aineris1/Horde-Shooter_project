using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;

    public bool destroyOnDeath;

    public void Damage()
    {
  
        hp -= 1;
        if (hp <= 0) Death();
    }

    public void Death()
    {
        print("RIP");
        if (destroyOnDeath == true)
        {
            Destroy(gameObject);
        }
        
    }
}
