using UnityEngine;
namespace AJH
{
    // 몬스터의
    public class BGMManager : MonoBehaviour
    {
        public static BGMManager instance;
        public AudioSource bgmSource;
        public AudioClip defaultBGM;
        public AudioClip bossBGM;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                PlayDefaultBGM();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayBGM(AudioClip clip)
        {
            if (bgmSource.clip == clip) return; // 이미 재생 중이면 무시
            bgmSource.Stop();
            bgmSource.clip = clip;
            bgmSource.Play();
        }

        public void PlayDefaultBGM()
        {
            PlayBGM(defaultBGM);
        }

        public void PlayBossBGM()
        {
            PlayBGM(bossBGM);
        }
    }
}