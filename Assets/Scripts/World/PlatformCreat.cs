using System.Collections.Generic;
using UnityEngine;

public class PlatformCreat : MonoBehaviour
{
    public GameObject Player, Camera;
    public Platforms[] PlatformPrefabs;
    public Platforms FirstPlatform;

    private float time;

    private List<Platforms> spawnedPlatforms = new List<Platforms>();

    public delegate void SpawnPlat(int platforms);
    public static event SpawnPlat SpawnPlatdel;
    public delegate void CameraGoy(bool cam, Vector3 camVec);
    public static event CameraGoy CameraGoDel;
    public delegate void CameraPosic(Vector3 camVec);
    public static event CameraPosic CameraPosDel;
    void Start()
    {
        ConfigurableParameters.timeScale = 0.25f;
        Camera.transform.position = new Vector3(-0.1000004f, 0, -1);
        spawnedPlatforms.Add(FirstPlatform);
        time = 0;
        SpawnPlatdel += SpawnPlatform;
        CameraGoDel += CameraGo;
        CameraPosDel += CameraPos;
    }
    void Update()
    {
        if (!ConfigurableParameters.noCamGo)
        {
            if (ConfigurableParameters.ScaleTime)
                ConfigurableParameters.speedCamera = 1f;

            else
                ConfigurableParameters.speedCamera = 2f;
        }
        else
        {
            ConfigurableParameters.speedCamera = 0f;
        }
        if (Player.transform.position.x > Camera.transform.position.x + 5f)
        {
            CameraPos(Vector3.MoveTowards(new Vector3(Camera.transform.position.x, Camera.transform.position.y, -1), new Vector3(Player.transform.position.x - 2, Camera.transform.position.y, -1), 20 * Time.deltaTime));
        }
        if (Player.transform.position.x > spawnedPlatforms[spawnedPlatforms.Count - 1].End.position.x - 15)
        {
            SpawnPlatform(5);
        }
        CameraGo(ConfigurableParameters.play, new Vector3(Camera.transform.position.x + ConfigurableParameters.speedCamera * Time.deltaTime, Camera.transform.position.y, Camera.transform.position.z));
    }
    private void SpawnPlatform(int value)
    {
        if (SpawnPlatdel != null)
        {
            Platforms newPlatform = Instantiate(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)]);
            newPlatform.transform.position = spawnedPlatforms[spawnedPlatforms.Count - 1].End.position - newPlatform.Begind.localPosition;
            spawnedPlatforms.Add(newPlatform);
            if (spawnedPlatforms.Count >= value)
            {
                Destroy(spawnedPlatforms[0].gameObject);
                spawnedPlatforms.RemoveAt(0);
            }
        }
    }
    private void CameraPos(Vector3 posCam)
    {
        if (CameraPosDel != null)
            Camera.transform.position = posCam;
    }
    public void CameraGo(bool pla, Vector3 CamVec)
    {
        if (CameraGoDel != null)
        {
            if (pla)
            {
                time += 0.5f * Time.deltaTime;
                if (time >= 10)
                {
                    Time.timeScale += ConfigurableParameters.timeScale;
                    PlayerPrefs.SetFloat("timeSkale", Time.timeScale);
                    PlayerPrefs.Save();
                    time = 0;
                }
                Camera.transform.position = CamVec;
            }
        }
    }
    private void OnDisable()
    {
        SpawnPlatdel -= SpawnPlatform;
        CameraGoDel -= CameraGo;
        CameraPosDel -= CameraPos;
    }
}
