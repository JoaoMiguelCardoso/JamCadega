using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoValor : MonoBehaviour
{
    [SerializeField] Text texto;
    [SerializeField] Gradient cor;

    public void AtualizarValor(int valor)
    {
        texto.text = valor.ToString();
        texto.color = cor.Evaluate(valor / 50f);
    }
}
