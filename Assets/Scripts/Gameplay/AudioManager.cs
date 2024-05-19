using System.Collections.Generic;
using SaveSystem;
using UnityEngine;
using UnityEngine.Audio;
using Utils.Singleton;

namespace Gameplay
{
    public class AudioManager : BasicSingleton<AudioManager> , ISavableComponent
    {
        public AudioMixer musicAudioMixer;
        public AudioMixer fxAudioMixer;

        float volumeMusicAudioMixer = 20;
        float volumeFxAudioMixer     = 20;


        protected override void Awake() 
        {
            base.Awake();
            
            musicAudioMixer = Resources.Load<AudioMixer>("AudioMixers/musicAudioMixer");
            fxAudioMixer     = Resources.Load<AudioMixer>("AudioMixers/fxAudioMixer");
        }

        private float TransformVolumeToDb(float volume)
        {
            volume = Mathf.Clamp(volume, 0, 100);
            return volume / 20;
        }

        private float TransformDbToVolume(float db)
        {
            db = Mathf.Clamp(db, 0, 20);
            return db * 20;
        }

        public void SetMusicVolume(float volume)
        {
            float db = TransformVolumeToDb(volume);
            volumeMusicAudioMixer = Mathf.Clamp(volume, 0 , 100);
            musicAudioMixer.SetFloat("mastervol", db);
        }

        public void SetVolumeFx(float volumen)
        {
            float db = TransformVolumeToDb(volumen);
            volumeFxAudioMixer = Mathf.Clamp(volumen, 0 , 100);
            fxAudioMixer.SetFloat("mastervol", db);
        }




        #region Persistencia
        public object CaptureState()
        {
            var datos = new  Dictionary<string, object>()
            {
                {"volumenMusicaAudioMixer", volumeMusicAudioMixer},
                {"volumenFxAudioMixer", volumeFxAudioMixer}
            };

            return datos;
        }

        public void RestoreState(object estado)
        {
            var datos = estado as Dictionary<string, object>;
            
            float volumenMusica = (float) datos.GetValueOrDefault("volumenMusicaAudioMixer", 10);
            float volumenFx     = (float) datos.GetValueOrDefault("volumenFxAudioMixer", 10);

            SetMusicVolume(volumenMusica);
            SetVolumeFx(volumenFx);
        }

        #endregion

    }
}