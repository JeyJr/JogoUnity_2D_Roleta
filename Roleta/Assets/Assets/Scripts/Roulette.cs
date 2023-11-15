using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    public float velocidadeRotacao = 50;
    public bool spin = false;
    public Image imagemUI;

    public void StartSpinRoulette(bool spin)
    {
        this.spin = spin;
        velocidadeRotacao = 50f;
    }

    private void Update()
    {
        if(spin)
        {
            float rotacao = 2f * velocidadeRotacao * Time.deltaTime;

            Vector3 angulosAtuais = imagemUI.rectTransform.localEulerAngles;
            angulosAtuais.z += rotacao;

            imagemUI.rectTransform.localEulerAngles = angulosAtuais;
        }
    }

    public void StopSpinRoulette()
    {
        StartCoroutine(StopSpin());
    }

    private IEnumerator StopSpin()
    {
        while(velocidadeRotacao > 0)
        {
            velocidadeRotacao-= 2;
            yield return new WaitForSeconds(.1f);
        }

        spin = false;
    }
}
