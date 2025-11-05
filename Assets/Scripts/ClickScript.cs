using UnityEngine;
using UnityEngine.InputSystem;

public class ClickScript : MonoBehaviour
{
    [SerializeField]
    GameObject circlePrefab;

    private Transform m_transform;

    private void Start()
    {
        m_transform = this.transform;
    }

    private void Update()
    {
        CreateOnClick();
        //TurnToMouse();
    }


    private Vector3 GetMousePosition()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
             new Vector3(mouseScreenPos.x, mouseScreenPos.y, -Camera.main.transform.position.z)
            );
        return mouseWorldPos;
    }

    private void CreateOnClick()
    {
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseWorldPos = GetMousePosition();
            GameObject go = Instantiate(circlePrefab, mouseWorldPos, Quaternion.identity);
        }
    }

    private void TurnToMouse()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = new Vector2(mouseWorldPos.x - transform.position.x, mouseWorldPos.y - transform.position.y);
        transform.up = direction;
    }    

    private void ClickedOn(RaycastHit2D obj)
    {
        obj.collider.GetComponent<SpriteRenderer>().color = Color.red;
    }
}