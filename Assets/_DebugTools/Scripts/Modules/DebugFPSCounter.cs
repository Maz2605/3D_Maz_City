using TMPro;
using UnityEngine;

namespace _DebugTools.Scripts.Modules
{
    public class DebugFPSCounter : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Text fpsText;

        [Header("Settings")]
        [SerializeField] private int sampleFrames = 60;   // số frame để tính trung bình
        [SerializeField] private float updateInterval = 0.5f; // chỉ update UI mỗi 0.5 giây

        private float[] frameTimes;
        private int frameIndex;
        private int framesCollected;

        private float timer;

        private void Awake()
        {
            frameTimes = new float[sampleFrames];
        }

        private void Update()
        {
            // Lưu deltaTime của frame hiện tại
            frameTimes[frameIndex] = Time.unscaledDeltaTime;
            frameIndex = (frameIndex + 1) % sampleFrames;

            if (framesCollected < sampleFrames)
                framesCollected++;

            // Đếm thời gian để quyết định khi nào update UI
            timer += Time.unscaledDeltaTime;
            if (timer >= updateInterval)
            {
                timer = 0f;
                UpdateFPSUI();
            }
        }

        private void UpdateFPSUI()
        {
            float total = 0f;
            for (int i = 0; i < framesCollected; i++)
                total += frameTimes[i];

            float avgDeltaTime = total / framesCollected;
            float fps = 1f / avgDeltaTime;

            if (fpsText)
                fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";
        }
    }
}