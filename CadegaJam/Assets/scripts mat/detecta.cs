using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detecta : MonoBehaviour
{
    public List<faction> AlvosPossiveis = new List<faction>();
    public List<Criaturas> Targets = new List<Criaturas>();
    public Criaturas AlvoAtual;

    private float TimeBtwShots;
    public float StartTimeBtwShots;
    public GameObject projectile;

    void Start()
    {
        TimeBtwShots = StartTimeBtwShots;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Criaturas>()) {
            Criaturas criaturaNoAlcance = collision.gameObject.GetComponent<Criaturas>();

            if (Targets.Contains(criaturaNoAlcance) == false && AlvosPossiveis.Contains(criaturaNoAlcance.type))  
            {
                Targets.Add(criaturaNoAlcance);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Criaturas>())
        {
            Criaturas criaturaNoAlcance = collision.gameObject.GetComponent<Criaturas>();

            if (Targets.Contains(criaturaNoAlcance))
            {
                Targets.Remove(criaturaNoAlcance);
            }
        }
    }

   public void Escolhe()
    {
        if (Targets.Contains(AlvoAtual) == false )
        {
            AlvoAtual = null;
        }

        if (Targets.Count > 0 && AlvoAtual == null) 
        {
            int RandomTarget = Random.Range(0,Targets.Count );
            Debug.Log(RandomTarget);
            AlvoAtual = Targets[RandomTarget];
        }
    }
    private void Update()
    {
        Escolhe();
        if(TimeBtwShots <= 0 && Targets.Count > 0)
        {
            GameObject Bala = Instantiate(projectile, transform.position, Quaternion.identity);
            Bala.GetComponent<Projectile>().Enemy = AlvoAtual.transform;
            TimeBtwShots = StartTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }

    }
}
