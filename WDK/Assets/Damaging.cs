using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Damaging
{
    float GetDamage(); 
    string GetDamagingEffect(); // TODO maybe add effects (fire, slow, poison)
}

