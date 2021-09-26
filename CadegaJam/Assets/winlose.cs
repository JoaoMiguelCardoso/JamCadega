using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winlose : MonoBehaviour
{
    [SerializeField]private GameObject pause;
    [SerializeField]private GameObject jogo;
    [SerializeField]private GameObject win;
    [SerializeField]private GameObject lose;

    private void Start(){
        lose.SetActive(false);
        win.SetActive(false);
    }

    public void ganhou(){
        Debug.Log("ganhou");
        win.SetActive(true);
        lose.SetActive(false);
        jogo.SetActive(false);
        pause.SetActive(false);
    }
    public void perdeu(){
        Debug.Log("perdeu");
        win.SetActive(false);
        lose.SetActive(true);
        jogo.SetActive(false);
        pause.SetActive(false);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void quit(){
        Application.Quit();
    }
}
