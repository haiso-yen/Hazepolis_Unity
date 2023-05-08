using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatSanityModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        //Sanity sanity = character.GetComponent<Sanity>();
       // if (sanity != null)
       //     sanity.AddSanity((int)val);
    }
}
