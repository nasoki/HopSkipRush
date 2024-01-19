using UnityEngine;
using DG.Tweening;

public class MouseInput : MonoBehaviour
{
    public Transform parentPosition;
    public Transform playerTransform;
    private float moveTime = 0.75f;
    private bool onLeftSide;

    [SerializeField] private Animator playerAC;

    void Update()
    {
        // sol týklama kontrolü / dokunma kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            // sol yarýya veya sað yarýya týklandýðýnýn kontrolü
            if (mousePosition.x < Screen.width / 2)
            {
                if (!onLeftSide)
                {
                    R2L();
                    Debug.Log("Sol yarýya týklandý.");
                    parentPosition.DOMoveX(parentPosition.position.x - 2f, moveTime);
                    parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                    onLeftSide = true;
                }
                else
                {
                    Forward();
                    parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                }
            }
            else
            {
                if (onLeftSide)
                {
                    L2R();
                    Debug.Log("Sað yarýya týklandý.");
                    parentPosition.DOMoveX(parentPosition.position.x + 2f, moveTime);
                    parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                    onLeftSide = false;
                }
                else
                {
                    Forward();
                    parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                }
            }
        }
        Debug.Log(onLeftSide);
    }
    void Forward()
    {
        playerTransform.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        playerAC.Play("Player_Jump");
    }
    void L2R()
    {
        playerTransform.transform.rotation = Quaternion.Euler(0f, 30f, 0f);
        playerAC.Play("Player_Jump");
    }
    void R2L()
    {
        playerTransform.transform.rotation = Quaternion.Euler(0f, -30f, 0f);
        playerAC.Play("Player_Jump");
    }
}

