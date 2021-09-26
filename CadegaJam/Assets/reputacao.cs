using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reputacao : MonoBehaviour
{
    [SerializeField]private float reputacaoNecessaria;
    [SerializeField]private float reputacaoInicial;
    [SerializeField]private float reputacaoMax;
    private float reputacaoAtual;
    public bool ganhou;
    public bool perdeu;
    private int WavesRestantes;

    private void Start(){
        reputacaoAtual = reputacaoInicial;
    }
    void Update()
    {
        if(WavesRestantes <= 0 ){
            if(GameObject.FindGameObjectsWithTag("Enemy") == null){
                if(reputacaoAtual >= reputacaoNecessaria){
                    ganhou = true;
                }else{
                    perdeu = true;
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
            reputacaoAtual = 0;
        }
    }
}
