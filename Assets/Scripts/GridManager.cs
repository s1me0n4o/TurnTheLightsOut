using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static Dictionary<int, GameObject> LightsPositions { get; set; }

    public GameObject theLightGO;
    public int rows = 5;
    public int cols = 5;
    public float offsetY = 3f;
    public float offset = 1.5f;

    public void LoadGrid(List<int> allLightsOff)
    {
        LightsPositions = new Dictionary<int, GameObject>();

        var counter = 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject lightClone = Instantiate(theLightGO, new Vector3(j * offset - offsetY, i * offset - offsetY, 0), Quaternion.identity);
                lightClone.transform.SetParent(this.gameObject.transform);
                lightClone.name = counter.ToString();

                LightsPositions.Add(counter, lightClone);

                counter++;
            }
        }

        SetLevelLights(allLightsOff);
    }

    public void SetLevelLights(List<int> allLightsOff)
    {
        foreach (var lightId in allLightsOff)
        {
            if (lightId == 0)
            {
                return;
            }
            LightsPositions.TryGetValue(lightId, out var go);
            go.GetComponent<LightningSwitch>().Change(go);
        }
    }
}
