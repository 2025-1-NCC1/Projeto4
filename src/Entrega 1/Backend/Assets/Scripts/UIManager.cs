using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public TextMeshProUGUI txtEnergia;
    public TextMeshProUGUI txtBemEstar;

    void Start()
    {
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        txtEnergia.text = "Energia: " + playerStatus.energia;
        txtBemEstar.text = "Bem-Estar: " + playerStatus.bemEstar;
    }

    // Métodos chamados pelos botões
    public void BtnAssistirTV_3h() { playerStatus.AssistirTV("3horas"); AtualizarUI(); }
    public void BtnAssistirTV_1h() { playerStatus.AssistirTV("1hora"); AtualizarUI(); }
    public void BtnAssistirTV_Nao() { playerStatus.AssistirTV("nao"); AtualizarUI(); }

    public void BtnDormirCedo() { playerStatus.Dormir("cedo"); AtualizarUI(); }
    public void BtnDormirTarde() { playerStatus.Dormir("tarde"); AtualizarUI(); }

    // Continue adicionando outros botões conforme o script PlayerStatus
}
