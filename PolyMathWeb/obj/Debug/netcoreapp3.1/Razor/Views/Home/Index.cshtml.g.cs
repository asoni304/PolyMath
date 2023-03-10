#pragma checksum "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c3fdb11f3f03adba8d42acb241664f750475772"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\_ViewImports.cshtml"
using PolyMathWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\_ViewImports.cshtml"
using PolyMathWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c3fdb11f3f03adba8d42acb241664f750475772", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1b150c7915da8a6b360b2e4e43354874dbacfff", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PolyMathWeb.Models.ViewModel.IndexVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\" >\r\n\t<div class=\"row pb-4 backgroundWhite\">\r\n");
#nullable restore
#line 5 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
         if (Model != null && Model.GenreList != null)
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
             foreach (var genre in Model.GenreList)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"container backgroundWhite pb-4\">\r\n\t\t\t\t\t\t\t<div class=\"card border\">\r\n\t\t\t\t\t\t\t\t<div class=\"card-header bg-dark text-light ml-0 row container\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-12 col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t<h1 class=\"text-warning\">");
#nullable restore
#line 13 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                            Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-12 col-md-6 text-md-right\">\r\n\t\t\t\t\t\t\t\t\t\t<h1 class=\"text-warning\">State : ");
#nullable restore
#line 16 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                    Write(genre.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
									</div>
								</div>
								<div class=""card-body"">
									<div class=""container rounded p-2"">
										<div class=""row"">
											<div class=""col-12 col-lg-8"">
												<div class=""row"">
													<div class=""col-12"">
														<h3 style=""color:#bbb9b9"">Established: ");
#nullable restore
#line 25 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                                          Write(genre.Created.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-12\">\r\n");
#nullable restore
#line 28 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                 if (Model.ArticleList.Where(u => u.GenreId == genre.Id).Count() > 0)
												{



#line default
#line hidden
#nullable disable
            WriteLiteral(@"																<table class=""table table-striped"" style=""border:1px solid #808080 "">
																	<tr class=""table-secondary"">
																		<th>
																			Genre
																		</th>
																		<th>Title</th>
																		<th>Content</th>
																		<th>Author</th>
																	</tr>
");
#nullable restore
#line 41 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                         foreach (var article in Model.ArticleList.Where(u => u.GenreId == genre.Id))
														{



#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 46 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                               Write(article.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 47 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                               Write(article.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 48 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                               Write(article.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 49 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                                                               Write(article.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 52 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
														}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</table>\r\n");
#nullable restore
#line 54 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
												}
												else
												{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<p>No artcicles exist</p>\r\n");
#nullable restore
#line 58 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
												}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-12 col-lg-4 text-center\">\r\n");
#nullable restore
#line 63 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
                                          
											var base64 = Convert.ToBase64String(genre.Picture);
											var finalStr = string.Format("data:image/jpg;base64,{0}", base64);

										

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 2257, "\"", 2272, 1);
#nullable restore
#line 68 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
WriteAttributeValue("", 2263, finalStr, 2263, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" />\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 75 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\User\Desktop\projects\c#\PolyMath\PolyMathWeb\Views\Home\Index.cshtml"
             
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t</div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PolyMathWeb.Models.ViewModel.IndexVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
