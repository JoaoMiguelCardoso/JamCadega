using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satisfacao : MonoBehaviour
{
    [SerializeField]private int satisfacaoInicial;
    [SerializeField]private int SatisfacaoMax;
    [SerializeField]private int SatsfacaoPorTiro;
    private int SatisfacaoAtual;
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
