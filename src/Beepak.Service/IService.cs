﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Beepak.Data;

namespace Beepak.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        User Register(
            string login, 
            string password, 
            string passwordRpt,
            string mail,
            string city);
    }
}
