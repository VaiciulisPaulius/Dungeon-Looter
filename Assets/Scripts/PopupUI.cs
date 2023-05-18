using UnityEngine;
using TMPro;

public class PopupUI : MonoBehaviour
{
    public float displayTime = 5f; // The duration the UI element will be displayed
    private float timer; // Timer variable to track the time elapsed

    public TMP_Text popupText; // Reference to the TMP_Text component

    void Start()
    {
        timer = displayTime; // Set the initial timer value
    }

    void Update()
    {
        timer -= Time.deltaTime; // Update the timer based on real-time

        if (timer <= 0f)
        {
            Destroy(gameObject); // Destroy the UI element when the timer reaches zero
        }
    }

    public void SetText(string text)
    {
        popupText.text = text; // Set the text of the UI element
    }
}
