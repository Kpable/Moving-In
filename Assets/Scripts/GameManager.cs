﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public ApartmentObject[] gifts;
    int giftIndex;
    public Transform dropOffPoint;
    public GameObject giftPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine("DropOffGift");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DropOffGift()
    {
        GameObject gift = Instantiate(giftPrefab, dropOffPoint.position, Quaternion.identity);
        //gift.transform.localScale = new Vector3(gifts[giftIndex].width, 1, gifts[giftIndex].length);
        var giftProperties = gift.GetComponent<PlaceableObject>();
        giftProperties.Properties = gifts[giftIndex];
        giftIndex++;
        if (giftIndex < gifts.Length)
        {
            yield return new WaitForSeconds(3);
            StartCoroutine("DropOffGift");
        }
    }
}

[System.Serializable]
public class ApartmentObject
{
    public string Name;
    //public ApartmentObjectType type;
    public PlacableOn[] placeables;
    public int width;
    public int length;
    public Vector2 Size { get { return new Vector2(width, length); } }
    public GameObject prefab;
}

public enum PlacableOn { Floor, Furniture, Wall, Shelf }
