using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF3028.Models
{
    public class Person
    {
        public Person(string name, DateTime birthday, Color favoriteColor)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.FavoriteColor = favoriteColor;
        }

        public string Name { private set; get; }

        public DateTime Birthday { private set; get; }

        public Color FavoriteColor { private set; get; }
    };
}
