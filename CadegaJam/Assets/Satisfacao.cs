using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satisfacao : MonoBehaviour
{
    [SerializeField] private float satisfacaoInicial;
    [SerializeField] private float satisfacaoMax;
    [SerializeField] private float satsfacaoPorTiro;
    private float satisfacaoAtual;
    public bool satisfeito;

    void Start()
    {
        satisfacaoAtual = satisfacaoInicial;
    }

    void Update()
    {
        
    }

    public bool AumentarSatisfacao(float satisfacao)
    {
        satisfacaoAtual = Mathf.Clamp(satisfacaoAtual + satisfacao, 0, satisfacaoMax);

        satisfeito = satisfacaoAtual == satisfacaoMax;

        return satisfeito;
    }

    public bool SatisfacaoSuficiente(float satisfacao)
    {
        return satisfacaoAtual + satisfacao >= satisfacaoMax;
    }
}
