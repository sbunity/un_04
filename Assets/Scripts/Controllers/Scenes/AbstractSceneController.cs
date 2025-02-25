using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Types;

namespace Controllers.Scenes
{
    public abstract class AbstractSceneController : MonoBehaviour
    {
        /*[SerializeField] 
        private SoundsController _soundsController;
        [SerializeField]
        private SceneSounds _sceneSounds;

        private MusicController _musicController;*/

        private void OnEnable()
        {
            //_musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
            
            //_sceneSounds.SetAudioClip();
            
            Initialize();
            Subscribe();
            OnSceneEnable();
        }

        private void Start()
        {
            PlayMusic();
            OnSceneStart();
        }

        private void OnDisable()
        {
            Unsubscribe();
            OnSceneDisable();
        }

        protected abstract void OnSceneEnable();
        protected abstract void OnSceneStart();
        protected abstract void OnSceneDisable();
        protected abstract void Initialize();
        protected abstract void Subscribe();
        protected abstract void Unsubscribe();

        protected void LoadScene(SceneType type)
        {
            SetClickClip();
            
            StartCoroutine(DelayLoadScene(type.ToString()));
        }

        protected void SetClickClip()
        {
            //PlaySound(AudioNames.ClickClip.ToString());
        }

        protected void PlaySound(string audioName)
        {
           //_soundsController.TryPlaySound(GetAudioClip(audioName));
        }
        
        protected void PlayMusic()
        {
            /*string clipName = SceneManager.GetActiveScene().name == NameScenes.Game.ToString()
                ? AudioNames.GameClip.ToString()
                : AudioNames.MenuClip.ToString();

            _musicController.TryPlayMusic(GetAudioClip(clipName));*/
        }
        
        /*private AudioClip GetAudioClip(string clipName)
        {
            return _sceneSounds.GetAudioClipByName(clipName);
        }*/

        private IEnumerator DelayLoadScene(string sceneName)
        {
            yield return new WaitForSecondsRealtime(0.3f);

            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}