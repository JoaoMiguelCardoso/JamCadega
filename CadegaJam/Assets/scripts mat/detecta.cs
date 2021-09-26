using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detecta : MonoBehaviour
{
    public List<faction> AlvosPossiveis = new List<faction>();
    public List<Criaturas> Targets = new List<Criaturas>();
    public Criaturas AlvoAtual;

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
            int RandomTarget = Random.Range(0,Targets.Count + 1);
            Debug.Log(RandomTarget);
            AlvoAtual = Targets[RandomTarget];
        }
    }
    private void Update()
    {
        Escolhe();
       
    }
}
