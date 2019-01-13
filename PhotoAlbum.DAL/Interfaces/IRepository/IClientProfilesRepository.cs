﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces.IRepository
{
    public interface IClientProfilesRepository : IRepository<ClientProfile>
    {
    }
}
