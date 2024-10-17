using UnityEngine;
using System.Linq;
using TMPro;
public class EventListener : MonoBehaviour
{
    public TextMeshProUGUI logText; // Reference to the TextMeshProUGUI component
    public int lineCount = 10; // Number of lines to display in the log
    private void OnEnable()
    {
        // Subscribe to events
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;
    }
    private void OnDisable()
    {
        // Unsubscribe from events to avoid memory leaks
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;
    }
    private void HandleObjectDamaged(string name, int remainingHealth)
    {
        string message = $"An object called {name} was damaged! Remaining Health: {remainingHealth}";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }
    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        string message = $"An object called {name} was destroyed!";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }
    // Function to update the log with a limit on the number of lines
    private void UpdateLog(string message, int maxLines)
    {
        if (logText != null)
        {
            // Split the current log text into lines
            var lines = logText.text.Split('\n').ToList();
            // Add the new message
            lines.Add(message);
            // If the number of lines exceeds the limit, remove the oldest
            if (lines.Count > maxLines)
            {
                lines.RemoveAt(0);
            }
            // Join the lines back into a single string
            logText.text = string.Join("\n", lines);
        }
    }
}