using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaLuz : MonoBehaviour
{
    [Header("Configuracao de Energia")]
    public float energiaTotal = 100f;
    public float velocidadeDoConsumo;

    [Header("Objetos")]

    public bool ventilador;
    public bool Luz;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ventilador || Luz)
        {
            StartCoroutine("GastaLuz");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!ventilador)
            {
                ventilador = true;
                StartCoroutine("GastaLuz");

            }
            else
            {
                ventilador = false;
            }
        }
    }
    void Gasta(float velocidade)
    {
        energiaTotal -= velocidade;
        Debug.Log(energiaTotal);
    }
    IEnumerator GastaLuz()
    {
        yield return new WaitForSeconds(0.5f);
        Gasta(5);
    }
}
