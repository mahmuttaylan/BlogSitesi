﻿using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Abstract
{
    public interface IImageRepository : IBaseBlogContextRepository<Image>
    {
    }
}
