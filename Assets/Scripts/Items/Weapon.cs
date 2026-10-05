using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private string _weaponType;

    public override void UseItemOn(Item heldItem)
    {
        Debug.Log("You tried to use " + heldItem.Name + " on the weapon, " + Name + "!");

        if (heldItem == this)
        {
            Debug.Log("You put the " + Name + " down.");

            //set materials back
            MaterialSwapper swapper = GetComponent<MaterialSwapper>();
            swapper?.RevertMaterials();

            PlayerHand.Instance.RemoveItemInHand();

            //change hand state
            InteractionStateMachine.Instance.ChangeToState(InteractionStateMachine.Instance.grabState);
        }

    }
    
    public override void PickupItem()
    {
        Debug.Log("You tried to grab the weapon, " + Name + ", which is a " + _weaponType + ".");

        //put into player hand
        PlayerHand.Instance.PutItemInHand(this);

        //change hand state
        InteractionStateMachine.Instance.ChangeToState(InteractionStateMachine.Instance.holdingState);

        //change mesh to ghostly?
        MaterialSwapper swapper = GetComponent<MaterialSwapper>();
        swapper?.SwapMaterials();
    }

    public override void LookItem()
    {
        Debug.Log("You tried to look at the weapon, " + Name + "!");
    }

    public override Color GetGlowColor()
    {
        if (!IsEdgeWeapon())
        {
            string largestPrinciple = "";
            int largestPrincipleCount = 0;
            foreach (var pair in Principles)
            {
                if (pair.Key != "Edge" && pair.Value > largestPrincipleCount)
                {
                    largestPrinciple = pair.Key;
                    largestPrincipleCount = pair.Value;
                }
            }

            if (largestPrinciple == "")
            {
                return Color.white;
            }

            return PrinciplesColorDictionary.PrincipleColors[largestPrinciple];
        }
        else
        {
            string largestPrinciple = "";
            int largestPrincipleCount = 0;
            foreach (var pair in Principles)
            {
                if (pair.Value > largestPrincipleCount)
                {
                    largestPrinciple = pair.Key;
                    largestPrincipleCount = pair.Value;
                }
            }

            if (largestPrinciple == "")
            {
                return Color.white;
            }

            return PrinciplesColorDictionary.PrincipleColors[largestPrinciple];
        }
    }

    private bool IsEdgeWeapon()
    {
        return (_weaponType == "Sword");
    }
}
