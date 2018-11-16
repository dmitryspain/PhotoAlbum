using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Dtos.Base
{
    public class EntityDto<T>
    {
        public T Id { get; set; }
    }
}
