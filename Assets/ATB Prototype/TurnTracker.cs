using UnityEngine;
using UnityEngine.UI;

public class TurnTracker : MonoBehaviour
{
    [SerializeField]
    public int MinValue = 1;
    [SerializeField]
    public int MaxValue = 11;
    [SerializeField]
    public Slider AtbSlider;
    
    private readonly float IncrementInterval = 0.5f;

    // Increment a counter from 0 to 100 by a random amount every second
    private int turnCount = 0;
    private float timer = 0f;
    private readonly System.Random random = new();

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= IncrementInterval)
        {
            timer = 0f;
            int increment = random.Next(MinValue, MaxValue);
            turnCount += increment;

            if (turnCount > 100)
            {
                turnCount = 100;
            }

            AtbSlider.value = turnCount / 100f; // Assuming the slider value is between 0 and 1
        }
    }

    public int GetTurnCount()
    {
        return turnCount;
    }

    public void ResetTurnCount()
    {
        turnCount = 0;
    }

    public bool HasReachedMaxTurnCount()
    {
        return turnCount >= 100;
    }
}
