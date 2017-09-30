using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public AudioClip boxAudio;
    public AudioClip playerLandsAudio;
	public AudioClip playerFootstepsGravelAudio;
	public AudioClip playerFootstepsSnowAudio;



    private UnityAction<Vector3> boxCollisionEventListener;

    private UnityAction<Vector3> playerLandsEventListener;
	private UnityAction<Vector3> playerFootstepsGravelEventListener;
	private UnityAction<Vector3> playerFootstepsSnowEventListener;



   

    void Awake()
    {

        boxCollisionEventListener = new UnityAction<Vector3>(boxCollisionEventHandler);

        playerLandsEventListener = new UnityAction<Vector3>(playerLandsEventHandler);

		playerFootstepsGravelEventListener = new UnityAction<Vector3>(playerFootstepsGravelEventHandler);
		playerFootstepsSnowEventListener = new UnityAction<Vector3>(playerFootstepsSnowEventHandler);

    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {

        EventManager.StartListening<BoxCollisionEvent, Vector3>(boxCollisionEventListener);
        EventManager.StartListening<PlayerLandsEvent, Vector3>(playerLandsEventListener);
		EventManager.StartListening<PlayerFootstepsGravelEvent, Vector3>(playerFootstepsGravelEventListener);
		EventManager.StartListening<PlayerFootstepSnowEvent, Vector3>(playerFootstepsSnowEventListener);
    }

    void OnDisable()
    {

        EventManager.StopListening<BoxCollisionEvent, Vector3>(boxCollisionEventListener);
        EventManager.StopListening<PlayerLandsEvent, Vector3>(playerLandsEventListener);
		EventManager.StopListening<PlayerFootstepSnowEvent, Vector3>(playerFootstepsSnowEventListener);
		EventManager.StopListening<PlayerFootstepsGravelEvent, Vector3>(playerFootstepsGravelEventListener);
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
	void playerFootstepsGravelEventHandler(Vector3 worldPos)
	{
		AudioSource.PlayClipAtPoint(this.playerFootstepsGravelAudio, worldPos);
	}
	void playerFootstepsSnowEventHandler(Vector3 worldPos)
	{
		AudioSource.PlayClipAtPoint(this.playerFootstepsSnowAudio, worldPos);
	}

}
