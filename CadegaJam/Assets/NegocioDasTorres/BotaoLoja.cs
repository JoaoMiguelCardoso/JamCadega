using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotaoLoja : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] int id;
    [SerializeField] Loja loja;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Selecionar()
    {
        loja.SelecionarTorre(id);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        loja.ExibirDescricao(id, transform.position.y);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        loja.AlterarObjDescricao(false);
    }
}
