﻿using System;
using System.Collections.Generic;

namespace GameTans.Lec03_CmdGame
{
    public class Actor
    {
        public World world;
        public virtual int Type => 0;
        public Vector2 _pos;
        
        public Vector2 pos {
            get => _pos;
            set
            {
                value = world.GetValidPos(value);
                _pos = value;
            }
        }
        public int damage;
        public int health;
        public bool isHurt;

        private List<Component> components = new List<Component>();
        public void AddComponent(Component component)
        {
            components.Add(component);
            component.Bind(this);
            component.Awake();
        }
        public void Awake()
        {
            Debug.Log($"{GetType().Name} Awake");
        }
        public void Update()
        {

            Debug.Log($"\t {GetType().Name} Update");
            foreach (var item in components)
            {
                item.Update(Time.deltaTime);
            }
        }
        public override string ToString()
        {
            return $"pos {pos} h:{health} type:{(Type == 1 ?'M':'P')} isHurt:{isHurt}";
        }

    }

}
