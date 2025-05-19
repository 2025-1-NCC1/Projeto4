using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoController : MonoBehaviour
{
    public Button meuBotao; //Declara o bot o



    // Start is called before the first frame update
    void Start()
    {
        // Verifica se o bot o foi atribuido
        if (meuBotao != null)
        {
            // Associa o evento de clique   fun  o
            meuBotao.onClick.AddListener(OnBotaoClick);
        }

    }
    // Fun  o chamada quando o bot o for clicado
    void OnBotaoClick()
    {
        Debug.Log("Bot o foi clicado!");
    }



    // Update is called once per frame
    void Update()
    {

    }
}