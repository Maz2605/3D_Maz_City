using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    
    public void ChangeColor()
    {
        if (backgroundImage != null)
        {
            backgroundImage.color = new Color(Random.value, Random.value, Random.value);
        }
    }
    
    public void HideImage()
    {
        if (backgroundImage != null)
        {
            backgroundImage.enabled = !backgroundImage.enabled;
        }
    }
}
