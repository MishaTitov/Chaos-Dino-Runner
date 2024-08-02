using TMPro;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI achievText;
    [SerializeField] int value;

    [field: SerializeField] public string nameAchiev { get; private set; }
    [SerializeField] string shortDescription;

    private void OnEnable()
    {
        value = AchievementsManager.instance.LoadGameModeData(nameAchiev);
        SetAchievementText();
    }

    private void SetAchievementText()
    {
        achievText.text = $"{nameAchiev} - {value} \n {shortDescription}";
    }
}
