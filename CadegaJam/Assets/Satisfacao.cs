using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satisfacao : MonoBehaviour
{
    [SerializeField]private float satisfacaoInicial;
    [SerializeField]private float SatisfacaoMax;
    [SerializeField]private float SatsfacaoPorTiro;
    private float SatisfacaoAtual;
    public bool satisfeito;
    void Start()
    {
        SatisfacaoAtual = satisfacaoInicial;
    }
    void Update()
    {
        satisfeito = (SatisfacaoAtual >= SatisfacaoMax);
    }
}
