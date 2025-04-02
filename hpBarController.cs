using UnityEngine;

public class hpBarController : MonoBehaviour
{
    // this.gameobject is the gameobject associated with the red hp bar
    public bool isPlayer;

    private Inhabitant theInhabitant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (this.isPlayer)
        {
            this.theInhabitant = Core.thePlayer;
            print("********** SET THE PLAYER" + this.theInhabitant.getName());
        }
        else
        {
            this.theInhabitant = Core.theMonster;
            //error here!!!
            print("********** SET THE MONSTER" + this.theInhabitant.getName());

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(this.theInhabitant != null)
        {
            print(this.theInhabitant.getName());
            float hpPercent = (float)this.theInhabitant.getCurrHp() / (float)this.theInhabitant.getMaxHp();
            this.gameObject.transform.localScale = new Vector3(hpPercent,
                                                this.gameObject.transform.localScale.y,
                                                this.gameObject.transform.localScale.z);
        }
        
    }
}
