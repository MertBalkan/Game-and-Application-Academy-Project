using UnityEngine;

public class lego2 : MonoBehaviour
{
    public float zamanYavaslatKatSayisi;
    public float zamanYavaslatmaSuresi;
    public bool girdimi;
    public LayerMask player;
    public float sightrange;
    public bool playerInsightRange;
    private void Update()
    {
        Time.timeScale += (1f / zamanYavaslatmaSuresi) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
       
        playerInsightRange = Physics.CheckSphere(transform.position, sightrange, player);
        if (playerInsightRange)
        {
            durdur();
        }
    }
    void durdur()
    {
        if (!girdimi)
        {

            Time.timeScale = zamanYavaslatKatSayisi;
            Time.fixedDeltaTime = Time.timeScale * 0.2f;
            
        }
        resetleme();
        girdimi = true;//kaldirirsak her girdiginde bu olay olacak true dersek tek seferlik calisir arkaplanda nolur bilemem

    }
    private void resetleme()
    {
        girdimi = false;
    }
}
