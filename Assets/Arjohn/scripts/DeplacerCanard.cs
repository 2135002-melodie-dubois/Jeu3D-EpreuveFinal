using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacerCanard : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/2XIf_Qhd0gE?si=hSFmvyDwVHMJgyZm

    PlayerInput playerInput;
    InputAction moveAction;
    private new Rigidbody rb;

    public float vitesse;
    public float vitesseRotation;
    private float rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Deplacer();
    }

    void Deplacer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * vitesse * Time.deltaTime;
    }

    void Rotater()
    {
        rotation = 
        rb.rotation = rb.rotation * Quaternion.AngleAxis(rotation * vitesseRotation * Time.deltaTime * Vector3.up);
    }
}
