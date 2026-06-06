using UnityEngine;
using TMPro;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text titleText;

    public void ShowVictory()
    {
        panel.SetActive(true);
        titleText.text = "¡Victoria! / Victory!";
    }

    public void ShowDefeat()
    {
        panel.SetActive(true);
        titleText.text = "Derrota... / Defeat...";
    }
}