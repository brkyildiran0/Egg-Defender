using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    Bank bank;
    TextMeshProUGUI textTMP;

    void Awake()
    {
        textTMP = GetComponent<TextMeshProUGUI>();
        textTMP.text = "Gold: ";
    }
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        string goldAmount = bank.CurrentBalance.ToString();
        textTMP.text = "Gold: " + goldAmount;
    }
}
