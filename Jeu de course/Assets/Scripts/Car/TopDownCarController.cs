using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    // Car settings
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20;

    // Local variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;

    // Components
    Rigidbody2D carRigidbody2D;
    
    // Awake is called when the script instance is being loaded.
    void Awake(){
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        ApplyEngineForce();
        OrthogonalVelocity();
        ApplySteering();
    }

    void ApplyEngineForce(){

        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        // Limite la vitesse max
        if(velocityVsUp > maxSpeed && accelerationInput > 0){
            return;
        }
        
        if(velocityVsUp < -maxSpeed && accelerationInput < 0){
            return;
        }

        //Limite la vitesse max
        if(carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0){
            return;
        }
        else{
            carRigidbody2D.drag = 0;
        }
        
        // Apply une force si on ne touche pas a l'acceleration
        if(accelerationInput == 0){
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime*3);
        }

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering(){
        rotationAngle -= steeringInput * turnFactor;

        carRigidbody2D.MoveRotation(rotationAngle);
    }

    void OrthogonalVelocity(){
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }


    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
