namespace NewCryptoApp.Core.GeneralModel
{
    public class ResourcesModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
