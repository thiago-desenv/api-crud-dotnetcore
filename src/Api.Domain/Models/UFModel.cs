namespace Api.Domain.Models
{
    public class UFModel : BaseModel
    {
        private string _uf;
        public string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }


    }
}
