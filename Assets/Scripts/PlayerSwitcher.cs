using UnityEngine;
using Aircraft;
using Unity.MLAgents.Policies;
using Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    private bool isPlayerControlled = false;

    [SerializeField] private AircraftAgent agent;
    [SerializeField] private AircraftPlayer player;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private Rigidbody agentBody;
    private Rigidbody playerBody;

    void Awake()
    {
        agentBody = agent.GetComponent<Rigidbody>();
        playerBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPlayerControlled = !isPlayerControlled;
            UpdateState();
        }
    }

    void UpdateState()
    {
        agent.gameObject.SetActive(!isPlayerControlled);

        if (isPlayerControlled)
        {
            player.transform.position = agent.transform.position;
            player.transform.rotation = agent.transform.rotation;
            playerBody.velocity = agentBody.velocity;
            playerBody.angularVelocity = agentBody.angularVelocity;
        }
        else
        {
            agent.transform.position = player.transform.position;
            agent.transform.rotation = player.transform.rotation;
            agentBody.velocity = playerBody.velocity;
            agentBody.angularVelocity = playerBody.angularVelocity;
        }

        player.gameObject.SetActive(isPlayerControlled);

        virtualCamera.m_Follow = isPlayerControlled ? player.transform : agent.transform;
        virtualCamera.m_LookAt = isPlayerControlled ? player.transform : agent.transform;
    }
}
