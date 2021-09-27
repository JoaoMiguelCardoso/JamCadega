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

    [SerializeField] List<AudioClip> musicas = new List<AudioClip>();
    [SerializeField] AudioSource source;

    public Transform sons;

    List<AudioSource> objsSom = new List<AudioSource>();
    bool trocandoMusica;

    public void ReproduzirEfeito(AudioClip clip, float volume, bool pitchAleatorio)
    {
        AudioSource _source = ObjSom();
        _source.clip = clip;
        _source.volume = volume;
        if (pitchAleatorio)
            _source.pitch = Random.Range(0.9f, 1.1f);
        _source.Play();
    }

    public void TrocarMusica(int indexMusica)
    {
        if(!trocandoMusica)
            StartCoroutine(Musica(musicas[indexMusica]));
    }

    IEnumerator Musica(AudioClip musica)
    {
        trocandoMusica = true;
        float volumeInicial = source.volume;

        while (source.volume > 0)
        {
            source.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        source.Stop();
        source.clip = musica;
        source.Play();

        while (source.volume < volumeInicial)
        {
            source.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        source.volume = volumeInicial;
        trocandoMusica = false;
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
