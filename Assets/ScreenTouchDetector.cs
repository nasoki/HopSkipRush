using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject Player;
    private bool onLeftSide;
    void Update()
    {
        // Fare sol týklama kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonu alýnýr
            Vector3 mousePosition = Input.mousePosition;

            // Fare pozisyonunun x koordinatý ekran geniþliðinin yarýsýndan küçükse
            if (mousePosition.x < Screen.width / 2)
            {
                if(!onLeftSide) 
                {
                    Debug.Log("Sol yarýya týklandý.");
                    Player.GetComponent<Renderer>().material.color = Color.blue;
                    Player.transform.position = new Vector3((Player.transform.position.x - 2), Player.transform.position.y, Player.transform.position.z + 2);
                    onLeftSide = true;
                    // Burada sol yarýya týklandýðýnda yapýlmasý gereken iþlemleri ekleyebilirsiniz.
                }
                else
                {
                    Player.transform.position = new Vector3((Player.transform.position.x), Player.transform.position.y, Player.transform.position.z + 2);
                }
            }
            else
            {
                if(onLeftSide)
                {
                    Debug.Log("Sað yarýya týklandý.");
                    Player.GetComponent<Renderer>().material.color = Color.red;
                    Player.transform.position = new Vector3((Player.transform.position.x + 2), Player.transform.position.y, Player.transform.position.z + 2);
                    onLeftSide = false;
                    // Burada sað yarýya týklandýðýnda yapýlmasý gereken iþlemleri ekleyebilirsiniz.
                }
                else
                {
                    Player.transform.position = new Vector3((Player.transform.position.x), Player.transform.position.y, Player.transform.position.z + 2);
                }
            }
        }
        Debug.Log(onLeftSide);
    }
}

