using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chhester : MonoBehaviour
{
    private float movimientoFuerza = 12f;

    private Rigidbody2D miCuerpoRigido;
    private bool seMovioDerecha = false;
    private bool seMovioIzquierda = false;    
    // Start is called before the first frame update
    void Start()
    {
        miCuerpoRigido =GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal"); //esta variable puede ser -1, 0 o 1
        Vector2 posicionJug = transform.position;

        if (movementX > 0 && !seMovioDerecha)
        {
            // Mover a la derecha
            posicionJug.x += movimientoFuerza * Time.deltaTime*250;
            seMovioDerecha = true;
            seMovioIzquierda = false;
        }
        else if (movementX < 0 && !seMovioIzquierda)
        {
            // Mover a la izquierda
            posicionJug.x -= movimientoFuerza * Time.deltaTime*250;
            seMovioIzquierda = true;
            seMovioDerecha = false;
        }
        transform.position = posicionJug;
    }
}

