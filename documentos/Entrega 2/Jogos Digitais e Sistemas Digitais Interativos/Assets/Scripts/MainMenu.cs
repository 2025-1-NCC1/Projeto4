using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para gerenciar cenas

public class MainMenu : MonoBehaviour
{
    // Fun��o que ser� chamada quando o bot�o de iniciar for clicado
    public void IniciarJogo()
    {
        // Muda para a cena do jogo (pode ser o nome da cena que voc� deseja carregar)
        SceneManager.LoadScene("GameScene"); // Altere para o nome da sua cena do jogo
    }
}
