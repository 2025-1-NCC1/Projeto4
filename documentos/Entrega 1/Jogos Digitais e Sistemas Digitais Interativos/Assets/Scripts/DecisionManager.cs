using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DecisionManager : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public TextMeshProUGUI perguntaText;
    public Button[] botoes;
    public TextMeshProUGUI[] botoesText;
    public TextMeshProUGUI txtRanking; // UI do ranking (visível no final)
    public Button btnJogarNovamente; // botão para reiniciar o jogo

    private int etapaAtual = 0;
    private bool diaFinalizado = false;

    void Start()
    {
        txtRanking.gameObject.SetActive(false); // Esconde o ranking no início
        MostrarProximaPergunta();
        btnJogarNovamente.gameObject.SetActive(false);
    }

    public void Responder(int opcao)
    {
        if (diaFinalizado) return;

        switch (etapaAtual)
        {
            case 0:
                if (opcao == 0) playerStatus.AssistirTV("3horas");
                else if (opcao == 1) playerStatus.AssistirTV("1hora");
                else playerStatus.AssistirTV("nao");
                break;

            case 1:
                if (opcao == 0) playerStatus.Dormir("cedo");
                else playerStatus.Dormir("tarde");
                break;

            case 2:
                if (opcao == 0) playerStatus.UsarChuveiro("10min");
                else if (opcao == 1) playerStatus.UsarChuveiro("20min");
                else playerStatus.UsarChuveiro("nao");
                break;

            case 3:
                if (opcao == 0) playerStatus.Cozinhar("forno");
                else if (opcao == 1) playerStatus.Cozinhar("microondas");
                else playerStatus.Cozinhar("pular");
                break;

            case 4:
                if (opcao == 0) playerStatus.Ventilar("janelas");
                else playerStatus.Ventilar("ventilador");
                break;

            case 5:
                if (opcao == 0) playerStatus.Iluminar("luzNatural");
                else playerStatus.Iluminar("lampada");
                break;

            case 6:
                if (opcao == 0) playerStatus.LavarRoupa("sim");
                else playerStatus.LavarRoupa("nao");
                break;

            case 7:
                if (opcao == 0) playerStatus.CarregarCelular("sim");
                else playerStatus.CarregarCelular("nao");
                break;

            case 8:
                if (opcao == 0) playerStatus.FazerCafe("sim");
                else playerStatus.FazerCafe("nao");
                break;

            case 9:
                if (opcao == 0) playerStatus.UsarComputador("2horas");
                else if (opcao == 1) playerStatus.UsarComputador("30min");
                else playerStatus.UsarComputador("nao");
                break;

            case 10:
                if (opcao == 0) playerStatus.PassarRoupa("sim");
                else playerStatus.PassarRoupa("nao");
                break;
        }

        playerStatus.AtualizarStatus();
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

        txtRanking.gameObject.SetActive(false); // Garante que ranking fique escondido até o final

        switch (etapaAtual)
        {
            case 0:
                perguntaText.text = "Assistir TV?";
                MostrarOpcoes(new string[] { "3h", "1h", "Não" });
                break;
            case 1:
                perguntaText.text = "Dormir agora?";
                MostrarOpcoes(new string[] { "Sim (cedo)", "Não (tarde)" });
                break;
            case 2:
                perguntaText.text = "Usar chuveiro?";
                MostrarOpcoes(new string[] { "10min", "20min", "Não" });
                break;
            case 3:
                perguntaText.text = "Cozinhar?";
                MostrarOpcoes(new string[] { "Forno", "Microondas", "Pular" });
                break;
            case 4:
                perguntaText.text = "Ventilar?";
                MostrarOpcoes(new string[] { "Janelas", "Ventilador" });
                break;
            case 5:
                perguntaText.text = "Iluminar?";
                MostrarOpcoes(new string[] { "Luz Natural", "Lâmpada" });
                break;
            case 6:
                perguntaText.text = "Lavar Roupa?";
                MostrarOpcoes(new string[] { "Sim", "Não" });
                break;
            case 7:
                perguntaText.text = "Carregar Celular?";
                MostrarOpcoes(new string[] { "Sim", "Não" });
                break;
            case 8:
                perguntaText.text = "Fazer Café?";
                MostrarOpcoes(new string[] { "Sim", "Não" });
                break;
            case 9:
                perguntaText.text = "Usar Computador?";
                MostrarOpcoes(new string[] { "2h", "30min", "Não" });
                break;
            case 10:
                perguntaText.text = "Passar Roupa?";
                MostrarOpcoes(new string[] { "Sim", "Não" });
                break;
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

    public void JogarNovamente()
    {
        etapaAtual = 0;
        diaFinalizado = false;

        playerStatus.ReiniciarStatus(); // você deve criar esse método no PlayerStatus se ainda não tiver
        txtRanking.gameObject.SetActive(false);
        btnJogarNovamente.gameObject.SetActive(false);

        MostrarProximaPergunta();
    }
    void FinalizarDia()
    {
        diaFinalizado = true;

        foreach (var btn in botoes)
            btn.gameObject.SetActive(false); // Esconde os botões

        txtRanking.gameObject.SetActive(true); // Mostra o ranking na UI
        playerStatus.FinalizarDia();
        txtRanking.text = playerStatus.RetornarRanking();
        btnJogarNovamente.gameObject.SetActive(true);
    }
}
