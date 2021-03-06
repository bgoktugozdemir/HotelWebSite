﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Models.Blog;

namespace WebProje.Controllers
{
    public class BlogController : Controller
    {
        private IPostsManagement _postsManagement;
        private ISettingsManagement _settingsManagement;
        private IPagesManagement _pagesManagement;

        public BlogController(IPostsManagement postsManagement, ISettingsManagement settingsManagement, IPagesManagement pagesManagement)
        {
            _postsManagement = postsManagement;
            _settingsManagement = settingsManagement;
            _pagesManagement = pagesManagement;
        }

        // GET: Blog
        public ActionResult Index()
        {
            BlogViewModel model = new BlogViewModel
            {
                PostsList = _postsManagement.GetAll().OrderByDescending(m => m.CreatedAt).ToList(),
                Setting = _settingsManagement.Get(m=>m.Name == "hotel.name"),
                Page = _pagesManagement.Get(p => p.Name == "blog-banner")
            };
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Posts prevPost;
                Posts nextPost;

                BlogViewModel model = new BlogViewModel
                {
                    PostsList = new List<Posts>(),
                    Post = _postsManagement.Get(m => m.ID == id),
                    Setting = _settingsManagement.Get(m => m.Name == "hotel.name")
                };
                if(model.Post.ID-1 >= 1)
                {
                    prevPost = _postsManagement.Get(p => p.ID == model.Post.ID - 1);
                    model.PostsList.Add(prevPost);
                }
                else
                {
                    model.PostsList.Add(model.Post);
                }

                if (model.Post.ID+1 <= _postsManagement.GetAll().Count())
                {
                    nextPost = _postsManagement.Get(p => p.ID == model.Post.ID + 1);
                    model.PostsList.Add(nextPost);
                }
                else
                {
                    model.PostsList.Add(model.Post);
                }

                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}