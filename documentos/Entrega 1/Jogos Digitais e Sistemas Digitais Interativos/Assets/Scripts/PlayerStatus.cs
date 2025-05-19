using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    public int energia = 0;
    public int bemEstar = 5;

    public TextMeshProUGUI txtEnergia;
    public TextMeshProUGUI txtBemEstar;
    public TextMeshProUGUI txtRanking;

    private List<int> consumosCasas = new List<int>();

    void Start()
    {
        AtualizarStatus();
    }

    public void AtualizarStatus()
    {
        energia = Mathf.Max(0, energia);
        bemEstar = Mathf.Clamp(bemEstar, 0, 99);

        txtEnergia.text = "Energia: " + energia + " kWh";
        txtBemEstar.text = "Bem-Estar: " + bemEstar;

        Debug.Log("Energia: " + energia + " | Bem-Estar: " + bemEstar);
    }

    // Método para ser chamado ao final do dia para gerar e exibir o ranking
    public void FinalizarDia()
    {
        GerarRankingCasas();
        MostrarRanking();
    }

    // Gerar consumo de energia aleatório para 4 casas
    void GerarRankingCasas()
    {
        consumosCasas.Clear();
        for (int i = 0; i < 4; i++)
        {
            consumosCasas.Add(Random.Range(5, 21)); // Consumo aleatório entre 5 e 20 kWh
        }
    }

    // Mostrar o ranking de consumo de energia
    void MostrarRanking()
    {
        // Adicionar o consumo de energia da casa do jogador ao ranking
        consumosCasas.Add(energia);

        // Ordenar os consumos em ordem decrescente (maior consumo primeiro)
        consumosCasas.Sort((a, b) => b.CompareTo(a));

        // Mostrar o ranking na tela
        txtRanking.text = "Ranking de Consumo de Energia:\n";
        for (int i = 0; i < consumosCasas.Count; i++)
        {
            if (i == 0)
                txtRanking.text += "Sua casa: " + consumosCasas[i] + " kWh\n";
            else
                txtRanking.text += "Casa " + i + ": " + consumosCasas[i] + " kWh\n";
        }
    }

    // Decisão: Assistir TV
    public void AssistirTV(string opcao)
    {
        switch (opcao)
        {
            case "3horas":
                energia += 3;
                bemEstar += 2;
                break;
            case "1hora":
                energia += 1;
                bemEstar += 1;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Dormir
    public void Dormir(string opcao)
    {
        switch (opcao)
        {
            case "cedo":
                bemEstar += 2;
                break;
            case "tarde":
                energia += 2;
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Usar chuveiro
    public void UsarChuveiro(string opcao)
    {
        switch (opcao)
        {
            case "10min":
                energia += 2;
                bemEstar += 1;
                break;
            case "20min":
                energia += 4;
                bemEstar += 2;
                break;
            case "nao":
                bemEstar -= 2;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Cozinhar
    public void Cozinhar(string opcao)
    {
        switch (opcao)
        {
            case "forno":
                energia += 5;
                bemEstar += 2;
                break;
            case "microondas":
                energia += 2;
                bemEstar += 1;
                break;
            case "pular":
                bemEstar -= 2;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Ventilar
    public void Ventilar(string opcao)
    {
        switch (opcao)
        {
            case "janelas":
                bemEstar += 1;
                break;
            case "ventilador":
                energia += 1;
                bemEstar += 2;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Iluminar
    public void Iluminar(string opcao)
    {
        switch (opcao)
        {
            case "luzNatural":
                bemEstar += 1;
                break;
            case "lampada":
                energia += 1;
                bemEstar += 2;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Lavar Roupa
    public void LavarRoupa(string opcao)
    {
        switch (opcao)
        {
            case "sim":
                energia += 4;
                bemEstar += 2;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Carregar Celular
    public void CarregarCelular(string opcao)
    {
        switch (opcao)
        {
            case "sim":
                energia += 1;
                bemEstar += 1;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Fazer Café
    public void FazerCafe(string opcao)
    {
        switch (opcao)
        {
            case "sim":
                energia += 2;
                bemEstar += 2;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Usar Computador
    public void UsarComputador(string opcao)
    {
        switch (opcao)
        {
            case "2horas":
                energia += 3;
                bemEstar += 1;
                break;
            case "30min":
                energia += 1;
                bemEstar += 1;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Decisão: Passar Roupa
    public void PassarRoupa(string opcao)
    {
        switch (opcao)
        {
            case "sim":
                energia += 3;
                bemEstar += 1;
                break;
            case "nao":
                bemEstar -= 1;
                break;
        }

        AtualizarStatus();
    }

    // Retorna o ranking formatado para exibição
    public string RetornarRanking()
    {
        List<int> consumosComJogador = new List<int>(consumosCasas);
        consumosComJogador.Add(energia); // Adiciona o consumo da casa do jogador

        // Cria uma cópia ordenada em ordem decrescente
        List<int> rankingOrdenado = new List<int>(consumosComJogador);
        rankingOrdenado.Sort((a, b) => b.CompareTo(a));

        string resultado = "Ranking de Consumo de Energia:\n";

        for (int i = 0; i < rankingOrdenado.Count; i++)
        {
            if (rankingOrdenado[i] == energia)
            {
                resultado += "Sua casa: " + rankingOrdenado[i] + " kWh\n";
            }
            else
            {
                resultado += "Casa " + i + ": " + rankingOrdenado[i] + " kWh\n";
            }
        }

        // Verifica se o jogador teve o menor consumo
        int menorConsumo = Mathf.Min(consumosComJogador.ToArray());

        if (energia == menorConsumo)
            resultado += "\nParabéns, você consumiu energia de forma consciente!";
        else
            resultado += "\nVocê consumiu energia em excesso!";

        return resultado;
    }

    public void ReiniciarStatus()
    {
        energia = 0;
        bemEstar = 5;
        AtualizarStatus();
    }
}
