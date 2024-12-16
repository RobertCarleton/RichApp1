using Microsoft.AspNetCore.Identity;

namespace WebApp34.Data.Models
{
    public class ApplicationResult : IdentityResult
    {
        private List<IdentityError> _errors = new List<IdentityError>();

        public new IEnumerable<IdentityError> Errors => _errors;

        public ApplicationResult() { }

        public ApplicationResult(IdentityResult identityResult)
        {
            if (identityResult == null)
            {
                throw new ArgumentNullException(nameof(identityResult), "IdentityResult cannot be null");
            }

            this.Succeeded = identityResult.Succeeded;

            if (identityResult.Errors != null)
            {
                _errors.AddRange(identityResult.Errors.Select(e => new IdentityError
                {
                    Code = e.Code,
                    Description = e.Description
                }));
            }
        }

        public static ApplicationResult FromIdentityResult(IdentityResult identityResult)
        {
            if (identityResult == null)
            {
                throw new ArgumentNullException(nameof(identityResult), "IdentityResult cannot be null");
            }

            return new ApplicationResult(identityResult);
        }

        public void AddError(string code, string description)
        {
            _errors.Add(new IdentityError { Code = code, Description = description });
        }
    }



}
