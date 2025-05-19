using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputsJogador : MonoBehaviour
{
    public float energiaTotal = 100f, velocidadeConsumo = 1f, cooldown = 0.3f;
    public List<Dispositivo> dispositivos = new();
    public Text textoEnergia, textoMensagem;
    public AudioSource somLigar, somDesligar;

    float energiaAtual, energiaGasta;
    float[] ultimoToggle = new float[10];

    void Start() => energiaAtual = energiaTotal;

    void Update()
    {
        float consumo = 0f;

        for (int i = 0; i < dispositivos.Count; i++)
        {
            var d = dispositivos[i];

            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && Time.time - ultimoToggle[i] >= cooldown)
            {
                d.ligado = !d.ligado;
                if (d.objetoVisual) d.objetoVisual.SetActive(d.ligado);
                if (textoMensagem) textoMensagem.text = d.nome.ToUpper() + " (" + d.categoria + ") " + (d.ligado ? "LIGADO" : "DESLIGADO");
                Debug.Log("Dispositivo " + d.nome + " agora esta " + (d.ligado ? "ligado" : "desligado"));
                ultimoToggle[i] = Time.time;
            }

            if (d.ligado && energiaAtual > 0f)
            {
                float uso = d.consumoPorSegundo * Time.deltaTime * velocidadeConsumo;
                consumo += uso;
                Debug.Log("Dispositivo " + d.nome + " consumindo: " + uso.ToString("F4") + "W");
            }
        }

        energiaAtual = Mathf.Max(energiaAtual - consumo, 0f);
        energiaGasta += consumo;
        if (textoEnergia) textoEnergia.text = "Energia: " + energiaAtual.ToString("F1") + "W | Gasta: " + energiaGasta.ToString("F1") + "W";
        Debug.Log("Energia atual: " + energiaAtual.ToString("F2") + " | Gasta: " + energiaGasta.ToString("F2"));
    }

    [System.Serializable]
    public class Dispositivo
    {
        public string nome, categoria;
        public float consumoPorSegundo = 1f;
        public bool ligado;
        public GameObject objetoVisual;
    }
}
