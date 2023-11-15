using Assets.Assets.Scripts.Enums;
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
        public float AnimDelay { get; private set; } = 0f;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            SetAnimationDuration("TransitionFade");
            this.gameObject.SetActive(false);
        }

        private void SetAnimationDuration(string animationName)
        {
            AnimatorStateInfo animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
            int animationHash = Animator.StringToHash(animationName);

            if (animStateInfo.shortNameHash == animationHash)
            {
                AnimDelay = animStateInfo.length;
            }
        }

        public void StartTransition()
        {
            anim.Play("TransitionFade");
            this.gameObject.SetActive(true);

            StartCoroutine(EndTransition());
        }

        private IEnumerator EndTransition()
        {
            yield return new WaitForSeconds(AnimDelay);
            this.gameObject.SetActive(false);
        }
    }
}
