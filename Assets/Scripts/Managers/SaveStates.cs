using UnityEngine;

public class SaveStates : MonoBehaviour
{
    public static SaveStates SaveThis;

    void Awake()
    {
        //needed to initiate this class
        if (!SaveThis) { SaveThis = this; }
    }


    protected int GravesPunched;




    //GravesPunched
    public int SetGravesPunched(int NumberPunched) { return GravesPunched; }
    public int GetGravesPunched() { return GravesPunched; }




}
