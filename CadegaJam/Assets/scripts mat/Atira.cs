using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atira : detecta
    
{
    
    private float TimeBtwShots;
    public float StartTimeBtwShots;
    public GameObject projectile;
    
    
    void Start()
    {
        TimeBtwShots = StartTimeBtwShots;
    }


    void Update()
    {
       

        if(TimeBtwShots <= 0 && Targets.Count > 0)
        {
           GameObject Bala = Instantiate(projectile, transform.position, Quaternion.identity);
            Bala.GetComponent<Projectile>().Enemy = GetComponentInChildren<detecta>().AlvoAtual.transform;
            TimeBtwShots = StartTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }

        
    }
}
