using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GerenciadorTorres : MonoBehaviour
{
    [SerializeField] PreviaTorre previa;
    [SerializeField] Loja loja;

    DadosTorre torreAtual;

    void Start()
    {
        AlterarEstadoPrevia(false);
    }

    void Update()
    {
        if (previa.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (previa.PosicaoValida())
                {
                    Vector2 posPrevia = previa.transform.position;
                    PosicionarTorre(torreAtual.torre, posPrevia);
                }
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
    }

    void PosicionarTorre(GameObject torre, Vector2 posicao)
    {
        Instantiate(torre, posicao, Quaternion.identity);
        AlterarEstadoPrevia(false);
        loja.TorreComprada();
    }
}
