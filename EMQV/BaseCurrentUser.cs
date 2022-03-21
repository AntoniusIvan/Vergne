namespace EMQV
{
    public class BaseCurrentUser
    {
        protected string oid;
        protected string username;
        protected string password;
        protected string passwordHash;
        protected string fullName;
        protected bool isAdministrator;
        protected string type;
        protected string role;
        protected Dictionary<string, string> roleDetail;

        public event EventHandler OpenChangePassword;

        public virtual void ChangePassword(string password)
        {
            throw new NotImplementedException();
        }
        public virtual bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            this.oid = null;
            this.username = null;
            this.passwordHash = null;
            this.fullName = null;
            this.isAdministrator = false;
            this.roleDetail = null;
            this.type = null;
        }


        protected void OnOpenChangePassword()
        {
            if (this.OpenChangePassword != null)
            {
                this.OpenChangePassword(this, EventArgs.Empty);
            }
        }

        public string Oid
        {
            get
            {
                return this.oid;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        public bool IsAdministrator
        {
            get
            {
                return this.isAdministrator;
            }
        }

        public Dictionary<string, string> RoleDetail
        {
            get
            {
                return this.roleDetail;
            }
        }

        public bool IsLogged
        {
            get
            {
                return !string.IsNullOrEmpty(this.oid);
            }
        }
    }
}