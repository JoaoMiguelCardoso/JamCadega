using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField] float velocidade;
    Torre torre;
    Transform alvo;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
    }

    public void DefinirTorre(Torre t)
    {
        torre = t;
    }

    public void DefinirAlvo(Transform t)
    {
        alvo = t;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform == alvo)
        {
            torre.RetornarProjetil(this);
            gameObject.SetActive(false);
        }
    }
}
