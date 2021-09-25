using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    [SerializeField] List<DadosTorre> torres;
    [SerializeField] GerenciadorTorres gerenciadorTorres;
    [SerializeField] int qtdInicialMoedas;
    [SerializeField] Text txtMoedas;

    int moedas;
    DadosTorre ultimaTorre;

    void Start()
    {
        AlterarMoedas(qtdInicialMoedas);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            AlterarMoedas(20);
    }

    public void SelecionarTorre(int idTorre)
    {
        ultimaTorre = torres[idTorre];
        if(moedas >= ultimaTorre.custo)
            gerenciadorTorres.EscolherTorre(ultimaTorre);
    }

    public void TorreComprada()
    {
        AlterarMoedas(-ultimaTorre.custo);
    }

    void AlterarMoedas(int valor)
    {
        moedas += valor;
        txtMoedas.text = moedas.ToString();
    }
}
