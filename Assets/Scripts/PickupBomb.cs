using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBomb : Pickup {
    public override void Action() {
        Player.instance.ChangeBombAmount(1);
    }
}
