using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string[] messages;

    private void OnMouseEnter()
    {
        TooltipManager._instance.SetShowTooltip(messages[Random.Range(0, 3)]);
    }

    private void OnMouseExit()
    {
        TooltipManager._instance.HideTooltip();
    }
}
