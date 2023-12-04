using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject Player;
    private bool onLeftSide;
    void Update()
    {
        // Fare sol t�klama kontrol�
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonu al�n�r
            Vector3 mousePosition = Input.mousePosition;

            // Fare pozisyonunun x koordinat� ekran geni�li�inin yar�s�ndan k���kse
            if (mousePosition.x < Screen.width / 2)
            {
                if(!onLeftSide) 
                {
                    Debug.Log("Sol yar�ya t�kland�.");
                    Player.GetComponent<Renderer>().material.color = Color.blue;
                    Player.transform.position = new Vector3((Player.transform.position.x - 2), Player.transform.position.y, Player.transform.position.z + 2);
                    onLeftSide = true;
                    // Burada sol yar�ya t�kland���nda yap�lmas� gereken i�lemleri ekleyebilirsiniz.
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
                    Debug.Log("Sa� yar�ya t�kland�.");
                    Player.GetComponent<Renderer>().material.color = Color.red;
                    Player.transform.position = new Vector3((Player.transform.position.x + 2), Player.transform.position.y, Player.transform.position.z + 2);
                    onLeftSide = false;
                    // Burada sa� yar�ya t�kland���nda yap�lmas� gereken i�lemleri ekleyebilirsiniz.
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

