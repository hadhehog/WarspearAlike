# WarspearAlike
Like I've already mentioned, it is an old-fashioned, or it would be better to say "retro" pixel RPG.
The main idea and fundamentals were brought by a Warspear.

Briefly, what is Warspear:
>Warspear Online is a mobile cross-platform massively multiplayer online role-playing game (MMORPG) by Russian studio AIGRIND LLC. It supports different mobile platforms: iOS, >Android, Windows Mobile, Symbian and Windows based PCs and laptops. First launch of the game was in 2008 and it was based on P2P model, in 2010 it was redesigned. 
>In March, 2011 an update called Legacy of Berengar was launched. The game became F2P

So, I decided to try and accomplish a 1 demo-level of a similar game. But before showing what we've got here, I would like to mention and to give my thanks to user ArMM1998 from opengameart.org, who has created such an amazing piece of artwork!
---
![Gameplay](https://github.com/hadhehog/WarspearAlike1/blob/master/WSA1/sho1.PNG)
---
![Gameplay](https://github.com/hadhehog/WarspearAlike1/blob/master/WSA1/sho2.PNG)
---
![Gameplay](https://github.com/hadhehog/WarspearAlike1/blob/master/WSA1/sho6.PNG)

# Controls and features

In this game we can move our character by WASD, as well as ARROWS. 
Attacking and interactiong with subjects like Signs, Chests, NPC are all going through Space, but we also can use key "M", 
that grants us ability to shoot enemies with arrows, but under one condition, only if you have energy in a Mana-scale.

In game you can collect such items like:
 - keys
 - potions
 - hearts (that grant you bonus HP)
 - coins
 - chests

Also you can fight evil tree plants, in other words Logs.

And of course you can recieve greeting from an AI, well... if you will be able to meet him a little bit closer.

**Explore the Location, fight Monsters and give yourself a try to find Five Coins as soon as Possible!**

# About Code

As for the code, I've mainly consolidated knowledge about the State Machine. That's why I entirely agree, that this project turned out quite beneficiary for me,
but to my mind, there is nothing special about the State Machine itself. 
**Though, I've come up with a really nice piece of code for "The smoothest camera I've ever seen"** 
  
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}
```
