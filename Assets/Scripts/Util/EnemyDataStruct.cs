public enum EnemyType {
    Normal = 0,
    Helmet,
    Underwear
}
public class EnemyData
{
    public float distance;
    public EnemyType type;

    public EnemyData( EnemyType ptype,float pdistance)
    {
        distance = pdistance;
        type = ptype;
    }
}