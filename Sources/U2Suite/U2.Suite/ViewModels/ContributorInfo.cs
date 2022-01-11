namespace U2.Suite
{
    public sealed class ContributorInfo
    {
        public ContributorInfo(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public string Name { get; set; }
        public string Role { get; set; }
    }
}