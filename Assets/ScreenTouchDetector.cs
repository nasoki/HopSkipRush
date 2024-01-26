using UnityEngine;
using DG.Tweening;

public class MouseInput : MonoBehaviour
{
    public Transform parentPosition, playerTransform;
    private float moveTime = 0.867f;
    private bool onLeftSide, canJump;

    [SerializeField] private Animator playerAC;

    private void Start()
    {
        canJump = true;
    }
    void Update()
    {
        // sol týklama kontrolü / dokunma kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            //DOJump maybe???
            Vector3 mousePosition = Input.mousePosition;
            // check whether its clicked on left or right
            if (mousePosition.x < Screen.width / 2)
            {
                if (canJump)
                {
                    if (!onLeftSide)
                    {
                        R2L();
                        Debug.Log("Sol yarýya týklandý.");
                        //parentPosition.DOMoveX(parentPosition.position.x - 2f, moveTime);
                        //parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                        parentPosition.DOJump(new Vector3(parentPosition.position.x - 2, parentPosition.position.y, parentPosition.position.z + 2), 0.5f, 1, moveTime, false);
                        onLeftSide = true;
                    }
                    else
                    {
                        Forward();
                        //parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                        parentPosition.DOJump(new Vector3(parentPosition.position.x, parentPosition.position.y, parentPosition.position.z + 2), 0.5f, 1, moveTime, false);
                    }
                    StartCoroutine(DisableJumpForDelay());
                }
            }
            else
            {
                if(canJump)
                {
                    if (onLeftSide)
                    {
                        L2R();
                        Debug.Log("Sað yarýya týklandý.");
                        //parentPosition.DOMoveX(parentPosition.position.x + 2f, moveTime);
                        //parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                        parentPosition.DOJump(new Vector3(parentPosition.position.x + 2, parentPosition.position.y, parentPosition.position.z + 2), 0.5f, 1, moveTime, false);
                        onLeftSide = false;
                    }
                    else
                    {
                        Forward();
                        //parentPosition.DOMoveZ(parentPosition.position.z + 2f, moveTime);
                        parentPosition.DOJump(new Vector3(parentPosition.position.x, parentPosition.position.y, parentPosition.position.z + 2), 0.5f, 1, moveTime, false);
                    }
                    StartCoroutine(DisableJumpForDelay());
                }
            }
        }
        Debug.Log(onLeftSide);
    }
    System.Collections.IEnumerator DisableJumpForDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(moveTime);
        canJump = true;
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

