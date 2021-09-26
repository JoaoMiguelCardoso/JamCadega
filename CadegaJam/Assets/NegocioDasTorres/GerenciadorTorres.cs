using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GerenciadorTorres : MonoBehaviour
{
    [SerializeField] PreviaTorre previa;
    [SerializeField] Loja loja;
    [SerializeField] Tabuleiro tabuleiro;

    DadosTorre torreAtual;
    Torre torreSelecionada;

    void Start()
    {
        AlterarEstadoPrevia(false);
    }

    void Update()
    {
        if (previa.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (previa.PosicaoValida())
                    PosicionarTorre(torreAtual.torre, previa.transform.position);
            }

            if (Input.GetMouseButtonDown(1))
            {
                AlterarEstadoPrevia(false);
            }
        }
    }

    void AlterarEstadoPrevia(bool ativa)
    {
        previa.gameObject.SetActive(ativa);
        previa.AtualizarPosicao();

        tabuleiro.ExibirValoresAreas(ativa);
    }

    void AlterarSpritePrevia(Sprite sprite)
    {
        previa.SelecionarSprite(sprite);
    }

    public void EscolherTorre(DadosTorre torre)
    {
        torreAtual = torre;
        AlterarEstadoPrevia(true);
        AlterarSpritePrevia(torreAtual.sprite);
        previa.DefinirValor(torreAtual.valorArea);
        previa.DefinirAlcance(torreAtual.alcance);

        if(torreSelecionada != null)
            torreSelecionada.AlterarObjRemover(false);
    }

    void PosicionarTorre(GameObject torre, Vector2 posicao)
    {
        Torre t = Instantiate(torre, posicao, Quaternion.identity).GetComponent<Torre>();
        t.DefinirGerenciador(this);
        AlterarEstadoPrevia(false);
        loja.TorreComprada(posicao);
    }

    public bool AutorizarRemocao(Torre t)
    {
        if(!previa.gameObject.activeSelf && torreSelecionada != null && torreSelecionada != t)
            torreSelecionada.AlterarObjRemover(false);

        torreSelecionada = t;
        return !previa.gameObject.activeSelf;
    }

    public void VenderTorre(Vector2 posicao, DadosTorre dados)
    {
        loja.TorreVendida(posicao, dados);
    }
}
