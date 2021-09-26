using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField]private GameObject option;
    [SerializeField]private GameObject creditos;
    [SerializeField]private GameObject inicio;
    [SerializeField]private GameObject canvasPause;
    [SerializeField]private GameObject jogo;
    [SerializeField]private GameObject fundo;
    [SerializeField]private GameObject BotaoDePulo;
    [SerializeField]private Animator transi;
    [SerializeField]private GameObject telawinlose;
    
    

    void Start()
    {
        inicio.SetActive(true);
        creditos.SetActive(false);
        option.SetActive(false);
        jogo.SetActive(false);
        canvasPause.SetActive(false);
        fundo.SetActive(true);
        BotaoDePulo.SetActive(false);
        telawinlose.SetActive(false);
    }
    public void iniciar(){
        StartCoroutine( transicao());
    }
    IEnumerator transicao(){
        transi.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        inicio.SetActive(false);
        creditos.SetActive(false);
        option.SetActive(false);
        jogo.SetActive(true);
        BotaoDePulo.SetActive(true);
        canvasPause.SetActive(true);
        fundo.SetActive(false);
        transi.SetTrigger("end");
        telawinlose.SetActive(true);
    }
    public void credito(){
        creditos.SetActive(true);
        inicio.SetActive(false);
    }
    public void options(){
        inicio.SetActive(false);
        option.SetActive(true);
    }
    public void back(){
        inicio.SetActive(true);
        option.SetActive(false);
        creditos.SetActive(false);
    }
    public void quit(){
        Application.Quit();
    }
}
