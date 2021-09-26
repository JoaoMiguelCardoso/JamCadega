using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reputacao : MonoBehaviour
{
    [SerializeField]private float reputacaoNecessaria;
    [SerializeField]private float reputacaoInicial;
    [SerializeField]private float reputacaoMax;
    private float reputacaoAtual;
    private int WavesRestantes;
    private GameObject spwaner;
    private GameObject winlose;
    public bool iniciou;
    private void Start(){
        reputacaoAtual = reputacaoInicial;
        spwaner = GameObject.FindGameObjectWithTag("spawner");
        winlose = GameObject.FindGameObjectWithTag("winlose");
    }
    void LateUpdate()
    {
        WavesRestantes = spwaner.GetComponent<SpawnaInimigos>().WavesRestantes;
        if(WavesRestantes <= 0 && iniciou== true){
            if(GameObject.FindGameObjectWithTag("Enemy") == null){
                if(reputacaoAtual >= reputacaoNecessaria){
                    winlose.GetComponent<winlose>().ganhou();
                }else{
                    winlose.GetComponent<winlose>().perdeu();
                }
            }
        }
    }

    public void aumentareputa(float a){
        if(reputacaoInicial +a < reputacaoMax){
            reputacaoAtual = reputacaoAtual + a;
        }else if(reputacaoInicial +a >= reputacaoMax){
            reputacaoAtual = reputacaoMax;
        }
    }
    public void diminuireputa(float a){
        if(reputacaoAtual - a > 0){
            reputacaoAtual = reputacaoAtual - a;
        }else if(reputacaoInicial -a <= 0){
            winlose.GetComponent<winlose>().perdeu();
            reputacaoAtual = 0;
        }
    }
}
