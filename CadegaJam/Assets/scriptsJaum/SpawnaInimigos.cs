using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaInimigos : MonoBehaviour
{
    [SerializeField]private float TempoEntreWaves;
    [SerializeField]private float TempoEntreInimigos;
    [SerializeField]private List<GameObject> Inimigos = new List<GameObject>();
    [SerializeField]private int QuantidadeInicial;
    [SerializeField]private int incremento;
    [SerializeField]private int QuantidadeWaves;
    private float tempoatual;
    private float tempoInimigo;
    private bool surge = true;
    private int quantidadeWave;
    private int foram;
    private int Wave;
    private int InimigoVari;

    void Start()
    {
        quantidadeWave = QuantidadeInicial;
        InimigoVari = QuantidadeWaves/Inimigos.Count ;
    }

    void Update()
    {
        spawna();
    }

    private void spawna(){
        if(Wave < QuantidadeWaves){
            if(tempoatual < Time.time){
                if(foram <= quantidadeWave){
                    if(tempoInimigo < Time.time){
                        if(surge == true){


                            Instantiate(Inimigos[0], transform.position, Quaternion.identity);
                            tempoInimigo = TempoEntreInimigos + Time.time;
                            surge= false;
                            foram ++;
                        }
                    }else
                    {
                        surge = true;
                    }
                }else{
                    quantidadeWave = quantidadeWave +incremento;
                    foram = 0;
                    Wave ++;
                    tempoatual = TempoEntreWaves + Time.time;
                    surge = true;
                }
            }
        }
    }
    private void instancia(){
        
    }
}
