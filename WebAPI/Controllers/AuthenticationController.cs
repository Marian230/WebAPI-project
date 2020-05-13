using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        private MyContext Context = new MyContext();

        private const string secret = "6oX1xyimndzdANpHNe7KJAX";

        [HttpGet]
        [Route("create/")]
        public virtual object Create(string email, string password)
        {
            Dictionary<string, object> payload;
            bool isAdmin = false;

            if (this.Context.Admins.Any
            (
                admin => admin.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                         && admin.Password == password
            ))
                isAdmin = true;

            else if (this.Context.Clients.Any
            (
                    client => client.MAC.Equals(email, StringComparison.OrdinalIgnoreCase)
                       && password == null
            ))
                isAdmin = false;
            else
                return Unauthorized();

            payload = new Dictionary<string, object>()
            {
                { "email", email },
                { "creation", DateTime.Now },
                { "expiration", DateTime.Now.AddMinutes(1) },
                { "admin", isAdmin }
            };

            IJwtEncoder encoder = new JwtEncoder(
                new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());

            var token = encoder.Encode(payload, AuthenticationController.secret);

            return token;
        }

        public void Delete()
        {

        }

        public void Get()
        {
            
        }

        [HttpGet]
        [Route("test/")]
        public static bool CheckToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IJwtValidator validator = new JwtValidator(serializer, new UtcDateTimeProvider());
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, new JwtBase64UrlEncoder(), new HMACSHA256Algorithm());

                var json = decoder.Decode(token, AuthenticationController.secret, verify: true);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            /*catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return "Token has invalid signature";
            }*/
        }
    }
}