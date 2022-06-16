using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    [SerializeField] float buildDelay = 0.7f;

    void Start()
    {
        StartCoroutine(BuildBallista());        
    }

    IEnumerator BuildBallista()
    {
        yield return new WaitForSeconds(buildDelay);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
        }
    }

    public bool CreateTower(Tower ballista, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) return false;

        if (bank.CurrentBalance >= cost)
        {
            GameObject newBallista = ballista.gameObject;
            Instantiate(newBallista, position, Quaternion.identity);
            DisableAllChildren();
            bank.Withdraw(cost);
            return true;
        }
        return false;
    }

    void DisableAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
