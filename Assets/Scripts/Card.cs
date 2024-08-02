using UnityEngine;
[CreateAssetMenu(fileName = "NewCard", menuName = "Unit")]

// Card scriptable object to contain cards info
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public int cardCost;
    public GameObject unitPrefab;
    public enum PointType { Green, Blue, Red }
    public PointType pointType; // type of points to spend

    // Is card a unit that follow, unit/spell that spawn in world space, artifact to use or just effect
    public enum spawnPosition { Follow, Stand, Artifact, Effect} 
    public spawnPosition spawnType;
    public bool Move; // Move card dont discarded when used and they cant be in deck
    public bool Token; // token card dosent go to deck when played 
    public bool canBeReturned = false; // Some cards can be returned to deck when right button presed (better to make more )
    public bool isActive; // active cards cannon be used and stay in hand
    public string cardEffect;
}

