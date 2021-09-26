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
    public int WavesRestantes;
    private int InimigoVari;
    private int waveinimigo;
    private int tipos;
    private int podetipo = 1;

    void Start()
    {
        tempoatual = TempoEntreWaves;
        quantidadeWave = QuantidadeInicial;
        InimigoVari = QuantidadeWaves/Inimigos.Count ;
        tipos = Inimigos.Count;
        WavesRestantes = QuantidadeWaves;
        GameObject.FindGameObjectWithTag("reputa").GetComponent<reputacao>().iniciou = true;
    }

    void Update()
    {
        WavesRestantes = QuantidadeWaves - Wave;
        spawna();
    }

    private void spawna(){
        if(Wave < QuantidadeWaves){
            if(tempoatual < Time.time){
                if(foram <= quantidadeWave){
                    if(tempoInimigo < Time.time){
                        if(surge == true){
                            instancia();
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
                    waveinimigo ++;
                    tempoatual = TempoEntreWaves + Time.time;
                    surge = true;
                }
            }
        }
        if(waveinimigo == InimigoVari){
            if(podetipo < tipos){
                podetipo ++;
                waveinimigo = 0;
            }
        }
    }
    private void instancia(){
        int a = Random.Range(0, podetipo);
        Instantiate(Inimigos[a], transform.position, Quaternion.identity);
    }
    public void pulatempo(){
        tempoatual = Time.time;
    }
}
