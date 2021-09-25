using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoValor : MonoBehaviour
{
    [SerializeField] Text texto;

    public void AtualizarValor(int valor)
    {
        texto.text = valor.ToString();
    }
}
