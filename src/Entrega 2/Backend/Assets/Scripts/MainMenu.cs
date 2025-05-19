using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class MainMenu : MonoBehaviour
{
    // Função que será chamada quando o botão de iniciar for clicado
    public void IniciarJogo()
    {
        // Muda para a cena do jogo (pode ser o nome da cena que você deseja carregar)
        SceneManager.LoadScene("GameScene"); // Altere para o nome da sua cena do jogo
    }
}
