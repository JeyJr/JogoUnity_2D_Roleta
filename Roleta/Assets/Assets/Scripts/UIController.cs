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

        private void Awake()
        {
            
        }

        public void BtnPlayGame()
        {
            transition.StartTransition();
            StartCoroutine(EndTransition("PanelRoulette"));
            StartCoroutine(EncerrarRoullete());
        }

        public IEnumerator EncerrarRoullete()
        {
            yield return new WaitForSeconds(1);
            transition.StartTransition();
            StartCoroutine(EndTransition("PanelEndGame"));
        }

        public void BtnEndGame()
        {
            transition.StartTransition();
            StartCoroutine(EndTransition("PanelMainMenu"));
        }

        private IEnumerator EndTransition(string panelNameToActive)
        {
            yield return new WaitForSeconds(transition.AnimDelay / 2);

            panels.ForEach(p =>
            {
                p.SetActive(false);

                if (p.name == panelNameToActive)
                    p.SetActive(true);
            });
        }
    }
}
