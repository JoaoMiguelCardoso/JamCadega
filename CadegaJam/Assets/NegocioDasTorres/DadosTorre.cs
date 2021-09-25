using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Torre", menuName = "Torres/Nova Torre", order = 1)]
public class DadosTorre : ScriptableObject
{
    public GameObject torre;
    public int custo;
    public int valorArea;
    public Sprite sprite;
    [Multiline]
    public string descricao;
}
