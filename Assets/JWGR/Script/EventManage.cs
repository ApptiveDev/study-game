using System.Threading;
using UnityEngine;
using System.Collections;

namespace JWGR
{
    public class EventManage : MonoBehaviour
    {
        public static int countKill = 0;
        public GameObject boss;
        private bool bossSpawned = false; // 보스가 이미 스폰되었는지 확인

        private void Start()
        {
            // 기본 배경음 재생
            if (SoundManage.instance != null)
            {
                SoundManage.instance.PlayBGM(SoundManage.EBgm.BGM_GAME);
                
            }
        }

        void Update()
        {
            if (countKill > 5 && !bossSpawned)
            {
                bossSpawned = true;
                StartCoroutine(SpawnBossWithMusic());
            }
        }

        IEnumerator SpawnBossWithMusic()
        {
            // 보스 등장시키기
            if (SoundManage.instance != null)
            {
                SoundManage.instance.StopBGM();
                yield return new WaitForSeconds(0.1f); // 짧은 딜레이 추가
                SoundManage.instance.PlayBGM(SoundManage.EBgm.BGM_BOSS);
            }
            if (boss != null)
            {
                boss.SetActive(true);
            }
        }

    }
}