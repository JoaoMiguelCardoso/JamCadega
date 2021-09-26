using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Torre : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float intervaloAtaque;
    [SerializeField] Projetil projetil;
    [SerializeField] Canvas objRemover;
    [SerializeField] DadosTorre dadosTorre;

    List<Transform> inimigos = new List<Transform>();
    Transform alvoAtual;
    float tempoAtaque;
    List<Projetil> projeteis = new List<Projetil>();
    Satisfacao inimigoAtual;
    GerenciadorTorres gerenciadorTorres;

    void Start()
    {
        objRemover.worldCamera = Camera.main;
    }

    void Update()
    {
        if (alvoAtual == null)
        {
            if (inimigos.Count > 0)
            {
                alvoAtual = inimigos[0];
                inimigoAtual = alvoAtual.GetComponent<Satisfacao>();
            }
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
        if (projeteis.Count == 0)
            InstanciarProjeteis();

        Projetil p = projeteis[0];
        p.gameObject.SetActive(true);
        p.transform.position = transform.position + (alvoAtual.position - transform.position).normalized;
        p.DefinirAlvo(alvoAtual, inimigoAtual);
        projeteis.Remove(p);

        if (inimigoAtual.SatisfacaoSuficiente(projetil.QtdSatisfacao()))
            TrocarAlvo();
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

    public void TrocarAlvo()
    {
        inimigos.Remove(alvoAtual);
        alvoAtual = null;
        inimigoAtual = null;
    }

    public void DefinirGerenciador(GerenciadorTorres gerenciador)
    {
        gerenciadorTorres = gerenciador;
    }

    public void AdicionarAlvo(Transform alvo)
    {
        inimigos.Add(alvo);
    }

    public void RemoverAlvo(Transform alvo)
    {
        if (alvo == alvoAtual)
            TrocarAlvo();

        if (inimigos.Contains(alvo))
            inimigos.Remove(alvo);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            bool remover = gerenciadorTorres.AutorizarRemocao(this);

            if (objRemover.gameObject.activeSelf)
                AlterarObjRemover(false);
            else
                AlterarObjRemover(remover);
        }
    }

    public void AlterarObjRemover(bool ativo)
    {
        objRemover.gameObject.SetActive(ativo);
    }

    public void ConfirmarRemocao()
    {
        gerenciadorTorres.VenderTorre(transform.position, dadosTorre);
        foreach (Projetil p in projeteis)
        {
            if(!p.gameObject.activeSelf)
                Destroy(p.gameObject);
        }
        Destroy(gameObject);
    }
}
