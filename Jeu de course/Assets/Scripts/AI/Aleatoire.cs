﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Aleatoire : MonoBehaviour
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
    private int entier = 0;
    private int finY;
    private List<PathNodes> chemin;
    private int tourner = 0;
    private  int j = 1;
    private int decalageX;
    private int decalageY;



    private void Start()
    {
        rb.transform.parent = null;



        if (map == 1)
        {
            System.Random random = new System.Random();
            entier = random.Next(0, 3);

            if (entier == 1 || entier == 2)
            {
                finY = 17;
            }
            else { finY = 15; }

            pathfinding = new Pathfinding(55, 35, new Vector3(-745, -503, 0));
            chemin = pathfinding.FindPath(4, 0, 53, finY, map, entier);

            decalageX = 25;
            decalageY = 17;
        }
        if (map == 2)
        {
            System.Random random = new System.Random();
            entier = random.Next(0, 3);

            if (entier == 1 || entier == 2)
            {
                finY = 27;
            }
            else { finY = 27; }

            pathfinding = new Pathfinding(62, 35, new Vector3(-950, -503, 0));
            chemin = pathfinding.FindPath(55, 0, 0, finY, map, entier);

            decalageX = 32;
            decalageY = 17;
        }



        for (int i = 0; i < chemin.Count - 1; i++)
        {
            //Pour afficher le chemin
            Debug.DrawLine(new Vector3(chemin[i].x - decalageX, chemin[i].y - decalageY) * 30f + Vector3.one * 20f, new Vector3(chemin[i + 1].x - decalageX, chemin[i + 1].y - decalageY) * 30f + Vector3.one * 20f, Color.green, 50f);

        }
        cible = new Vector3((chemin[1].x - chemin[0].x) * 30f + positionDeDepartX, (chemin[1].y - chemin[0].y) * 30f + positionDeDepartY);
       // Debug.Log(cible);

    }

    private void Update()
    {
       // if (transform.position.x <= 783 || transform.position.y <= -52)
        //{
            if (tourner == 0)
            {
                double distance = Math.Sqrt(Math.Pow(transform.position.x - cible.x, 2) + Math.Pow(transform.position.y - cible.y, 2));
               

                if (distance < 100 )
                {
                    Vector3 vecteur1 = new Vector3((cible.x - transform.position.x), (cible.y - transform.position.y));
                    //Vector3 vecteur1 = new Vector3(cible.x - (cible.x - ((chemin[j + 1].x - chemin[j].x) * 30f)), cible.y - (cible.y - ((chemin[j + 1].y - chemin[j].y) * 30f)));
                    Vector3 vecteur2 = transform.up;

                    angle = Math.Round((Vector3.AngleBetween(vecteur1, vecteur2)) * (180 / Math.PI), 0);
                   // Debug.Log(angle);
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
                            if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x &&  vecteur1.x < 0)
                            {
                                direction = direction * -1;
                            }
                            else if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x && vecteur1.y < 0 && vecteur1.x > 0)
                            {
                            //Debug.Log("allo");
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
                            if (vecteur1.y / vecteur1.x < vecteur2.y / vecteur2.x)
                            {
                                direction = direction * -1;
                            }
                            else if (vecteur1.y / vecteur1.x > 0 && vecteur1.y > 0)
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
                    else if (transform.eulerAngles.z == 90)
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
                    else { tourner = 1;}

                }
            }

            if (transform.position.x >= cible.x - 30 && transform.position.y >= cible.y - 30 && transform.position.x <= cible.x + 30 && transform.position.y <= cible.y + 30 /*&& angle < 1f && angle > -1f*/)
            {
             if(vitesse < 400)
            {
                vitesse += 120;
            }

                cible = new Vector3((chemin[j + 1].x - chemin[j].x) * 30f + cible.x, (chemin[j + 1].y - chemin[j].y) * 30f + cible.y);
                //Debug.Log("Cible: " + cible);
                // vitesse = 220f;

                j++;
                tourner = 0;
            }
        //}
    }
    private void FixedUpdate()
    {
        if (0 < Time.time)
        {
           // if (transform.position.x <= 783 || transform.position.y <= -52)
           // {
                rb.AddForce(transform.up * vitesse);
           // }
        }
    }


}
