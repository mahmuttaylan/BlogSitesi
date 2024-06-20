using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]       //Hangi rollerin sayfaya erişebileceği belirtilir. RoleConsts yazma sebebimiz eğer rollerden birinin ismi değişirse tek tek manuel değiştirmek yerine RoleConsts class'ından değiştirmemiz yeterli olacak.
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
        }


        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeleted();
            return View(articles);
        }


        public async Task<IActionResult> DeletedArticle()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryDeleted();
            return View(articles);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleCreateVM { CategoryVMs = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateVM articleCreateVM)
        {
            if (articleCreateVM.Photo == null)
            {
                ModelState.AddModelError("", "Resim yüklemeden makale yayımlayamazsınız.");
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleCreateVM { CategoryVMs = categories });
            }

            var map = _mapper.Map<Article>(articleCreateVM);    //VM'i Article'a çeviriyoruz. Buradaki birbirine çevrilen nesneleri AutoMapper/Mapping class'ına da eklememiz gerekir.
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                //Validasyonlardan bir hata gelirse Kategori combobox'ının içinin yine dolu gelmesi için bu kodları yine yazıyoruz.
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleCreateVM { CategoryVMs = categories });
            }

            await _articleService.CreateArticle(articleCreateVM);
            return RedirectToAction("Index", "Article", new {Area = "Admin"});
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeleted(id);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateVM = _mapper.Map<ArticleUpdateVM>(article);    //map'leme ile article özelliklerini VM içine attık.
            articleUpdateVM.CategoryVMs = categories;

            return View(articleUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateVM articleUpdateVM)
        {
            var map = _mapper.Map<Article>(articleUpdateVM);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                articleUpdateVM.CategoryVMs = categories;
                return View(articleUpdateVM);
            }

            await _articleService.UpdateArticle(articleUpdateVM);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


        public async Task<IActionResult> Delete(int id) 
        {
            await _articleService.SafeDeleteArticle(id);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


        public async Task<IActionResult> UndoDelete(int id)
        {
            await _articleService.UndoDeleteArticle(id);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}