using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerMovement Start: Sucessful");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = new Vector3(0, 0, 5) * Time.deltaTime;
        movementVector = (Vector3.forward * 10) * Time.deltaTime;

        //Translate used on local axis of the object not on global
        transform.Translate(movementVector);
    }
}
