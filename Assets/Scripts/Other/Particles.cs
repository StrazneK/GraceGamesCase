using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Other
{
    public class Particles : MonoBehaviour
    {
       [SerializeField] ParticleSystem freezeParticle;
        [SerializeField] ParticleSystem timeParticle;

        void PlayFreezeParticle() => PlayParticle(freezeParticle);
        void PlayTimeParticle() => PlayParticle(timeParticle);
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnBoostFreeze, PlayFreezeParticle);
            EventManager.AddHandler(GameEvent.OnBoostTime, PlayTimeParticle);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnBoostFreeze, PlayFreezeParticle);
            EventManager.RemoveHandler(GameEvent.OnBoostTime, PlayTimeParticle);
        }
        void PlayParticle(ParticleSystem partSystem)
        {
            partSystem.Play();
        }
    }
}