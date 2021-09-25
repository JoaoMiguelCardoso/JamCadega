using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] int xMin;
    [SerializeField] int xMax;
    [SerializeField] int yMin;
    [SerializeField] int yMax;
    [SerializeField] LayerMask areaValida;
    [SerializeField] GameObject textoValor;
    [SerializeField] Transform objTextos;
    Dictionary<Vector2, int> posicoes = new Dictionary<Vector2, int>();
    Dictionary<Vector2, TextoValor> valores = new Dictionary<Vector2, TextoValor>();

    void Start()
    {
        for (int i = yMin; i < yMax; i++)
        {
            for (int i2 = xMin; i2 < xMax; i2++)
            {
                Vector2 pos = new Vector2(i2 + 0.5f, i + 0.5f);

                if (Physics2D.OverlapCircle(pos, 0.15f, areaValida))
                {
                    posicoes.Add(pos, 0);

                    TextoValor t = Instantiate(textoValor, pos, Quaternion.identity, objTextos).GetComponent<TextoValor>();
                    valores.Add(pos, t);
                    t.AtualizarValor(0);
                }

                // Debug.Log(pos + ", " + valor);
            }
        }

        ExibirValoresAreas(false);
    }

    void Update()
    {

    }

    public void ExibirValoresAreas(bool exibir)
    {
        objTextos.gameObject.SetActive(exibir);
    }

    public void AlterarValorArea(Vector2 posicao, int valor)
    {
        for (int i = (int)(posicao.y - 1.5f); i < (int)(posicao.y + 1.5f); i++)
        {
            for (int i2 = (int)(posicao.x - 1.5f); i2 < (int)(posicao.x + 1.5f); i2++)
            {
                Vector2 pos = new Vector2(i2 + 0.5f, i + 0.5f);
                Debug.Log(pos + "x: " + i2 + ", y: " + i);

                if (pos == posicao)
                    posicoes[pos] = 50;
                else if (posicoes.ContainsKey(pos))
                {
                    posicoes[pos] += valor;
                    valores[pos].AtualizarValor(posicoes[pos]);
                }
            }
        }
    }
}
