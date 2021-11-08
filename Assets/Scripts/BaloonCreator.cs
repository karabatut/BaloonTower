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
        //En baþta beklemeden bir balon yaratýr.
        createBaloon();
    }

    // Update is called once per frame
    void Update()
    {
        //Üçer saniye aralýklarla yeni bir balon yaratýlýr.
        if(timer > 3f)
        {
            createBaloon();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void createBaloon()
    {
        //Yeni balon yaratýlýr ve parent olarak BaloonCreator objesi verilir.
        //Balon yaratýlýrken pozisyonuna ufak bir rastgelelik koymak gerekti çünkü
        //balonlarýn þekli tam küre olduðu için alt alta dizilip takýlýyorlardý.
        baloonObject = Instantiate(baloonPrefab, this.transform.position 
            + new Vector3(Random.Range(0f,0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)), Quaternion.identity);
        baloonObject.transform.parent = this.transform;
    }

}
