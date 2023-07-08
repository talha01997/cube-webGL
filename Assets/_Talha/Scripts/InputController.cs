using UnityEngine;
using UnityEngine.SceneManagement;
public class InputController : MonoBehaviour
{
	public static InputController instance;

	#region var

	[SerializeField] Vector3 prevPosition;
	[SerializeField] private Transform target;
	[SerializeField] float controllSensitivity;
	[SerializeField] float moveSpeed;
	[SerializeField] float horizontal;
	[SerializeField] float maxXClamp;

    #endregion

    private void Awake()
    {
	    Input.multiTouchEnabled = false;
		Init();
    }

	void Init()
    {
        if (instance == null)
        {
			instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		PlayerInputControlls();
		Movement();
    }

    #region InputControlls

    void PlayerInputControlls()
    {
		if (Input.GetMouseButtonDown(0))
		{
			print("mouse down");
			prevPosition = Input.mousePosition; // used this to get first input when user presses mouse button
		}

		if (Input.GetMouseButton(0))
		{
			print("get mouse");
			Vector3 touchDelta = Input.mousePosition - prevPosition; // calculating swipe value
			var positionDelta = touchDelta * controllSensitivity;
			horizontal= positionDelta.x / Screen.width / 2f;
			prevPosition = Input.mousePosition;
		}
		else
		{
			// made everything zero here so that when user isn't holding mouse then the difference becomes zero
			prevPosition = Vector3.zero;
			horizontal = 0;
		}
	}

    void Movement()
    {
		Vector3 newPosition = target.localPosition + Vector3.right * horizontal * Time.deltaTime * moveSpeed;
		newPosition.x = Mathf.Clamp(newPosition.x, -maxXClamp, maxXClamp); // clamped the position on x so that it stays within given bounds
		target.localPosition = newPosition;
	}


    #endregion

	public void Restart()
    {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
