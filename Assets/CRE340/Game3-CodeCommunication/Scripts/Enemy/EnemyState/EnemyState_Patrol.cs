using UnityEngine;
public class EnemyState_Patrol : IEnemyState
{
    private Vector3 patrolCenter;
    private Vector3 patrolTarget;
    private float patrolRange = 5f; // Range within which the enemy will patrol
    private float patrolSpeed = 1.5f; // Speed while patrolling
    private float targetReachedThreshold = 0.2f; // How close the enemy needs to get to a point before switching to the next target
    private float idleProbability = 0.001f; // Probability of switching back to Idle
                                        // Called when transitioning into Patrol State
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Patrol State");
        patrolCenter = enemy.transform.position; // Set the patrol's center to the enemy's current position
        SetNewPatrolTarget(enemy); // Define a target location within the patrol range
    }
    // Called each frame to update patrol behaviour
    public void Update(Enemy enemy)
    {
        // Transition to Chase if the player is within chase range
        if (enemy.target != null && Vector3.Distance(enemy.transform.position, enemy.target.position) <
        enemy.chaseRange)
        {
            enemy.SetState(new EnemyState_Chase());
            return;
        }
        // Move towards the patrol target
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, patrolTarget, patrolSpeed *
        Time.deltaTime);
        // Check if the target is reached and set a new patrol target if necessary
        if (Vector3.Distance(enemy.transform.position, patrolTarget) < targetReachedThreshold)
        {
            SetNewPatrolTarget(enemy);
        }
        // Random chance to switch to Idle for variety in behaviour
        if (Random.value < idleProbability)
        {
            enemy.SetState(new EnemyState_Idle());
        }
    }
    // Called when exiting Patrol State
    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Patrol State");
    }
    // Sets a random patrol target within the patrol range
    private void SetNewPatrolTarget(Enemy enemy)
    {
        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);
        patrolTarget = patrolCenter + new Vector3(randomX, 0, randomZ);
    }
}
