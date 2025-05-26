using UnityEngine;
namespace AJH
{
    
    public class floatingText : MonoBehaviour
    {

        [SerializeField] private float floatSpeed = 1f;
        [SerializeField] private float floatHeight = 10f;

        private RectTransform rectTransform;
        private Vector2 initialPos;
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            initialPos = rectTransform.anchoredPosition;
        }

        // Update is called once per frame
        void Update()
        {
            float newX = Mathf.Sin(Time.time * floatSpeed/2) * floatHeight/2;
            float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            rectTransform.anchoredPosition = initialPos + new Vector2(newX, newY);

        }
    }
}
