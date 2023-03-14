using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    //allow a game object and a game controlled to be passed in
    [SerializeField] private GameObject cardBack;
    [SerializeField] private GameController gameController;
    //create in
	private int _spriteId;
    
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on mouse click
	public void OnMouseDown()
	{
        //check if the card is active and back be picked
        if (cardBack.activeSelf && gameController.canPick)
        {
            //remove the card back
            cardBack.SetActive(false);
            //call image picked function
            gameController.imagePicked(this);
        } 
	}

    //get sprite id
	public int spriteId
    {
        get { return _spriteId; }
    }

    //change the sprites to diffrent one
    public void SwapSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent < SpriteRenderer>().sprite = image;
    }

    //put the card back to its original spot
    public void Close()
    {
        //make cardback come back
        cardBack.SetActive(true); 
    }

}
