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

    public void FinalizarDia()
    {
        GerarRankingCasas();
        MostrarRanking();
    }

    void GerarRankingCasas()
    {
        consumosCasas.Clear();
        for (int i = 0; i < 4; i++)
        {
            consumosCasas.Add(Random.Range(5, 21));
        }
    }

    void MostrarRanking()
    {
        txtRanking.text = RetornarRanking();
    }

    public string RetornarRanking()
    {
        List<int> ranking = new List<int>(consumosCasas);
        ranking.Add(energia);

        ranking.Sort((a, b) => b.CompareTo(a));

        string resultado = "Ranking de Consumo de Energia:\n";

        int pos = 1;
        foreach (int consumo in ranking)
        {
            if (consumo == energia)
                resultado += $"Sua casa: {consumo} kWh\n";
            else
                resultado += $"Casa {pos++}: {consumo} kWh\n";
        }

        int menorConsumo = Mathf.Min(ranking.ToArray());

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

    // Métodos de decisão
    public void AssistirTV(string opcao)
    {
        if (opcao == "3horas") { energia += 3; bemEstar += 2; }
        else if (opcao == "1hora") { energia += 1; bemEstar += 1; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }

    public void Dormir(string opcao)
    {
        if (opcao == "cedo") bemEstar += 2;
        else { energia += 2; bemEstar -= 1; }
        AtualizarStatus();
    }

    public void UsarChuveiro(string opcao)
    {
        if (opcao == "10min") { energia += 2; bemEstar += 1; }
        else if (opcao == "20min") { energia += 4; bemEstar += 2; }
        else { bemEstar -= 2; }
        AtualizarStatus();
    }

    public void Cozinhar(string opcao)
    {
        if (opcao == "forno") { energia += 5; bemEstar += 2; }
        else if (opcao == "microondas") { energia += 2; bemEstar += 1; }
        else { bemEstar -= 2; }
        AtualizarStatus();
    }

    public void Ventilar(string opcao)
    {
        if (opcao == "janelas") bemEstar += 1;
        else { energia += 1; bemEstar += 2; }
        AtualizarStatus();
    }

    public void Iluminar(string opcao)
    {
        if (opcao == "luzNatural") bemEstar += 1;
        else { energia += 1; bemEstar += 2; }
        AtualizarStatus();
    }

    public void LavarRoupa(string opcao)
    {
        if (opcao == "sim") { energia += 4; bemEstar += 2; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }

    public void CarregarCelular(string opcao)
    {
        if (opcao == "sim") { energia += 1; bemEstar += 1; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }

    public void FazerCafe(string opcao)
    {
        if (opcao == "sim") { energia += 2; bemEstar += 2; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }

    public void UsarComputador(string opcao)
    {
        if (opcao == "2horas") { energia += 3; bemEstar += 1; }
        else if (opcao == "30min") { energia += 1; bemEstar += 1; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }

    public void PassarRoupa(string opcao)
    {
        if (opcao == "sim") { energia += 3; bemEstar += 1; }
        else { bemEstar -= 1; }
        AtualizarStatus();
    }
}
