using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "Christophe" || password != "WCFRocks!")
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown username or incorrect password");
            }
        }
    }
}
