using UnityEngine;
using System.Collections;
using Assets.Scripts.Util;

public class AITargettingVisualizer : MonoBehaviour
{
    public LineRenderer visualElement;
    public float maxThickness = 0.2f;

    void OnAITargetting(AIShooterInfo info)
    {
        if (info.State == AIShooterState.NOT_IN_RANGE)
        {
            this.visualElement.gameObject.SetActive(false);
            return;
        }

        float width = maxThickness*(1 - info.TimeToShoot/info.ShootDelay);
        visualElement.SetWidth(width, width);

        this.visualElement.gameObject.SetActive(true);
        this.visualElement.gameObject.transform.position = info.From;
        this.visualElement.gameObject.transform.rotation = QuaternionUtil.FromDirection2D(info.Target);
    }
}