using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistLogic : MonoBehaviour
{
    [Header("Item #1 Properties")]
    public Toggle item01Toggle;
    public Text item01Text;
    public Color crossedOffColor01 = Color.gray;
    public Color baseColor01;

    [Header("Item #2 Properties")]
    public Toggle item02Toggle;
    public Text item02Text;
    public Color crossedOffColor02 = Color.gray;
    public Color baseColor02;

    [Header("Item #3 Properties")]
    public Toggle item03Toggle;
    public Text item03Text;
    public Color crossedOffColor03 = Color.gray;
    public Color baseColor03;

    [Header("Item #4 Properties")]
    public Toggle item04Toggle;
    public Text item04Text;
    public Color crossedOffColor04 = Color.gray;
    public Color baseColor04;


    // Start is called before the first frame update
    void Start()
    {
        // Listed Item #1
        if (item01Text != null) baseColor01 = item01Text.color;
        if (item01Toggle != null) item01Toggle.onValueChanged.AddListener(OnToggleChangedItem01);

        // Listed Item #2
        if (item02Text != null) baseColor02 = item02Text.color;
        if (item02Toggle != null) item02Toggle.onValueChanged.AddListener(OnToggleChangedItem02);

        // Listed Item #3
        if (item03Text != null) baseColor03 = item03Text.color;
        if (item03Toggle != null) item03Toggle.onValueChanged.AddListener(OnToggleChangedItem03);

        // Listed Item #4
        if (item04Text != null) baseColor04 = item04Text.color;
        if (item04Toggle != null) item04Toggle.onValueChanged.AddListener(OnToggleChangedItem03);
    }


    public void MarkCollected()
    {
        // Collected Item #1
        if (item01Toggle != null)
            item01Toggle.isOn = true;

        // Collected Item #2
        if (item02Toggle != null)
            item02Toggle.isOn = true;

        // Collected Item #3
        if (item03Toggle != null)
            item03Toggle.isOn = true;

        // Collected Item #4
        if (item04Toggle != null)
            item04Toggle.isOn = true;
    }


    public void OnToggleChangedItem01(bool isOnItem01)
    {
        // Toggle Item #1 on Checklist
        if (item01Text == null) return;

        if (isOnItem01)
        {
            //Crosses out text on Checklist UI
            item01Text.text = $"<s>(item01Text.text)</s>";
            item01Text.color = crossedOffColor01;
        }
    }

    public void OnToggleChangedItem02(bool isOnItem02)
    {
        // Toggle Item #1 on Checklist
        if (item02Text == null) return;

        if (isOnItem02)
        {
            //Crosses out text on Checklist UI
            item02Text.text = $"<s>(item02Text.text)</s>";
            item02Text.color = crossedOffColor02;
        }
    }

    public void OnToggleChangedItem03(bool isOnItem03)
    {
        // Toggle Item #3 on Checklist
        if (item03Text == null) return;

        if (isOnItem03)
        {
            //Crosses out text on Checklist UI
            item03Text.text = $"<s>(item03Text.text)</s>";
            item03Text.color = crossedOffColor03;
        }
    }

    public void OnToggleChangedItem04(bool isOnItem04)
    {
        // Toggle Item #4 on Checklist
        if (item04Text == null) return;

        if (isOnItem04)
        {
            //Crosses out text on Checklist UI
            item04Text.text = $"<s>(item04Text.text)</s>";
            item04Text.color = crossedOffColor04;
        }
    }
}