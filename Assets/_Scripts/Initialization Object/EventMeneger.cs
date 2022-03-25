using System;
using UnityEngine;

public class EventMeneger
{
    public static Action OnDiedPlayer;
    public static Action OnDiedEnemy;
    public static Action<Vector2, int> OnAddScore;
    public static Action OnAddCoin;

    public static void SendDiedPlayer()
    {
        OnDiedPlayer?.Invoke();
    }

    public static void SendDiedEnemy()
    {
        OnDiedEnemy?.Invoke();
    }

    public static void SendAddScore(Vector2 where, int whoScore)
    {
        OnAddScore?.Invoke(where, whoScore);
    }

    public static void SendAddCoin()
    {
        OnAddCoin?.Invoke();
    }

}
