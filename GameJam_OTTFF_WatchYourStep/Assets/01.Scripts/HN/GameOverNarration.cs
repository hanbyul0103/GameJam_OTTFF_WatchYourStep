using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverNarration : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI narration;

    void Start()
    {
        RandomText();
    }

    void RandomText()
    {
        string[] narrations = { "살려줘", "무거워", "나 먼저 갈게", "밍밍밍" };
        int rd = Random.Range(0, narrations.Length);

        narration.text = narrations[rd];
    }
}
