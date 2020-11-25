using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour {

    public List<Kingdom> kingdoms = new List<Kingdom>();

    [Space] [Header("Public References")] 
    public GameObject kingdomPointPrefab;
    public GameObject kingdomButtonPrefab;
    public Transform modelTransform;
    public Transform kingdomButtonsContainer;

    [Space]

    [Header("Tween Settings")]
    public float lookDuration;
    public Ease lookEase;

    [Space]
    public Vector2 visualOffset;

    private int _sceneIndexOffset = 3;

	void Start (){
        for (int index = 0; index < kingdoms.Count; index++){
            Kingdom k = kingdoms[index];
            SpawnKingdomPoint(k,index);
        }

        if (kingdoms.Count > 0)
        {
            LookAtKingdom(kingdoms[0]);
            EventSystem.current.SetSelectedGameObject(kingdomButtonsContainer.GetChild(0).gameObject);
        }
    }

    private void SpawnKingdomPoint(Kingdom k,int index)
    {
        if(k.isLocked)
            return;
        GameObject kingdom = Instantiate(kingdomPointPrefab, modelTransform);
        kingdom.transform.localEulerAngles = new Vector3(k.y + visualOffset.y, -k.x - visualOffset.x, 0);
        k.visualPoint = kingdom.transform.GetChild(0);

        SpawnKingdomButton(k,index);
    }

    private void SpawnKingdomButton(Kingdom k,int index)
    {
        Kingdom kingdom = k;
        Button kingdomButton = Instantiate(kingdomButtonPrefab, kingdomButtonsContainer).GetComponent<Button>();
        kingdomButton.GetComponent<WorldSelectButton>().sceneToLoad = (SceneIndex) (index + _sceneIndexOffset);
        kingdomButton.onClick.AddListener(() => LookAtKingdom(kingdom));

        kingdomButton.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = k.name;
    }

    public void LookAtKingdom(Kingdom k)
    {
        Transform cameraParent = Camera.main.transform.parent;
        Transform cameraPivot = cameraParent.parent;

        cameraParent.DOLocalRotate(new Vector3(k.y, 0, 0), lookDuration, RotateMode.Fast).SetEase(lookEase);
        cameraPivot.DOLocalRotate(new Vector3(0,-k.x, 0), lookDuration, RotateMode.Fast).SetEase(lookEase);

        FindObjectOfType<FollowTarget>().target = k.visualPoint;
    }



    void Update () {
        if (EventSystem.current.currentSelectedGameObject == null){
            LookAtKingdom(kingdoms[0]);
            EventSystem.current.SetSelectedGameObject(kingdomButtonsContainer.GetChild(0).gameObject);
        }

    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;

        //only draw if there is at least one stage
        if (kingdoms.Count > 0)
        {
            for (int i = 0; i < kingdoms.Count; i++)
            {
                //creat two empty objects
                GameObject point = new GameObject();
                GameObject parent = new GameObject();
                //move the point object to the front of the world sphere
                point.transform.position += - new Vector3(0,0,.5f);
                //parent the point to the "parent" object in the center
                point.transform.parent = parent.transform;
                //set the visual offset
                parent.transform.eulerAngles = new Vector3(visualOffset.y, -visualOffset.x, 0);

                if (!Application.isPlaying)
                {
                    Gizmos.DrawWireSphere(point.transform.position, 0.02f);
                }

                //spint the parent object based on the stage coordinates
                parent.transform.eulerAngles += new Vector3(kingdoms[i].y, -kingdoms[i].x, 0);
                //draw a gizmo sphere // handle label in the point object's position
                Gizmos.DrawSphere(point.transform.position, 0.07f);
                //destroy all
                DestroyImmediate(point);
                DestroyImmediate(parent);
            }
        }
#endif
    }
    
    public void LoadMainMenu(){
        Loader.Load(SceneIndex.MAIN_MENU);
    }
}

[System.Serializable]
public class Kingdom
{
    public string name;

    [Range(-180,180)]
    public float x;
    [Range (-89,89)]
    public float y;

    [HideInInspector]
    public Transform visualPoint;

    public bool isLocked = true;
}
