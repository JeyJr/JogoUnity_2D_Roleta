using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Transition : MonoBehaviour
    {
        Animator anim;
        public float DelayTime { get; private set; } = 1f;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            SetActiveTranstition(true);
            anim.Play("TransitionFadeOut");
        }

        public void StartTransition()
        {
            anim.Play("TransitionFade");
            SetActiveTranstition(true);

            StartCoroutine(EndTransition(DelayTime));
        }

        public void SetActiveTranstition(bool active)
        {
            this.gameObject.SetActive(active);
        }

        private IEnumerator EndTransition(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            SetActiveTranstition(false);
        }
    }
}
