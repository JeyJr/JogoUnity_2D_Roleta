using Assets.Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    private float rotSpeed = 1;
    private float maxRotSpeed = 400;
    private bool spin = false;
    private Image imagemUI;
    private IUIController uIControllerInstance;
    public SelectedColor selectedColor;

    private void Start()
    {
        uIControllerInstance = FindObjectOfType<UIController>();
        imagemUI = GetComponent<Image>();
    }



    private void Update()
    {
        if(spin)
        {

            float rotacao = 2f * rotSpeed * Time.deltaTime;

            Vector3 angulosAtuais = imagemUI.rectTransform.localEulerAngles;
            angulosAtuais.z += rotacao;

            if (angulosAtuais.z >= 360)
                angulosAtuais.z = 0;

            imagemUI.rectTransform.localEulerAngles = angulosAtuais;
            ObterCorSelecionada(angulosAtuais.z);
        }
    }

    public void StartSpinRoulette()
    {
        SetInitialValues();
        StartCoroutine(StartSpin());
    }
    public void StopSpinRoulette()
    {
        StartCoroutine(StopSpin());
    }
    private void SetInitialValues()
    {
        if (imagemUI == null)
            imagemUI = GetComponent<Image>();

        Vector3 angulosAtuais = imagemUI.rectTransform.localEulerAngles;
        angulosAtuais.z = 0;
        imagemUI.rectTransform.localEulerAngles = angulosAtuais;

        selectedColor = SelectedColor.Red;
    }

    private IEnumerator StartSpin()
    {
        spin = true;
        rotSpeed = 1f;

        while (rotSpeed < maxRotSpeed && spin)
        {
            yield return new WaitForSeconds(.01f);
            rotSpeed += 1;
        }
    }

    private void ObterCorSelecionada(float z)
    {
        if(selectedColor == SelectedColor.Red && z > 46 && z <= 135)
        {
            selectedColor = SelectedColor.Green;
        }
        else if(selectedColor == SelectedColor.Green && z > 135 && z <= 223)
        {
            selectedColor = SelectedColor.Yellow;
        }
        else if (selectedColor == SelectedColor.Yellow && z > 223 && z <= 315)
        {
            selectedColor = SelectedColor.Blue;
        }
        else if (selectedColor == SelectedColor.Blue && z > 315)
        {
            selectedColor = SelectedColor.Red;
        }
    }

    private IEnumerator StopSpin()
    {
        while(rotSpeed > 0)
        {
            rotSpeed -= 3;
            yield return new WaitForSeconds(.01f);
        }

        spin = false;

        yield return new WaitForSeconds(1);
        uIControllerInstance.EndGame(selectedColor);
    }
}
