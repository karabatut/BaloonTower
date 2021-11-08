using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonCreator : MonoBehaviour
{
    public GameObject baloonPrefab;
    GameObject baloonObject;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //En ba�ta beklemeden bir balon yarat�r.
        createBaloon();
    }

    // Update is called once per frame
    void Update()
    {
        //��er saniye aral�klarla yeni bir balon yarat�l�r.
        if(timer > 3f)
        {
            createBaloon();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void createBaloon()
    {
        //Yeni balon yarat�l�r ve parent olarak BaloonCreator objesi verilir.
        //Balon yarat�l�rken pozisyonuna ufak bir rastgelelik koymak gerekti ��nk�
        //balonlar�n �ekli tam k�re oldu�u i�in alt alta dizilip tak�l�yorlard�.
        baloonObject = Instantiate(baloonPrefab, this.transform.position 
            + new Vector3(Random.Range(0f,0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)), Quaternion.identity);
        baloonObject.transform.parent = this.transform;
    }

}
