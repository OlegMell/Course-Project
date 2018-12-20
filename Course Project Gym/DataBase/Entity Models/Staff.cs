namespace Course_Project_Gym.DataBase
{
    public class Staff
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public float WorkExperience { get; set; }
        virtual public Position Position { get; set; }
        virtual public Accounts Account { get; set; }
        virtual public Complex Complex { get; set; }
        virtual public Images ProfileImg { get; set; }
    }
}
