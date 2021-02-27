namespace ControlSpending
{
    //Категорія складається з назви, опису, кольору та іконки
    public class Category
    {
        private string _name;
        private string _description;
        private string _color;
        private string _icon;

        public string Name
        {
            get { return _name; } 
            set { _name = value; } 
        }

        public string Description
        {
            get { return _description; } 
            set { _description = value; } 
        }

        public string Color
        {
            get { return _color; } 
            set { _color = value; }
        }

        public string Icon
        {
            get { return _icon; } 
            set { _icon = value; }
        }

        public Category() { }

        public Category(string name, string description, string color, string icon)
        {
            _name = name;
            _description = description;
            _color = color;
            _icon = icon;
        }
        
        public override string ToString()
        {
            return $"{Name}, {Description}, {Color}, {Icon}";
        }
    }
}