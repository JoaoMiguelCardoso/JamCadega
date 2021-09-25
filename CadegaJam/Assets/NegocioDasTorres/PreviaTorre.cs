using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviaTorre : MonoBehaviour
{
    [SerializeField] SpriteRenderer spritePrevia;
    [SerializeField] GameObject posicaoInvalida;
    [SerializeField] LayerMask colisaoTorre;

    bool posValida;
    Vector2 posAjustada;

    void Start()
    {

    }

    void Update()
    {
        Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posAjustada.x = posMouse.x > 0 ? Mathf.FloorToInt(posMouse.x) : Mathf.CeilToInt(posMouse.x);
        posAjustada.x += Mathf.Sign(posMouse.x) * 0.5f;
        posAjustada.y = posMouse.y > 0 ? Mathf.FloorToInt(posMouse.y) : Mathf.CeilToInt(posMouse.y);
        posAjustada.y += Mathf.Sign(posMouse.y) * 0.5f;

        // posAjustada = new Vector2(Mathf.FloorToInt(posMouse.x) + (Mathf.Sign(posMouse.x) * 0.5f),
        //                         Mathf.FloorToInt(posMouse.y) + (Mathf.Sign(posMouse.y) * 0.5f));

        if (posAjustada != (Vector2)transform.position)
        {
            AtualizarPosicao();
        }
    }

    public void AtualizarPosicao()
    {
        transform.position = posAjustada;
        posValida = !Physics2D.OverlapCircle(transform.position, 0.25f, colisaoTorre);
        posicaoInvalida.SetActive(!posValida);
    }

    public void SelecionarSprite(Sprite sprite)
    {
        spritePrevia.sprite = sprite;
    }

    public bool PosicaoValida()
    {
        return posValida;
    }
}
