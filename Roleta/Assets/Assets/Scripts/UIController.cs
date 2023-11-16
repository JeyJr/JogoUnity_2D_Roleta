using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class UIController : MonoBehaviour, IUIController
    {
        public Transition transition;
        
        [Header("Componentes PanelRoulette")]
        public Roulette roulette;

        [Header("Componentes PanelEndGame")]
        public TextMeshProUGUI txtFinalMessage;
        public Image imgFinalLogo;

        [Space(15)]
        public List<GameObject> panels = new List<GameObject>();


        private float delayTime = 0.5f;

        private void Awake()
        {
            StartCoroutine(EndTransition(0f, "PanelMainMenu"));
            transition.SetActiveTranstition(true);
        }

        public void MainMenu()
        {
            StartCoroutine(EndTransition(delayTime, "PanelMainMenu"));
            transition.SetActiveTranstition(true);
        }

        public void PlayGame()
        {
            StartCoroutine(EndTransition(delayTime, "PanelRoulette"));
            transition.StartTransition();
        }

        public void StopRoulette()
        {
            roulette.StopSpinRoulette();
        }

        public void EndGame()
        {
            transition.StartTransition();
            StartCoroutine(EndTransition(delayTime, "PanelEndGame"));
        }

        public void EndGame(SelectedColor selectedColor)
        {
            EndGame();

            switch (selectedColor) 
            {
                case SelectedColor.Red:
                    imgFinalLogo.color = new Color(255, 0, 0);
                    txtFinalMessage.text = "Cor vermelha!";
                    break;
                case SelectedColor.Green: 
                    break;
                case SelectedColor.Blue: 
                    break;
                case SelectedColor.Yellow : 
                    break;
            }
        }

        private IEnumerator EndTransition(float delayTime, string panelNameToActive)
        {
            yield return new WaitForSeconds(delayTime);

            panels.ForEach(p =>
            {
                p.SetActive(false);

                if (p.name == panelNameToActive)
                    p.SetActive(true);
            });

            if(panelNameToActive == "PanelRoulette")
                roulette.StartSpinRoulette();
        }

    }
}
