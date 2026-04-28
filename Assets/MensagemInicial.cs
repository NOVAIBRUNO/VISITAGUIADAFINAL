using UnityEngine;
using TMPro;

public class MensagemInicial : MonoBehaviour
{
    public GameObject texto;
    public float tempo = 4f;

    void Start()
    {
        Invoke("Esconder", tempo);
    }

    void Esconder()
    {
        texto.SetActive(false);
    }
}