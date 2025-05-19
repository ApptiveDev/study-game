using System.Threading;
using UnityEngine;

namespace JWGR
{
    public class EventManage : MonoBehaviour
    {
        public static int countKill = 0;
        public GameObject boss;

        private void Start() // Awake 대신 Start 사용
        {
            // 기본 배경음 재생
            if (SoundManage.instance != null)
            {
                SoundManage.instance.PlayBGM(SoundManage.EBgm.BGM_GAME);
            }
            else
            {
                Debug.LogError("SoundManage 인스턴스가 초기화가 안됨.");
            }
        }

        void Update()
        {
            if (countKill > 5)
            {
                // 보스 등장시키기
                if (SoundManage.instance != null)
                {
                    SoundManage.instance.StopBGM();
                    SoundManage.instance.PlayBGM(SoundManage.EBgm.BGM_BOSS);
                }
                if (boss != null)
                {
                    boss.SetActive(true);
                }
            }
        }
    }
}