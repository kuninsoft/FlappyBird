using System;
using UnityEngine;

public class PlayerLifetime : MonoBehaviour
{
    public static event EventHandler<EventArgs> Died;

    private void OnTriggerEnter2D(Collider2D col)
    {
        OnPlayerDied();
    }

    private void OnBecameInvisible()
    {
        OnPlayerDied();
    }

    private void OnPlayerDied()
    {
        Died?.Invoke(this, EventArgs.Empty);
    }
}
