using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public enum EnemyMotionStates
    {
        spin,
        horizontal,
        vertical
    }


    private Transform enemyTransform;

    public EnemyMotionStates motionState = EnemyMotionStates.horizontal;
    public float enemyMovementSpeed = 0.5f;
    public float enemySpinSpeed = 180.0f;

	// Use this for initialization
	void Start () {
        enemyTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (motionState)
        {
            case EnemyMotionStates.spin:
                enemyTransform.Rotate(Vector3.up, enemySpinSpeed * Time.deltaTime);
                break;
            case EnemyMotionStates.horizontal:
                enemyTransform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * enemyMovementSpeed);
                break;
            case EnemyMotionStates.vertical:
                enemyTransform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * enemyMovementSpeed);
                break;
        }
	}
}
