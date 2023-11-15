using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class UIController : MonoBehaviour
    {
        public List<GameObject> panels = new List<GameObject>();
        public Roulette roulette;
        public Transition transition;

        private float delayTime = 0.5f;

        private void Awake()
        {
            SetInitialPanels();
        }

        private void SetInitialPanels()
        {
            StartCoroutine(EndTransition(0f, "PanelMainMenu"));
            transition.SetActiveTranstition(true);
        }

        public void BtnPlayGame()
        {
            transition.StartTransition();
            roulette.StartSpinRoulette(true);
            StartCoroutine(EndTransition(delayTime, "PanelRoulette"));
        }

        public void BtnStopRoulette()
        {
            roulette.StopSpinRoulette();
        }

        public void BtnEndGame()
        {
            transition.StartTransition();
            StartCoroutine(EndTransition(delayTime,"PanelMainMenu"));
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
        }
    
        private IEnumerator PlayGame()
        {
            yield return new WaitForSeconds(2);
            roulette.StartSpinRoulette(true);
        }
    }
}
