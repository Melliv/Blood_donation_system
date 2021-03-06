using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Io;
using AngleSharp.Html.Dom;

namespace TestProject.Helpers
{
    public static class HtmlHelpers
    {
        public static async Task<IHtmlDocument> GetDocumentAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var document = await BrowsingContext.New().OpenAsync(ResponseFactory, CancellationToken.None);
            return (IHtmlDocument) document;

            void ResponseFactory(VirtualResponse htmlResponse)
            {
                htmlResponse
                    .Address(response.RequestMessage?.RequestUri)
                    .Status(response.StatusCode);

                MapHeaders(response.Headers);
                MapHeaders(response.Content.Headers);

                htmlResponse.Content(content);

                void MapHeaders(HttpHeaders headers)
                {
                    foreach (var header in headers)
                    {
                        foreach (var value in header.Value)
                        {
                            htmlResponse.Header(header.Key, value);
                        }
                    }
                }
            }
        }
        
        public static async Task<IHtmlCollection<IElement>> ResponseToElemCollection(
            HttpResponseMessage httpResponseMessage,
            string selector)
        {
            var htmlDocument = await HtmlHelpers.GetDocumentAsync(httpResponseMessage);
            var searchedElements =  htmlDocument.QuerySelectorAll(selector);
            return searchedElements;
        }
    }
}