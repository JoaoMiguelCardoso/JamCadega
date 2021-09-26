using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] List<string> tagsAtacar;
    [SerializeField] float intervaloAtaque;
    [SerializeField] Projetil projetil;

    List<Transform> inimigos = new List<Transform>();
    Transform inimigoAtual;
    float tempoAtaque;
    List<Projetil> projeteis = new List<Projetil>();

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
                Atirar();
                tempoAtaque = intervaloAtaque;
            }
        }
    }

    void Atirar()
    {
        if(projeteis.Count == 0)
            InstanciarProjeteis();

        Projetil p = projeteis[0];
        p.gameObject.SetActive(true);
        p.transform.position = transform.position;
        p.DefinirAlvo(inimigoAtual);
        projeteis.Remove(p);
    }

    void InstanciarProjeteis()
    {
        for (int i = 0; i < 10; i++)
        {
            Projetil p = Instantiate(projetil, transform.position, Quaternion.identity);
            projeteis.Add(p);
            p.DefinirTorre(this);
            p.gameObject.SetActive(false);
        }
    }

    public void RetornarProjetil(Projetil p)
    {
        projeteis.Add(p);
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
