using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public Light sun;

    public Color dayFogColor;
    public Color nightFogColor;

    private float timer = 0f;

    public float phaseDuration = 15f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < phaseDuration)
        {
            // DAY
            sun.intensity = 1.5f;
            RenderSettings.fogColor = dayFogColor;
        }
        else if (timer < phaseDuration * 2)
        {
            // NIGHT
            sun.intensity = 0.3f;
            RenderSettings.fogColor = nightFogColor;
        }
        else
        {
            timer = 0f;
        }
    }
}