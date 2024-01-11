using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	public GameObject bulletPrefab;
	public SpriteRenderer playerSprite;
	public Animator playerAnim;
	public float speed = 4f;

	public Rigidbody2D rb;

	private float movement = 0f;

    public static bool IsFired;

	public AudioSource audioSource;
	public AudioClip[] audioClip;
    public void Start()
    {
        IsFired = false;
    }
    // Update is called once per frame
    void Update () {
		movement = Input.GetAxisRaw("Horizontal") * speed;
	}

	void FixedUpdate()
	{
		if (movement < 0f)
		{
			playerAnim.SetBool("Move", true);

			rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
			playerSprite.flipX = false;
		}
		else if (movement > 0f)
		{
			playerAnim.SetBool("Move", true);
			rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
			playerSprite.flipX = true;
		}
		else if (movement == 0f)
		{
			playerAnim.SetBool("Move", false);

		}

		if (Input.GetKey(KeyCode.Space))

        {
            audioSource.clip = audioClip[1];
            audioSource.Play();
            playerSprite.flipX = false;
            playerAnim.SetBool("Move", false);
            playerAnim.SetBool("Attack", true);
            IsFired = true;
        }
		else
		{
            playerAnim.SetBool("Attack", false);
        }

        if (IsFired)
        {
			
             bulletPrefab.transform.localScale =bulletPrefab.transform.localScale + Vector3.up * Time.deltaTime * speed;
        }
        else
        {
            bulletPrefab.transform.position = transform.position;
            bulletPrefab.transform.localScale = new Vector3(0.05f, 0f, 0.5f);
        }






    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.tag == "Ball")
		{
            audioSource.clip = audioClip[0];
            audioSource.Play();
            Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
 }

