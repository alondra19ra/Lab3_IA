using UnityEngine;

public class FSMManager : MonoBehaviour
{
    public State currentState;

    [Header("Necesidades")]
    public float hambre;
    public float energia = 100f;
    public float necesidadWC;

    [Header("Sensores")]
    public bool jugueteDetectado;
    public Transform jugueteTransform;

    [Header("Puntos del escenario")]
    public Transform comedor;
    public Transform cama;
    public Transform banio;

    void Start()
    {
        ChangeState(new JugarState(this));
    }

    void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }

    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Juguete"))
        {
            jugueteDetectado = true;
            jugueteTransform = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Juguete"))
        {
            jugueteDetectado = false;
            jugueteTransform = null;
        }
    }
}