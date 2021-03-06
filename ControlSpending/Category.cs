﻿using System;
using System.IO;

namespace CSharp.ControlSpending
{
    // Class Category keeps the name, description, color and icon.
    public class Category : Entity
    {
        private string _name;
        private string _description;
        private string _color;
        private FileInfo _icon;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Name!");
                }
            } 
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; } 
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _color = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Color!");
                }
            }
        }

        public FileInfo Icon
        {
            get { return _icon; }
            set
            {
                if (value != null)
                {
                    _icon = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Icon!");
                }
            }
        }

        public Category() { }

        public Category(string name, string color, string iconPath)
        {
            _name = name;
            _color = color;
            _icon = new FileInfo(iconPath);
            if (!Validate())
            {
                throw new ArgumentException("Invalid argument in constructor of Category!");
            }
        }

        public override bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Color))
                result = false;
            if (Icon == null)
                result = false;

            return result;
        }

        public override string ToString()
        {
            if (Description != null)
            {
                return $"{Name}, {Description}, {Color}, {Icon.Name}";
            }
            else
            {
                return $"{Name}, {Color}, {Icon.Name}";
            }
        }
    }
}