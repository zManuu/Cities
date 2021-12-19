using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Ingame : MonoBehaviour
{

    [Serializable]
    public class CityDetails
    {
        public string CityName;
        public RoadSegments[] RoadSegments;



        /// <returns>A JSON string containing all the relavent information.</returns>
        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    [Serializable]
    public class RoadSegments
    {
        public int X;
        public int Y;
        public int Type;

        public RoadSegments(int x, int y, int type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }








    [SerializeField] private SpriteRenderer[] RoadTextures;
    [SerializeField] private Transform RoadParent;


    private void Start()
    {
        string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cities";
        string filePath = dirPath + "\\world.citysave";

        if (!Directory.Exists(dirPath))
        {
            print("DATA DIR NOT FOUND; CREATING THE DIR...");
            Directory.CreateDirectory(dirPath);
        }

        if (!File.Exists(filePath))
        {
            print("CITY SAVE FILE NOT FOUND; CREATING EXAMPLE FILE...");
            File.Create(filePath).Close();

            CityDetails exampleCityDetails = new CityDetails() {
                CityName = "TEST",
                RoadSegments = new RoadSegments[]
                {
                    new RoadSegments(1, 1, 0),
                    new RoadSegments(1, 2, 0),
                    new RoadSegments(3, 2, 0)
                }
            };

            File.WriteAllText(filePath, exampleCityDetails.ToString());
        }

        CityDetails cityDetails = JsonUtility.FromJson<CityDetails>(File.ReadAllText(filePath));
        cityDetails.RoadSegments.ToList().ForEach(segment =>
        {
            SpriteRenderer sprite = Instantiate(RoadTextures[segment.Type], RoadParent);
            sprite.transform.position = new Vector2(segment.X, segment.Y);
        });
        
    }
}
