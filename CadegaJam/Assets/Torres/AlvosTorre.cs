using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvosTorre : MonoBehaviour
{
    [SerializeField] Torre torre;
    [SerializeField] List<string> tagsAtacar;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (tagsAtacar.Contains(col.tag))
            torre.AdicionarAlvo(col.transform);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (tagsAtacar.Contains(col.tag))
            torre.RemoverAlvo(col.transform);
    }
}
