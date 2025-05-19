using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DecisionManager : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public TextMeshProUGUI perguntaText;
    public Button[] botoes;
    public TextMeshProUGUI[] botoesText;
    public TextMeshProUGUI txtRanking;
    public Button btnJogarNovamente;

    private int etapaAtual = 0;
    private bool diaFinalizado = false;
    private bool bemEstarZerado = false;

    void Start()
    {
        txtRanking.gameObject.SetActive(false);
        btnJogarNovamente.gameObject.SetActive(false);
        MostrarProximaPergunta();
    }

    public void Responder(int opcao)
    {
        if (diaFinalizado) return;

        switch (etapaAtual)
        {
            case 0: playerStatus.AssistirTV(opcao == 0 ? "3horas" : opcao == 1 ? "1hora" : "nao"); break;
            case 1: playerStatus.Dormir(opcao == 0 ? "cedo" : "tarde"); break;
            case 2: playerStatus.UsarChuveiro(opcao == 0 ? "10min" : opcao == 1 ? "20min" : "nao"); break;
            case 3: playerStatus.Cozinhar(opcao == 0 ? "forno" : opcao == 1 ? "microondas" : "pular"); break;
            case 4: playerStatus.Ventilar(opcao == 0 ? "janelas" : "ventilador"); break;
            case 5: playerStatus.Iluminar(opcao == 0 ? "luzNatural" : "lampada"); break;
            case 6: playerStatus.LavarRoupa(opcao == 0 ? "sim" : "nao"); break;
            case 7: playerStatus.CarregarCelular(opcao == 0 ? "sim" : "nao"); break;
            case 8: playerStatus.FazerCafe(opcao == 0 ? "sim" : "nao"); break;
            case 9: playerStatus.UsarComputador(opcao == 0 ? "2horas" : opcao == 1 ? "30min" : "nao"); break;
            case 10: playerStatus.PassarRoupa(opcao == 0 ? "sim" : "nao"); break;
        }

        if (playerStatus.bemEstar <= 0)
        {
            perguntaText.text = "Seu bem-estar chegou ao limite. Cuide-se melhor e tente novamente!";
            bemEstarZerado = true;
            FinalizarDia();
            return;
        }

        etapaAtual++;

        if (etapaAtual > 10)
        {
            perguntaText.text = "Fim do dia!";
            FinalizarDia();
        }
        else
        {
            MostrarProximaPergunta();
        }
    }

    void MostrarProximaPergunta()
    {
        foreach (var btn in botoes)
            btn.gameObject.SetActive(false);

        txtRanking.gameObject.SetActive(false);

        switch (etapaAtual)
        {
            case 0: perguntaText.text = "Assistir TV?"; MostrarOpcoes(new string[] { "3h", "1h", "Não" }); break;
            case 1: perguntaText.text = "Dormir agora?"; MostrarOpcoes(new string[] { "Sim (cedo)", "Não (tarde)" }); break;
            case 2: perguntaText.text = "Usar chuveiro?"; MostrarOpcoes(new string[] { "10min", "20min", "Não" }); break;
            case 3: perguntaText.text = "Cozinhar?"; MostrarOpcoes(new string[] { "Forno", "Microondas", "Pular" }); break;
            case 4: perguntaText.text = "Ventilar?"; MostrarOpcoes(new string[] { "Janelas", "Ventilador" }); break;
            case 5: perguntaText.text = "Iluminar?"; MostrarOpcoes(new string[] { "Luz Natural", "Lâmpada" }); break;
            case 6: perguntaText.text = "Lavar Roupa?"; MostrarOpcoes(new string[] { "Sim", "Não" }); break;
            case 7: perguntaText.text = "Carregar Celular?"; MostrarOpcoes(new string[] { "Sim", "Não" }); break;
            case 8: perguntaText.text = "Fazer Café?"; MostrarOpcoes(new string[] { "Sim", "Não" }); break;
            case 9: perguntaText.text = "Usar Computador?"; MostrarOpcoes(new string[] { "2h", "30min", "Não" }); break;
            case 10: perguntaText.text = "Passar Roupa?"; MostrarOpcoes(new string[] { "Sim", "Não" }); break;
        }
    }

    void MostrarOpcoes(string[] opcoes)
    {
        for (int i = 0; i < opcoes.Length; i++)
        {
            botoes[i].gameObject.SetActive(true);
            botoesText[i].text = opcoes[i];
        }
    }

    void FinalizarDia()
    {
        diaFinalizado = true;

        foreach (var btn in botoes)
            btn.gameObject.SetActive(false);

        btnJogarNovamente.gameObject.SetActive(true);

        if (!bemEstarZerado)
        {
            playerStatus.FinalizarDia();
            txtRanking.text = playerStatus.RetornarRanking();
            txtRanking.gameObject.SetActive(true);
        }
        else
        {
            txtRanking.gameObject.SetActive(false); // Certifique-se de esconder o ranking
        }
    }

    public void JogarNovamente()
    {
        etapaAtual = 0;
        diaFinalizado = false;
        bemEstarZerado = false;

        playerStatus.ReiniciarStatus();
        txtRanking.gameObject.SetActive(false);
        btnJogarNovamente.gameObject.SetActive(false);

        MostrarProximaPergunta();
    }
}
