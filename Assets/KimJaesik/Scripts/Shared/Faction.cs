using UnityEngine;

namespace KJS
{
    public class Faction : MonoBehaviour
    {
        [Tooltip("이 오브젝트의 진영을 설정합니다.")]
        public FactionType type = FactionType.Neutral;

        //추가 확장 기능을 위해 MonoBehaviour로 생성
    }
}
