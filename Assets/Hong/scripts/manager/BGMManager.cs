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
        public AudioClip gameOverBGM;


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

        public void playGameOverBGM()
        {
            // 게임 오버 BGM 재생 로직 추가 필요
            // 예시로 기본 BGM을 재생하도록 설정
            bgmSource.loop = false; // 게임 오버 BGM은 반복하지 않음
            PlayBGM(gameOverBGM);

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