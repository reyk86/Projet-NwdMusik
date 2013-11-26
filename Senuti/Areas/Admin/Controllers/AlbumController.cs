using Nwd.BackOffice.Model;
using Nwd.BackOffice.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nwd.FrontOffice.Impl;
using Nwd.FrontOffice.ViewModels;
using Nwd.FrontOffice;

namespace Senuti.Areas.Admin.Controllers
{
    public class AlbumController : Controller
    {
        public int SongId { get; set; }

        public ActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Album album)
        {
            try
            {
                if (album.Title != null || album.Title != string.Empty)
                    if (album.Artist != null)
                    {
                        album.ReleaseDate = DateTime.Now;
                        AlbumRepository.CreateAlbum(album, Server);
                        @ViewBag.success = "Album créé.";
                    }
            }
            catch
            {
                @ViewBag.success = "/!\\Erreur lors de la création./!\\";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddTrack()
        {
            if (HttpContext.Request.Url.Query == string.Empty)
                ViewBag.id = 0;
            else
                ViewBag.id = HttpContext.Request.Url.Query.Substring(HttpContext.Request.Url.Query.Length - 1, 1);
            return PartialView("_FormTracks");
        }

        public ActionResult List()
        {
            MusicReader musicReader = new MusicReader();
            Catalog catalog = musicReader.GetCatalog();
            return View(catalog);
        }

        public ActionResult Edit()
        {
            int albumId = -1;
            int.TryParse(Request.Url.Query.Substring(Request.Url.Query.Length - 1, 1), out albumId);

            Album album = AlbumRepository.GetAlbumForEdit(albumId);

            ViewBag.albumId = albumId;
            ViewBag.albumTitle = album.Title;
            ViewBag.type = album.Type;
            ViewBag.artistName = album.Artist.Name;
            ViewBag.artistBiography = album.Artist.Biography;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            try
            {
                AlbumRepository.EditAlbum(album, Server);
                ViewBag.success = "Modification effectuée.";
            }
            catch
            {
                ViewBag.success = "/!\\Erreur lors de la modification./!\\";
            }
            return View();
        }
    }
}
