﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    [MetadataType(typeof(UserMasterData))]
    public class User
    {
    
    }

    [MetadataType(typeof(UserMasterData))]
    public partial class ProductMasterData
    {


        [NotMapped]
        public System.Web.HttpPostedFileBase ImaUpload { get; set; }
    }
}