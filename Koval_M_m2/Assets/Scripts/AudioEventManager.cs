using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public AudioClip boxAudio;
    public AudioClip playerLandsAudio;
	public AudioClip playerFootstepsAudio;



    private UnityAction<Vector3> boxCollisionEventListener;

    private UnityAction<Vector3> playerLandsEventListener;
	private UnityAction<Vector3> playerFootstepsEventListener;



   

    void Awake()
    {

        boxCollisionEventListener = new UnityAction<Vector3>(boxCollisionEventHandler);

        playerLandsEventListener = new UnityAction<Vector3>(playerLandsEventHandler);

		playerFootstepsEventListener = new UnityAction<Vector3>(playerFootstepsEventHandler);

    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {

        EventManager.StartListening<BoxCollisionEvent, Vector3>(boxCollisionEventListener);
        EventManager.StartListening<PlayerLandsEvent, Vector3>(playerLandsEventListener);
		EventManager.StartListening<PlayerFootstepsEvent, Vector3>(playerFootstepsEventListener);
    }

    void OnDisable()
    {

        EventManager.StopListening<BoxCollisionEvent, Vector3>(boxCollisionEventListener);
        EventManager.StopListening<PlayerLandsEvent, Vector3>(playerLandsEventListener);
		EventManager.StopListening<PlayerFootstepsEvent, Vector3>(playerFootstepsEventListener);
    }


	
    // Update is called once per frame
    void Update()
    {
    }


 

    void boxCollisionEventHandler(Vector3 worldPos)
    {
        AudioSource.PlayClipAtPoint(this.boxAudio, worldPos);
    }

    void playerLandsEventHandler(Vector3 worldPos)
    {
        AudioSource.PlayClipAtPoint(this.playerLandsAudio, worldPos);
    }
	void playerFootstepsEventHandler(Vector3 worldPos)
	{
		AudioSource.PlayClipAtPoint(this.playerFootstepsAudio, worldPos);
	}

}
