using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpriteSwapDemo : MonoBehaviour
{
    // The name of the sprite sheet to use

    // The name of the currently loaded sprite sheet
    private string loadedSpriteSheetName;
    private string[] maleSkins={"Male1", "Male2" , "Male3" };
    private string[] femaleSkins = {"Female1", "Female2", "Female3" };
    private string[] selectedSkins;
    private int selectedSkinsInt=2;

    // The dictionary containing all the sliced up sprites in the sprite sheet
    private Dictionary<string, Sprite> spriteSheet;

    // The Unity sprite renderer so that we don't have to get it multiple times
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Start()
    {
        // Get and cache the sprite renderer for this game object
        this.spriteRenderer = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>();
        selectedSkins = maleSkins;
        LoadSpriteSheet();
    }

    private void LateUpdate()
    {

        // Swap out the sprite to be rendered by its name
        // Important: The name of the sprite must be the same!
        this.spriteRenderer.sprite = this.spriteSheet[this.spriteRenderer.sprite.name];
    }
    // Loads the sprites from a sprite sheet
    public void LoadSpriteSheet()
    {
        // Load the sprites from a sprite sheet file (png). 
        // Note: The file specified must exist in a folder named Resources
        var sprites = Resources.LoadAll<Sprite>(selectedSkins[selectedSkinsInt]);
        this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);

        // Remember the name of the sprite sheet in case it is changed later
        this.loadedSpriteSheetName = selectedSkins[selectedSkinsInt];
    }
    /// <summary>
    /// Функция меняет тело персонажа в зависимости от указаного номера
    /// </summary>
    /// <param name="num">Номер скина</param>
   public void clickOnSkinSelect(int skin)
    {
        selectedSkinsInt += skin;
        if (selectedSkinsInt > maleSkins.Length-1) selectedSkinsInt = 0;
        else if (selectedSkinsInt < 0) selectedSkinsInt = maleSkins.Length - 1;
        Debug.Log(selectedSkinsInt);
        LoadSpriteSheet();
    }
    public void clickOnGender(bool gender)
    {
        if (gender)
            selectedSkins = maleSkins;
        else
            selectedSkins = femaleSkins;
        LoadSpriteSheet();
    }
}
