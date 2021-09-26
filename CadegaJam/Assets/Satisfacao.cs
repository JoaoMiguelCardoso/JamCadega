using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Satisfacao : MonoBehaviour
{
    public bool satisfeito;
    [SerializeField] private float satisfacaoInicial;
    [SerializeField] private float satisfacaoMax;
    [SerializeField] private float satsfacaoPorTiro;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Image barraSatisfacao;

    private float satisfacaoAtual;

    void Start()
    {
        canvas.worldCamera = Camera.main;
        AumentarSatisfacao(satisfacaoInicial);
    }

    void Update()
    {
        
    }

    public bool AumentarSatisfacao(float satisfacao)
    {
        satisfacaoAtual = Mathf.Clamp(satisfacaoAtual + (satisfacao * satsfacaoPorTiro), 0, satisfacaoMax);

        satisfeito = satisfacaoAtual == satisfacaoMax;

        barraSatisfacao.fillAmount = satisfacaoAtual / satisfacaoMax;

        return satisfeito;
    }

    public bool SatisfacaoSuficiente(float satisfacao)
    {
        return satisfacaoAtual + satisfacao >= satisfacaoMax;
    }
}
