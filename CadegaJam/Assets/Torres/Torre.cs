using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] List<string> tagsAtacar;
    [SerializeField] float intervaloAtaque;

    List<Transform> inimigos = new List<Transform>();
    Transform inimigoAtual;
    float tempoAtaque;

    void Start()
    {

    }

    void Update()
    {
        if (inimigoAtual == null)
        {
            if (inimigos.Count > 0)
                inimigoAtual = inimigos[0];
        }
        else
        {
            if (tempoAtaque > 0)
                tempoAtaque -= Time.deltaTime;
            else
            {
                // atira ou sla
                tempoAtaque = intervaloAtaque;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (tagsAtacar.Contains(col.tag))
            inimigos.Add(col.transform);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform == inimigoAtual)
            inimigoAtual = null;

        if (inimigos.Contains(col.transform))
            inimigos.Remove(col.transform);
    }
}
