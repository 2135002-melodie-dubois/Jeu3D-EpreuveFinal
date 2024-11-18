using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacerCanard : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/2XIf_Qhd0gE?si=hSFmvyDwVHMJgyZm

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction rotateAction;
    private Rigidbody rb;

    public float vitesse;
    public float vitesseRotation;
    private float rotate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rotateAction = playerInput.actions.FindAction("Rotater");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Deplacer();
        Rotater();
    }

    void Deplacer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += transform.rotation * new Vector3(direction.x, 0, direction.y) * vitesse * Time.deltaTime;
    }

    void Rotater()
    {
        float rotate = rotateAction.ReadValue<float>();
        rb.rotation = rb.rotation * Quaternion.AngleAxis(rotate * vitesseRotation * Time.deltaTime, Vector3.up);
    }
}
