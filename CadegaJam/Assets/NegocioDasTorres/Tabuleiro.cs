using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] int xMin;
    [SerializeField] int xMax;
    [SerializeField] int yMin;
    [SerializeField] int yMax;
    Dictionary<Vector2, int> posicoes = new Dictionary<Vector2, int>();

    void Start()
    {
        for (int i = yMin; i < yMax; i++)
        {
            for (int i2 = xMin; i2 < xMax; i2++)
            {
                Vector2 pos = new Vector2(i2 + 0.5f, i + 0.5f);
                int valor = Physics2D.OverlapCircle(pos, 0.15f) ? -1 : 0;

                posicoes.Add(pos, valor);
            }
        }
    }

    void Update()
    {
        
    }
}
