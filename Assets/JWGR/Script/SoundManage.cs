using UnityEngine;

namespace JWGR
{
    //사운드의 타입이다. 사운드를 중단을 식별하기위해 사용한다.
    public enum SoundType
    {
        BGM,
        EFFECT,
    }

    public class SoundManage : MonoBehaviour
    {
        public static SoundManage instance;

        //BGM 종류들
        public enum EBgm
        {
            BGM_GAME,
            BGM_BOSS,
        }

        //SFX 종류들
        public enum ESfx
        {
            SFX_LASER,
            SFX_ARROW,
        }

        //audio clip 담을 수 있는 배열
        [SerializeField] AudioClip[] bgms;
        [SerializeField] AudioClip[] sfxs;

        //플레이하는 AudioSource
        [SerializeField] AudioSource audioBgm;
        [SerializeField] AudioSource audioSfx;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // EBgm 열거형을 매개변수로 받아 해당하는 배경 음악 클립을 재생
        public void PlayBGM(EBgm bgmIdx)
        {
            //enum int형으로 형변환 가능
            audioBgm.clip = bgms[(int)bgmIdx];
            audioBgm.Play();
        }

        // 현재 재생 중인 배경 음악 정지
        public void StopBGM()
        {
            audioBgm.Stop();
        }

        // ESfx 열거형을 매개변수로 받아 해당하는 효과음 클립을 재생
        public void PlaySFX(ESfx esfx)
        {
            audioSfx.PlayOneShot(sfxs[(int)esfx]);
        }
    }
}