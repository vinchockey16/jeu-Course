using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Aetoile : MonoBehaviour
{
    public float vitesse;
    public float positionDeDepartX;
    public float positionDeDepartY;
    public Rigidbody2D rb;
    public int map;

    private Vector3 cible;
    private Pathfinding pathfinding;
    private float direction;
    private double angle;
    private int tourner = 0;
    private List<PathNodes> chemin;
    private int j = 1;
    private float decalageX;
    private float decalageY;
    private float infiniPos = float.PositiveInfinity;
    private float infiniNeg = float.NegativeInfinity;


    private void Start()
    {
        rb.transform.parent = null;
        if (map == 1)
        {
            pathfinding = new Pathfinding(55, 35, new Vector3(-745, -503, 0));
            chemin = pathfinding.FindPath(6, 0, 53, 15, map, 0);
            decalageX = 25;
            decalageY = 17;
        }
        else if(map == 2)
        {
            pathfinding = new Pathfinding(62, 35, new Vector3(-950, -503, 0));
            chemin = pathfinding.FindPath(53, 0, 0, 27, map, 0);
            decalageX = 32;
            decalageY = 17;
        }
        else if (map == 3)
        {
            pathfinding = new Pathfinding(72, 37, new Vector3(-1065, -580, 0));
            chemin = pathfinding.FindPath(6, 0, 0, 27, map, 0);
            decalageX = 35.7f;
            decalageY = 19.5f;
        }
        else if (map == 4)
        {
            pathfinding = new Pathfinding(65, 37, new Vector3(-1020, -545, 0));
            chemin = pathfinding.FindPath(35, 17, 26, 5, map, 0);
            decalageX = 34.2f;
            decalageY = 18.5f;
        }




        for (int i = 0; i < chemin.Count - 1; i++)
        {
            //Pour afficher le chemin
             Debug.DrawLine(new Vector3(chemin[i].x - decalageX, chemin[i].y-decalageY) * 30f + Vector3.one * 20f, new Vector3(chemin[i + 1].x -decalageX, chemin[i + 1].y -decalageY) * 30f + Vector3.one * 20f, Color.green, 50f);
            //Debug.Log(new Vector3(chemin[i].x, chemin[i].y));



        }
        cible = new Vector3((chemin[1].x - chemin[0].x) * 30f + positionDeDepartX, (chemin[1].y - chemin[0].y) * 30f + positionDeDepartY);


    }

    private void Update()
    {
        //if (transform.position.x >= -840 || transform.position.y <= 326)
        //{
            if (tourner == 0)
            {
                double distance = Math.Sqrt(Math.Pow(transform.position.x - cible.x, 2) + Math.Pow(transform.position.y - cible.y, 2));

                if (distance < 100 )
                {
                    Vector3 vecteur1 = new Vector3((cible.x - transform.position.x), (cible.y - transform.position.y));
                    //Vector3 vecteur1 = new Vector3(cible.x - (cible.x - ((chemin[j + 1].x - chemin[j].x) * 30f)), cible.y - (cible.y - ((chemin[j + 1].y - chemin[j].y) * 30f)));
                    Vector3 vecteur2 = transform.up;

                    angle = (Vector3.AngleBetween(vecteur1, vecteur2)) * (180 / Math.PI);
                   // Debug.Log(angle);
                    //Debug.Log(vecteur1);
                    direction = Convert.ToSingle(angle);

                    if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 90)
                    {
                        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 180)
                        {
                            if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x)
                            {
                                direction = direction * -1;
                            }
                        else if (/*vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x*/ vecteur1.y < 0 && vecteur1.x < 0)
                        {
                            direction = direction * -1;
                        }

                    }
                        else if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 180)
                        {
                            if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x && vecteur1.x < 0)
                            {
                                direction = direction * -1;
                            }
                        else if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x && vecteur1.y < 0 && vecteur1.x > 0)
                        {
        
                            direction = direction * 1;
                        }
                        else if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x && vecteur1.y < 0 && vecteur1.x < 0)
                        {
                            direction = direction * -1;
                        }

                    }
                        else if (transform.eulerAngles.z <= 180 && transform.eulerAngles.z >= 180)
                        {
                            if (vecteur1.y / vecteur1.x > 0)
                            {
                                direction = direction * -1;
                            }
                        }
                    }
                    else if (transform.eulerAngles.z > 270 || transform.eulerAngles.z < 90)
                    { 
                        
                       if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 90)
                        {
                            if(vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x)
                            {
                                direction = direction * -1;
                            }
                            else  if (vecteur1.y / vecteur1.x > 0 && vecteur1.y > 0)
                            {
                                
                                direction = direction * -1;
                            }
                        }
                       else if (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 270)
                        {
                            if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x && vecteur1.y / vecteur1.x > 0)
                            {
                                direction = direction * -1;
                            }
                            else if (vecteur1.y / vecteur1.x < 0 && vecteur1.y > 0)
                            {
                                direction = direction * 1;
                            }
                            else if (vecteur1.y / vecteur1.x < 0 && vecteur1.y < 0)
                            {
                                direction = direction * -1;
                            }

                        }
                        else if (transform.eulerAngles.z == 0 || transform.eulerAngles.z == 360)
                        {
                            if (vecteur1.y / vecteur1.x > 0)
                            {
                                direction = direction * -1;
                            }

                        }
                    }
                    else if (transform.eulerAngles.z == 90 )
                    {
                        if (vecteur1.y / vecteur1.x < 0)
                        {
                            direction = direction * -1;
                        }
                    } 
                    else if (transform.eulerAngles.z == 270)
                    {
                        if (vecteur1.y / vecteur1.x < 0)
                        {
                            direction = direction * -1;
                        }
                    }

                    if (angle != 0f)
                    {
                       // vitesse = 150f;
                        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, (direction / Math.Abs(direction)) * 150f * Time.deltaTime));
                    }
                    else { tourner = 1; }
                }
            }

            if (transform.position.x >= cible.x - 30 && transform.position.y >= cible.y - 30 && transform.position.x <= cible.x + 30 && transform.position.y <= cible.y + 30 /*&& angle < 1f && angle > -1f*/)
            {

            if (vitesse < 400)
            {
                vitesse += 120;
            }

            cible = new Vector3((chemin[j + 1].x - chemin[j].x) * 30f + cible.x, (chemin[j + 1].y - chemin[j].y) * 30f + cible.y);
                //Debug.Log("Cible: " + cible);
                j++;
                tourner = 0;

            }
       // }
    }
    private void FixedUpdate()
    {
        if (0 < Time.time)
        {
            //if (transform.position.x >= -840 || transform.position.y <= 326)
            //{
                rb.AddForce(transform.up * vitesse);
           // }
        }
    }


}

