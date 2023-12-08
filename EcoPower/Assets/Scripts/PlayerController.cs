using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    #region variables
    public static PlayerController instance;
    private Animator anim;
    public CharacterController charController;
    public float moveSpeed, turnSpeed, jumpForce, gravity;
    private Vector3 moveDirection = Vector3.zero;
    public Camera playerCamera;
    public GameObject playerModel;
    public bool isKnocking;
    public float knockBackLength = 0.5f;
    private float knockBackCounter;
    public Vector2 knockBackPower;
    public GameObject[] playerPieces;

    #endregion


    private void Awake()
    {
        instance = this;
    }
    void Start () 
	{
		charController = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();

	}

	void Update ()
    {

    #region animaciones

    if (Input.GetKey("w") || Input.GetKey("s"))
    {
        anim.SetInteger("AnimationPar", 1);
    }
    else
    {
        anim.SetInteger("AnimationPar", 0);
    }
    anim.SetBool("isGrounded", charController.isGrounded);

    #endregion

        if (!isKnocking)
        {
            #region Movimiento Basico

            //Caminar/Correr (W-S)
            float yPositionStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") + (transform.right * Input.GetAxisRaw("Horizontal")));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yPositionStore;

            //Saltar (Space)
            if (charController.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {

                    moveDirection.y = jumpForce;
                }
            }
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravity;
            charController.Move(moveDirection * Time.deltaTime);
            anim.SetFloat("JumpVertical", charController.velocity.y);


            //Rotacion sin rotar el jugado (A-D)
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, 5f * Time.deltaTime);
            }

            #endregion
        }
        if (isKnocking)
        {
            knockBackCounter -= Time.deltaTime;
            float yPositionStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * knockBackPower.x;
            charController.Move(moveDirection * Time.deltaTime);
            moveDirection.y = yPositionStore;
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravity;

            if (knockBackCounter <= 0) 
            {
                isKnocking = false;
            }
        }

    }

    public void KnockBack()
    {
        isKnocking = true;
        knockBackCounter = knockBackLength;
        moveDirection.y = knockBackPower.y;
        charController.Move(moveDirection * Time.deltaTime * gravity);
    }
}
