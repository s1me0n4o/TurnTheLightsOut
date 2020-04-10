using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameManager gameManager;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audio.Play();
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500))
            {
                Debug.DrawRay(ray.origin, hit.point, Color.red);
                MakeMove(hit.collider.gameObject);
            }
        }
    }

    private void MakeMove(GameObject collidedObject)
    {
        var collidedObjectIndex = int.Parse(collidedObject.name);
        ChangeState(collidedObject, 0, collidedObjectIndex);
        ChangeState(collidedObject, 5, collidedObjectIndex);
        ChangeState(collidedObject, -5, collidedObjectIndex);

        if (collidedObjectIndex % 5 != 0)
        {
            ChangeState(collidedObject, 1, collidedObjectIndex);
        }

        if (collidedObjectIndex % 5 != 1)
        {
            ChangeState(collidedObject, -1, collidedObjectIndex);
        }

        gameManager.IsLevelCompleted();
    }

    private void ChangeState(GameObject collidedObject, int surroundingObjectIndex, int collidedObjectIndex)
    {

        collidedObjectIndex += surroundingObjectIndex;

        if (collidedObjectIndex < 1 || collidedObjectIndex > 25)
        {
            return;
        }
        
        GridManager.LightsPositions.TryGetValue(collidedObjectIndex, out GameObject lightObj);
        lightObj.GetComponent<LightningSwitch>().Change(lightObj);
    }
}
