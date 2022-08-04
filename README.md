# Simple Pooling

## Table Of Contents 
 
<details>
<summary>Details</summary>

  - [Introduction](#introduction)
  - [Features](#features)
  - [How to use](#how-to-use)
  - [Things To Keep In Mind](#things-to-keep-in-mind)
  - [Example](#example)
  - [Last Words](#last-words)
</details>

## Introduction
It's a light pooling library without any "SINGLETON"

    
## Features
 - Supports List, Stack, Queue and Array pools
 - Implements generic way of pooling, meaning there is no "SINGLETON" under the hood
 - Supports multiple pools
 - Holds pool data as SO (ScriptableObject) so that it is much more easier to change pool in the editor
 - Holds pools in the hierarchy nice and clean
 
 ## How To Use
 
 - In order to use SimplePooling, all you need to do is to create a "ISimplePool" object inside a class and initialize it with a "SimplePoolData" object as follows
 
```csharp 
    public class BulletFactory : MonoBehaviour  
    {
        public SimplePoolData poolData;

        private ISimplePool<Bullet> bulletPool;

        private void Awake()
        {
            // Array example
            bulletPool = new SimpleArrayPool<Bullet>(poolData);
            
            // List example
            bulletPool = new SimpleListPool<Bullet>(poolData);
            
            //Stack example
            bulletPool = new SimpleStackPool<Bullet>(poolData);
            
            //Queue example
            bulletPool = new SimpleQueuePool<Bullet>(poolData);
        }
    }
```

## Things To Keep In Mind
  - Pool types must inherit from MonoBehaviour
  - Each pool has to have a "SimplePoolData" which is a SO(Scriptable Object) to initialize

## Example
 - Go to "SimplePooling/Scenes/DemoScene" and hit play


## Last Words
 - As far as I can see, this is not one of the best pooling assets to use. But, I hate SINGLETON implementations of pooling so I decided to make one 
 without any singleton and came up with this.
 
 
 
 
 
 
 
 
