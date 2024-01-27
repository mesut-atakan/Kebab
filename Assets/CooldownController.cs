using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    [SerializeField] private Text cooldownText;
    public float cooldownTime = 20; // İstediğiniz cooldown süresi (saniye cinsinden)

    private float currentTime;

    void Start()
    {
        currentTime = cooldownTime;
    }

    void Update()
    {
        // Zamanı azalt
        currentTime -= Time.deltaTime;

        // Text rengini güncelle
        UpdateTextColor();

        // Cooldown süresi bittiğinde
        if (currentTime <= 0f)
        {
            currentTime = 0f; // Sıfıra ayarla
            // İşlemleri buraya ekleyebilirsiniz (örneğin, başka bir şeyi etkinleştirme)
        }

        this.cooldownText.text = currentTime.ToString();
    }

    void UpdateTextColor()
    {
        // Rengi kırmızıya doğru değiştir
        float normalizedTime = 1 - currentTime / cooldownTime; // Normalleştirilmiş zaman (0 ile 1 arasında)
        Color lerpedColor = Color.Lerp(Color.white, Color.red, normalizedTime);
        cooldownText.color = lerpedColor;
    }
}
