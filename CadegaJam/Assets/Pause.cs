using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    private bool pausado;
    [SerializeField]private GameObject telapause;
    [SerializeField]private GameObject option;
    
    void Start()
    {
        telapause.SetActive(false);
        option.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(pausado == false){
                Pausa();
            }else{
                resume();
            }
        }
    }

    public void Pausa(){
        pausado = true;
        telapause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume(){
        pausado = false;
        telapause.SetActive(false);
        option.SetActive(false);
        Time.timeScale = 1f;
    }
    public void options(){
        telapause.SetActive(false);
        option.SetActive(true);
    }
    public void back(){
        telapause.SetActive(true);
        option.SetActive(false);
    }
    public void quit(){
        Application.Quit();
    }
    public void main(){
        SceneManager.LoadScene(0);
    }
}
