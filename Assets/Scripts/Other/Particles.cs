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
        [SerializeField] ParticleSystem lightningParticle;
        [SerializeField] ParticleSystem magnetParticle;
        [SerializeField] ParticleSystem confettiParticle;

        void PlayFreezeParticle() => PlayParticle(freezeParticle);
        void PlayTimeParticle() => PlayParticle(timeParticle);
        void PlayLightningParticle() => PlayParticle(lightningParticle);
        void PlayMagnetParticle() => PlayParticle(magnetParticle);
        void PlayConfettiParticle() => PlayParticle(confettiParticle);
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnBoostFreeze, PlayFreezeParticle);
            EventManager.AddHandler(GameEvent.OnBoostTime, PlayTimeParticle);
            EventManager.AddHandler(GameEvent.OnBoostLightning, PlayLightningParticle);
            EventManager.AddHandler(GameEvent.OnBoostMagnet, PlayMagnetParticle);
            EventManager.AddHandler(GameEvent.OnGameWin, PlayConfettiParticle);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnBoostFreeze, PlayFreezeParticle);
            EventManager.RemoveHandler(GameEvent.OnBoostTime, PlayTimeParticle);
            EventManager.RemoveHandler(GameEvent.OnBoostLightning, PlayLightningParticle);
            EventManager.RemoveHandler(GameEvent.OnBoostMagnet, PlayMagnetParticle);
            EventManager.RemoveHandler(GameEvent.OnGameWin, PlayConfettiParticle);
        }
        void PlayParticle(ParticleSystem partSystem)
        {
            partSystem.Play();
        }
    }
}