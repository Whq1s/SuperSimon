using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int[] secuenciaJugador = { 0, 0, 0, 0, 0 };
    [SerializeField] int indiceActualJugador;
    [SerializeField] GenerateSequence generarSecuencia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ComprobarSecuencia(int boton)
    {
        if (generarSecuencia.isAbleToPlay == false) return;
        secuenciaJugador[indiceActualJugador] = boton;

        if (secuenciaJugador[indiceActualJugador] != generarSecuencia.sequence[indiceActualJugador])
        {
            Debug.Log("Perder");
            Perder();
        }
        indiceActualJugador++;
        if (indiceActualJugador == generarSecuencia.currentIndex)
        {
            if (indiceActualJugador == secuenciaJugador.Length)
            {
                Debug.Log("He ganado");
                return;
            }
            StartCoroutine(generarSecuencia.StartGame());
            indiceActualJugador = 0;

        }
    }
    public void Perder()
    {
        indiceActualJugador = 0;
        generarSecuencia.currentIndex = 0;
        for (int i = 0; i < secuenciaJugador.Length; i++)
        {
            secuenciaJugador[i] = 0;
            generarSecuencia.sequence[i] = 0;
        }
        StartCoroutine(generarSecuencia.StartGame());
        
    }
}
