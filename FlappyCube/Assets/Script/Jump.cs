using UnityEngine;

public class Jump : MonoBehaviour
{
    CharacterController characterController;
    Vector3 moveDirection;

    [SerializeField]
    float jumpPower = 10;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveDirection.y = jumpPower;
        }

        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        moveDirection.x = 1;
        //}

        moveDirection.y -= 10 * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
