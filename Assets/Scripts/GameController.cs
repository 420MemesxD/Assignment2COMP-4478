using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //initalize varriables
    public const int col = 4;
	public const int row = 4;
    public const float xSpace = 5f;
    public const float ySpace = -2.4f;

	private MainImageScript firstPick;
	private MainImageScript secondPick;

    //pass in a script and a image
	[SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    //function to randomize the location of the cards
    private int[] Randomiser(int[] locations)
    {
        //initilize array
        int[] array = locations.Clone() as int[];
        //fir loop to fun aslong as the array length
        for(int i = 0; i < array.Length; i++)
        {
            //initalize a new array and put in array values
            int newArray = array[i];
            //create int to get random int
            int w = Random.Range(i, array.Length);
            //use random int to randomize the array
            array[i] = array[w];
            //put random array into newArray
            array[w] = newArray;
        }
        return array;
    }

	// Start is called before the first frame update
	private void Start()
    {
        //give locations 8 spots
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        //randomize the spots
        locations = Randomiser(locations);

        //get the start position
        Vector3 startPosition = startObject.transform.position;

        //nested for loop 
        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                //image varrible
                MainImageScript image;
                //if i = 0 and j = 0
                if(i == 0 && j == 0)
                {
                    //set image to startObject
                    image = startObject;
                }
                else
                {
                    //set image to startObject
                    image = Instantiate(startObject) as MainImageScript;
                }
                //init index
                int index = j * col + i;
                //init id = locations at the index
                int id = locations[index];
                //set the sprites
                image.SwapSprite(id, images[id]);

                //put them at the given locations
                float positionX = (xSpace * i) + startPosition.x;
                float positionY = (ySpace * j) + startPosition.y;
                image.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to return a boolean
    public bool canPick
    {

        //check if it is the second pick or not
		get { return secondPick == null; }
    }

    //check if the image has been picked
    public void imagePicked(MainImageScript startObject)
    {
        //if firstpick = null
        if(firstPick == null)
        {
            //set firstPick to startObject
            firstPick = startObject;
        }
        else
        {
            //set secondPick to start object
            secondPick = startObject;
            //call check pick function
            StartCoroutine(CheckPick());
        }
    }

    //check pick function
    private IEnumerator CheckPick()
    {
        //if the sprites match
        if(firstPick.spriteId == secondPick.spriteId)
        {

        }
        else
        {
            //wait for half a second
            yield return new WaitForSeconds(0.5f);

            //bring the card backs of the slelected cards back
            firstPick.Close();
            secondPick.Close();
        }
        //set first and second pick to null
        firstPick = null;
        secondPick = null;
    }

    //restart function to restart game
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
