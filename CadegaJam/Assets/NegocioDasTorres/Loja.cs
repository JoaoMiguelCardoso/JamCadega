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
    [SerializeField] GameObject objDescricao;
    [SerializeField] Text txtDescricao;
    [SerializeField] Tabuleiro tabuleiro;

    int moedas;
    DadosTorre ultimaTorre;

    void Start()
    {
        ultimaTorre = torres[0];
        AlterarMoedas(qtdInicialMoedas);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AlterarMoedas(20);
    }

    public void SelecionarTorre(int idTorre)
    {
        if (moedas >= torres[idTorre].custo)
        {
            ultimaTorre = torres[idTorre];
            gerenciadorTorres.EscolherTorre(ultimaTorre);
        }
    }

    public void TorreComprada(Vector2 posicao)
    {
        AlterarMoedas(-ultimaTorre.custo);
        tabuleiro.AlterarValorArea(posicao, ultimaTorre.valorArea);
    }

    public void TorreVendida(Vector2 posicao, DadosTorre dados)
    {
        AlterarMoedas(Mathf.RoundToInt(dados.custo / 2));
        tabuleiro.AlterarValorArea(posicao, -dados.valorArea);
    }

    void AlterarMoedas(int valor)
    {
        moedas += valor;
        txtMoedas.text = moedas.ToString();
    }

    public void AlterarObjDescricao(bool ativo)
    {
        objDescricao.SetActive(ativo);
    }

    public void ExibirDescricao(int id, float posX)
    {
        AlterarObjDescricao(true);
        txtDescricao.text = torres[id].descricao;
        objDescricao.transform.position = new Vector2(posX, objDescricao.transform.position.y);
    }
}
