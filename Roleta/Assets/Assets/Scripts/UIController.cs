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
            StartCoroutine(EndTransition(delayTime, "PanelRoulette"));
            StartCoroutine(EncerrarRoullete());
        }
        public void BtnEndGame()
        {
            transition.StartTransition();
            StartCoroutine(EndTransition(delayTime,"PanelMainMenu"));
        }

        public IEnumerator EncerrarRoullete()
        {
            yield return new WaitForSeconds(1);
            transition.StartTransition();
            StartCoroutine(EndTransition(delayTime, "PanelEndGame"));
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
    }
}
