using UnityEngine;

public class LightningSwitch : MonoBehaviour
{
    public bool isTurnedOff = false;

    public void Change(GameObject lightObj)
    {
        var shurikenLight = lightObj.transform.GetChild(0);
        if (isTurnedOff)
        {
            isTurnedOff = false;
            shurikenLight.gameObject.SetActive(true);
        }
        else
        {
            isTurnedOff = true;
            shurikenLight.gameObject.SetActive(false);
        }
    }

    public bool IsTheLightOff()
    {
        return isTurnedOff;
    }
}
