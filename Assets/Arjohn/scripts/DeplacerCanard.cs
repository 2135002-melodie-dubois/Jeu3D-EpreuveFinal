using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacerCanard : MonoBehaviour
{
    // REFERENCES :
    // https://youtu.be/2XIf_Qhd0gE?si=hSFmvyDwVHMJgyZm (How To Add 3D Movement Using Unity's New Input System)
    // https://youtu.be/5mlwvbu1fxQ?si=A0iiMmAg-0I3oz3Y (Idle, Walk, and Run Animations in Unity Tutorial)

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction rotateAction;
    private Rigidbody rb;
    private Animator an;

    public float vitesse;
    public float vitesseRotation;
    private Vector3 moveDirection;
    private float rotate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rotateAction = playerInput.actions.FindAction("Rotater");
    }

    // Update is called once per frame
    void Update()
    {
        Deplacer();
        // si le joueur bouge, il va activer l'animation de tremousse,
        // sinon, bouge pas
        if (moveDirection == Vector3.zero)
        {
            an.SetBool("Bouge", false);
        }
        else
        {
            an.SetBool("Bouge", true);
        }
        Rotater();
    }

    /// <summary>
    /// fonction pour deplacer le canard
    /// </summary>
    void Deplacer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += transform.rotation * moveDirection * vitesse * Time.deltaTime;
    }

    /// <summary>
    /// fonction pour rotater le canard
    /// </summary>
    void Rotater()
    {
        float rotate = rotateAction.ReadValue<float>();
        rb.rotation = rb.rotation * Quaternion.AngleAxis(rotate * vitesseRotation * Time.deltaTime, Vector3.up);
    }
}
