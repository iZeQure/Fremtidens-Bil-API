namespace Fremtidens_Bil_API.Objects
{
    public abstract class BaseEntity
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
