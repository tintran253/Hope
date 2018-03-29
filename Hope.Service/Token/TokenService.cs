using Hope.Core;
using System.Linq;

namespace Hope.Services
{
    public class TokenService : ITokenService
    {
        private readonly IRepository<Token> _tokenRepository;

        public TokenService(IRepository<Token> tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public Token GetByToken(string accessToken)
        {
            var q = from t in this._tokenRepository.Table
                    where t.AccessToken == accessToken
                    select t;
            return q.FirstOrDefault();
        }
    }
}
