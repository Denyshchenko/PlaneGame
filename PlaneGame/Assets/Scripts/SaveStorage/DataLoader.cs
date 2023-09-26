using UnityEngine;


public class DataLoader : MonoBehaviour
{
    public Score Score;



    private void Update()
    {
     

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
            Debug.Log("DataIsSaved");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LoadData();
        }
    }


    public void SaveData()
    {
        SaveSystem.SaveData(this);
      
    }

    public void LoadData()
    {
        GameData data = SaveSystem.LoadData();

        Score.MaxScore = data.Score;
    }
    
}
