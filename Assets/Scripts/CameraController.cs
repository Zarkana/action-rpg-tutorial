using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  public GameObject followTarget;
  private Vector3 targetPos;
  public float moveSpeed;

  private static bool cameraExists;

  public BoxCollider2D boundBox;
  private Vector3 minBounds;
  private Vector3 maxBounds;

  private Camera theCamera;
  private float halfHeight;
  private float halfWidth;

	// Use this for initialization
	void Start () {
    DontDestroyOnLoad(transform.gameObject);

    if (!cameraExists)
    {
      cameraExists = true;
      DontDestroyOnLoad(transform.gameObject);
    }
    else
    {
      Destroy(gameObject);
    }

    minBounds = boundBox.bounds.min;//lowest x and lowest y
    maxBounds = boundBox.bounds.max;//highest x and lowest y

    theCamera = GetComponent<Camera>();
    halfHeight = theCamera.orthographicSize;
    halfWidth = halfHeight * Screen.width / Screen.height;

    if (boundBox == null)
    {
      boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
      minBounds = boundBox.bounds.min;//lowest x and lowest y
      maxBounds = boundBox.bounds.max;//highest x and lowest y
    }

  }
	
	// Update is called once per frame
	void Update () {
    targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
    transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

    if(boundBox == null)
    {
      boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
      minBounds = boundBox.bounds.min;//lowest x and lowest y
      maxBounds = boundBox.bounds.max;//highest x and lowest y
    }

    float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
    float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfWidth, maxBounds.y - halfHeight);
    transform.position = new Vector3(clampedX, clampedY, transform.position.z);
  }

  public void SetBounds (BoxCollider2D newBounds)
  {
    boundBox = newBounds;

    minBounds = boundBox.bounds.min;//lowest x and lowest y
    maxBounds = boundBox.bounds.max;//highest x and lowest y
  }
}
