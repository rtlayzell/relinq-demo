using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rql.Core
{
    public interface IHttpClient
    {
		Task<T> GetAsync<T>(Uri uri);
    }
}
