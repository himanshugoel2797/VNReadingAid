using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace VNReadingAid
{
    class ResourceSchemeHandlerFactory : CefSharp.ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new ResourceSchemeHandler();
        }

        class ResourceSchemeHandler : ResourceHandler
        {
            public override bool ProcessRequestAsync(IRequest request, ICallback callback)
            {
                callback.Continue();
                return true;
            }

            public override Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
            {
                var strm = new MemoryStream(Encoding.Default.GetBytes(Properties.Resources.translator));
                responseLength = strm.Length;
                redirectUrl = null;
                return strm;
            }
        }
    }
}
