using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSons : MonoBehaviour
{
    public static GerenciadorSons instancia;

    void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
    }

    public Transform sons;

    List<AudioSource> objsSom = new List<AudioSource>();

    public void ReproduzirEfeito(AudioClip clip, float volume, bool pitchAleatorio)
    {
        AudioSource _source = ObjSom();
        _source.clip = clip;
        _source.volume = volume;
        if (pitchAleatorio)
            _source.pitch = Random.Range(0.9f, 1.1f);
        _source.Play();
    }

    AudioSource ObjSom()
    {
        if (objsSom.Count > 0)
        {
            for (int i = 0; i < objsSom.Count; i++)
            {
                if (!objsSom[i].isPlaying)
                    return objsSom[i];
            }
        }

        GameObject som = new GameObject("Som");
        som.transform.position = sons.position;
        som.transform.parent = sons;
        AudioSource _source = som.AddComponent<AudioSource>();
        objsSom.Add(_source);

        return _source;
    }
}
