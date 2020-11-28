using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SpriteSwapDemo : MonoBehaviour
{
    // The name of the sprite sheet to use

    // The name of the currently loaded sprite sheet
    private string loadedSpriteSheetName;
    private string loadedArmorSpriteSheetName;
    private string loadedHairSpriteSheetName;
    private string[] maleSkins={"Male1", "Male2" , "Male3" };
    private string[] femaleSkins = {"Female1", "Female2", "Female3" };
    private string[] selectedSkins;
    private string[] selectedArmorSkins;
    private string[] selectedHairSkins;
    private string[] armorSkins = { "Armor1", "Armor2", "Armor3" };
    private string[] femaleHairSkins = {"fhair1","fhair2","fhair3"};
    private string[] maleHairSkins = { "mhair1", "mhair2", "mhair3" };
    private int selectedArmorInt = 1;
    private int selectedSkinsInt = 2;
    private int selectedHairInt = 0;
    [SerializeField]
    private Slider mySlider;
    [SerializeField]
    private Image handle;
    // The dictionary containing all the sliced up sprites in the sprite sheet
    private Dictionary<string, Sprite> spriteSheet,armorSpriteSheet,hairSpriteSheet;

    // The Unity sprite renderer so that we don't have to get it multiple times
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteArmorRenderer;
    private SpriteRenderer spriteHairRenderer;

    // Use this for initialization
    private void Start()
    {
        // Get and cache the sprite renderer for this game object
        this.spriteRenderer = GameObject.Find("Body").GetComponentInChildren<SpriteRenderer>();
        this.spriteArmorRenderer = GameObject.Find("Armor").GetComponentInChildren<SpriteRenderer>();
        this.spriteHairRenderer = GameObject.Find("Hair").GetComponentInChildren<SpriteRenderer>();
        selectedSkins = maleSkins;
        selectedArmorSkins = armorSkins;
        selectedHairSkins = maleHairSkins;
        LoadSpriteSheet();
        mySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void LateUpdate()
    {

        // Swap out the sprite to be rendered by its name
        // Important: The name of the sprite must be the same!
        this.spriteRenderer.sprite = this.spriteSheet[this.spriteRenderer.sprite.name];
        this.spriteArmorRenderer.sprite = this.armorSpriteSheet[this.spriteArmorRenderer.sprite.name];
        this.spriteHairRenderer.sprite = this.hairSpriteSheet[this.spriteHairRenderer.sprite.name];
    }
    // Loads the sprites from a sprite sheet
    public void LoadSpriteSheet()
    {
        // Load the sprites from a sprite sheet file (png). 
        // Note: The file specified must exist in a folder named Resources
        var sprites = Resources.LoadAll<Sprite>(selectedSkins[selectedSkinsInt]);
        var armorSprites = Resources.LoadAll<Sprite>(selectedArmorSkins[selectedArmorInt]);
        var hairSprites = Resources.LoadAll<Sprite>(selectedHairSkins[selectedHairInt]);
        this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);
        this.armorSpriteSheet = armorSprites.ToDictionary(x => x.name, x => x);
        this.hairSpriteSheet = hairSprites.ToDictionary(x => x.name, x => x);

        // Remember the name of the sprite sheet in case it is changed later
        this.loadedSpriteSheetName = selectedSkins[selectedSkinsInt];
        this.loadedArmorSpriteSheetName = selectedArmorSkins[selectedArmorInt];
        this.loadedHairSpriteSheetName = selectedHairSkins[selectedHairInt];
    }
    /// <summary>
    /// Функция меняет тело персонажа в зависимости от указаного номера
    /// </summary>
    /// <param name="num">Номер скина</param>
   public void ClickOnSkinSelect(int skin)
    {
        selectedSkinsInt += skin;
        if (selectedSkinsInt > maleSkins.Length-1) selectedSkinsInt = 0;
        else if (selectedSkinsInt < 0) selectedSkinsInt = maleSkins.Length - 1;
        Debug.Log(selectedSkinsInt);
        LoadSpriteSheet();
    }
    public void ClickOnHairSelect(int hair)
    {
        selectedHairInt += hair;
        if (selectedHairInt > femaleHairSkins.Length - 1) selectedHairInt = 0;
        else if (selectedHairInt < 0) selectedHairInt = femaleHairSkins.Length - 1;
        LoadSpriteSheet();
    }
    public void ClickOnGender(bool gender)
    {
        if (gender)
        {
            selectedSkins = maleSkins;
            selectedHairSkins = maleHairSkins;
        }
        else
        {
            selectedSkins = femaleSkins;
            selectedHairSkins = femaleHairSkins;
        }
        LoadSpriteSheet();
    }
    public void ClickOnClass(int classInt)
    {
        selectedArmorInt = classInt;
        LoadSpriteSheet();
    }
    public void ValueChangeCheck()
    {
        handle.color = Color.HSVToRGB(mySlider.value, 1, 1);
        spriteHairRenderer.color = handle.color;
    }
}
