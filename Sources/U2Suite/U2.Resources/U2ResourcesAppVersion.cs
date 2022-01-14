namespace U2.Resources
{
    public sealed class U2ResourcesAppVersion
    {
        public string GetAssemblyVersion()
        {
            return this.GetType().Assembly.GetName().Version.ToString();
        }
    }
}
