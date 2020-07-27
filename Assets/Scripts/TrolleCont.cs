using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleCont : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _Trolley;
    [SerializeField] private GameObject _Camera;
    [SerializeField]  TextMesh Text;
    private float _coefficient = 0;
    [SerializeField] private float _friction = 0.01f;
    private bool TapOn;
    private bool Stap = true;
  
    void Update()
    {
        

        transform.position= transform.position + new Vector3(0,0, _speed * Time.deltaTime);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        _speed -= _friction;
        if (_speed < 0)
        {
            _speed = 0;
        }// Чтобы дризина не катилась назад

        #region TrolleyMoveFirstStap

        if (Stap == true)
        {
            _coefficient += 1 * Time.deltaTime;
            Text.text = $"{ _coefficient}";
            if (Input.GetMouseButtonDown(0))
            {
                if (_coefficient <= 0)
                {
                    _speed -= 2;
                    _coefficient = 0;
                }


                if (_coefficient >= 0.5f && _coefficient < 1)
                {
                    _speed += 4;
                    _coefficient = 0;
                }

                if (_coefficient >= 1 && _coefficient < 1.5f)
                {
                    _speed += 8;
                    _coefficient = 0;
                }

                if (_coefficient >= 1.5f && _coefficient < 3)
                {
                    _speed += 12;
                    _coefficient = 0;
                }
                if (_coefficient >= 3)
                {
                    _speed += 24;
                    _coefficient = 0;
                }
                if (_coefficient <= 3 && _coefficient <= 1000)
                {
                    _speed -= 5;
                    _coefficient = 0;
                }
            }//Ускорение на нажатия            
        }
        #endregion

        #region TrolleyMoveSecondStap;
        else
        {
           
                Vector3 Cursor = Input.mousePosition;
                Cursor = Camera.main.ScreenToViewportPoint(Cursor);
                Cursor.y = 0;
                Cursor.z = 0;
                transform.position += Cursor;
            
        }
        #endregion

       

       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SecondPalne")
        {
            _Camera.GetComponent<Animator>().enabled = true;
            Stap = false;
           
        }


    }
     
}
