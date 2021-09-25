using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaNoCaminho : MonoBehaviour
{
    private List<GameObject> pontos = new List<GameObject>();
    [SerializeField]private float velocidade;
    private int PontoAtual;

    void Start()
    {
        GetCaminho();
        transform.position = pontos[PontoAtual].transform.position;
    }

    void Update()
    {
        Anda();
    }
    private void GetCaminho(){
        GameObject pack = GameObject.FindGameObjectWithTag("caminho");
        int a = pack.transform.childCount;
        for (int i = 0; i < a; i++)
        {
            pontos.Add(pack.transform.GetChild(i).gameObject);
        }
    }
    private void Anda(){
        if (PontoAtual <= pontos.Count -1)
        {

            transform.position = Vector2.MoveTowards(transform.position,pontos[PontoAtual].transform.position,velocidade * Time.deltaTime);

            if (transform.position == pontos[PontoAtual].transform.position)
            {
                PontoAtual += 1;
            }
        }
        if(PontoAtual == pontos.Count){
            Destroy(this.gameObject);
        }
    }
}
