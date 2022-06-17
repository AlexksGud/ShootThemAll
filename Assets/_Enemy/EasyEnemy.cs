using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Person
{
    
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (_healthPonts <= 0)
        {
            OnDie();
        }
       
    }
    public void OnDie()
    {

    }
}
