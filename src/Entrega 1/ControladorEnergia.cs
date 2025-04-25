using UnityEngine;
using UnityEngine.UI;

public class ControladorDeEnergia : MonoBehaviour
{
    public Slider barraDeEnergia;   // Refer ncia   barra de energia
    public Text textoEnergia;       // Refer ncia ao texto de energia (UI Text)
    public float energiaMaxima = 100f;  // Energia m xima
    public float energiaAtual;          // Energia atual
    public float taxaDeGasto = 20f;    // Quanto de energia   gasto por segundo
    public KeyCode teclaDeAcao = KeyCode.LeftShift;  // Tecla que vai gastar a energia (Shift)

    void Start()
    {
        energiaAtual = energiaMaxima;  // Inicializa a energia com o valor m ximo
        barraDeEnergia.maxValue = energiaMaxima;  // Define o valor m ximo da barra
        barraDeEnergia.value = energiaAtual;  // Define o valor inicial da barra
        AtualizarTextoEnergia();  // Atualiza o texto de energia na tela
    }

    void Update()
    {
        // Se a tecla de a  o for pressionada e ainda houver energia
        if (Input.GetKey(teclaDeAcao) && energiaAtual > 0)
        {
            // Reduz a energia com base na taxa de gasto por segundo
            energiaAtual -= taxaDeGasto * Time.deltaTime;
            energiaAtual = Mathf.Clamp(energiaAtual, 0, energiaMaxima);  // Garante que a energia n o ultrapasse os limites
            barraDeEnergia.value = energiaAtual;  // Atualiza o valor da barra de energia
            AtualizarTextoEnergia();  // Atualiza o texto da energia na tela
        }
    }

    // Fun  o para atualizar o texto da energia na tela
    void AtualizarTextoEnergia()
    {
        textoEnergia.text = "Energia: " + energiaAtual.ToString("F1") + "%";  // Exibe a energia com uma casa decimal
    }
}
