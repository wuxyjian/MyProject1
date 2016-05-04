using MVC5_EF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_EF6.Controllers
{
    public class AccountController : Controller
    {
        // GET: Accoun测试
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Login() 
        {
            ViewBag.LoginState = "登陆前...";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc) 
        {
            myTestEntities db = new myTestEntities();
           

            string email = fc["InputEmail"];
            string password = fc["InputPassword"];
            
            var user = db.SysUser.Where(b => b.Email == email & b.password == password);
            if(user.Count()>0)
            ViewBag.LoginState = email+"登陆后...";
            else
                ViewBag.LoginState = email + "登陆失败...";
            return View();

            
        }
        //EF更新
        public ActionResult EFUpdateDemo()
        {

            //1.找到对象
            myTestEntities db = new myTestEntities();
            var sysUser = db.SysUser.FirstOrDefault(u => u.Username == "Tom");

            //2.更新对象数据

            if (sysUser != null)
            {

                sysUser.Username = "Tom2";

            }

            //3.保存修改

            db.SaveChanges();

            return View();

        }

        //数据添加和删除
        public ActionResult EFAddOrDeleteDemo()
        {

            //添加
            myTestEntities db = new myTestEntities();
            //1.创建新的实体

            var newSysUser = new SysUser()

            {

                Username = "Scott",

                password = "tiger",

                Email = "Scott@sohu.com"

            };

            //2.增加

            db.SysUser.Add(newSysUser);

            //3.保存修改

            db.SaveChanges();



            //删除

            //1.找到需要删除的对象

            var delSysUser = db.SysUser.FirstOrDefault(u => u.Username == "Scott");

            //2.删除

            if (delSysUser != null)
            {

                db.SysUser.Remove(delSysUser);

            }

            //3.保存修改

            db.SaveChanges();

            return View("EFQueryDemo");

        }
        //查询demo
        public ActionResult EFSelectDemo()
        {

            myTestEntities db = new myTestEntities();
            //查询所有
            var users = from u in db.SysUser
                        select u; //表达式方式
            IList<SysUser> a = users.ToList<SysUser>();
            users = db.SysUser; //函数式方式

            //条件查询
            users = from u in db.SysUser
                    where u.Username == "wujian@qq.com"
                    select u; //表达式方式

            users = db.SysUser.Where(u => u.Username == "wujian"); //函数式方式
            a = users.ToList<SysUser>();

            //排序和分页查询
            users = (from u in db.SysUser

                     orderby u.Username

                     select u).Skip(0).Take(5); //表达式方式


            users = db.SysUser.OrderBy(u => u.Username).Skip(0).Take(5); //函数式方式
            a = users.ToList<SysUser>();

            return View("EFSelectDemo");
        }

        public ActionResult Register() 
        {
            return View();
        }
    }
}
