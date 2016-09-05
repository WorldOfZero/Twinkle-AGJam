using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

public class WorldService {

    private readonly string host = @"http://twinkleserver20160904025814.azurewebsites.net/api/";
    private readonly string path = @"world";

    public WorldService()
    {

    }

    public IEnumerable<GameWorldData> Get(int resultNumber = 50)
    {
        HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}{1}", host, path)));
        var response = request.GetResponse();
        var stream = response.GetResponseStream();
        using (var reader = new StreamReader(stream))
        {
            string jsonResults = reader.ReadToEnd();
            return JsonUtility.FromJson<GameWorldsCollection>(jsonResults).Worlds;
        }
    }

    public void Post(GameWorldData world)
    {
        HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}{1}", host, path)));
        request.ContentType = "application/json";
        request.Method = "POST";
        var bodyStream = request.GetRequestStream();
        using (var writer = new StreamWriter(bodyStream))
        {
            var serializedWorld = JsonUtility.ToJson(world);
            writer.Write(serializedWorld);
        }
    }
}
