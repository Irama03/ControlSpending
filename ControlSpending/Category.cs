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
        
        public override string ToString()
        {
            return $"{Name}, {Description}, {Color}, {Icon}";
        }
    }
}