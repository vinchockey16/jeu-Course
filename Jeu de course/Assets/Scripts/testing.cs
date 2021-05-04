using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class testing : MonoBehaviour
{
    // [SerializeField] private CharacterPathfindingMovementHandler characterPathfinding;

    private Vector3 cible;
    private Quaternion rotation;
   // private float angleTransform = 0;
    int tourner = 0;
    public float vitesse;
    public float positionDeDepartX;
    public float positionDeDepartY;
    public Rigidbody2D rb;
    public float clockwise = 1000.0f;
    public float counterClockwise = 5.0f;

    private Pathfinding pathfinding;
    private float direction;

    private List<PathNodes> chemin;
    int j = 1;

    //private Transform cible;
    //public float vitesse = 1.0f;


    private void Start()
    {
        rb.transform.parent = null;
        pathfinding = new Pathfinding(49, 29);
        chemin = pathfinding.FindPath(5, 0, 48, 15, 1);
        //Debug.Log("x: " + chemin[i].x + " y: " + chemin[i].y + " vecteur: " + new Vector3(chemin[i].x - 34, chemin[i].y - 12));
        //transform.Translate((new Vector3(chemin[i + 1].x , chemin[i + 1].y ) * 0.5f + Vector3.one * 0.2f) + (new Vector3(chemin[i].x , chemin[i].y ) * -1 * 0.5f + Vector3.one * 0.2f));

        /*transform.position = new Vector3(chemin[i].x - 34, chemin[i].y - 12);
        GameObject Test = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible = Test.transform;
        cible.transform.localScale = new Vector3(0.85f, 1.0f, -3.0f);
        cible.transform.position = new Vector3(0.8f, 0.0f, 0.8f);

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
        if (chemin[i + 1].x -34 < 48)
        {
            if (chemin[i + 1].y -12 < 15)
            {
                //transform.Translate(new Vector3(chemin[i + 1].x - 34, chemin[i + 1].y - 12) * -1 * 0.5f + Vector3.one * 0.2f);
            }
        }*/

        if (transform.position.x < 48 - 34)
        {
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(chemin[i].x - 34, chemin[i].y - 12) * 0.5f + Vector3.one * 0.2f, new Vector3(chemin[i + 1].x - 34, chemin[i + 1].y - 12) * 0.5f + Vector3.one * 0.2f, Color.green, 20f);
                //Debug.Log(new Vector3(chemin[i].x, chemin[i].y));
               
                

            }
            cible = new Vector3((chemin[1].x - chemin[0].x) * 0.5f + positionDeDepartX , (chemin[1].y - chemin[0].y) * 0.5f + positionDeDepartY);
            Debug.Log(cible);
        }
    }

    private void Update()
    {
        if (tourner == 0)
        {
            double distance = Math.Sqrt(Math.Pow(transform.position.x - cible.x, 2) + Math.Pow(transform.position.y - cible.y, 2));
            //Debug.Log(distance);
            if (distance < 1)
            {
                Vector3 vecteur1 = new Vector3(cible.x - transform.position.x, cible.y - transform.position.y);
                Vector3 vecteur2 = transform.up;
               // Debug.Log("Direction vers la cilbe: " + vecteur1);
                //Debug.Log("Direction voiture: " + vecteur2);
               // Vector3 vecteur2 = new Vector3(chemin[j].x - chemin[j - 1].x, chemin[j].y - chemin[j - 1].y);

                double angle = (Vector3.AngleBetween(vecteur1, vecteur2)) * (180 / Math.PI);

                direction = Convert.ToSingle(angle);
                
                if(transform.position.x + vecteur1.x > transform.position.x + vecteur2.x )
                {
                    direction = -1 * direction;
                }
                else if (transform.position.y + vecteur1.y < transform.position.y + vecteur2.y)
                {
                    direction = -1 * direction;
                }
                

                /* if ((vecteur1.x - vecteur1.y) > (vecteur2.x - vecteur2.y))
                 {
                     direction = -1 * direction;
                 }*/
                // Debug.Log("angle " + direction);
                //transform.Rotate(0, 0, direction / 2 * Time.deltaTime * 100f);
                //transform.Rotate(0, 0, direction / 2 * Time.deltaTime * 100f);


                //if (direction > 0.005 || direction < -0.005)
                // {
                if (direction != 0)
                {
                    
                    

                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, (direction / Math.Abs(direction)) * 100f * Time.deltaTime));


                    //transform.Rotate(0,0,-10f);
                    // while(transform.rotation.z != angle)
                    // while (transform.rotation.z != direction + angleTransform)
                    // {
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, (direction + angleTransform)), 50f * Time.deltaTime);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, (direction + angleTransform)), 100f * Time.deltaTime);

                    // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, direction + angleTransform), 5000f * Time.deltaTime);
                    //angleTransform = angleTransform + direction;
                    //}

                }
                else { tourner = 1; }
                // Debug.Log(new Vector3(chemin[j + 1].x - chemin[j].x, chemin[j + 1].y - chemin[j].y));
                // Debug.Log(new Vector3(chemin[j].x - chemin[j - 1].x, chemin[j].y - chemin[j - 1].y));
                // Debug.Log(direction);
                //}
                
            }
        }
        //Debug.Log(transform.position.x + " >= " + cible.x);
       // Debug.Log(transform.position.y + " >= " + cible.y);
       // Debug.Log(direction);
        if (transform.position.x >= cible.x-0.5 && transform.position.y >= cible.y - 0.5)
        {
            //if (direction == 0)
            //{




                /*
                if (direction != 0 && tourner == 0)
                {


                    if ((vecteur1.x - vecteur1.y) > (vecteur2.x - vecteur2.y))
                    {
                        direction = -1 * direction;
                    }

                    //transform.Rotate(0, 0, direction/2 * Time.deltaTime * 100f);

                    tourner = 1;

                }*/

                //if (transform.position.x < 7 && transform.position.y < 2)
                //{

                //transform.Translate(cible * 0.001f);

                //transform.position = Vector3.MoveTowards(transform.position, cible, 1f * Time.deltaTime);

                //transform.position += transform.left * Time.deltaTime * 5f;


                //Debug.Log(transform.position);
                cible = new Vector3((chemin[j + 1].x - chemin[j].x) * 0.5f + cible.x, (chemin[j + 1].y - chemin[j].y) * 0.5f + cible.y);
                Debug.Log("Cible: " + cible);
                // Debug.Log((chemin[j + 1].x - chemin[j].x) + " + " + transform.position.x);
                //Debug.Log((chemin[j + 1].y - chemin[j].y) + " + " + transform.position.y);

                j++;
                tourner = 0;


                // Debug.Log("point: (" + (chemin[j + 1].x - chemin[j].x) + ", " + (chemin[j + 1].y - chemin[j].y));

                // Debug.Log("cible: " + cible);
            //}
        }
            //else
            //{
                //Quaternion deltaRotationRight = Quaternion.Euler(cible * Time.deltaTime);
                // transform.MoveRotation(transform.rotation * deltaRotationRight);






                /*cible = new Vector3((chemin[j + 1].x - chemin[j].x) * 0.5f + transform.position.x, (chemin[j + 1].y - chemin[j].y) * 0.5f + transform.position.y);
                j++;
                tourner = 0;


                // Debug.Log("point: (" + (chemin[j + 1].x - chemin[j].x) + ", " + (chemin[j + 1].y - chemin[j].y));
                
                 Debug.Log("cible: " + cible);*/
           // }

        //}
        /*
                pathfinding.GetGrid().GetXY(new Vector3(48, 15, 0), out int x, out int y);
                List<PathNodes> chemin = pathfinding.FindPath(4, 0, 48, 15, 1);
                if (transform.position.x < 48-34 ){
                    for (int i = 0; i < chemin.Count - 1; i++)
                    {
                        Debug.DrawLine(new Vector3(chemin[i].x - 34, chemin[i].y - 12) * 0.5f + Vector3.one * 0.2f, new Vector3(chemin[i + 1].x - 34, chemin[i + 1].y - 12) * 0.5f + Vector3.one * 0.2f, Color.green, 10f);
                        Debug.Log(new Vector3(chemin[i+1].x - chemin[i].x, chemin[i+1].y - chemin[i].y));

                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.2f, 0.01f * Time.deltaTime);

                        //Vector3 direction = new Vector3(chemin[i].x, chemin[i].y) + transform.position  ;
                        //transform.forward = Vector3.RotateTowards(transform.forward,direction ,0.1f *Time.deltaTime,  0.0f);
                        //transform.position = Vector3.Lerp(transform.position, new Vector3(chemin[i + 1].x - chemin[i].x, chemin[i + 1].y - chemin[i].y), 0.1f * Time.deltaTime);
                        // transform.Translate(new Vector3(chemin[i+1].x - chemin[i].x, 0,0) * Time.deltaTime * 0.1f);
                        //transform.Translate(new Vector3(-1 * chemin[i + 1].x - chemin[i].x, 0, 0) * Time.deltaTime * 0.1f);

                        // transform.Translate(new Vector3(chemin[i + 1].x, chemin[i + 1].y) * Time.deltaTime * 0.01f);
                    }
                    //Debug.Log("Vecteur: " + chemin[i].x);
                }*/
        //transform.Translate(new Vector3(chemin[1].x - 34, chemin[1].y - 12)* Time.deltaTime * Speed);
        // characterPathfinding.SetTargetPosition(new Vector3(48, 15, 0));


        // float step = vitesse * Time.deltaTime; // calculate distance to move
        // transform.position = Vector3.MoveTowards(transform.position, cible.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        /* if (Vector3.Distance(transform.position, cible.position) < 0.001f)
         {
             // Swap the position of the cylinder.
             cible.position *= -1.0f;
         }*/

        //characterPathfinding.SetTargetPosition(new Vector3(48, 15));


        /* if (Input.GetMouseButtonDown(0))
         {
             Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
             pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
             List<PathNodes> chemin = pathfinding.FindPath(4, 0, x, y, 1);
             if(chemin != null)
             {
                 for(int i=0; i < chemin.Count - 1; i++)
                 {
                     Debug.DrawLine(new Vector3(chemin[i].x -34, chemin[i].y -12) * 0.5f + Vector3.one * 0.2f, new Vector3(chemin[i+1].x - 34, chemin[i+1].y - 12) * 0.5f + Vector3.one * 0.2f, Color.green, 10f);
                 }

             }
         }*/
    }

    private void FixedUpdate()
    {
        //Debug.Log(transform.position.x);
       // Debug.Log(transform.position.y);
        if (transform.position.x < 7 && transform.position.y < 2)
        {
            rb.AddForce(transform.up * vitesse);
        }
    }


}

    
