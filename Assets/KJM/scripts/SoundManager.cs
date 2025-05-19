using UnityEngine;

namespace KJM
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        public AudioClip swordClip;
        public AudioClip arrowClip;
        public AudioClip bombClip;
        public AudioClip WandClip;
        public AudioClip FireZoneClip;
        private AudioSource sound;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

        }

        public void PlayWeaponSound(string weaponName)
        {
            AudioClip clip = null;

            switch (weaponName)
            {
                case "Sword":
                    clip = swordClip;
                    break;
                case "Arrow":
                    clip = arrowClip;
                    break;
                case "Bomb":
                    clip = bombClip;
                    break;
                case "Wand":
                    clip = WandClip;
                    break;
            }
            if (clip != null)
            {
                sound.PlayOneShot(clip);
            }
        }
        public void BombSound()
        {
            AudioClip clip = FireZoneClip;
            sound.PlayOneShot(clip);
        }
    }
}