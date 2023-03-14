using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //allow a game controller and a string to be passed in
    [SerializeField] private GameController gameController;
    [SerializeField] private string functionOnClick;

    //if you mouse over the button it will be tinted blue
	public void OnMouseOver()
	{
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.blue;
        }
	}

    //on mouse down
	public void OnMouseDown()
	{
        //transform
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
	}

    //on mouse up
	public void OnMouseUp()
	{
		//transform
		transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        //if game controller is running
        if(gameController != null)
        {
            //send the text functionOnClick which is "Restart"
            gameController.SendMessage(functionOnClick);
        }
	}

    //when you unhover the button
    public void OnMouseExit() {
        //get the sprite
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        //if sprite is not null
        if(sprite != null)
        {
            //set colour to white
            sprite.color = Color.white;
        }
        
    }
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
