﻿using Eggs.Core.Api.Model.Models;

namespace Eggs.Core.Api.Model.ViewModels
{
    /// <summary>
    /// 用来测试 RestSharp Get 请求
    /// </summary>
    public class TestRestSharpGetDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BlogArticle data { get; set; }
    }
}