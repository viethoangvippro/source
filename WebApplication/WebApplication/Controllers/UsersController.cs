
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruongVietHoang_QLThongtin_MVC.Data;
using TruongVietHoang_QLThongtin_MVC.ViewModel;

namespace TruongVietHoang_QLThongTin_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public UsersController(QLThongTinDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult LoginTruongVietHoang()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginTruongVietHoang(LoginInput login)
        {
            
            if (ModelState.IsValid)
            {
                var result = _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == CreateMD5(login.Password));
                if (result != null)
                {
                    return RedirectToAction("IndexTruongVietHoang", "Tinhs");
                }
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không chính xác");
            }
            return View(login);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }
}
