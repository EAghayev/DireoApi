using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Direo.Data;
using Direo.Models;
using Direo.Helpers;
using CryptoHelper;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Direo.Controllers.V1
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DireoContext _context;

        public User logged;

        public UsersController(DireoContext context)
        {
            _context = context;
        }

        /*Get All Users*/
        [Route("GetUsers")]
        public object Get()
        {
            return _context.Users.Where(s => s.Status == 0);
        }

        /*Get All Users with basic data*/
        [Route("GetUsersBasic")]
        public object GetBasic()
        {
            return _context.Users.Where(s => s.Status == 0).Select(u => new
            {
                u.Id,
                u.Fullname,
                u.Email,
                u.About,
                u.Gender,
                Profile = string.IsNullOrEmpty(u.Profile) ? null : $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/uploads/{u.Profile}"
            });
        }

        /*Get a User*/
        [Route("GetUser")]
        public object Get(string id)
        {
            User user = _context.Users.Find(id);

            #region CheckIsNull
            if (user == null)
            {
                return NotFound();
            }
            #endregion

            return user;
        }

        /*Get a User with basic data*/
        [Route("GetUserBasic")]
        public object GetBasic(string id)
        {
            User user = _context.Users.Find(id);

            #region CheckIsNull
            if (user == null)
            {
                return NotFound();
            }
            #endregion

            return new
            {
                user.Id,
                user.Fullname,
                user.Email,
                user.About,
                user.Gender,
                Profile = string.IsNullOrEmpty(user.Profile) ? null : $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/uploads/{user.Profile}"
            };
        }

        /*Registration*/
        [HttpPost]
        [Route("register")]
        public object Register(User user)
        {
            #region CheckEmailExist
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "This email already exist");
            }
            #endregion

            #region CheckPasswordIsInvalid
            if (!PasswordValid.Valid(user.Password))
            {
                ModelState.AddModelError("Password", PasswordValid.Message);
            }
            #endregion

            #region CheckModelIsInvalid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            user.Password = Crypto.HashPassword(user.Password);
            user.Status = 0;
            user.CreatedAt = DateTime.UtcNow.AddHours(4);
            user.Profile = user.Gender ? "male.png" : "female.png";

            /*Try SaveChanges*/
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return StatusCode(201);
        }

        /*Update profile*/
        [HttpPut]
        [Route("edit")]
        public object Edit(string id, [FromForm] User usr)
        {

            #region CheckIdsAreDifferent
            if (id != usr.Id)
            {
                return BadRequest("Ids are different");
            }
            #endregion

            User user = _context.Users.Find(id);

            #region CheckIsNull
            if (usr == null)
            {
                return NotFound();
            }
            #endregion

            #region CheckToken
            if (!String.IsNullOrWhiteSpace(Request.Headers["token"]))
            {
                if (_context.Users.Any(u => u.Token == Request.Headers["token"]))
                {
                    if (user.Token != Request.Headers["token"])
                    {
                        return StatusCode(401);
                    }
                }
                else
                {
                    return StatusCode(401);
                }
            }
            else
            {
                return StatusCode(401);
            }
            #endregion

            #region CheckEmailExsit
            if (_context.Users.Any(u=>u.Email==usr.Email && u.Id != user.Id))
            {
                ModelState.AddModelError("Email", "This email already exist");
            }
            #endregion

            #region CheckModelIsInvalid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            /*Save file*/
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files[0];
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                    string filename =  DateTime.Now.ToString("yyyyMMddHHmmssss")+ file.FileName;
                    usr.Profile = filename;
                    try
                    {
                        FileManager.FileSave(filename, file);
                        user.Profile = filename;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            user.About = usr.About;
            user.Address = usr.Address;
            user.Email = usr.Email;
            user.Fullname = usr.Fullname;
            user.Gender = usr.Gender;
            user.Google = usr.Google;
            user.Phone = usr.Phone;
            user.Linkedin = usr.Linkedin;
            user.Twitter = usr.Twitter;
            user.Website = usr.Website;
            user.Youtube = usr.Youtube;

            /*SaveChanges*/
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }

            return NoContent();
        }

        [HttpPut]
        [Route("ResetPassword")]
        public object Reset([FromBody]UserSignIn usr)
        {
            //#region CheckIdIsEmpty
            //if(String.IsNullOrWhiteSpace(usr.Id))
            //#endregion

            #region CheckIsNullOrEmpty
            if (string.IsNullOrWhiteSpace(usr.Email) || string.IsNullOrWhiteSpace(usr.NewPassword) || string.IsNullOrWhiteSpace(usr.Password))
            {
                return StatusCode(402,"Email,Password or New password is null or empty");
            }
            #endregion

            User user = _context.Users.FirstOrDefault(u=>u.Id==usr.Id && u.Email==usr.Email);
          
            #region CheckIsNull
            if (user == null)
            {
                return NotFound();
            }
            #endregion

            #region CheckToken
            if (!String.IsNullOrWhiteSpace(Request.Headers["token"]))
            {

                if (user.Token != Request.Headers["token"])
                {
                    return StatusCode(401);
                }
            }
            else
            {
                return StatusCode(401);
            }
            #endregion

            #region CheckOldPassword
            if (!Crypto.VerifyHashedPassword(user.Password, usr.Password))
            {
                return StatusCode(409, "Password incorrect!");
            }
            #endregion

            #region CheckPasswordIsInvalid
            if (!PasswordValid.Valid(usr.NewPassword))
            {
                ModelState.AddModelError("Password", PasswordValid.Message);
            }
            #endregion

            #region CheckModelIsInvalid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            user.Password = Crypto.HashPassword(usr.NewPassword);

            /*save changes*/
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }

            return NoContent();
        }

        /*Login*/
        [HttpPost]
        [Route("login")]
        public object Login(UserSignIn usr)
        {
            #region CheckIsEmpty
            if (String.IsNullOrWhiteSpace(usr.Email) || String.IsNullOrWhiteSpace(usr.Password))
            {
                return BadRequest("Email and Password cannot be empty");
            }
            #endregion

            User user = _context.Users.FirstOrDefault(u => u.Email == usr.Email);

            #region CheckIsNull
            if (user == null)
            {
                return NotFound();
            }
            #endregion

            #region CheckPasswordIsIncorrect
            if (!Crypto.VerifyHashedPassword(user.Password, usr.Password))
            {
                return StatusCode(401);
            }
            #endregion

            user.Token = Guid.NewGuid().ToString().Replace("-", string.Empty);
            _context.SaveChanges();

            return Ok(new
            {
                userId = user.Id,
                token = user.Token
            });
        }
    }

    public class UserSignIn
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}