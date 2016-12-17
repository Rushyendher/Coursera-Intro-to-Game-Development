using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private GameManager gameManagerInstance;
    private Rigidbody playerRigid;
    private int currentHealth;

    public float playerSpeed;
    public GameObject coinExplodePrefab;
    public GameObject playerExplodePrefab;

    void Awake()
    {
        gameManagerInstance = GameManager.instance;
    }

	// Use this for initialization
	void Start () {
        currentHealth = PlayerInfo.health;
        playerRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalSpeed, 0.0f, verticalSpeed);

        playerRigid.AddForce(movement * playerSpeed);
	}

    void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        Vector3 otherPos = other.gameObject.transform.position;
        switch (otherTag)
        {
            case "Pickup":          
                Destroy(other.gameObject);
                gameManagerInstance.DisplayScore();
                Instantiate(coinExplodePrefab, otherPos, Quaternion.identity);

                break;
            case "DeathZone":
                gameManagerInstance.RestartGame();
                break;
            case "Enemy":
                DecreaseHealth(EnemyInfo.damage);
                if(currentHealth <= 0)
                {
                    Instantiate(playerExplodePrefab, transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    gameManagerInstance.GameOver();
                }
                break;       
        }
    }

    private void WaitTime()
    {
        gameManagerInstance.RestartGame();
    }

    private void DecreaseHealth(int damage)
    {
        currentHealth = currentHealth - damage;
    }
 
}
