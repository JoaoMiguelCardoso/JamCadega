using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] float satisfacao;
    [SerializeField] float moedas;
    Torre torre;
    Transform alvo;
    Satisfacao satisfacaoInimigo;
    Loja loja;

    void Start()
    {

    }

    void Update()
    {
        if (alvo == null)
        {
            Retornar();
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
    }

    public void DefinirTorre(Torre t)
    {
        torre = t;
    }

    public void DefinirAlvo(Transform t, Satisfacao s)
    {
        alvo = t;
        satisfacaoInimigo = s;
    }

    public void DefinirLoja(Loja l)
    {
        loja = l;
    }

    public float QtdSatisfacao()
    {
        return satisfacao;
    }

    void Retornar()
    {
        torre.RetornarProjetil(this);
        DefinirAlvo(null, null);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform == alvo)
        {
            satisfacaoInimigo.AumentarSatisfacao(satisfacao);
            loja.AcertarProjetil(moedas);
            if (torre == null)
            {
                TorreRemovida();
                return;
            }

            Retornar();
        }
    }

    public void TorreRemovida()
    {
        Destroy(gameObject);
    }
}
